using server.Services.Interfaces;
using WebApi.DBClasses;

namespace server.Services
{
    public class PopularService : IPopularService
    {
        public List<Popular> Category(int count)
        {
            using (WebContext db = new())
            {
                int countCards = 21;
                Random rand = new();

                List<Popular> populars = (from popular in db.Populars.Skip(countCards * count).Take(countCards) select popular).ToList();

                for (int i = 0; i < populars.Count; i++)
                {
                    int j = rand.Next(i, populars.Count);

                    Popular temp = populars[i];
                    populars[i] = populars[j];
                    populars[j] = temp;
                }

                return populars;
            }
        }
    }
}
