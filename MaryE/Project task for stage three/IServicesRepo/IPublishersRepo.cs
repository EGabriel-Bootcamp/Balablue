using LibraryManagementApp.Dtos;
using LibraryManagementApp.Models;

namespace LibraryManagementApp.IServicesRepo
{
    public interface IPublishersRepo
    {
        List<Publishers> GetAllPublishers();
        Publishers GetPublisherById(int id);
        void CreatePublisher(PublishersDto publishersDto);

        PublishersWithAuthorsDto GetAuthorsAttachedToAPublisher(int PublishersId);
    }
}
