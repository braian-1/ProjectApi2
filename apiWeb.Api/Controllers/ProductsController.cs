using apiWeb.Application.Services;
using apiWeb.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiWeb.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductsService _service;

    public ProductsController(ProductsService service)
    {
        _service = service;
    }

    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var product = await _service.GetAllProducts();
        return Ok(product);
    }

    
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _service.GetProductById(id);
        return Ok(product);
    }

    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddProductAsync(Products product)
    {
        await _service.AddProductAsync(product);
        return Ok(product);
    }

    
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateProductAsync(int id, Products product)
    {
        product.Id = id;
        await _service.UpdateProduct(product);
        return Ok(product);
    }

    
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteProductAsync(int id)
    {
        await _service.DeleteProduct(id);
        return Ok();
    }
}