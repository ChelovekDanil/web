using Microsoft.IdentityModel.Tokens;
using Netflix.Domain.common;
using Netflix.Domain.Interface.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Netflix.Application.Service
{
    public class JwtTokenService : IJwtService
    {
        public JwtTodo GetJwtToken(string username)
        {
            var claims = new List<Claim> { new(ClaimTypes.Name, username) };

            var accessToken = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(1)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            Guid refreshToken = Guid.NewGuid();

            return new(new JwtSecurityTokenHandler().WriteToken(accessToken), refreshToken);
        }
    }
}