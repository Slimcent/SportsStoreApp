using Microsoft.EntityFrameworkCore;
using SportsStore.Models.Entities;

namespace SportsStore.Data.Context
{
    public class SportsStoreDbContext : DbContext
    {
        public SportsStoreDbContext(DbContextOptions<SportsStoreDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
