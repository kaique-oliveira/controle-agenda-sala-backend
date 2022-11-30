using AgendaSala.Database.Interfaces;
using AgendaSala.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System;

namespace AgendaSala.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class agendamentoController : ControllerBase
    {
        private readonly ICrudAgendamento _servicoCrudAgendamento;

        public agendamentoController(ICrudAgendamento servicoCrudAgendamento)
        {
            _servicoCrudAgendamento = servicoCrudAgendamento;
        }


        [HttpPost]
        [Route("inserir")]
        public async Task<ActionResult<dynamic>> InserirAgendamento([FromBody] Agendamento _agendamento)
        {
            _servicoCrudAgendamento.Inserir(_agendamento);

            return Ok(201);
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<dynamic>> buscarAgendamentoPorId([FromRoute] int id)
        {
            return   _servicoCrudAgendamento.BuscarPorId(id);

        }

        [HttpGet]
        [Route("buscar")]
        public async Task<ActionResult<dynamic>> buscarTodasAgendamento()
        {
            return   _servicoCrudAgendamento.BuscarTodos().ToList();

        }

        [HttpPut]
        [Route("atualizar")]
        public async Task<ActionResult<dynamic>> AtualizarAgendamento([FromBody] Agendamento _agendamento)
        {

            if (buscarAgendamentoPorId(_agendamento.Id) == null)
            {
                return BadRequest(new { statusCode = 404, message = "agendamento não existe." });
            }

            _servicoCrudAgendamento.Atualizar(_agendamento);

            return Ok(201);
        }

        [HttpDelete]
        [Route("deletar")]
        public async Task<ActionResult<dynamic>> DeletarAgendamento([FromBody] Agendamento _agendamento)
        {

            if (buscarAgendamentoPorId(_agendamento.Id) == null)
            {
                return BadRequest(new { statusCode = 404, message = "agendamento não existe." });
            }

            _servicoCrudAgendamento.Deletar(_agendamento);

            return Ok(201);
        }
    }
}
