using Netflix.Domain.Models;

namespace Netflix.Domain.Interface.Services
{
    public interface IUserService
    {
        Task<UsersTodo?> CreateUserAsync(string Username, string Password);
        Task<UsersTodo?> GetUserAsync(string Username);
        Task<string?> UpdateUserAsync(string Username, string NewUsername);
        Task<int> DeleteUserAsync(string Username);
    }
}