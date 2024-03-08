using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Netflix.Domain.Interface;

namespace NetflixWebApi.Controllers.MoviesControllers
{
    [Authorize]
    [Route("api/serials")]
    [ApiController]
    public class SerialsController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public SerialsController([FromKeyedServices("serialService")] IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieTodo>>> Serials(int count)
        {
            var response = await _movieService.GetMovieAsync(count);

            return Ok(response);
        }
    }
}   