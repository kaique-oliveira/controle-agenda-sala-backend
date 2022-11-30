using AgendaSala.Database.Interfaces;
using AgendaSala.Database.ServicosCrud;
using AgendaSala.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace AgendaSala.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class setorController : ControllerBase
    {
        private readonly ICrudSetor _servicoCrudSetor;

        public setorController(ICrudSetor servicoCrudSetor)
        {
            _servicoCrudSetor = servicoCrudSetor;

        }

        [HttpPost]
        [Route("inserir")]
        public async Task<ActionResult<dynamic>> InserirSetor([FromBody] Setor _setor)
        {
            _servicoCrudSetor.Inserir(_setor);

            return Ok(201);
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<dynamic>> buscarSetorPorId([FromRoute] int id)
        {
            return _servicoCrudSetor.BuscarPorId(id);

        }

        [HttpGet]
        [Route("buscar")]
        public async Task<ActionResult<dynamic>> buscarTodosSetores()
        {
            return _servicoCrudSetor.BuscarTodos().ToList();

        }
    }
}
