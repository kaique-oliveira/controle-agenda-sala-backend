
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

            if (!login.Email.Contains("@interfocus"))
            {
                return BadRequest("por favor informe um e-mail interfocus!");
            }

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
            //DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var tempoAtual = DateTime.Now.Ticks;
            var _tokenRead = _servicoAuthToken.lerToken(token);


            int id = int.Parse(_tokenRead.Payload.First(x => x.Key == "id").Value.ToString());
            Usuario? _usuario = _servicoCrudUsuario.BuscarPorId(id);

            if (tempoAtual >= _tokenRead.ValidTo.Ticks) {

                token.Token = _servicoAuthToken.GerarToken(_usuario);         
            }

            return new
            {
                token = token.Token,
                usuario = new
                {
                    id = _usuario.Id,
                    nome = _usuario.Nome,
                    email = _usuario.Email,
                    tipo = _usuario.Tipo,
                    setor = _usuario.Setor
                },

            };
        }
    }
}
