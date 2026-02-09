using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Training.Database;
using Training.DTO;
using Training.Models;

namespace Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _context.products.Include(curProduct => curProduct.Category).Select(curProduct => new ProductResponseDTO
            {
                Id = curProduct.Id,
                Name = curProduct.Name,
                Price = curProduct.Price,
                CategoryId = curProduct.CategoryId,
                CategoryName = curProduct.Category.Name
            }).ToList();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            var product = _context.products.Include(curProduct => curProduct.Category).Select(curProduct => new ProductResponseDTO
            {
                Id = curProduct.Id,
                Name = curProduct.Name,
                Price = curProduct.Price,
                CategoryId = curProduct.CategoryId,
                CategoryName = curProduct.Category.Name
            }).First();

            if (product == null)
            {
                return NotFound();
            }

            else
            {
                return Ok(product);
            }
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductRequestDTO productDTO)
        {
            Product newProduct = new Product
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Price = productDTO.Price,
                CategoryId = productDTO.CategoryId
            };

            _context.products.Add(newProduct);
            _context.SaveChanges();
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct([FromRoute] Guid id, [FromBody] ProductRequestDTO productDTO)
        {
            var oldProduct = _context.products.Find(id);

            Product newProduct = new Product
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Price = productDTO.Price,
                CategoryId = productDTO.CategoryId
            };

            if (oldProduct == null)
            {
                return NotFound();
            }

            else
            {
                oldProduct = newProduct;
                _context.SaveChanges();
                return Created();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory([FromRoute] Guid id)
        {
            var product = _context.products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            else
            {
                _context.products.Remove(product);
                _context.SaveChanges();
                return NoContent();
            }
        }
    }
}
