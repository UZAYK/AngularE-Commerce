using Microsoft.EntityFrameworkCore;
using API.Core.DbModels;

namespace API.Infrastructure.DataContext
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options) {}
        public DbSet<Product> Products { get; set; }
    }
}
