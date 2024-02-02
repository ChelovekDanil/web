using Microsoft.AspNetCore.Mvc;
using server.Services;
using server.Services.Interfaces;
using WebApi.DBClasses;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController([FromKeyedServices("films")] IMovieService filmsService) : Controller
    {
        private readonly IMovieService _filmsService = filmsService;

        [HttpGet]
        public List<Movies> GetMovies(int count)
        {
            return _filmsService.GetMovies(count);
        }
    }
}