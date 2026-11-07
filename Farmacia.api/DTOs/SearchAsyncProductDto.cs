using System.ComponentModel.DataAnnotations;

namespace Farmacia.api.DTOs;

public class SearchAsyncProductDto
{
    [Required]
    [MaxLength(25)]
    public string Name { get; set; } = string.Empty;
}