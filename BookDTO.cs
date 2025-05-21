using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BookManagerApp.DTO
{
    public class BookDTO
    {
        [Required]
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? Year { get; set; }
    }
}
