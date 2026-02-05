using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public static List<string> namesList = new List<string> { "Basel", "Belal", "Haitham" };

        [HttpGet]
        public List<string> GetNames()
        {
            return namesList;
        }

        [HttpPost]
        public List<string> AddName(string newName)
        {
            namesList.Add(newName);
            return namesList;
        }

        [HttpPut]
        public List<string> UpdateName(int oldIndex, string newName)
        {
            namesList[oldIndex] = newName;
            return namesList;
        }

        [HttpDelete]
        public List<string> DeleteName(int index)
        {
            namesList.RemoveAt(index);
            return namesList;
        }
    }
}
