using Netflix.Domain.Models;

namespace Netflix.Domain.Interface.Repositories
{
    public interface ILoginRepository
    {
        Task<UsersTodo?> GetUserAsync(string Username);
    }
}
