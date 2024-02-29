using Netflix.Domain.Models;

namespace Netflix.Domain.Interface.Repositories
{
    public interface IAuthTokensRepository
    {
        Task<JwtTodo> GetAuthTokensAsync(string Username);
    }
}
