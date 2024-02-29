using Netflix.Domain.Models;

namespace Netflix.Domain.Interface.Services
{
    public interface IAuthTokensService
    {
        Task<JwtTodo> GetAuthTokensAsync(string Username);
    }
}
