using AgendaSala.Database.Interface;
using AgendaSala.Database.Repositories;
using AgendaSala.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace AgendaSala.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class roleController : ControllerBase
    {
        private readonly IRoleCrud _roleRepository;

        public roleController(IRoleCrud roleRepository)
        {
            _roleRepository = roleRepository;

        }

        [HttpPost]
        [Route("insert")]
        public async Task<ActionResult<dynamic>> Post([FromBody] Setor _role)
        {

            _roleRepository.Insert(_role);

            return Ok(201);
        }
    }
}
