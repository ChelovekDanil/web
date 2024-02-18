using NetflixWebApi;

namespace Netflix.Domain.Interface.Repositories
{
    public interface ISerialsRepository
    {
        Task<List<MovieTodo>> GetAsync(int count);
    }
}
