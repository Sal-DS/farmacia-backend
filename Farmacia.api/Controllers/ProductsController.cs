using System.Xml.Schema;
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
    public async Task<IActionResult> GetProducts()
    {
        var products = await _repository.GetAllAsync();
        return Ok(products);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if(product == null)
        {
            return NoContent();
        }
        return Ok(product);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct(Product product)
    {
        var CreateProduct = await _repository.AddAsync(product);
        return Ok(CreateProduct);
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
    public async Task<IActionResult> UpdateProducts(Product product)
    {
        var updated = await _repository.UpdateAsync(product);
        if (!updated)
        {
            return NotFound();
        }
        await _repository.UpdateAsync(product);
        return Ok(product);
    }
}