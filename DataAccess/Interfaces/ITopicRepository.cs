using System.Collections.Generic;
using Models;

namespace DataAccess
{
    public interface ITopicRepository : IRepository<Topic>
    {
        Topic GetByIdWithNav(int query);

        IEnumerable<Topic> GetAllWithNav();
        IEnumerable<Topic> SearchByName(string query);
        IEnumerable<Topic> SearchByBody(string query);
        IEnumerable<Topic> SearchByProfileId(int query);
        IEnumerable<Topic> ListByCategoryId(int query);
    }
}