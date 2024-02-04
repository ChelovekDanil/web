using Microsoft.AspNetCore.Mvc;
using server.Services.Interfaces;

namespace server.Controllers.JwtControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtTokenController([FromKeyedServices("jwtToken")] IJwtToken jwtToken) : ControllerBase
    {
        private readonly IJwtToken _jwtToken = jwtToken;

        [HttpGet("{username}")]
        public string GetJwtToken(string username)
        {
            return _jwtToken.GetJwtToken(username);
        }
    }
}