namespace NetflixWebApi.Constract
{
    public class AuthResponse
    {
        public AuthResponse(string username, string accessToken)
        {
            Username = username;
            AccessToken = accessToken;
        }
        public string Username { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
    }
}
