using server.Services.Interfaces;
using WebApi.DBClasses;

namespace server.Services
{
    public class CategoryService : ICategoryService
    {
        public List<Films> Category(int count)
        {          
            using (WebContext db = new())
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
