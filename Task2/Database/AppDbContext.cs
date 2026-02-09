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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var department1 = new Department
        {
            Name = "Foothill"
        };

        var department2 = new Department
        {
            Name = "Asal"
        };

        var department3 = new Department
        {
            Name = "Aeliasoft"
        };

        modelBuilder.Entity<Department>().HasData(department1, department2, department3);

        var employee1 = new Employee
        {
            Name = "Basel"
        };

        var employee2 = new Employee
        {
            Name = "Haitham"
        };

        var employee3 = new Employee
        {
            Name = "Belal"
        };

        modelBuilder.Entity<Employee>().HasData(employee1, employee2, employee3);
    }
}
