using LibraryManagementApp.Models;

namespace LibraryManagementApp.Dtos
{
    public class AuthorsDto
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public int PublishersId { get; set; }
    }

    public class AuthorWithBooksDto
    {
        public string FullName { get; set; }
        public List<string> BookTitles { get; set; }
    }

}
