using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Netflix.Domain.common
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer";
        public const string AUDIENCE = "MyAuthClient";
        const string KEY = "bmjvi5ncm45gh98465mjyhb5m,c'aiw9x,h4jk56hv[smwv6}mx5mfiqyv[xum5jvm4";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new(Encoding.UTF8.GetBytes(KEY));
    }
}