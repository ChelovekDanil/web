using Microsoft.AspNetCore.Mvc;
using server.Services.Interfaces;
using WebApi.DBClasses;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IFilmsService _categoryService;

        public HomeController(IFilmsService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public List<Films> Category(int count)
        {
            return _categoryService.Category(count);
        }
    }
}