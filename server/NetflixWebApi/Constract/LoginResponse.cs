namespace NetflixWebApi.Constract
{
    public class LoginResponse
    {
        public LoginResponse(int id, string username, string accessToken)
        {
            Id = id;
            Username = username;
            AccessToken = accessToken;
        }

        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
    }
}
