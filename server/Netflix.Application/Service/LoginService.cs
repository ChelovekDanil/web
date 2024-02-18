using Microsoft.EntityFrameworkCore.Storage.Internal;
using Netflix.Domain.common;
using Netflix.Domain.Interface.Repositories;
using Netflix.Domain.Interface.Services;
using Netflix.Domain.Models;

namespace Netflix.Application.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<UsersTodo> GetUserAsync(string Username)
        {
            return await _loginRepository.GetUserAsync(Username);
        }
    }
}
