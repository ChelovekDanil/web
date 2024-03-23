using Microsoft.Extensions.DependencyInjection;
using Netflix.Domain.Abstractions.Repositories;
using Netflix.Domain.Interface;
using NetflixWebApi;

namespace Netflix.Application.Service
{
    public class SerialService : IMovieService
    {
        private readonly BaseMoviesRepository _serialsRepository;

        public SerialService([FromKeyedServices("serialsRepository")] BaseMoviesRepository serialsRepository)
        {
            _serialsRepository = serialsRepository;
        }

        public async Task<List<MovieTodo>> GetMovieAsync(int count)
        {
            return await _serialsRepository.GetAsync(count);
        }
    }
}
