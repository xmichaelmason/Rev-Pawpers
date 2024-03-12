using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class FavoriteRepository : Repository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(PawpersDbContext context) : base(context)
        {
        }
        
        /// <summary>
        /// Queries DB to find list of favorite dogs based on favorite model's DogId field 
        /// retrieves search results of dogs with matching DogId
        /// </summary>
        /// <param name="query">int </param>
        /// <returns>query which will be DogId</returns>
        public IEnumerable<Favorite> SearchByDogId(int query)
        {

            var result = base.GetAll()
                        .Where(i => i.DogId.Equals(query));

            if (!result.Any())
            {
                throw new KeyNotFoundException("Value cannot be empty");
            }
            return result;

        }

        /// <summary>
        /// Queries DB to find list of profiles based on favorite model's ProfileId field 
        /// retrieves search results of profiles with matching ProfileId
        /// </summary>
        /// <param name="query">int </param>
        /// <returns>query which will be ProfileId</returns>
        public IEnumerable<Favorite> SearchByProfileId(int query)
        {
            var result = base.GetAll()
                        .Where(i => i.ProfileId.Equals(query));
            if (!result.Any())
            {
                throw new KeyNotFoundException("No result found");
            }

            return result;


        }
    }
}