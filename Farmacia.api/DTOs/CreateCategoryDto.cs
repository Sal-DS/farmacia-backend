using System.ComponentModel.DataAnnotations;

namespace Farmacia.api.DTOs;

public class CreateCategoryDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
}
