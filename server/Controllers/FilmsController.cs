using Microsoft.AspNetCore.Mvc;
using server.Services.Interfaces;
using WebApi.DBClasses;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : Controller
    {
        private IFilmsService _filmsService;

        public FilmsController(IFilmsService filmsService)
        {
            _filmsService = filmsService;
        }

        [HttpGet]
        public List<Films> Catogory(int count)
        {
            return _filmsService.Category(count);
        }
    }
}