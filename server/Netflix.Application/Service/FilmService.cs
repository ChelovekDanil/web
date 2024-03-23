using Microsoft.Extensions.DependencyInjection;
using Netflix.Domain.Abstractions.Repositories;
using Netflix.Domain.Interface;
using NetflixWebApi;

namespace Netflix.Application.Service
{
    public class FilmService : IMovieService
    {
        private readonly BaseMoviesRepository _filmRepository;

       public FilmService ([FromKeyedServices("filmRepository")] BaseMoviesRepository filmRepository)
       {
            _filmRepository = filmRepository;
       }

        public async Task<List<MovieTodo>> GetMovieAsync(int count)
        {
            return await _filmRepository.GetAsync(count);
        }
    }
}
