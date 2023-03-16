using LibraryManagementApp.Dtos;
using LibraryManagementApp.IServicesRepo;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepo _booksRepo;

        public BooksController(IBooksRepo booksRepo)
        {
            _booksRepo = booksRepo;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksRepo.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksRepo.GetBookById(id);
            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] BooksDto book, int authorId)
        {
            _booksRepo.CreateBook(book, authorId);
            return Ok();
        }
    }
}
