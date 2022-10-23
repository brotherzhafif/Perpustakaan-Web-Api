using Microsoft.EntityFrameworkCore;
using Perpustakaan_Web_Api.Models;

namespace Perpustakaan_Web_Api.Data
{
    public class PeminjamanAPIDbContext : DbContext
    {
        public PeminjamanAPIDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<GetPeminjamanRequest> Peminjaman { get; set; }
    }
}
