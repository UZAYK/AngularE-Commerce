using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using API.Data.DbModels;

namespace API.Data.DataContext
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options): base (options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
