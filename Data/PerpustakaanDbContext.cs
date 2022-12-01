using Microsoft.EntityFrameworkCore;
using Perpustakaan_Web_Api.Models;

namespace Perpustakaan_Web_Api.Data
{
    public class PerpustakaanDbContext : DbContext
    {
        public PerpustakaanDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<GetPeminjamanRequest> Peminjaman { get; set; }
        public DbSet<GetBooksRequest> Buku { get; set; }
        public DbSet<GetUserRequest> User { get; set; }

    }
}
