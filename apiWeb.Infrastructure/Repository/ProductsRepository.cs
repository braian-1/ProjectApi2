using apiWeb.Domain.Interface;
using apiWeb.Domain.Models;
using apiWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace apiWeb.Infrastructure.Repository;

public class ProductsRepository : IProductsRepository
{
    private readonly AppDbContext _context;

    public ProductsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Products>> GetAllProductsAsync()
    {
        return await _context.Product.ToListAsync();
    }

    public async Task<Products> GetProductByIdAsync(int id)
    {
        return await _context.Product.FindAsync(id);
    }

    public async Task AddProductAsync(Products product)
    {
        _context.Product.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(Products product)
    {
        _context.Product.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _context.Product.FindAsync(id);
        _context.Product.Remove(product);
        await _context.SaveChangesAsync();
    }
}