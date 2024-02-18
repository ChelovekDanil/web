using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix.Domain.Interface.Services;
using Netflix.Domain.Models;
using NetflixWebApi.Constract;

namespace NetflixWebApi.Controllers.AuthControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IAuthTokensService _authTokensService;
        public LoginController(ILoginService loginService, IAuthTokensService authTokensService)
        {
            _loginService = loginService;
            _authTokensService = authTokensService; 
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            if (request.Username is null || request.Password is null)
            {
                return NotFound();
            }

            var user = await _loginService.GetUserAsync(request.Username);

            if (user is null)
            {
                return NotFound();
            }

            var tokens = await _authTokensService.GetAuthTokensAsync(request.Username);

            Response.Cookies.Append("refresh_token", $"{tokens.RefreshToken}",
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None
                });

            return user.Password == request.Password ? Ok(new LoginResponse(user.Id, user.Username, tokens.AccessToken)) : NotFound();
        }
    }
}
