using LibraryManagementApp.Data;
using LibraryManagementApp.Dtos;
using LibraryManagementApp.IServicesRepo;
using LibraryManagementApp.Models;

namespace LibraryManagementApp.ServicesRepo
{
    public class PublishersRepo : IPublishersRepo
    {
        private readonly LibraryManagementDbContext _db;

        public PublishersRepo(LibraryManagementDbContext db)
        {
            _db = db;
        }

        public void CreatePublisher(PublishersDto publishersDto)
        {
            var publisher = new Publishers()
            {
                Name = publishersDto.Name,
                Address= publishersDto.Address, 
                Location= publishersDto.Location
            };

            _db.Publishers.Add(publisher);
            _db.SaveChanges();

        }

        public List<Publishers> GetAllPublishers()
        {
            var allPublishers = _db.Publishers.ToList();
            return allPublishers;
        }

        public Publishers GetPublisherById(int id)
        {
            var getPublisherById = _db.Publishers.FirstOrDefault(x => x.Id == id);
            return getPublisherById;
        }
        public PublishersWithAuthorsDto GetAuthorsAttachedToAPublisher(int publisherId)
        {
            var getAuthorById = _db.Publishers.Where(n => n.Id == publisherId).Select(n => new PublishersWithAuthorsDto()
            {
                Name = n.Name,
                BookAuthors = n.Author.Select(n => new PAuthorDto()
                {
                    AuthorName = n.FullName,
                    Authors = n.Book_Author.Select(n => n.Author.FullName).ToList()
                }).ToList()
            }).FirstOrDefault();
           
            return getAuthorById;
        }

    }
}
