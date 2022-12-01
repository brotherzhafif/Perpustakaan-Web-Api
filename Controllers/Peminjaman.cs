using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perpustakaan_Web_Api.Data;
using Perpustakaan_Web_Api.Models;

namespace Perpustakaan_Web_Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class Peminjaman : Controller
    {
        private readonly PerpustakaanDbContext dbContext;

        public Peminjaman(PerpustakaanDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPeminjaman()
        {
            return Ok(await dbContext.Peminjaman.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddPeminjamanRequest(AddPeminjamanRequest addPeminjaman)
        {
            var peminjaman = new GetPeminjamanRequest()
            {
                Id = Guid.NewGuid(),
                Nama = addPeminjaman.Nama,
                Kelas = addPeminjaman.Kelas,
                Buku = addPeminjaman.Buku,
                Pengawas = addPeminjaman.Pengawas,
                Tanggal = addPeminjaman.Tanggal,
                Denda = addPeminjaman.Denda,
                Status = addPeminjaman.Status
            };

            await dbContext.AddAsync(peminjaman);
            await dbContext.SaveChangesAsync();
            return Ok(peminjaman);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdatePeminjamanRequest([FromRoute] Guid id, UpdatePeminjamanRequest updatePeminjaman)
        {
            var peminjaman = await dbContext.Peminjaman.FindAsync(id);

            if(peminjaman != null)
            {
                peminjaman.Nama = updatePeminjaman.Nama;
                peminjaman.Kelas = updatePeminjaman.Kelas;
                peminjaman.Buku = updatePeminjaman.Buku;
                peminjaman.Pengawas = updatePeminjaman.Pengawas;
                peminjaman.Tanggal = updatePeminjaman.Tanggal;
                peminjaman.Denda = updatePeminjaman.Denda;
                peminjaman.Status = updatePeminjaman.Status;

                await dbContext.SaveChangesAsync();
                return Ok(peminjaman);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeletePeminjamanRequest([FromRoute] Guid id)
        {
            var peminjaman = await dbContext.Peminjaman.FindAsync(id);
            if (peminjaman != null)
            {
                dbContext.Peminjaman.Remove(peminjaman);
                await dbContext.SaveChangesAsync();

                return Ok(peminjaman);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> SelectPeminjaman([FromRoute] Guid id)
        {
            var peminjaman = await dbContext.Peminjaman.FindAsync(id);
            if(peminjaman != null)
            {
                return Ok(peminjaman);
            }
            return NotFound();
        }
    }
}
