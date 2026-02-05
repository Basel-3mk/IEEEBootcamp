using Microsoft.EntityFrameworkCore;
using Task1.Models;

namespace Task1.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Student> students { get; set; }

    public DbSet<Course> courses { get; set; }

    public DbSet<Enrollment> enrollments { get; set; }
}
