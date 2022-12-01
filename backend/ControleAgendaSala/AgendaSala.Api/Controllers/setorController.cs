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
            try
            {
                _servicoCrudSetor.Inserir(_setor);

                return Ok(new {message = "Setor cadastrado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest( $"erro interno no servidor: {ex}" );
            }
        }


        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<dynamic>> buscarSetorPorId([FromRoute] int id)
        {
            try
            {
                var _setor = _servicoCrudSetor.BuscarPorId(id);

                if (_setor == null)
                {
                    return BadRequest("Setor informado não encontrado!");
                }

                return Ok(_setor);
            }
            catch (Exception ex)
            {
                return BadRequest($"erro interno no servidor: {ex}");
            }
        }


        [HttpGet]
        [Route("buscar")]
        public async Task<ActionResult<dynamic>> buscarTodosSetores()
        {
            try
            {
                return _servicoCrudSetor.BuscarTodos().ToList();
            }
            catch (Exception ex)
            {
                return BadRequest($"erro interno no servidor: {ex}");
            }

        }

        [HttpPut]
        [Route("atualizar")]
        public async Task<ActionResult<dynamic>> AtualizarSetor([FromBody] Setor _setor)
        {
            try
            {
                if (buscarSetorPorId(_setor.Id) == null)
                {
                    return BadRequest("Setor informado não encontrado!");
                }

                _servicoCrudSetor.Atualizar(_setor);

                return Ok( "Setor atualizado com sucesso!" );
                }
            catch (Exception ex)
            {
                return BadRequest($"erro interno no servidor: {ex}");
            }
        }


        [HttpDelete]
        [Route("deletar")]
        public async Task<ActionResult<dynamic>> DeletarSetor([FromBody] Setor _setor)
        {
            try
            {
                if (buscarSetorPorId(_setor.Id) == null)
                {
                    return BadRequest( "Setor informado não encontrado!" );
                }

                _servicoCrudSetor.Deletar(_setor);

                return Ok( "Setor deletado com sucesso!" );
                }
            catch (Exception ex)
            {
                return BadRequest($"erro interno no servidor: {ex}");
            }
        }
    }
}
