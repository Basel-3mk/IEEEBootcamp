using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task2.Database;
using Task2.Models;

namespace Task2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly AppDbContext _context;

    public DepartmentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetDepartments()
    {
        var departments = _context.departments.ToList();
        return Ok(departments);
    }

    [HttpGet("{id}")]
    public IActionResult GetDepartmentById([FromRoute] Guid id)
    {
        var department = _context.departments.Find(id);

        if (department == null)
        {
            return NotFound();
        }

        else
        {
            return Ok(department);
        }
    }

    [HttpPost]
    public IActionResult AddDepartment([FromBody] string newName)
    {
        if (newName.Length > 20)
        {
            return BadRequest("The Name Is Too Long");
        }

        else
        {
            var department = new Department
            {
                Name = newName
            };

            _context.departments.Add(department);
            _context.SaveChanges();
            return Created();
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDepartment([FromRoute] Guid oldId, [FromBody] string newName)
    {
        var department = _context.departments.Find(oldId);

        if (department == null)
        {
            return NotFound();
        }

        else if (newName.Length > 20)
        {
            return BadRequest("The Name Is Too Long");
        }

        else
        {
            department.Name = newName;
            _context.SaveChanges();
            return Created();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDepartment([FromRoute] Guid id)
    {
        var department = _context.departments.Find(id);

        if (department == null)
        {
            return NotFound();
        }

        else
        {
            _context.departments.Remove(department);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
