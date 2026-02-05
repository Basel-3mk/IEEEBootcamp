using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training.Models;

public class Product
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required (ErrorMessage = "Name Is Required")]
    [MaxLength(20)]
    public string Name { get; set; }

    [Required (ErrorMessage = "Price Is Required")]
    [Range(1, 1000)]
    public int Price { get; set; }

    [Required (ErrorMessage = "CategoryId Is Required")]
    public Guid CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
}
