using LibraryManagementApp.Dtos;
using LibraryManagementApp.Models;

namespace LibraryManagementApp.IServicesRepo
{
    public interface IBooksRepo
    {
        List<Books> GetAllBooks();
        BooksWithAuthorsDto GetBookById(int bookId);
        void CreateBook(BooksDto booksDto, int authorId);
    }
}
