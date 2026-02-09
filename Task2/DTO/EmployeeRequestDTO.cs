namespace Task2.DTO;

public class EmployeeRequestDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; }

    public Guid DepartmentId { get; set; }
}
