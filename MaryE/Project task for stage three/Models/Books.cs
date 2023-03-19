using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementApp.Models
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }

        [ForeignKey("AuthorId")]
        public int? AuthorId { get; set; }
        public Authors? Author { get; set; }
        public DateTime? DateAdded { get; set; }
        public List<Book_Author>? Book_Authors { get; set; }

    }
}
