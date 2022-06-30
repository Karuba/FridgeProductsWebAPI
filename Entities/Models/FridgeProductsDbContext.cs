using Microsoft.EntityFrameworkCore;

namespace FridgeProductsWebAPI.Models
{
    public class FridgeProductsDbContext : DbContext
    {
        public FridgeProductsDbContext(DbContextOptions<FridgeProductsDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<FridgeModel> FridgeModels { get; set; }
        public DbSet<FridgeProduct> FridgeProductsSet { get; set; }
        public DbSet<Product> ProductsSet { get; set; }
        
    }
}
