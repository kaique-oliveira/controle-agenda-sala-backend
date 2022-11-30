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
            //_user.Role = _roleRepository.FindId(5);

            _servicoCrudUsuario.Inserir(_usuario);
            
            return Ok(201);
        }
    }
}
