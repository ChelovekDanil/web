using Netflix.Domain.Models;

namespace Netflix.Domain.Interface.Repositories
{
    public interface IUserRepository
    {
        Task<UsersTodo?> CreateUserAsync(string Username, string Password);
        Task<UsersTodo?> GetUserAsync(string Username);
        Task<string?> UpdateUserAsync(string Username, string NewUsername);
        Task<int> DeleteUserAsync(string Username);
    }
}