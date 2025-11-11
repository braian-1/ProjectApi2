using Xunit;
using Moq;
using System.Threading.Tasks;
using apiWeb.Application.Services;
using apiWeb.Domain.Interface;
using apiWeb.Domain.Models;

namespace apiWeb.Tests.Services
{
    public class ProductsServiceTests
    {
        [Fact]
        public async Task AddProductAsync()
        {
            // Arrange
            var mockRepo = new Mock<IProductsRepository>();
            var service = new ProductsService(mockRepo.Object);

            var newProduct = new Products
            {
                Id = 1,
                Name = "Celular",
                Price = 1500
            };

            // Act
            await service.AddProductAsync(newProduct);

            // Assert
            mockRepo.Verify(r => r.AddProductAsync(It.IsAny<Products>()), Times.Once);
        }
    }
}