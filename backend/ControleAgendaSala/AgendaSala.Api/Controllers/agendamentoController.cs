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
    }
}
