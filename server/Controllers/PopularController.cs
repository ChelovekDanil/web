using Microsoft.AspNetCore.Mvc;
using server.Services.Interfaces;
using WebApi.DBClasses;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularController([FromKeyedServices("popular")]IMovieService popularService) : Controller
    {
        private readonly IMovieService _popularService = popularService;

        [HttpGet]
        public List<Movies> GetMovies(int count)
        {
            return _popularService.GetMovies(count);
        }
    }
}