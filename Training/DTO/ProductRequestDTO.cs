namespace Training.DTO;

public class ProductRequestDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; }

    public int Price { get; set; }

    public Guid CategoryId { get; set; }
}
