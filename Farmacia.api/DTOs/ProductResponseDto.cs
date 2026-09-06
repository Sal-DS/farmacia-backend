namespace Farmacia.api.DTOs;

public class ProductResponseDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Manufacturer { get; set; } = string.Empty;

    public int CategoryId { get; set; }

    public CategoryResponseDto? Category { get; set; }
}
