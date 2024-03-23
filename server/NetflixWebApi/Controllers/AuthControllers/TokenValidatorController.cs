﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetflixWebApi.Controllers.AuthControllers
{
    [Authorize]
    [Route("api/TokenValidator")]
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