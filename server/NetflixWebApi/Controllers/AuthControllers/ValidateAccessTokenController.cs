using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetflixWebApi.Controllers.AuthControllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateAccessTokenController : ControllerBase
    {
        [HttpGet]
        public ActionResult IsValidToken() => Ok();
    }
}
