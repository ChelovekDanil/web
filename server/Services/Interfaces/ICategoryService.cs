using WebApi.DBClasses;

namespace server.Services.Interfaces
{
    public interface ICategoryService
    {
        List<Films> Category(int count);
    }
}
