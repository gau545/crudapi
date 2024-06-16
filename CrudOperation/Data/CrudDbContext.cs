using CrudOperation.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CrudOperation.Data
{
    public class CrudDbContext : DbContext
    {
        public CrudDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
