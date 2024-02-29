using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetflixWebApi.Controllers.AuthControllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenValidatorController : ControllerBase
    {
        [HttpGet]
        public ActionResult TokenValidator()
        {
            return Ok();
        }
    }
}
