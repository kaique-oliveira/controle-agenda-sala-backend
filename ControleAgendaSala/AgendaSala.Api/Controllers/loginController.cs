﻿
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
                token = token,
                usuario = new
                {
                    id = _usuario.Id,
                    nome = _usuario.Nome,
                    email = _usuario.Email,
                    tipo = _usuario.Tipo,
                },
                
            };
        }

        [HttpPost]
        [Route("validartoken")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> ValidarToken([FromBody] Tokenn token)
        {
            var _token = AuthToken.lerToken(token);

            return new
            {
                token = token.Token,
                usuario = new
                {
                    id = _token.Payload.First(x => x.Key == "id").Value,
                    nome = _token.Payload.First(x => x.Key == "nome").Value,
                    email = _token.Payload.First(x => x.Key == "email").Value,
                    tipo = _token.Payload.First(x => x.Key == "tipo").Value,
                },

            };
        }
    }
}
