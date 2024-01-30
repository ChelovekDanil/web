using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebApi.DBClasses;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IResult Index(int count)
        {
            using (WebContext db = new WebContext())
            {
                int countImage = 6;
                Random rand = new Random();

                List<Image> images = (from image in db.Images.Skip(countImage * count).Take(countImage) select image).ToList();

                for (int i = 0; i < images.Count; i++)
                {
                    int j = rand.Next(i, images.Count);

                    Image temp = images[i];
                    images[i] = images[j];
                    images[j] = temp;
                }

                return Results.Json(images);
            }
        }
    }
    public record Card(string Title, string Discription, string Url);
}