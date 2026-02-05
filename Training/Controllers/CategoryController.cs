using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.Models;

namespace Training.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    public static List<Category> categoriesList = new List<Category>
    {
        new Category { Name = "Cat1" },
        new Category { Name = "Cat2" },
        new Category { Name = "Cat3" }
    };

    [HttpGet("GetAllCategories")]
    public IActionResult GetCategories()
    {
        return Ok(categoriesList);
    }

    [HttpPost]
    public IActionResult AddCategory(string newName)
    {
        if (newName.Length > 20)
        {
            return BadRequest("Very Long Name");
        }

        else
        {
            categoriesList.Add(new Category { Name = newName });
            return Created();
        }
    }

    [HttpPut]
    public IActionResult UpdateCategory(int oldIndex, string newName)
    {
        if (oldIndex >= categoriesList.Count)
        {
            return NotFound("Out Of Bound Index");
        }

        else if (newName.Length > 20)
        {
            return BadRequest("Very Long Name");
        }

        else
        {
            categoriesList[oldIndex].Name = newName;
            return Created();
        }
    }

    [HttpDelete]
    public IActionResult DeleteCategory(int index)
    {
        if (index >= categoriesList.Count)
        {
            return NotFound("Out Of Bound Index");
        }

        else
        {
            categoriesList.RemoveAt(index);
            return Created();
        }
    }
}