using Microsoft.Extensions.DependencyInjection;
using Netflix.Domain.Abstractions.Repositories;
using Netflix.Domain.Interface;
using Netflix.Domain.Interface.Repositories;
using NetflixWebApi;

namespace Netflix.Application.Service
{
    public class PopularMovieService : IMovieService
    {
        private readonly BaseMoviesRepository _popularMovieRepository;

        public PopularMovieService([FromKeyedServices("popularMovieRepository")]BaseMoviesRepository popularMovieRepository) 
        {
            _popularMovieRepository = popularMovieRepository;
        }

        public async Task<List<MovieTodo>> GetMovieAsync(int count)
        {
            var movies = await _popularMovieRepository.GetAsync(count);

            Random rand = new();

            for (int i = 0; i < movies.Count; i++)
            {
                int j = rand.Next(i, movies.Count);

                (movies[i], movies[j]) = (movies[j], movies[i]);
            }

            return movies;
        }
    }
}
