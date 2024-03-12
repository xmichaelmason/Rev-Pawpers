using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace BusinessLogic
{

    public class FavoriteBL : BaseBL<Favorite>, IFavoriteBL
    {
        protected readonly IFavoriteRepository favoriteRepository;

        public FavoriteBL(IFavoriteRepository favoriteRepository) : base(favoriteRepository)
        {
            this.favoriteRepository = favoriteRepository;
        }

        public IEnumerable<Favorite> SearchByDogId(int query)
        {
            return favoriteRepository.SearchByDogId(query);
        }

        public IEnumerable<Favorite> SearchByProfileId(int query)
        {
            return favoriteRepository.SearchByProfileId(query);
        }
    }
}