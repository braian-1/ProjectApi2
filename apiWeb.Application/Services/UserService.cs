using apiWeb.Domain.Interface;
using apiWeb.Domain.Models;

namespace apiWeb.Application.Services;

public class UserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _repository.GetAllUsersAsync();
    }
    
    public async Task<User> GetUserById(int id)
    {
        return await _repository.GetUserByIdAsync(id);
    }

    public async Task AddUser(User user)
    {
        await _repository.RegisterUser(user);
    }

    public async Task UpdateUser(User user)
    {
        await _repository.UpdateUserAsync(user);
    }
    
    public async Task DeleteUser(int id)
    {
        await _repository.DeleteUserAsync(id);
    }
    public async Task<bool> VerifyLoginAsync(string username, string password)
    {
        var user = await _repository.GetUserByUsernameAsync(username);
        if (user == null) return false;
        return user.PasswordHash == password;
    }

}