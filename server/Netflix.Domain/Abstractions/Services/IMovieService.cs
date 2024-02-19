using NetflixWebApi;

namespace Netflix.Domain.Interface
{
    public interface IMovieService
    {
        Task<List<MovieTodo>> GetMovieAsync(int count);
    }
}
