using Microsoft.EntityFrameworkCore;
using Netflix.Domain.Abstractions.Repositories;
using Netflix.Domain.Interface.Repositories;
using NetflixWebApi;
namespace Netflix.Infrastucture.Repositories
{
    public class FilmRepository : BaseMoviesRepository
    {
        private readonly WebContext _context;

        public FilmRepository(WebContext context)
        {
            _context = context;
        }

        public override async Task<List<MovieTodo>> GetAsync(int count)
        {
            List<MovieTodo> movies = await _context.Movies
                .Where(movie => movie.Category == "film")
                .Skip(countCard * count)
                .Take(countCard)
                .ToListAsync();

            return movies;
        }
    }
}
