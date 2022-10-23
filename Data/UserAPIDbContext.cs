using Microsoft.EntityFrameworkCore;
using Perpustakaan_Web_Api.Models;

namespace Perpustakaan_Web_Api.Data
{
    public class UserAPIDbContext : DbContext
    {
        public UserAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<GetUserRequest> User { get; set; }
    }
}
