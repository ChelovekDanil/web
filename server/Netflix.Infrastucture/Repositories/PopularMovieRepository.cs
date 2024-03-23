using Microsoft.EntityFrameworkCore;
using Netflix.Domain.Abstractions.Repositories;
using NetflixWebApi;

namespace Netflix.Infrastucture.PopularMovieService
{
    public class PopularMovieRepository : BaseMoviesRepository, IPopularMovieRepository
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

            Random rand = new();

            for (int i = 0; i < movies.Count; i++)
            {
                int j = rand.Next(i, movies.Count);

                (movies[i], movies[j]) = (movies[j], movies[i]);
            }

            return movies;
        }

        public async Task<MovieTodo?> GetOneAsync(string Title)
        {
            var movie = await _context.Movies
                .FirstOrDefaultAsync(movie => movie.Title == Title);

            return movie;
        }
    }
}
