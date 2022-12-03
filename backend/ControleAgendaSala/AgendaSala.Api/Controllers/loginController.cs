using AgendaSala.Auth.Servicos;
using AgendaSala.Database.Interfaces;
using AgendaSala.Domain.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaSala.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class loginController : ControllerBase
    {
        private readonly ICrudUsuario _servicoCrudUsuario;

        public loginController(ICrudUsuario servicoCrudUsuario)
        {
            _servicoCrudUsuario = servicoCrudUsuario;
        }

        [HttpPost]
        [Route("usuario")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> Login([FromBody] Login login)
        {
            Usuario? _usuario = _servicoCrudUsuario.BuscarTodos()
                .Where(u => u.Email == login.Email).FirstOrDefault();

            if (_usuario == null)
            {
                return BadRequest( "Email informado não encontrado!"  );
            }

            if (!AuthSenha.CompararSenha(_usuario.Senha, login.Senha))
            {
                return BadRequest( "Senha informada está incorreta!");
            }

            var token = AuthToken.GerarToken(_usuario);

            return new
            {
                usuario = _usuario.Nome,
                setor = _usuario.Setor,
                tipo = _usuario.Tipo,
                token = token
            };
        }
    }
}
