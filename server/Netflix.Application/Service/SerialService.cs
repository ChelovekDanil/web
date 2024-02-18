using Netflix.Domain.Interface;
using Netflix.Domain.Interface.Repositories;
using NetflixWebApi;

namespace Netflix.Application.Service
{
    public class SerialService : IMovieService
    {
        private readonly ISerialsRepository _serialsRepository;

        public SerialService(ISerialsRepository serialsRepository)
        {
            _serialsRepository = serialsRepository;
        }

        public async Task<List<MovieTodo>> GetMovieAsync(int count)
        {
            var movies = await _serialsRepository.GetAsync(count);

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
