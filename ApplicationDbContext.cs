using Microsoft.EntityFrameworkCore;
using BookManagerApp.Models;

namespace BookManagerApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books => Set<Book>();
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Book_Domains>().
                    HasKey(b => new { b.BookId, b.DomainId});

            modelBuilder.Entity<Book_Domains>()
                .HasOne(b => b.Book)
                .WithMany(b => b.Book_Domains)
                .HasForeignKey(b => b.BookId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Book_Domains>()
                .HasOne(b => b.Domain)
                .WithMany(b => b.Book_Domains)
                .HasForeignKey(b => b.DomainId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


                modelBuilder.Entity<Book_Mechanics>().
                   HasKey(b => new { b.BookId, b.MechanicId });

            modelBuilder.Entity<Book_Mechanics>()
                .HasOne(b => b.Book)
                .WithMany(b => b.Book_Mechanics)
                .HasForeignKey(b => b.BookId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Book_Mechanics>()  
                .HasOne(b => b.Mechanic)
                .WithMany(b => b.Book_Mechanics)
                .HasForeignKey(b => b.MechanicId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Book>().ToTable("Books");


            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "1984", Author = "George Orwell", Year = 1949 },
                new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Year = 1960},
                new Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Year = 1925}
            );
        }
    }
}


namespace BookManagerApp.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
    }
}
