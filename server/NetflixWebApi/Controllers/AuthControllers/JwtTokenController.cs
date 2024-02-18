using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix.Domain.common;
using Netflix.Domain.Interface.Services;
using System.Web;

namespace NetflixWebApi.Controllers.AuthControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtTokenController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public JwtTokenController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpGet("{username}")]
        public ActionResult<string> JwtToken(string username)
        {
            var jwt = _jwtService.GetJwtToken(username);

            Response.Cookies.Append("refresh_token", $"{jwt.RefreshToken}",
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None
                });


            return Ok(jwt.AccessToken);
        }
    }
}