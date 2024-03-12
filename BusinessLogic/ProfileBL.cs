using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace BusinessLogic
{

    public class ProfileBL : BaseBL<Profile>, IProfileBL
    {
        protected readonly IProfileRepository profileRepository;

        public ProfileBL(IProfileRepository profileRepository) : base(profileRepository)
        {
            this.profileRepository = profileRepository;
        }

        public Profile GetByIdWithNav(int query)
        {
            return profileRepository.GetByIdWithNav(query);
        }

        public Profile GetByEmail(string query)
        {
            return profileRepository.GetByEmail(query);
        }

        public IEnumerable<Profile> SearchByPhoneNumber(string query)
        {
            return profileRepository.SearchByPhoneNumber(query);
        }

        public IEnumerable<Profile> SearchByProfileName(string query)
        {
            return profileRepository.SearchByProfileName(query);
        }
    }
}