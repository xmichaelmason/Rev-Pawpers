using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        readonly PawpersDbContext repository;
        public ProfileRepository(PawpersDbContext context) : base(context)
        {
            repository = context;
        }

        /// <summary>
        /// Queries DB to find single item based on the primary key 
        /// loads nav properties of the entity
        /// </summary>
        /// <param name="query">int </param>
        /// <returns>query which will be profile ID</returns>
        public Profile GetByIdWithNav(int query)
        {
            var profile = repository.Profiles
                .Include(p => p.ProfileDwelling)
                .Include(p => p.Favorites)
                .Include(p => p.Topics)
                .Include(p => p.Replies)
                .Single(p => p.ProfileId.Equals(query));

            return profile;
        }

        /// <summary>
        /// Queries DB to find list of emails based on profile model's ProfileEmail field 
        /// retrieves search results of profiles with matching ProfileEmail
        /// </summary>
        /// <param name="query">string </param>
        /// <returns>query which will be ProfileEmail</returns>
        public Profile GetByEmail(string query)
        {
            var profiles = repository.Profiles
                    .Single(p => p.ProfileEmail.ToLower().Equals(query.ToLower()));
            if (profiles == null)
            {
                throw new KeyNotFoundException("None found");
            }
            return profiles;
        }

        /// <summary>
        /// Queries DB to find list of phone numbers based on profile model's ProfileHonephone field 
        /// retrieves search results of profiles with matching ProfileHomephone
        /// </summary>
        /// <param name="query">string </param>
        /// <returns>query which will be ProfileHomephone</returns>
        public IEnumerable<Profile> SearchByPhoneNumber(string query)
        {
            var profiles = base.GetAll().Where(p => p.ProfilePersonalphone.Contains(query));
            if (!profiles.Any())
            {
                throw new KeyNotFoundException("not found");
            }
            return profiles;
        }

        /// <summary>
        /// Queries DB to find list of names based on profile model's ProfileName field 
        /// retrieves search results of profiles with matching ProfileName
        /// </summary>
        /// <param name="query">string </param>
        /// <returns>query which will be ProfileName</returns>
        public IEnumerable<Profile> SearchByProfileName(string query)
        {
            var profiles = base.GetAll().Where(p => p.ProfileName.Contains(query));
            if (!profiles.Any())
            {
                throw new KeyNotFoundException("not found");
            }
            return profiles;
        }
    }
}