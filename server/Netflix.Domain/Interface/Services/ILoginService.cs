using Netflix.Domain.common;
using Netflix.Domain.Models;

namespace Netflix.Domain.Interface.Services
{
    public interface ILoginService
    {
        Task<UsersTodo> GetUserAsync(string Username);
    }
}
