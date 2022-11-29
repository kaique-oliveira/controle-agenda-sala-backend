using AgendaSala.Database.Interface;
using AgendaSala.Database.Repositories;
using AgendaSala.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AgendaSala.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class roleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly INpgSqlConnection npgSqlConnection;

        public roleController(IRoleRepository roleRepository, INpgSqlConnection npgSqlConnection)
        {
            _roleRepository = roleRepository;
            this.npgSqlConnection=npgSqlConnection;
        }

        [HttpPost]
        [Route("insert")]
        public async Task<ActionResult<dynamic>> Post([FromBody] Role _role)
        {
            npgSqlConnection.CreateSession();
            _roleRepository.Insert(_role);

            return Ok(201);
        }
    }
}
