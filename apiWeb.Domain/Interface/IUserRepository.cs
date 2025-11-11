using apiWeb.Domain.Models;

namespace apiWeb.Domain.Interface;

public interface IUserRepository
{
    Task RegisterUser (User user);
    Task<IEnumerable<User>>  GetAllUsersAsync();
    Task<User> GetUserByIdAsync(int id);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int id);
    Task<User?> GetUserByUsernameAsync(string username);
}