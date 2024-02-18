using Microsoft.EntityFrameworkCore.Storage;
using Netflix.Domain.common;
using Netflix.Domain.Interface.Repositories;
using Netflix.Domain.Interface.Services;

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
