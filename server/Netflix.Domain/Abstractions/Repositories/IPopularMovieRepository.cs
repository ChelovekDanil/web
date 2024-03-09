using NetflixWebApi;

namespace Netflix.Domain.Abstractions.Repositories
{
    public interface IPopularMovieRepository
    {
        Task<MovieTodo?> GetOneAsync(string Title);
    }
}
