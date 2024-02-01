using WebApi.DBClasses;

namespace server.Services.Interfaces
{
    public interface IFilmsService
    {
        List<Films> Category(int count);
    }
}
