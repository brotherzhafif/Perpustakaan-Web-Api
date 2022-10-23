using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perpustakaan_Web_Api.Data;
using Perpustakaan_Web_Api.Models;

namespace Perpustakaan_Web_Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class Buku : Controller
    {
        private readonly BukuAPIDbContext dbContext;

        public Buku(BukuAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await dbContext.Buku.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddBookRequest(AddBookRequest addBook)
        {
            var book = new GetBooksRequest()
            {
                ID = Guid.NewGuid(),
                Nama = addBook.Nama,
                Jenis = addBook.Jenis
            };

            await dbContext.AddAsync(book);
            await dbContext.SaveChangesAsync();

            return Ok(book);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateBookRequest([FromRoute] Guid id, UpdateBookRequest updateBook)
        {
            var book = await dbContext.Buku.FindAsync(id);

            if (book != null)
            {
                book.Nama = updateBook.Nama;
                book.Jenis = updateBook.Jenis;

                await dbContext.SaveChangesAsync();

                return Ok(book);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteBookRequest([FromRoute] Guid id)
        {
            var book = await dbContext.Buku.FindAsync(id);

            if (book != null)
            {
                dbContext.Buku.Remove(book);
                await dbContext.SaveChangesAsync();
                return Ok(book);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> FindBookRequest([FromRoute] Guid id)
        {
            var book = await dbContext.Buku.FindAsync(id);

            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
    }
}
