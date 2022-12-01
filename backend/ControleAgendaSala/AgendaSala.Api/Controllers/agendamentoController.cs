using AgendaSala.Database.Interfaces;
using AgendaSala.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System;
using AgendaSala.Services.Interfaces;

namespace AgendaSala.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class agendamentoController : ControllerBase
    {
        private readonly ICrudAgendamento _servicoCrudAgendamento;
        private readonly IServicoValidarAgendamento _servicoValidarAgendamento;

        public agendamentoController(ICrudAgendamento servicoCrudAgendamento, IServicoValidarAgendamento servicoValidarAgendamento)
        {
            _servicoCrudAgendamento = servicoCrudAgendamento;
            _servicoValidarAgendamento = servicoValidarAgendamento;
        }


        [HttpPost]
        [Route("inserir")]
        public async Task<ActionResult<dynamic>> InserirAgendamento([FromBody] Agendamento _agendamento)
        {
            try
            {
                if (_servicoValidarAgendamento.CompararAgendamentos(_agendamento) == false)
                {
                    return BadRequest("agendamento iguais");
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


        [HttpGet]
        [Route("buscar")]
        public async Task<ActionResult<dynamic>> buscarTodasAgendamento()
        {
            try
            {
                return _servicoCrudAgendamento.BuscarTodos().ToList();
            }
            catch (Exception ex)
            {
                return BadRequest($"erro interno no servidor: {ex}");
            }
        }


        [HttpPut]
        [Route("atualizar")]
        public async Task<ActionResult<dynamic>> AtualizarAgendamento([FromBody] Agendamento _agendamento)
        {
            try
            {
                if (buscarAgendamentoPorId(_agendamento.Id) == null)
                {
                    return BadRequest("Agendamento informado não encontrado!");
                }

                _servicoCrudAgendamento.Atualizar(_agendamento);

                return Ok("Agendamento atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"erro interno no servidor: {ex}");
            }
        }


        [HttpDelete]
        [Route("deletar")]
        public async Task<ActionResult<dynamic>> DeletarAgendamento([FromBody] Agendamento _agendamento)
        {
            try
            {
                if (buscarAgendamentoPorId(_agendamento.Id) == null)
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
