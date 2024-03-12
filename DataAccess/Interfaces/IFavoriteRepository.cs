using System.Collections.Generic;
using Models;

namespace DataAccess
{
    public interface IFavoriteRepository : IRepository<Favorite>
    {
        IEnumerable<Favorite> SearchByProfileId(int query);
        IEnumerable<Favorite> SearchByDogId(int query);
    }
}