using apiWeb.Domain.Models;

namespace apiWeb.Domain.Interface;

public interface IProductsRepository
{
    Task<IEnumerable<Products>> GetAllProductsAsync();
    Task<Products> GetProductByIdAsync(int id);
    Task AddProductAsync(Products product);
    Task UpdateProductAsync(Products product);
    Task DeleteProductAsync(int id);
}