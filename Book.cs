using Microsoft.EntityFrameworkCore;
using BookManagerApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookManagerApp
{
    [Table("Book")]
    public class Book
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = null!;

        [Required]
        public string Author { get; set; }
        
        [Required]
        public int Year { get; set; }

       

        public ICollection<Book_Domains>? Book_Domains { get; set; }
        public ICollection<Book_Mechanics>? Book_Mechanics { get; set; }
        public DateTime LastModifiedDate { get; internal set; }
    }

   
}        
