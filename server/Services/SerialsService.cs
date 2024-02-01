using server.Services.Interfaces;
using WebApi.DBClasses;

namespace server.Services
{
    public class SerialsService : ISerialsService
    {
        public List<Serials> Category(int count)
        {
            using (WebContext db = new())
            {
                int countCards = 21;
                Random rand = new();

                List<Serials> serials = (from serial in db.Serials.Skip(countCards * count).Take(countCards) select serial).ToList();

                for (int i = 0; i < serials.Count; i++)
                {
                    int j = rand.Next(i, serials.Count);

                    Serials temp = serials[i];
                    serials[i] = serials[j];
                    serials[j] = temp;
                }

                return serials;
            }
        }
    }
}
