using NetflixWebApi;

namespace Netflix.Domain.Interface.Repositories
{
    public interface IPopularMovieRepository
    {
        Task<List<MovieTodo>> GetAsync(int count);
    }
}
