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
            if (!HttpContext.Request.Cookies.ContainsKey("refresh_token"))
            {
                return NotFound("not found cookie");
            }

            var cookieValue = HttpContext.Request.Cookies["refresh_token"];

            var user = await _userService.GetUserAsync(username);

            if (user is null)
            {
                return NotFound("not found user");
            }

            if (user.RefreshToken == cookieValue)
            {
                var tokens = await _authTokensService.GetAuthTokensAsync(username);

                return Ok(tokens);
            }
            else
            {
                return BadRequest("wrong refresh token");
            }
        }
    }
}