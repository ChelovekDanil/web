using server.Services.Interfaces;
using WebApi.DBClasses;

namespace server.Services
{
    public class FilmsService : IFilmsService
    {
        public List<Films> Category(int count)
        {          
            using (WebContext db = new())
            {
                int countCards = 21;
                Random rand = new();

                List<Films> films = (from film in db.Films.Skip(countCards * count).Take(countCards) select film).ToList();

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
