using Microsoft.AspNetCore.Mvc;
using Netflix.Domain.Interface;

namespace NetflixWebApi.Controllers.MoviesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularMoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public PopularMoviesController([FromKeyedServices("popularmovie")] IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieTodo>>> PopularMovie(int count)
        {
            var response = await _movieService.GetMovieAsync(count);

            return Ok(response);
        }
    }
}
