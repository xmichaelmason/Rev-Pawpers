using System.Collections.Generic;
using Models;

namespace BusinessLogic
{
    public interface IFavoriteBL : IBaseBL<Favorite>
    {
        IEnumerable<Favorite> SearchByDogId(int query);
        IEnumerable<Favorite> SearchByProfileId(int query);
    }
}