using Microsoft.EntityFrameworkCore;
using Netflix.Domain.Interface.Repositories;
using NetflixWebApi;
namespace Netflix.Infrastucture.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly WebContext _context;

        public FilmRepository(WebContext context)
        {
            _context = context;
        }

        public async Task<List<MovieTodo>> GetAsync(int count)
        {
            // number of elements that will be pulled from the database
            const int countCard = 21; 

            List<MovieTodo> movies = await _context.Movies
                .Where(movie => movie.Category == "film")
                .Skip(countCard * count)
                .Take(countCard)
                .ToListAsync();

            return movies;
        }
    }
}
