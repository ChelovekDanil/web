using Microsoft.AspNetCore.Mvc;
using server.Services.Interfaces;
using WebApi.DBClasses;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SerialsController : Controller
    {
        private ISerialsService _serialsService;

        public SerialsController (ISerialsService serialsService)
        {
            _serialsService = serialsService;
        }

        [HttpGet]
        public List<Serials> Category(int count) 
        {
            return _serialsService.Category(count);
        }
    }
}
