using LibraryManagementApp.Data;
using LibraryManagementApp.Dtos;
using LibraryManagementApp.IServicesRepo;
using LibraryManagementApp.Models;

namespace LibraryManagementApp.ServicesRepo
{
    public class BooksRepo : IBooksRepo
    {
        private readonly LibraryManagementDbContext _db;

        public BooksRepo(LibraryManagementDbContext db)
        {
            _db = db;
        }

        public void CreateBook(BooksDto booksDto, int authorId)
        {
            var aut = _db.Authors.First(x => x.Id == authorId);
            if(aut != null)
            {
                var book = new Books()
                {
                    Title = booksDto.Title,
                    Description = booksDto.Description,
                    IsRead = booksDto.IsRead,
                    DateRead = booksDto.IsRead ? booksDto.DateRead.Value : null,
                    Rate = booksDto.IsRead ? booksDto.Rate.Value : null,
                    Genre = booksDto.Genre,
                    AuthorId = booksDto.AuthorId,
                    DateAdded = DateTime.Now
                };
                _db.Books.Add(book);
                _db.SaveChanges();

                foreach (var id in booksDto.AuthorsId)
                {
                    var book_author = new Book_Author()
                    {
                        BookId = book.Id,
                        AuthorId = id
                    };

                    _db.Book_Author.Add(book_author);
                    _db.SaveChanges();
                }

            }
            
        }

        public List<Books> GetAllBooks()
        {
            var allBooks = _db.Books.ToList();
            return allBooks;
        }

        public BooksWithAuthorsDto GetBookById(int bookId)
        {
            var bookWithAuthors = _db.Books.Where(n => n.Id == bookId).Select(book => new BooksWithAuthorsDto()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                AuthorNames = book.Book_Authors.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();

           return bookWithAuthors;
        }
    }
}
