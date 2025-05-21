using BookManagerApp.DTO.v1;
using BookManagerApp.DTO.v2;
using BookManagerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookManagerApp.Controllers.v2
{
    [Route("v{version:apiVersion} /[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public DTO.v2.RestDTO<List<Book>> Get()
        {
            return new DTO.v2.RestDTO<List<Book>>
            {
                Data = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "1984",
                Author = "George Orwell",
                Year = 1949,
                
            },
            new Book
            {
                Id = 2,
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                Year = 1960,
               
            },
            new Book
            {
                Id = 3,
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                Year = 1925,
                
            }
        },
                Links = new List<LinkDTO>
        {
            new LinkDTO(
                Url.Action(null, "Book", null, Request.Scheme)!,
                "self",
                "GET")
        }
            };
        }
    }
}

