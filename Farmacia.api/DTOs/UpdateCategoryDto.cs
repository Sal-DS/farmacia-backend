using System.ComponentModel.DataAnnotations;

namespace Farmacia.api.DTOs;

public class UpdateCategoryDto
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
}
