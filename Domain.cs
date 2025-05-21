using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagerApp.Models
{
    public class Domain
    {
            
            [Required]
            public int BookId { get; set; }

            [Key]
            [Required]
            public string DomainId { get; set; }

            [Required]
            public DateTime CreatedDate { get; set; }

        public ICollection<Book_Domains> Book_Domains { get; set; }

    }
}
