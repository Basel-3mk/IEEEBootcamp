using Microsoft.EntityFrameworkCore;
using Training.Models;

namespace Training.Database;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Category> categories { get; set; }

    public DbSet<Product> products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var category1 = new Category
        {
            Name = "Al-Jabari"
        };

        var category2 = new Category
        {
            Name = "Al-Hroub"
        };

        var category3 = new Category
        {
            Name = "Al-Amleh"
        };

        modelBuilder.Entity<Category>().HasData(category1, category2, category3);

        var product1 = new Product
        {
            Name = "Basel",
            Price = 1,
            CategoryId = category1.Id
        };

        var product2 = new Product
        {
            Name = "Haitham",
            Price = 1,
            CategoryId = category2.Id
        };

        var product3 = new Product
        {
            Name = "Belal",
            Price = 1,
            CategoryId = category3.Id
        };

        modelBuilder.Entity<Product>().HasData(product1, product2, product3);
    }
}

