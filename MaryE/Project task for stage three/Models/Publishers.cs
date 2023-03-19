using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApp.Models
{
    public class Publishers
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Address { get; set; }
        public List<Authors>? Author { get; set; }
      
    }
}
