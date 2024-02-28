using NetflixWebApi;

namespace Netflix.Domain.Abstractions.Repositories
{
    public abstract class BaseMoviesRepository
    {
        // number of "cards" that will be pulled from the database
        protected const int countCard = 21;

        public abstract Task<List<MovieTodo>> GetAsync(int count);
    }
}
