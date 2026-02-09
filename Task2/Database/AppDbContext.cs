using Microsoft.EntityFrameworkCore;
using Task2.Models;

namespace Task2.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Department> departments { get; set; }

    public DbSet<Employee> employees { get; set; }
}
