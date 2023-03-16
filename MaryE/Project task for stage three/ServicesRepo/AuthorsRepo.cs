using LibraryManagementApp.Data;
using LibraryManagementApp.Dtos;
using LibraryManagementApp.IServicesRepo;
using LibraryManagementApp.Models;

namespace LibraryManagementApp.ServicesRepo
{
    public class AuthorsRepo : IAuthorsRepo
    {
        private readonly LibraryManagementDbContext _db;

        public AuthorsRepo(LibraryManagementDbContext db)
        {
            _db = db;
        }

        public void CreateAuthor(AuthorsDto authorsDto, int publishersId)
        {
            var pub = _db.Publishers.First(x => x.Id == publishersId);

            if (pub != null)
            {
                var author = new Authors()
                {
                    FullName = authorsDto.FullName,
                    Address = authorsDto.Address,
                    PublishersId = publishersId
                };

                _db.Authors.Add(author);
                _db.SaveChanges();

            }
        }

        public List<Authors> GetAllAuthors()
        {
            var allAuthors = _db.Authors.ToList();
            return allAuthors;
        }

        public Authors GetAuthorById(int id)
        {
            var getbyId = _db.Authors.FirstOrDefault(x => x.Id == id);
            return getbyId;
        }

        public AuthorWithBooksDto GetBooksAttachedToAnAuthor(int authorsId)
        {
            var _author = _db.Authors.Where(n => n.Id == authorsId).Select(n => new AuthorWithBooksDto()
            {
                FullName = n.FullName,
                BookTitles = n.Book_Author.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();
            
            return _author;
        }
    }
}
