using Xunit;
using Moq;
using System.Threading.Tasks;
using apiWeb.Application.Services;
using apiWeb.Domain.Interface;
using apiWeb.Domain.Models;

namespace apiWeb.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task VerifyLoginAsync_UserNotFound()
        {
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(r => r.GetUserByUsernameAsync("john"))
                .ReturnsAsync((User?)null);

            var service = new UserService(mockRepo.Object);

            var result = await service.VerifyLoginAsync("john", "1234");

            Assert.False(result);
        }

        [Fact]
        public async Task VerifyLoginAsync()
        {
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(r => r.GetUserByUsernameAsync("john"))
                .ReturnsAsync(new User { Username = "john", PasswordHash = "1234" });

            var service = new UserService(mockRepo.Object);

            var result = await service.VerifyLoginAsync("john", "wrong");

            Assert.False(result);
        }

        [Fact]
        public async Task VerifyLoginAsync_CorrectCredentials_ReturnsTrue()
        {
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(r => r.GetUserByUsernameAsync("john"))
                .ReturnsAsync(new User { Username = "john", PasswordHash = "1234" });

            var service = new UserService(mockRepo.Object);

            var result = await service.VerifyLoginAsync("john", "1234");

            Assert.True(result);
        }
    }
}