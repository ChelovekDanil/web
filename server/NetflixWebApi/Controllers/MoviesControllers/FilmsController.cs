using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Netflix.Domain.Interface;

namespace NetflixWebApi.Controllers.MoviesControllers
{
    [Authorize]
    [Route("api/films")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public FilmsController([FromKeyedServices("filmService")] IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieTodo>>> Films(int count)
        {
            var response = await _movieService.GetMovieAsync(count);

            return Ok(response);
        }
    }
}