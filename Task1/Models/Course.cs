using System.ComponentModel.DataAnnotations;

namespace Task1.Models;

public class Course
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required (ErrorMessage = "Course Name Is Required")]
    public string Name { get; set; }

    [Required (ErrorMessage = "Course Hours Is Required")]
    public int Hours { get; set; }

    public List<Enrollment> Enrollments = new List<Enrollment>();
}
