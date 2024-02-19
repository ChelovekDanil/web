using Netflix.Domain.Models;

namespace Netflix.Domain.Interface.Services
{
    public interface IUserService
    {
        Task<UsersTodo?> GetUserAsync(string Username);
        Task<UsersTodo?> CreateUserAsync(string Username, string Password);
    }
}
