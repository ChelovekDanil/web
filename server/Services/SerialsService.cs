using server.Services.Interfaces;
using WebApi.DBClasses;

namespace server.Services
{
    public class SerialsService : IMovieService
    {
        public List<Movies> GetMovies(int count)
        {
            int countCards = 21;
            Random rand = new();

            using WebContext db = new();

            List<Movies> movies = new(from movie in db.Movies.Skip(countCards * count).Take(countCards) where movie.Category == "serial" select movie);
            
            for (int i = 0; i < movies.Count; i++)
            {
                int j = rand.Next(i, movies.Count);

                (movies[i], movies[j]) = (movies[j], movies[i]);
            }
            
            return movies;
        }
    }
}