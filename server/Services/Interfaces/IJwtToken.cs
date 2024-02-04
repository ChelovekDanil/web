namespace server.Services.Interfaces
{
    public interface IJwtToken
    {
        string GetJwtToken(string username);
    }
}
