using System.Collections.Generic;
using Models;

namespace DataAccess
{
    public interface IProfileRepository : IRepository<Profile>
    {
        Profile GetByIdWithNav(int query);
        IEnumerable<Profile> SearchByProfileName(string query);
        IEnumerable<Profile> SearchByPhoneNumber(string query);
        Profile GetByEmail(string query);
    }
}