using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2.Database;
using Task2.DTO;
using Task2.Models;

namespace Task2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly AppDbContext _context;

    EmployeeController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetEmployees()
    {
        var employees = _context.employees.Include(curEmployee => curEmployee.DepartmentId).Select(curEmployee => new EmployeeResponseDTO
        {
            Id = curEmployee.Id,
            Name = curEmployee.Name,
            DepartmentId = curEmployee.DepartmentId,
            DepartmentName = curEmployee.Department.Name
        }).ToList();

        return Ok(employees);
    }

    [HttpGet("{id}")]
    public IActionResult GetEmployeeById([FromRoute] Guid id)
    {
        var employee = _context.employees.Include(curEmployee => curEmployee.DepartmentId).Select(curEmployee => new EmployeeResponseDTO
        {
            Id = curEmployee.Id,
            Name = curEmployee.Name,
            DepartmentId = curEmployee.DepartmentId,
            DepartmentName = curEmployee.Department.Name
        }).First();

        if (employee == null)
        {
            return NotFound();
        }

        else
        {
            return Ok(employee);
        }
    }

    [HttpPost]
    public IActionResult AddEmployee([FromBody] EmployeeRequestDTO employeeDTO)
    {
        Employee newEmployee = new Employee
        {
            Id = employeeDTO.Id,
            Name = employeeDTO.Name,
            DepartmentId = employeeDTO.DepartmentId
        };

        _context.employees.Add(newEmployee);
        _context.SaveChanges();
        return Created();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateEmployee([FromRoute] Guid id, [FromBody] EmployeeRequestDTO employeeDTO)
    {
        var oldEmployee = _context.employees.Find(id);

        Employee newEmployee = new Employee
        {
            Id = employeeDTO.Id,
            Name = employeeDTO.Name,
            DepartmentId = employeeDTO.DepartmentId
        };

        if (oldEmployee == null)
        {
            return NotFound();
        }

        else if (newEmployee.Name.Length > 20)
        {
            return BadRequest("Name Is Too Long");
        }

        else
        {
            oldEmployee = newEmployee;
            _context.SaveChanges();
            return Created();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEmployee([FromRoute] Guid id)
    {
        var employee = _context.employees.Find(id);

        if (employee == null)
        {
            return NotFound();
        }

        else
        {
            _context.employees.Remove(employee);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
