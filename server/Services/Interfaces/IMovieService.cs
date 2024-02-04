using WebApi.DBClasses;

namespace server.Services.Interfaces
{
    public interface IMovieService
    {
        List<Movies> GetMovies(int count);
    }
}