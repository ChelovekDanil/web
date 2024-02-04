using server.Services.Interfaces;
using WebApi.DBClasses;

namespace server.Services
{
    public class PopularService(WebContext context) : IMovieService
    {
        private readonly WebContext _context = context;

        public List<Movies> GetMovies(int count)
        {
            int countCards = 21;
            Random rand = new();

            List<Movies> movies = new(from movie in _context.Movies.Skip(countCards * count).Take(countCards) select movie);
            
            for (int i = 0; i < movies.Count; i++)
            {
                int j = rand.Next(i, movies.Count);
            
                (movies[i], movies[j]) = (movies[j], movies[i]);
            }
            
            return movies;
        }
    }
}
