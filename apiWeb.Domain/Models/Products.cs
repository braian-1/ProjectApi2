namespace apiWeb.Domain.Models;

public class Products
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public double Price { get; set; }
}