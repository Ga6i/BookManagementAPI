using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BookManagerApp.Models;
using BookManagerApp.Models.Csv;
using System.Globalization;

namespace BookManagerApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<SeedController> _logger;

        public SeedController(
            ApplicationDbContext context,
            ILogger<SeedController> logger,
            IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
            _logger = logger;
        }

        [HttpPut(Name = "Seed")]
        [ResponseCache(NoStore = true)]
        public async Task<IActionResult> SeedDataFromCsv()
        {
            try
            {
                var config = new CsvConfiguration(CultureInfo.GetCultureInfo("pt-BR"))
                {
                    HasHeaderRecord = true,
                    Delimiter = ";",
                };

                var path = Path.Combine(_env.ContentRootPath, "Data/Books.csv");

                using var reader = new StreamReader(path);
                using var csv = new CsvReader(reader, config);

                var records = csv.GetRecords<BookRecord>().ToList();

                // Track existing books to prevent duplicates
                var existingBooks = await _context.Books.ToDictionaryAsync(b => b.Id);

                int importedCount = 0;

                foreach (var record in records)
                {
                    if (!existingBooks.ContainsKey(record.BookId))
                    {
                        var book = new Book
                        {
                            Id = record.BookId,
                            Title = record.Title,
                            Author = record.Author,
                            Year = record.Year,
                        };

                        _context.Books.Add(book);
                        importedCount++;
                    }
                }

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    Message = "CSV data successfully imported.",
                    RecordsImported = importedCount,
                    TotalBooks = existingBooks.Count + importedCount
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the CSV data.");
                return StatusCode(500, "An error occurred while processing the CSV file.");
            }
        }


    }
}
