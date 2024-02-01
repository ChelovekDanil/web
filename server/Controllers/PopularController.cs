using Microsoft.AspNetCore.Mvc;
using server.Services.Interfaces;
using WebApi.DBClasses;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularController : Controller
    {
        private IPopularService _popularService;

        public PopularController(IPopularService popularService)
        {
            _popularService = popularService;
        }

        [HttpGet]
        public List<Popular> Category(int count)
        {
            return _popularService.Category(count);
        }
    }
}
