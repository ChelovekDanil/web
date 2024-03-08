using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix.Domain.Interface.Services;
using Netflix.Domain.Models;
using NetflixWebApi.Constract;

namespace NetflixWebApi.Controllers.AuthControllers
{
    [Route("api/Auth")]
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

            return user.Password == request.Password ? Ok(new AuthResponse(user.Username, tokens.AccessToken)) : NotFound();
        }

        [Route("Registration")]
        [HttpPost]
        [ProducesResponseType<AuthResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Registration([FromBody] AuthRequest request)
        {
            if (request.Username is null || request.Password is null)
            {
                return BadRequest("Null request");
            }

            var user = await _userService.CreateUserAsync(request.Username, request.Password);

            if (user is null)
            {
                return StatusCode(500, "User exists");
            }

            var tokens = await _authTokensService.GetAuthTokensAsync(request.Username);

            Response.Cookies.Append("refresh_token", $"{tokens.RefreshToken}",
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None
                });

            return StatusCode(201, new AuthResponse(user.Username, tokens.AccessToken));
        }
    }
}