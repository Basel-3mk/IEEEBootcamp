using System.ComponentModel.DataAnnotations;

namespace Task2.Models;

public class Department
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Name Is Required")]
    [MaxLength(20)]
    public string Name { get; set; }

    public List<Employee> Employees = new List<Employee>();
}
