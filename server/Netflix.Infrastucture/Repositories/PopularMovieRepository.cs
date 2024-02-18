using Microsoft.EntityFrameworkCore;
using Netflix.Domain.Interface.Repositories;
using NetflixWebApi;

namespace Netflix.Infrastucture.PopularMovieService
{
    public class PopularMovieRepository : IPopularMovieRepository
    {
        private readonly WebContext _context;

        public PopularMovieRepository(WebContext context)
        {
            _context = context;
        }

        public async Task<List<MovieTodo>> GetAsync(int count)
        {
            // number of elements that will be pulled from the database
            const int countCard = 21;

            List<MovieTodo> movies = await _context.Movies
                .Skip(countCard * count)
                .Take(countCard)
                .ToListAsync();

            return movies;
        }
    }
}
