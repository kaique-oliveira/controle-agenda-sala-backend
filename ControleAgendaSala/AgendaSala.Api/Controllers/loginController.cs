
using AgendaSala.Auth;
using AgendaSala.Auth.Interfaces;
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
        private readonly IAuthToken _servicoAuthToken;

        public loginController(ICrudUsuario servicoCrudUsuario, IAuthToken servicoAuthToken )
        {
            _servicoCrudUsuario = servicoCrudUsuario;
            _servicoAuthToken = servicoAuthToken;
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

            var token = _servicoAuthToken.GerarToken(_usuario);

            return new
            {
                token = token,
                usuario = new
                {
                    id = _usuario.Id,
                    nome = _usuario.Nome,
                    email = _usuario.Email,
                    tipo = _usuario.Tipo,
                    setor = _usuario.Setor,
                },
                
            };
        }

        [HttpPost]
        [Route("validartoken")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> ValidarToken([FromBody] ModelToken token)
        {
            var tempoAtual = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var _tokenRead = _servicoAuthToken.lerToken(token);
            var _refreshToken = "";
            var s = DateTime.UtcNow;

            if (tempoAtual >= _tokenRead.Payload.Exp) {
                int id = int.Parse(_tokenRead.Payload.First(x => x.Key == "id").Value.ToString());
                Usuario? _usuario = _servicoCrudUsuario.BuscarPorId(id);
                _refreshToken = _servicoAuthToken.GerarToken(_usuario);

                token.Token = _refreshToken;
                _tokenRead = _servicoAuthToken.lerToken(token);
            }
           

            return new
            {
                token = token.Token,
                usuario = new
                {
                    id = _tokenRead.Payload.First(x => x.Key == "id").Value,
                    nome = _tokenRead.Payload.First(x => x.Key == "nome").Value,
                    email = _tokenRead.Payload.First(x => x.Key == "email").Value,
                    tipo = _tokenRead.Payload.First(x => x.Key == "tipo").Value,
                },

            };
        }
    }
}
