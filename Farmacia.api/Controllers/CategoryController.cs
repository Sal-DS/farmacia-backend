using Farmacia.api.DTOs;
using Farmacia.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Farmacia.api.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository repo;

    public CategoryController(ICategoryRepository catrepo)
    {
        repo = catrepo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryResponseDto>>> Get()
    {
        var categories = await repo.GetAsync();
        return Ok(categories.Select(ToResponseDto));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryResponseDto>> GetById(int id)
    {
        var category = await repo.GetByIdAsync(id);
        if (category is null)
        {
            return NotFound();
        }

        return Ok(ToResponseDto(category));
    }

    [HttpPost]
    public async Task<ActionResult<CategoryResponseDto>> CreateCategory(CreateCategoryDto dto)
    {
        var category = new Category { Name = dto.Name };
        var created = await repo.AddAsync(category);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, ToResponseDto(created));
    }

    [HttpPut]
    public async Task<ActionResult<CategoryResponseDto>> UpdateCategory(UpdateCategoryDto dto)
    {
        var category = await repo.GetByIdAsync(dto.Id);
        if (category is null)
        {
            return NotFound();
        }

        category.Name = dto.Name;
        var updated = await repo.UpdateAsync(category);
        if (!updated)
        {
            return NotFound();
        }

        return Ok(ToResponseDto(category));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var deleted = await repo.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }

    private static CategoryResponseDto ToResponseDto(Category category)
    {
        return new CategoryResponseDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}
