using Agenda_API.Data;
using Agenda_API.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Agenda_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        private readonly DbContexto _context;

        public SetorController(DbContexto context)
        {
            _context = context;
        }

        // GET api/<SetorController>/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Setor>>> Get()
        {
            return await _context.Setor.ToListAsync();
        }

        // POST api/<SetorController>
        [HttpPost]
        public async Task<ActionResult<Setor>> PostSetor([FromBody] Setor setor)
        {
            _context.Setor.Add(setor);
            
             await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = setor.Id }, setor);
        }

        // PUT api/<SetorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SetorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
