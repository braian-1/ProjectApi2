using apiWeb.Domain.Interface;
using apiWeb.Domain.Models;

namespace apiWeb.Application.Services;

public class ProductsService
{
    private readonly IProductsRepository _repository;

    public ProductsService(IProductsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Products>> GetAllProducts()
    {
        return await _repository.GetAllProductsAsync();
    }
    
    public async Task<Products> GetProductById(int id)
    {
        return await _repository.GetProductByIdAsync(id);
    }

    public async Task AddProductAsync(Products product)
    {
        await _repository.AddProductAsync(product);
    }

    public async Task UpdateProduct(Products product)
    {
        await _repository.UpdateProductAsync(product);
    }
    
    public async Task DeleteProduct(int id)
    {
        await _repository.DeleteProductAsync(id);
    }
}