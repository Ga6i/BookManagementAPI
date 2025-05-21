using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookManagerApp.Models;

namespace BookManagerApp.Models
{
    public class Book_Domains
    {
        [Required]
        [Key]
        public required Domain Domain { get; set; }

        [Key]
        [Required]
        public int BookId { get; set; }

        [Key]
        [Required]
        public string DomainId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public Book? Book { get; set; }
        public Mechanic? Mechanic { get; set; }
    };
    public class BookDomainCollection
    {
        public ICollection<Book_Domains>? Book_Domains { get; set; }
    }
}
