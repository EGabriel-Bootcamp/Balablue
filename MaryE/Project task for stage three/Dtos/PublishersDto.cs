using LibraryManagementApp.Models;

namespace LibraryManagementApp.Dtos
{
    public class PublishersDto
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Address { get; set; }
       
    }
    public class PublishersWithAuthorsDto
    {
        public string? Name { get; set; }
        public List<PAuthorDto> BookAuthors { get; set; }      
    }

    public class PAuthorDto
    {
        public string? AuthorName { get; set;}
        public List<string> Authors { get; set; }
    }
}
