using AgendaSala.Database.Interfaces;
using AgendaSala.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using AgendaSala.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using AgendaSala.Api.Models;

namespace AgendaSala.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class agendamentoController : ControllerBase
    {
        private readonly ICrudAgendamento _servicoCrudAgendamento;
        private readonly ICrudSala _servicoCrudSala;
        private readonly ICrudUsuario _servicoCrudUsuario;
        private readonly IServicoValidarAgendamento _servicoValidarAgendamento;
        private readonly IServicoCalcularHoraFinal _servicoCalcularHoraFinal;

        public agendamentoController(
            ICrudAgendamento servicoCrudAgendamento, 
            IServicoValidarAgendamento servicoValidarAgendamento,
            IServicoCalcularHoraFinal servicoCalcularHoraFinal,
            ICrudSala servicoCrudSala,
            ICrudUsuario servicoCrudUsuario)
        {
            _servicoCrudAgendamento = servicoCrudAgendamento;
            _servicoValidarAgendamento = servicoValidarAgendamento;
            _servicoCalcularHoraFinal = servicoCalcularHoraFinal;
            _servicoCrudSala = servicoCrudSala;
            _servicoCrudUsuario = servicoCrudUsuario;
        }


        [HttpPost]
        [Route("inserir")]
        [Authorize]
        public async Task<ActionResult<dynamic>> InserirAgendamento([FromBody] CadastroAgendamento cadastroAgendamento)
        {
            try
            {
                Agendamento _agendamento = new Agendamento();
                _agendamento.Titulo = cadastroAgendamento.Titulo;
                _agendamento.DataAgendamento = cadastroAgendamento.DataAgendamento;
                _agendamento.HoraInicial = cadastroAgendamento.HoraInicial;
                _agendamento.Duracao = cadastroAgendamento.Duracao;
                _agendamento.HoraFinal = _servicoCalcularHoraFinal.CalcularHora(_agendamento.HoraInicial, _agendamento.Duracao);                
                _agendamento.Sala = _servicoCrudSala.BuscarPorId(cadastroAgendamento.IdSala);
                _agendamento.Usuario = _servicoCrudUsuario.BuscarPorId(cadastroAgendamento.IdUsuario);


                if (_servicoValidarAgendamento.CompararAgendamentos(_agendamento, _servicoCrudAgendamento.BuscarTodos()) == false)
                {
                    return BadRequest("Horário indisponivel!");
                }
                _servicoCrudAgendamento.Inserir(_agendamento);

                return Ok("Agendamento cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"erro interno no servidor: {ex}");
            }
        }


        [HttpGet]
        [Route("buscar/{id}")]
        [Authorize]
        public async Task<ActionResult<dynamic>> buscarAgendamentoPorId([FromRoute] int id)
        {
            try
            {
                var _agendamento = _servicoCrudAgendamento.BuscarPorId(id);

                if (_agendamento == null)
                {
                    return BadRequest("agendamento informado não encontrado!");
                }

                return Ok(_agendamento);
            }
            catch (Exception ex)
            {
                return BadRequest($"erro interno no servidor: {ex}");
            }
        }


        [HttpPost]
        [Route("buscar")]
        [Authorize]
        public async Task<ActionResult<dynamic>> buscarTodasAgendamento(FiltroAgendamentos filtro)
        {
            try
            {
                var _agendamentos = _servicoCrudAgendamento.BuscarTodos()
                    .Where(a => 
                        a.DataAgendamento.Date == DateTime.Parse(filtro.Data).Date 
                        && a.Sala.Id == filtro.IdSala)
                    .OrderBy(a => a.HoraInicial)
                    .ToList();

                return _agendamentos;
            }
            catch (Exception ex)
            {
                return BadRequest($"erro interno no servidor: {ex}");
            }
        }


        [HttpPut]
        [Route("atualizar")]
        public async Task<ActionResult<dynamic>> AtualizarAgendamento([FromBody] CadastroAgendamento agendamentoEditado)
        {
            try
            {
                var _agendamento = _servicoCrudAgendamento.BuscarPorId(agendamentoEditado.Id);     

                if (_agendamento.Id == null)
                {
                    return BadRequest("Agendamento informado não encontrado!");
                }

                if (_agendamento.DataAgendamento.Date == agendamentoEditado.DataAgendamento.Date
                    && _agendamento.Sala.Id == agendamentoEditado.IdSala
                    && _agendamento.HoraInicial.TimeOfDay == agendamentoEditado.HoraInicial.TimeOfDay
                    && _agendamento.Duracao.TimeOfDay == agendamentoEditado.Duracao.TimeOfDay)
                {
                    _agendamento.Titulo = agendamentoEditado.Titulo;
                    _agendamento.DataAgendamento = agendamentoEditado.DataAgendamento;
                    _agendamento.HoraInicial = agendamentoEditado.HoraInicial;
                    _agendamento.Duracao = agendamentoEditado.Duracao;
                    _agendamento.HoraFinal = _servicoCalcularHoraFinal.CalcularHora(_agendamento.HoraInicial, _agendamento.Duracao);
                    _agendamento.Sala = _servicoCrudSala.BuscarPorId(agendamentoEditado.IdSala);

                    _servicoCrudAgendamento.Atualizar(_agendamento);
                }
                else
                {

                    if (_servicoValidarAgendamento.CompararAgendamentos(_agendamento, _servicoCrudAgendamento.BuscarTodos())  == false)
                    {
                        return BadRequest("Horário indisponivel!");
                    }

                    _agendamento.Titulo = agendamentoEditado.Titulo;
                    _agendamento.DataAgendamento = agendamentoEditado.DataAgendamento;
                    _agendamento.HoraInicial = agendamentoEditado.HoraInicial;
                    _agendamento.Duracao = agendamentoEditado.Duracao;
                    _agendamento.HoraFinal = _servicoCalcularHoraFinal.CalcularHora(_agendamento.HoraInicial, _agendamento.Duracao);
                    _agendamento.Sala = _servicoCrudSala.BuscarPorId(agendamentoEditado.IdSala);

                    _servicoCrudAgendamento.Atualizar(_agendamento);
                }


                return Ok("Agendamento atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"erro interno no servidor: {ex}");
            }
        }


        [HttpDelete]
        [Route("deletar/{id}")]
        [Authorize]
        public async Task<ActionResult<dynamic>> DeletarAgendamento([FromRoute] int id)
        {
            try
            {
                Agendamento _agendamento = _servicoCrudAgendamento.BuscarPorId(id);

                if (_agendamento == null)
                {
                    return BadRequest("Agendamento informado não encontrado!");
                }

                _servicoCrudAgendamento.Deletar(_agendamento);

                return Ok("Agendamento deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"erro interno no servidor: {ex}");
            }
        }
    }
}
