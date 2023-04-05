using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement_DataAccess;
using UserManagement_DataAccess.InterfacesImplementation;
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
        private readonly IUser _repo;
        private readonly UserManagementContext _context;

        public UsersController(IUser repo, UserManagementContext context)
        {
            _repo = repo;
            _context = context;
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
        //[HttpGet("/multiple/{usernames}")]
        //public async Task<IActionResult> GetMultipleUsers(IList<string> list)
        //{
        //    var users = await _repo.GetMutipleAsync(list);
        //    //return users;
        //}
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
                Gender = regDTO.Gender,
                MaritalStatus = regDTO.MaritalStatus,
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
            userExist.Gender = updateDTO.Gender;
            userExist.MaritalStatus = updateDTO.MaritalStatus;
            userExist.Address = updateDTO.Address;
            userExist.City = updateDTO.City;
            userExist.State = updateDTO.State;
            userExist.Country = updateDTO.Country;
            userExist.UpdatedAt = DateTime.Now;

            await _repo.UpdateAsync(userExist);
            return Ok("User Updated Successfully");
        }
        [HttpPost("Filterusers")]
        public async Task<IActionResult> FilterUsers([FromBody] UserFilter filter)
        {
            if (filter == null)
            {
                return BadRequest("Invalid Input");
            }

            //var users = await _repo.GetFilteredUsersAsync(filter);
            var users = await _repo.GetFilteredUsersAsync(filter);

            return Ok(users);
        }
        [HttpDelete("user/{username}")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("Invalid Input");
            }

            var userExist = await _repo.GetAsync(u => u.UserName == username);
            if(userExist == null)
            {
                return NotFound($"Username '{username}' not found");
            }

            await _repo.DeleteAsync(d=>userExist.UserName == username);
            return Ok($"'{username}' successfully deleted");
        }
        [HttpDelete("/{specificUsers}")]
        public async Task<IActionResult> DeleteSpecificUsers([FromBody] List<string> usernames)
        {
            if(usernames == null)
            {
                return BadRequest("Invalid Input");
            }
            List<string> failedToDelete = new List<string>();
            List<string> successfulDeletions = new List<string>();
            
            var usersToDelete = await _repo.GetAsync(u=>usernames.Contains(u.UserName));
            //foreach(var user in usersToDelete)
            //{
            //    failedToDelete.Add(user.UserName);
            //}
            if (usersToDelete == null)
            {
                return NotFound($"The specified usernames are not found");
            }

            //var delete = await _repo.DeleteMultipleAsync(usersToDelete);
            //if (usersToDelete.Count <= usernames.Count)
            //{
            //    _context.Users.RemoveRange(usersToDelete);
            //    await _context.SaveChangesAsync();

            //    foreach (var username in usernames)
            //    {
            //        if (usersToDelete.Any(u => u.UserName == username))
            //        {
            //            successfulDeletions.Add(username);
            //        }
            //        else
            //        {
            //            failedToDelete.Add(username);
            //        }
            //    }
            //    if (failedToDelete.Count > 0)
            //    {
            //        return BadRequest($"The following username(s) {string.Join(",", failedToDelete)} were not deleted. Reason: Usernames not found");
            //    }
            //}
            return Ok($"Deleted the following users: {string.Join(",", successfulDeletions)}");
        }

    }
}
