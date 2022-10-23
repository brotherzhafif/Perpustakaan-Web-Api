using Microsoft.EntityFrameworkCore;
using Perpustakaan_Web_Api.Models;

namespace Perpustakaan_Web_Api.Data
{
    public class BukuAPIDbContext : DbContext
    {
        public BukuAPIDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<GetBooksRequest> Buku { get; set; }
    }
}
