using apiWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace apiWeb.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Products>  Product { get; set; }
    public DbSet<User> Users { get; set; }
}