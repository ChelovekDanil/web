using Netflix.Domain.Interface.Repositories;
using Netflix.Domain.Interface.Services;
using Netflix.Domain.Models;

namespace Netflix.Application.Service
{
    public class AuthTokensService : IAuthTokensService
    {
        private readonly IAuthTokensRepository _authTokensRepository;
        public AuthTokensService(IAuthTokensRepository authTokensRepository)
        {
            _authTokensRepository = authTokensRepository;
        }

        public async Task<JwtTodo> GetAuthTokensAsync(string Username)
        {
            return await _authTokensRepository.GetAuthTokensAsync(Username);
        }
    }
}
