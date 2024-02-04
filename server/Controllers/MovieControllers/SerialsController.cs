using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Services.Interfaces;
using WebApi.DBClasses;

namespace server.Controllers.MovieControlers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SerialsController([FromKeyedServices("serials")] IMovieService serialsService) : ControllerBase
    {
        private readonly IMovieService _serialsService = serialsService;

        [HttpGet]
        public List<Movies> GetMovies(int count)
        {
            return _serialsService.GetMovies(count);
        }
    }
}
