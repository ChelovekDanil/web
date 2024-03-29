﻿using Microsoft.EntityFrameworkCore;
using Netflix.Domain.Interface.Repositories;
using Netflix.Domain.Models;
using NetflixWebApi;

namespace Netflix.Infrastucture.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WebContext _context;

        public UserRepository(WebContext context)
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

        public async Task<UsersTodo?> CreateUserAsync(string Username, string Password)
        {
            if (await GetUserAsync(Username) != null)
            {
                return null;
            }

            var newUser = new UsersTodo {
                Id = Guid.NewGuid().ToString(),
                Username = Username,
                Password = Password,
                RefreshToken = Guid.NewGuid().ToString()
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task<string?> UpdateUserAsync(string Username, string NewUsername)
        {
            if (await GetUserAsync(Username) is null)
            {
                return null;
            }

            var user = await _context.Users
                .Where(user => user.Username == Username)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(user => user.Username, user => NewUsername));

            return user.ToString();
        }

        public async Task<int> DeleteUserAsync(string Username)
        {
            if (await GetUserAsync(Username) is null)
            {
                return 0;
            }

            var result = await _context.Users
                .Where(user => user.Username == Username)
                .ExecuteDeleteAsync();

            return result;
        }
    }
}
