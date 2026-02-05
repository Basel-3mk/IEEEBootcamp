using System.ComponentModel.DataAnnotations;

namespace Task1.Models;

public class Student
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required (ErrorMessage = "First Name Is Required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name Is Required")]
    public string LastName { get; set; }

    public List<Enrollment> Enrollments = new List<Enrollment>();
}
