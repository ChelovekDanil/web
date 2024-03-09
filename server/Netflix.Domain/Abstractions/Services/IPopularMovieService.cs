using NetflixWebApi;

namespace Netflix.Domain.Abstractions.Services
{
    public interface IPopularMovieService
    {
        Task<MovieTodo?> GetOneAsync(string Title);
    }
}
