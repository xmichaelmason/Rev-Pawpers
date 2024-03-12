using System.Collections.Generic;
using Models;

namespace DataAccess
{
    public interface IReplyRepository : IRepository<Reply>
    {
        IEnumerable<Reply> SearchByProfileId(int query);
        IEnumerable<Reply> SearchByTopicId(int query);
    }
}