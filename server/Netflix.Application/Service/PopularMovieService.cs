using Microsoft.Extensions.DependencyInjection;
using Netflix.Domain.Abstractions.Repositories;
using Netflix.Domain.Abstractions.Services;
using Netflix.Domain.Interface;
using NetflixWebApi;

namespace Netflix.Application.Service
{
    public class PopularMovieService : IMovieService, IPopularMovieService
    {
        private readonly BaseMoviesRepository _popularMovieRepository;
        private readonly IPopularMovieRepository _onePopularMovieRepository;

        public PopularMovieService([FromKeyedServices("popularMovieRepository")]BaseMoviesRepository popularMovieRepository, IPopularMovieRepository onePopularMovieRepository) 
        {
            _popularMovieRepository = popularMovieRepository;
            _onePopularMovieRepository = onePopularMovieRepository;
        }

        public async Task<List<MovieTodo>> GetMovieAsync(int count)
        {
            return await _popularMovieRepository.GetAsync(count);
        }

        public async Task<MovieTodo?> GetOneAsync(string Title)
        {
            return await _onePopularMovieRepository.GetOneAsync(Title);
        }
    }
}
