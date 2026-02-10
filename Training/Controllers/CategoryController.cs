using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.Database;
using Training.Models;

namespace Training.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoryController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet ("Get_All_Categories")]
    public IActionResult GetCategories()
    {
        var categories = _context.categories.ToList();
        return Ok(categories);
    }

    [HttpGet ("Get_First_Category")]
    public IActionResult GetFirstCategory()
    {
        var category = _context.categories.First();

        if (category == null)
        {
            return NotFound();
        }

        else
        {
            return Ok(category);
        }
    }

    [HttpPost ("Post_Category")]
    public IActionResult AddCategory([FromBody] string newName)
    {
        if (newName.Length > 20)
        {
            return BadRequest("Very Long Name");
        }

        else
        {
            _context.categories.Add(new Category { Name = newName });
            _context.SaveChanges();
            return Created();
        }
    }

    [HttpPut("Put_{id}")]
    public IActionResult UpdateCategory([FromRoute] Guid id, [FromBody] string newName)
    {
        var oldCategory = _context.categories.Find(id);

        if (oldCategory == null)
        {
            return NotFound();
        }

        else if (newName.Length > 20)
        {
            return BadRequest("Very Long Name");
        }

        else
        {
            oldCategory.Name = newName;
            _context.SaveChanges();
            return Created();
        }
    }

    [HttpDelete ("Delete_{id}")]
    public IActionResult DeleteCategory([FromRoute] Guid id)
    {
        var category = _context.categories.Find(id);

        if (category == null)
        {
            return NotFound();
        }

        else
        {
            _context.categories.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }
    }
}