using AgendaSala.Database.Interfaces;
using AgendaSala.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace AgendaSala.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class salaController : ControllerBase
    {

        private readonly ICrudSala _servicoCrudSala;

        public salaController(ICrudSala servicoCrudSala)
        {
            _servicoCrudSala = servicoCrudSala;
        }


        [HttpPost]
        [Route("inserir")]
        public async Task<ActionResult<dynamic>> InserirSala([FromBody] Sala _sala)
        {
            try
            {
                _servicoCrudSala.Inserir(_sala);

                return Ok( "Sala cadastrada com sucesso!" );
            }
            catch (Exception ex )
            {
                return BadRequest( $"erro interno no servidor: {ex}" );
            }
        }


        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<dynamic>> buscarSalaPorId([FromRoute] int id)
        {
            try
            {
                var _sala = _servicoCrudSala.BuscarPorId(id);

                if (_sala == null)
                {
                    return BadRequest( "Sala informado não encontrado!" );
                }

                return Ok(_sala);
            }
            catch (Exception ex)
            {
                return BadRequest( $"erro interno no servidor: {ex}" );
            }

        }


        [HttpGet]
        [Route("buscar")]
        public async Task<ActionResult<dynamic>> buscarTodasSala()
        {
            try
            {
                return _servicoCrudSala.BuscarTodos().ToList();
            } 
            catch (Exception ex)
            {
                return BadRequest( $"erro interno no servidor: {ex}" );
            }
        }


        [HttpPut]
        [Route("atualizar")]
        public async Task<ActionResult<dynamic>> AtualizarSala([FromBody] Sala _sala)
        {
            try
            {
                if (buscarSalaPorId(_sala.Id) == null)
                {
                    return BadRequest( "Sala informado não encontrado!" );
                }

                _servicoCrudSala.Atualizar(_sala);

                return Ok( "Sala atualizada com sucesso!" );
            }
            catch (Exception ex)
            {

                return BadRequest( $"erro interno no servidor: {ex}" );
            }
        }


        [HttpDelete]
        [Route("deletar")]
        public async Task<ActionResult<dynamic>> DeletarSala([FromBody] Sala _sala)
        {
            try
            {
                if (buscarSalaPorId(_sala.Id) == null)
                {
                    return BadRequest( "Sala informado não encontrado!" );
                }

                _servicoCrudSala.Deletar(_sala);

                return Ok( "Sala deletada com sucesso!" );
            }
            catch (Exception ex)
            {
                return BadRequest( $"erro interno no servidor: {ex}" );
            }
        }
    }
}
