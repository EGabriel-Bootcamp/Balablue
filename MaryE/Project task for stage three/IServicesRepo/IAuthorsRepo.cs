using LibraryManagementApp.Dtos;
using LibraryManagementApp.Models;

namespace LibraryManagementApp.IServicesRepo
{
    public interface IAuthorsRepo
    {
        List<Authors> GetAllAuthors();
        Authors GetAuthorById(int id);
        void CreateAuthor(AuthorsDto authorDto, int publishersId);

        AuthorWithBooksDto GetBooksAttachedToAnAuthor(int authorsId);
    }
}
