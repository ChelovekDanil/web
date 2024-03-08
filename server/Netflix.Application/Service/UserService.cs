using Netflix.Domain.Interface.Repositories;
using Netflix.Domain.Interface.Services;
using Netflix.Domain.Models;

namespace Netflix.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UsersTodo?> CreateUserAsync(string Username, string Password)
        {
            return await _userRepository.CreateUserAsync(Username, Password);
        }

        public async Task<UsersTodo?> GetUserAsync(string Username)
        {
            return await _userRepository.GetUserAsync(Username);
        }

        public async Task<string?> UpdateUserAsync(string Username, string NewUsername)
        {
            return await _userRepository.UpdateUserAsync(Username, NewUsername);
        }

        public async Task<int> DeleteUserAsync(string Username)
        {
            return await _userRepository.DeleteUserAsync(Username);
        }
    }
}