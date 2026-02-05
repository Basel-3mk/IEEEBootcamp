using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.Models;

namespace Training.Controllers
{
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

        [HttpGet]
        public List<Category> GetCategories()
        {
            return categoriesList;
        }

        [HttpPost]
        public List<Category> AddCategory(string newName)
        {
            categoriesList.Add(new Category { Name = newName });
            return categoriesList;
        }

        [HttpPut]
        public List<Category> UpdateCategory(int oldIndex, string newName)
        {
            categoriesList[oldIndex].Name = newName;
            return categoriesList;
        }

        [HttpDelete]
        public List<Category> DeleteCategory(int index)
        {
            categoriesList.RemoveAt(index);
            return categoriesList;
        }
    }
}