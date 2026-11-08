using BackendBar.Models;
using BackendBar.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendBar.Controllers
{
    namespace Ejercicio1.Controllers
    {
        [Authorize]
        [Route("api/[controller]")]
        [ApiController]
        public class UserController : ControllerBase
        {
            private readonly UserRepository _userRepository;

            public UserController(UserRepository userRepository)
            {
                _userRepository = userRepository;
            }


            //Get All
            [HttpGet]
            public ICollection<User> GetAllUsers()
            {
                return _userRepository.getAllUsers();
            }

            //Get by ID
            [HttpGet("id")]
            public ActionResult<User> UserById(int id)
            {
                var user = _userRepository.userById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }

            //Add User
            [HttpPost]
            [Authorize(Roles = "Admin")]
            public ActionResult AddUser([FromBody] User user)
            {
                var _user = new User
                {
                    Id = user.Id,
                    Name = user.Name,
                    Phone = user.Phone,
                    Email = user.Email,
                    RoleId = user.Id

                };

                _userRepository.addUser(_user);
                return CreatedAtAction(nameof(UserById), new { id = user.Id }, user);
            }

            //Delete by Id
            [HttpDelete]
            [Authorize(Roles = "Admin")]
            public ActionResult DeleteUserById(int id)
            {
                bool deleted = _userRepository.deleteUserById(id);
                if (deleted)
                    return Ok();
                return BadRequest();
            }
        }
    }

}
