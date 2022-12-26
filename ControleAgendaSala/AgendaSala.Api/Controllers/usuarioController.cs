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
        private readonly ICrudAgendamento _servicoCrudAgendamento;

        public usuarioController(ICrudUsuario servicoCrudUsuario, ICrudAgendamento servicoCrudAgendamento)
        {
            _servicoCrudUsuario = servicoCrudUsuario;
            _servicoCrudAgendamento = servicoCrudAgendamento;
        }



        [HttpPost]
        [Route("inserir")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> InserirUsuario([FromBody] Usuario _usuario)
        {
            try
            {
                if(_servicoCrudUsuario.BuscarTodos().Where(u => u.Email == _usuario.Email).ToList().Count > 0)
                {
                    return BadRequest("E-mail informado já está sendo usado!");
                }
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
        [Authorize]
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
        [Authorize("admin")]
        public async Task<ActionResult<dynamic>> buscarTodosUsuarios()
        {
            try
            {
                return _servicoCrudUsuario.BuscarTodos().OrderBy(u => u.Nome).ToList();
            }
            catch (Exception ex)
            {
                return BadRequest( $"erro interno no servidor: {ex}" );
            }
        }


        [HttpPut]
        [Route("atualizar")]
        [Authorize("admin")]
        public async Task<ActionResult<dynamic>> AtualizarUsuario([FromBody] Usuario _usuario)
        {

            try
            {
                var usuarioConsultado =  _servicoCrudUsuario.BuscarPorId(_usuario.Id);
                if (usuarioConsultado == null)
                {
                    return BadRequest( "Usuário informado não encontrado!" );
                }

                if(usuarioConsultado.Senha != _usuario.Senha)
                {
                    _usuario.Senha = AuthSenha.CriarHashSenha(_usuario.Senha);
                }


                _servicoCrudUsuario.Atualizar(_usuario);

                return Ok( "Usuário atualizado com sucesso!" );
            }
            catch (Exception ex)
            {
                return BadRequest( $"erro interno no servidor: {ex}" );
            }
        }


        [HttpDelete]
        [Route("deletar/{id}")]
        [Authorize("admin")]
        public async Task<ActionResult<dynamic>> DeletarUsuario([FromRoute] int id)
        {
            try
            {
                var _usuario =  _servicoCrudUsuario.BuscarPorId(id);

                if (_usuario == null)
                {
                    return BadRequest( "Usuário informado não encontrado!" );
                }

                var agendamentos =  _servicoCrudAgendamento.BuscarTodos().Where(a => a.Usuario.Id == id).ToList();

                foreach (var agendamento in agendamentos)
                {
                    _servicoCrudAgendamento.Deletar(agendamento);
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
