using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Services.Interfaces;
using WebApi.DBClasses;

namespace server.Controllers.MovieControlers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PopularController([FromKeyedServices("popular")] IMovieService popularService) : ControllerBase
    {
        private readonly IMovieService _popularService = popularService;

        [HttpGet]
        public List<Movies> GetMovies(int count)
        {
            return _popularService.GetMovies(count);
        }
    }
}