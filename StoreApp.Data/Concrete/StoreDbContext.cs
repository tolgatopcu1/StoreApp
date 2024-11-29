using Microsoft.EntityFrameworkCore;

namespace StoreApp.Data.Concrete;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {

    }
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasMany(e=>e.Categories)
            .WithMany(e=>e.Products)
            .UsingEntity<ProductCategory>();

        modelBuilder.Entity<Category>()
            .HasIndex(u=>u.Url)
            .IsUnique();

        modelBuilder.Entity<Product>().HasData(
            new List<Product>(){
                new (){ Id = 1, Name = "Iphone 13" , Description = "Harika Telefon", Price =70000},
                new (){ Id = 2, Name = "Iphone 14" , Description = "Harika Telefon", Price =80000},
                new (){ Id = 3, Name = "Iphone 15" , Description = "Harika Telefon", Price =90000},
                new (){ Id = 4, Name = "Iphone 16" , Description = "Harika Telefon", Price =90000},
                new (){ Id = 5, Name = "Çamaşır makinesi" , Description = "Harika Makine", Price =1000000},
            }
        );

        modelBuilder.Entity<Category>().HasData(
            new List<Category>(){
                new () {Id = 1 , Name = "Telefon", Url = "telefon"},
                new () {Id = 2 , Name = "Elektronik", Url = "elektronik"},
                new () {Id = 3 , Name = "Beyaz Eşya", Url = "beyaz-esya"}
            }
        );
        modelBuilder.Entity<ProductCategory>().HasData(
            new List<ProductCategory>(){
                new ProductCategory() {ProductId = 1 , CategoryId = 1},
                new ProductCategory() {ProductId = 2 , CategoryId = 1},
                new ProductCategory() {ProductId = 3 , CategoryId = 1},
                new ProductCategory() {ProductId = 4 , CategoryId = 1},
                new ProductCategory() {ProductId = 4 , CategoryId = 2},
                new ProductCategory() {ProductId = 5 , CategoryId = 2},
                new ProductCategory() {ProductId = 5 , CategoryId = 3},
            }
        );
    }
}