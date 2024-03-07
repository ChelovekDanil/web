using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix.Domain.Interface.Services;
using Netflix.Domain.Models;
using NetflixWebApi.Constract;

namespace NetflixWebApi.Controllers.AuthControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefreshTokenController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthTokensService _authTokensService;
        public RefreshTokenController(IUserService userService, IAuthTokensService authTokensService)
        {
            _userService = userService;
            _authTokensService = authTokensService;
        }

        [HttpGet]
        [ProducesResponseType<JwtTodo>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RefreshToken(string username)
        {
            await Console.Out.WriteLineAsync($"username: {username}");

            if (!HttpContext.Request.Cookies.ContainsKey("refresh_token"))
            {
                await Console.Out.WriteLineAsync("not cookie");
                return NotFound("not found cookie");
            }

            var cookies = Request.Cookies;

            foreach (var cookie in cookies)
            {
                await Console.Out.WriteLineAsync($"Имя куки: {cookie.Key}, Значение куки: {cookie.Value}");
            }

            var cookieValue = HttpContext.Request.Cookies["refresh_token"];

            var user = await _userService.GetUserAsync(username);

            if (user is null)
            {
                return NotFound("not found user");
            }

            await Console.Out.WriteLineAsync($"user cookie: {user.RefreshToken}");

            if (user.RefreshToken == cookieValue)
            {
                var tokens = await _authTokensService.GetAuthTokensAsync(username);

                Response.Cookies.Append("refresh_token", $"{tokens.RefreshToken}",
                    new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.None
                    });

                return Ok(tokens);
            }
            else
            {
                return BadRequest("wrong refresh token");
            }
        }
    }
}