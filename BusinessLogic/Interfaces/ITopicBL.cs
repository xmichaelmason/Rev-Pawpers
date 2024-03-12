using BusinessLogic;
using Models;
using System.Collections.Generic;


namespace BusinessLogic
{
    public interface ITopicBL : IBaseBL<Topic>
    {
        Topic GetByIdWithNav(int query);
        IEnumerable<Topic> GetAllWithNav();
        IEnumerable<Topic> SearchByBody(string query);
        IEnumerable<Topic> ListByCategoryId(int query);
        IEnumerable<Topic> SearchByName(string query);
        IEnumerable<Topic> SearchByProfileId(int query);
    }
}