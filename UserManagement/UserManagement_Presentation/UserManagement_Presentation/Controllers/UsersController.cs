using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Usermanagement_Domain.DTOs;
using Usermanagement_Domain.Interfaces;
using Usermanagement_Domain.Models;

namespace UserManagement_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<Users> _repo;

        public UsersController(IRepository<Users> repo)
        {
            _repo = repo;
        }

        [HttpGet("AllUsers")]
        public async Task<IEnumerable<Users>> GetUsers()
        {
            IEnumerable<Users> users = await _repo.GetAllAsync();
            return users;
        }
        [HttpGet("User/{username}")]
        public async Task<IActionResult> GetUser(string username)
        {

            var user = await _repo.GetAsync(u=>u.UserName == username);
            if (user == null)
            {
                return NotFound($"User '{username}' not found");
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<UpsertDTO>> RegisterUser(UpsertDTO regDTO)
        {
            if (regDTO == null)
            {
                return BadRequest("Invalid input");
            }

            var userExist = await _repo.GetAsync(u=>u.UserName == regDTO.UserName);
            if(userExist != null)
            {
                return BadRequest("Username exists");
            }
            Users newuser = new Users()
            {
                UserName = regDTO.UserName,
                Password = regDTO.Password,
                Email = regDTO.Email,
                FirstName = regDTO.FirstName,
                LastName = regDTO.LastName,
                Age = regDTO.Age,
                Address = regDTO.Address,
                City = regDTO.City,
                State = regDTO.State,
                Country = regDTO.Country,
                RegisteredAt = DateTime.Now
            };
            await _repo.CreateAsync(newuser);
            return Ok("User creation successful");
        }
        [HttpPut]
        public async Task<ActionResult<UpsertDTO>> UpdateUser(UpsertDTO updateDTO)
        {
            if(updateDTO == null)
            {
                return BadRequest("Invalid Input");
            }

            var userExist = await _repo.GetAsync(u=>u.UserName == updateDTO.UserName);
            if(userExist == null)
            {
                return NotFound($"Username '{updateDTO.UserName}' does not exist");
            }


            userExist.Password = updateDTO.Password;
            userExist.Email = updateDTO.Email;
            userExist.FirstName = updateDTO.FirstName;
            userExist.LastName = updateDTO.LastName;
            userExist.Age = updateDTO.Age;
            userExist.Address = updateDTO.Address;
            userExist.City = updateDTO.City;
            userExist.State = updateDTO.State;
            userExist.Country = updateDTO.Country;
            userExist.UpdatedAt = DateTime.Now;

            await _repo.UpdateAsync(userExist);
            return Ok("User Updated Successfully");
        }
    }
}
