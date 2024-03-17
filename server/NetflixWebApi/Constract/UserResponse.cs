namespace NetflixWebApi.Constract
{
    public class UserResponse
    {
        public UserResponse(string id, string username)
        {
            Id = id;
            Username = username;
        }

        public string Id { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}
