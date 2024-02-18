using Microsoft.EntityFrameworkCore;
using Netflix.Domain.Interface.Repositories;
using Netflix.Domain.Models;
using NetflixWebApi;

namespace Netflix.Infrastucture.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly WebContext _context;
        public LoginRepository(WebContext context)
        {
            _context = context;
        }

        public async Task<UsersTodo?> GetUserAsync(string Username)
        {
            var user = await _context.Users
                .Where(user => user.Username == Username)
                .FirstOrDefaultAsync();

            return user;
        }
    }
}