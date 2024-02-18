using Netflix.Domain.common;

namespace Netflix.Domain.Interface.Services
{
    public interface IJwtService
    {
        JwtTodo GetJwtToken(string username);
    }
}
