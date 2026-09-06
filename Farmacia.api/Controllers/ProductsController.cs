using Farmacia.api.DTOs;
using Farmacia.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Farmacia.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductsController(IProductRepository productRepository)
    {
        _repository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetProducts()
    {
        var products = await _repository.GetAllAsync();
        return Ok(products.Select(ToResponseDto));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponseDto>> GetById(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product is null)
        {
            return NotFound();
        }

        return Ok(ToResponseDto(product));
    }

    [HttpPost]
    public async Task<ActionResult<ProductResponseDto>> CreateProduct(CreateProductDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Manufacturer = dto.Manufacturer,
            CategoryId = dto.CategoryId
        };

        var created = await _repository.AddAsync(product);
        var savedProduct = await _repository.GetByIdAsync(created.Id) ?? created;
        return CreatedAtAction(nameof(GetById), new { id = savedProduct.Id }, ToResponseDto(savedProduct));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducts(int id)
    {
        var deleted = await _repository.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult<ProductResponseDto>> UpdateProducts(UpdateProductDto dto)
    {
        var product = await _repository.GetByIdAsync(dto.Id);
        if (product is null)
        {
            return NotFound();
        }

        product.Name = dto.Name;
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.Manufacturer = dto.Manufacturer;
        product.CategoryId = dto.CategoryId;

        var updated = await _repository.UpdateAsync(product);
        if (!updated)
        {
            return NotFound();
        }

        var savedProduct = await _repository.GetByIdAsync(product.Id) ?? product;
        return Ok(ToResponseDto(savedProduct));
    }

    private static ProductResponseDto ToResponseDto(Product product)
    {
        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Manufacturer = product.Manufacturer,
            CategoryId = product.CategoryId,
            Category = product.Category is null ? null : new CategoryResponseDto
            {
                Id = product.Category.Id,
                Name = product.Category.Name
            }
        };
    }
}
