using AgendaSala.Database.Interfaces;
using AgendaSala.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace AgendaSala.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class salaController : ControllerBase
    {

        private readonly ICrudSala _servicoCrudSala;

        public salaController(ICrudSala servicoCrudSala)
        {
            _servicoCrudSala = servicoCrudSala;
        }

        [HttpPost]
        [Route("inserir")]
        public async Task<ActionResult<dynamic>> InserirSala([FromBody] Sala _sala)
        {
            _servicoCrudSala.Inserir(_sala);

            return Ok(201);
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<dynamic>> buscarSalaPorId([FromRoute] int id)
        {
            return _servicoCrudSala.BuscarPorId(id);

        }

        [HttpGet]
        [Route("buscar")]
        public async Task<ActionResult<dynamic>> buscarTodasSala()
        {
            return _servicoCrudSala.BuscarTodos().ToList();

        }
    }
}
