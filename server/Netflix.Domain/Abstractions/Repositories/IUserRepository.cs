using Netflix.Domain.Models;

namespace Netflix.Domain.Interface.Repositories
{
    public interface IUserRepository
    {
        Task<UsersTodo?> GetUserAsync(string Username);
        Task<UsersTodo?> CreateUserAsync(string Username, string Password);
    }
}
