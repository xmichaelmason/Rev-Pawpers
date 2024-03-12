using BusinessLogic;
using Models;
using System.Collections.Generic;


namespace BusinessLogic
{
    public interface IReplyBL : IBaseBL<Reply>
    {
        IEnumerable<Reply> SearchByProfileId(int query);
        IEnumerable<Reply> SearchByTopicId(int query);
    }
}