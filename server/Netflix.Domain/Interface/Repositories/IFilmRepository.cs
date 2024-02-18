using NetflixWebApi;

namespace Netflix.Domain.Interface.Repositories
{
    public interface IFilmRepository
    {
        Task<List<MovieTodo>> GetAsync(int count);
    }
}
