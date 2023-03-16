using LibraryManagementApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementApp.Dtos
{
    public class BooksDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public int? AuthorId { get; set; }
        public DateTime? DateAdded { get; set; }
        public List<int> AuthorsId { get; set; }
        
    }

    public class BooksWithAuthorsDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public List<string> AuthorNames { get; set; }

    }
}
