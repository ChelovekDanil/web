using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Netflix.Domain.Interface;

namespace NetflixWebApi.Controllers.MoviesControllers
{
    [Authorize]
    [Route("api/popularMovies")]
    [ApiController]
    public class PopularMoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public PopularMoviesController([FromKeyedServices("popularMovieService")] IMovieService movieService)
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
