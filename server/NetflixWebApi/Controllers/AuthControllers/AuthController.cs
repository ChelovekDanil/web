using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix.Domain.Interface.Services;
using Netflix.Domain.Models;
using NetflixWebApi.Constract;

namespace NetflixWebApi.Controllers.AuthControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthTokensService _authTokensService;
        public AuthController(IUserService userService, IAuthTokensService authTokensService)
        {
            _userService = userService;
            _authTokensService = authTokensService; 
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request)
        {
            if (request.Username is null || request.Password is null)
            {
                return NotFound();
            }

            var user = await _userService.GetUserAsync(request.Username);

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

            return user.Password == request.Password ? Ok(new AuthResponse(user.Id, user.Username, tokens.AccessToken)) : NotFound();
        }

        [Route("Registation")]
        [HttpPost]
        public async Task<ActionResult<AuthResponse>> Registration([FromBody] AuthRequest request)
        {
            if (request.Username is null || request.Password is null)
            {
                return NotFound();
            }

            var user = await _userService.CreateUserAsync(request.Username, request.Password);

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

            return Ok(new AuthResponse(user.Id, user.Username, tokens.AccessToken));
        }
    }
}
