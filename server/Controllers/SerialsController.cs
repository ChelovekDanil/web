using Microsoft.AspNetCore.Mvc;
using server.Services.Interfaces;
using WebApi.DBClasses;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SerialsController([FromKeyedServices("serials")]IMovieService serialsService) : Controller
    {
        private readonly IMovieService _serialsService = serialsService;

        [HttpGet]
        public List<Movies> GetMovies(int count) 
        {
            return _serialsService.GetMovies(count);
        }
    }
}
