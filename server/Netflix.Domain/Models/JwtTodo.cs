namespace Netflix.Domain.Models
{
    public class JwtTodo
    {
        public JwtTodo(string accessToken, Guid refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public string AccessToken { get; set; } = string.Empty;
        public Guid RefreshToken { get; set; }
    }
}
