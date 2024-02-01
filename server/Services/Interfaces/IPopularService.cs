using WebApi.DBClasses;

namespace server.Services.Interfaces
{
    public interface IPopularService
    {
        List<Popular> Category(int count);
    }
}
