using AutoMapper;
using LibraryManagementApp.Dtos;
using LibraryManagementApp.IServicesRepo;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsRepo _authorsRepo;
       
        public AuthorsController(IAuthorsRepo authorsRepo)
        {
            _authorsRepo = authorsRepo;
           
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {

            var allAuthors = _authorsRepo.GetAllAuthors();
            return Ok(allAuthors);

        }

        [HttpGet("{id}/GetAuthorById")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _authorsRepo.GetAuthorById(id);
            return Ok(author);
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] AuthorsDto authorsDto, int publishersId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                    
           _authorsRepo.CreateAuthor(authorsDto, publishersId);
            return Ok();
        }

        [HttpGet("{id}/GetbooksToAnAuthorId")]
        public IActionResult GetBooksAttachedToAnAuthor(int id)
        {
           
            var book = _authorsRepo.GetBooksAttachedToAnAuthor(id);

            return Ok(book);
        }
    }
}
