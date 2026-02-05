using System.ComponentModel.DataAnnotations;

namespace Training.Models;

public class Category
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required (ErrorMessage = "Name Is Required")]
    [MaxLength(20)]
    public string Name { get; set; }

    public List<Product> Products = new List<Product>();
}