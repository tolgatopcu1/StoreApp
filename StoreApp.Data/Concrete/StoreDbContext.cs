using Microsoft.EntityFrameworkCore;

namespace StoreApp.Data.Concrete;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {

    }
    public DbSet<Product> Products => Set<Product>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new List<Product>(){
                new (){ Id = 1, Name = "Iphone 13" , Description = "Harika Telefon", Category="Telefon", Price =70000},
                new (){ Id = 2, Name = "Iphone 13" , Description = "Harika Telefon", Category="Telefon", Price =80000},
                new (){ Id = 3, Name = "Iphone 13" , Description = "Harika Telefon", Category="Telefon", Price =90000},
            }
        );
    }
}