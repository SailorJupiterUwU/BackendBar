using BackendBar.Interfaces;
using BackendBar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendBar.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return Ok(await _userRepository.getAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> UserById(int id)
        {
            var user = await _userRepository.userById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddUser([FromBody] User user)
        {
            var newUser = new User
            {
                Name = user.Name,
                Phone = user.Phone,
                Email = user.Email,
                RoleId = user.RoleId
            };

            await _userRepository.addUser(newUser);
            return CreatedAtAction(nameof(UserById), new { id = newUser.Id }, newUser);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> UpdateUser([FromBody] User user)
        {
            var updated = await _userRepository.updateUserById(user);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteUserById(int id)
        {
            var deleted = await _userRepository.deleteUserById(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}