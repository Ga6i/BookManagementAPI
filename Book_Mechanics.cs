using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagerApp.Models
{
    public class Book_Mechanics
    {
        [Key]
        [Required]
        public int BookId { get; set; }

        [Key]
        [Required]
        public int MechanicId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public Book? Book { get; set; }
        public Mechanic? Mechanic { get; set; }
    }
}
