using Microsoft.AspNetCore.Mvc;
using TodoApi.DTO;
using TodoApi.Interface;
using TodoApi.Models;


namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) { 
            this._userRepository = userRepository;
        }
        [HttpGet("")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<User>))]
        public IActionResult GetAll()
        {
            return Ok(this._userRepository.GetAll());
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(this._userRepository.GetUserById(id)) ;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(UserDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var newUser = await _userRepository.Create(user);
            return this.Ok(newUser);

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id,UserDto user) {
            if (user == null)
            {
                return BadRequest();
            }
            var response = await this._userRepository.Update(id, user);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await this._userRepository.Delete(id);
            return Ok(response);
        }
    }
}
