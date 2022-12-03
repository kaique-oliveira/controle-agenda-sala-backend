using AgendaSala.Database.Interfaces;
using AgendaSala.Domain.Entidades;
using AgendaSala.Auth.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> InserirUsuario([FromBody] Usuario _usuario)
        {
            try
            {
                //criptografa a senha do usuário
                _usuario.Senha = AuthSenha.CriarHashSenha(_usuario.Senha);

                _servicoCrudUsuario.Inserir(_usuario);

                return Ok( "Usuário cadastrado com sucesso!" );
            }
            catch (Exception ex)
            {
                return BadRequest( $"erro interno no servidor: {ex}" );
            }
        }


        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<dynamic>> buscarUsuarioPorId([FromRoute] int id)
        {
            try
            {
                var _usuario = _servicoCrudUsuario.BuscarPorId(id);

                if (_usuario == null)
                {
                    return BadRequest( "Usuário informado não encontrado!" );
                }


                return Ok(_usuario);
            }
            catch (Exception ex)
            {
                return BadRequest( $"erro interno no servidor: {ex}" );
            }
        }


        [HttpGet]
        [Route("buscar")]
        public async Task<ActionResult<dynamic>> buscarTodosUsuarios()
        {
            try
            {
                return _servicoCrudUsuario.BuscarTodos().ToList();
            }
            catch (Exception ex)
            {
                return BadRequest( $"erro interno no servidor: {ex}" );
            }
        }


        [HttpPut]
        [Route("atualizar")]
        public async Task<ActionResult<dynamic>> AtualizarUsuario([FromBody] Usuario _usuario)
        {

            try
            {
                if (buscarUsuarioPorId(_usuario.Id) == null)
                {
                    return BadRequest( "Usuário informado não encontrado!" );
                }

                _usuario.Senha = AuthSenha.CriarHashSenha(_usuario.Senha);

                _servicoCrudUsuario.Atualizar(_usuario);

                return Ok( "Usuário atualizado com sucesso!" );
            }
            catch (Exception ex)
            {
                return BadRequest( $"erro interno no servidor: {ex}" );
            }
        }


        [HttpDelete]
        [Route("deletar")]
        public async Task<ActionResult<dynamic>> DeletarUsuario([FromBody] Usuario _usuario)
        {
            try
            {
                if (buscarUsuarioPorId(_usuario.Id) == null)
                {
                    return BadRequest( "Usuário informado não encontrado!" );
                }

                _servicoCrudUsuario.Deletar(_usuario);

                return Ok( "Usuário deletado com sucesso!" );
            }
            catch (Exception ex)
            {
                return BadRequest( $"erro interno no servidor: {ex}" );
            }
        }
    }
}
