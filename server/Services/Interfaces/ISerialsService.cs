using WebApi.DBClasses;

namespace server.Services.Interfaces
{
    public interface ISerialsService
    {
        List<Serials> Category(int count);
    }
}
