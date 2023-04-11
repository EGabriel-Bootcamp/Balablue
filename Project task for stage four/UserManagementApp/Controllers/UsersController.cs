using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserManagementApp.Domain.Entities;
using UserManagementApp.Domain.Repository;
using UserManagementApp.Dtos;

namespace UserManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        

        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            var user = _unitOfWork.User.GetAll();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserDto userDto)
        {
            var newUser = _mapper.Map<User>(userDto);
            _unitOfWork.User.Add(newUser);
            _unitOfWork.Save();

            return Ok(newUser);
        }

        [HttpGet("/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _unitOfWork.User.GetById(id);
            var result = _mapper.Map<UserDto>(user);
            return Ok(result);
        }

        [HttpPut("/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserDto userDto)
        {
            var updateUser = _unitOfWork.User.GetById(id);
            _mapper.Map(userDto, updateUser);
            _unitOfWork.User.Update(updateUser);
            _unitOfWork.Save();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            var deleteUser =  _unitOfWork.User.GetById( id);
            _unitOfWork.User.Remove(deleteUser.Id);
            _unitOfWork.Save();

            return NoContent();
        }

        [HttpGet("/FliterUserInfo")]
        public IActionResult GetUsersWithFilter(int? age, string? gender, string? maritalStatus, string? address)
        {
            var users = _unitOfWork.User.Find(u =>
                    (!age.HasValue || u.Age == age.Value) &&
                    (string.IsNullOrEmpty(gender) || u.Gender.ToLower() == gender.ToLower()) &&
                    (string.IsNullOrEmpty(maritalStatus) || u.MaritalStatus.ToLower() == maritalStatus.ToLower()) &&
                    (string.IsNullOrEmpty(address) || u.Address.ToLower() == address.ToLower())).ToList();
            if (users.Count == 0)
            {
                return NotFound("User Info is not found");
            }
            else
            {
                return Ok(users);
            }
        }
    }
}
