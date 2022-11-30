using AgendaSala.Database.Interfaces;
using AgendaSala.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace AgendaSala.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class usuarioController : ControllerBase
    {
        private readonly ICrudUsuario _servicoCrudUsuario;

        public usuarioController(ICrudUsuario servicoCrudUsuario)
        {
            _servicoCrudUsuario = servicoCrudUsuario;
        }

        [HttpPost]
        [Route("inserir")]
        public async Task<ActionResult<dynamic>> InserirUsuario([FromBody] Usuario _usuario)
        {
            _servicoCrudUsuario.Inserir(_usuario);
            
            return Ok(201);
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<dynamic>> buscarUsuarioPorId([FromRoute] int id)
        {
            return  _servicoCrudUsuario.BuscarPorId(id);

        }

        [HttpGet]
        [Route("buscar")]
        public async Task<ActionResult<dynamic>> buscarTodosUsuarios()
        {
            return  _servicoCrudUsuario.BuscarTodos().ToList();

        }
    }
}
