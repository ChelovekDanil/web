using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Services;
using server.Services.Interfaces;
using WebApi.DBClasses;

namespace server.Controllers.MovieControlers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController([FromKeyedServices("films")] IMovieService filmsService) : ControllerBase
    {
        private readonly IMovieService _filmsService = filmsService;

        [HttpGet]
        public List<Movies> GetMovies(int count)
        {
            return _filmsService.GetMovies(count);
        }
    }
}