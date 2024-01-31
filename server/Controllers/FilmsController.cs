﻿using Microsoft.AspNetCore.Mvc;
using WebApi.DBClasses;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : Controller
    {
        [HttpGet]
        public List<Films> Index(int count)
        {
            using (WebContext db = new WebContext())
            {
                int countImage = 21;
                Random rand = new Random();

                List<Films> films = (from film in db.Films.Skip(countImage * count).Take(countImage) select film).ToList();
                
                for (int i = 0; i < films.Count; i++)
                {
                    int j = rand.Next(i, films.Count);

                    Films temp = films[i];
                    films[i] = films[j];
                    films[j] = temp;
                }

                return films;
            }
        }
    }
}