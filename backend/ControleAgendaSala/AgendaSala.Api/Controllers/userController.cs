using AgendaSala.Database.Interface;
using AgendaSala.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace AgendaSala.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class userController : ControllerBase
    {
        private readonly IUserCrud _userRepository;
        private readonly IRoleCrud _roleRepository;

        public userController(IUserCrud userRepository, IRoleCrud roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        [HttpPost]
        [Route("insert")]
        public async Task<ActionResult<dynamic>> Post([FromBody] Usuario _user)
        {
            //_user.Role = _roleRepository.FindId(5);

            _userRepository.Insert(_user);
            
            return Ok(201);
        }
    }
}
