using Microsoft.AspNetCore.Mvc;
using WebApi.DBClasses;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularController : Controller
    {
        [HttpGet]
        public IResult Index(int count)
        {
            using (WebContext db = new WebContext())
            {
                int countImage = 21;
                Random rand = new Random();

                List<Popular> populars = (from popular in db.Populars.Skip(countImage * count).Take(countImage) select popular).ToList();

                for (int i = 0; i < populars.Count; i++)
                {
                    int j = rand.Next(i, populars.Count);

                    Popular temp = populars[i];
                    populars[i] = populars[j];
                    populars[j] = temp;
                }

                return Results.Json(populars);
            }
        }
    }
}
