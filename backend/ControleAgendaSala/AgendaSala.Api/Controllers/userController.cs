using AgendaSala.Database.Interface;
using AgendaSala.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AgendaSala.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class userController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public userController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        [HttpPost]
        [Route("insert")]
        public async Task<ActionResult<dynamic>> Post([FromBody] User _user)
        {
            //_user.Role = _roleRepository.FindId(5);

            _userRepository.Insert(_user);
            
            return Ok(201);
        }
    }
}
