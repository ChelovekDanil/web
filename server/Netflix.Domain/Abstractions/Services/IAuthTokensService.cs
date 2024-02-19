using Netflix.Domain.common;

namespace Netflix.Domain.Interface.Services
{
    public interface IAuthTokensService
    {
        Task<JwtTodo> GetAuthTokensAsync(string Username);
    }
}
