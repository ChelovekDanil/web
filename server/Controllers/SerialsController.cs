using Microsoft.AspNetCore.Mvc;
using WebApi.DBClasses;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SerialsController : Controller
    {
        [HttpGet]
        public IResult Index(int count)
        {
            using (WebContext db = new WebContext())
            {
                int countImage = 21;
                Random rand = new Random();

                List<Serials> serials = (from serial in db.Serials.Skip(countImage * count).Take(countImage) select serial).ToList();

                for (int i = 0; i < serials.Count; i++)
                {
                    int j = rand.Next(i, serials.Count);

                    Serials temp = serials[i];
                    serials[i] = serials[j];
                    serials[j] = temp;
                }

                return Results.Json(serials);
            }
        }
    }
}
