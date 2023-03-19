using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementApp.Models
{
    public class Authors
    {
        [Key]
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }

        [ForeignKey("PublishersId")]
        public int? PublishersId { get; set; }
        public Publishers Publishers { get; set; }
        public List<Book_Author>? Book_Author { get; set; }
      
    }
}
