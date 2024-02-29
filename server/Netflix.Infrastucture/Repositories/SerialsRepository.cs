using Microsoft.EntityFrameworkCore;
using Netflix.Domain.Abstractions.Repositories;
using Netflix.Domain.Interface.Repositories;
using NetflixWebApi;

namespace Netflix.Infrastucture.Repositories
{
    public class SerialsRepository : BaseMoviesRepository
    {
        private readonly WebContext _context;

        public SerialsRepository(WebContext context)
        {
            _context = context;
        }

        public override async Task<List<MovieTodo>> GetAsync(int count)
        {
            List<MovieTodo> movies = await _context.Movies
                .Where(movie => movie.Category == "serial")
                .Skip(countCard * count)
                .Take(countCard)
                .ToListAsync();

            return movies;
        }
    }
}