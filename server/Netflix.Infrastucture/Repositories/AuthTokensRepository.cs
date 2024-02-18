using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Netflix.Domain.common;
using Netflix.Domain.Interface.Repositories;
using NetflixWebApi;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Netflix.Infrastucture.Repositories
{
    public class AuthTokensRepository : IAuthTokensRepository
    {
        private readonly WebContext _context;
        public AuthTokensRepository(WebContext context)
        {
            _context = context;
        }

        public async Task<JwtTodo> GetAuthTokensAsync(string Username)
        {
            var claims = new List<Claim> { new(ClaimTypes.Name, Username) };

            var accessToken = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(1)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            Guid refreshToken = Guid.NewGuid();

            var user = await _context.Users
                .Where(user => user.Username == Username)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(user => user.RefreshToken, user => refreshToken.ToString()));

            return new(new JwtSecurityTokenHandler().WriteToken(accessToken), refreshToken);
        }
    }
}