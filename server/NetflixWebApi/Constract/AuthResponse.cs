namespace NetflixWebApi.Constract
{
    public class AuthResponse
    {
        public AuthResponse(string id, string username, string accessToken)
        {
            Id = id;
            Username = username;
            AccessToken = accessToken;
        }

        public string Id { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
    }
}
