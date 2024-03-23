using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Netflix.Domain.Abstractions.Services;
using Netflix.Domain.Interface;

namespace NetflixWebApi.Controllers.MoviesControllers
{
    [Authorize]
    [Route("api/popularMovies")]
    [ApiController]
    public class PopularMoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IPopularMovieService _popularMovieService;

        public PopularMoviesController([FromKeyedServices("popularMovieService")] IMovieService movieService, IPopularMovieService popularMovieService)
        {
            _movieService = movieService;
            _popularMovieService = popularMovieService;
        }

        // for many movie
        [HttpGet]
        public async Task<ActionResult<List<MovieTodo>>> PopularMovie(int count)
        {
            var response = await _movieService.GetMovieAsync(count);

            return Ok(response);
        }

        // for one movie
        [HttpGet("{Title}")]
        public async Task<ActionResult<MovieTodo>> OneMovie([FromRoute] string Title)
        {
            var response = await _popularMovieService.GetOneAsync(Title);

            return Ok(response);
        }
    }
}