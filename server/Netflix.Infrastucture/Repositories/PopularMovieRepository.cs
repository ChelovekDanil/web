using Microsoft.EntityFrameworkCore;
using Netflix.Domain.Abstractions.Repositories;
using Netflix.Domain.Interface.Repositories;
using NetflixWebApi;

namespace Netflix.Infrastucture.PopularMovieService
{
    public class PopularMovieRepository : BaseMoviesRepository
    {
        private readonly WebContext _context;

        public PopularMovieRepository(WebContext context)
        {
            _context = context;
        }

        public override async Task<List<MovieTodo>> GetAsync(int count)
        {
            List<MovieTodo> movies = await _context.Movies
                .Skip(countCard * count)
                .Take(countCard)
                .ToListAsync();

            return movies;
        }
    }
}
