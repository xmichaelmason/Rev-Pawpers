using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace DataAccess
{
    public class ReplyRepository : Repository<Reply>, IReplyRepository
    {
        public ReplyRepository(PawpersDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Queries DB to find list of replies based on reply model's ProfileId field 
        /// retrieves search results of replies with matching ProfileId
        /// </summary>
        /// <param name="query">int </param>
        /// <returns>query which will be ProfileId</returns>
        public IEnumerable<Reply> SearchByProfileId(int query)
        {
            var result = base.GetAll()
                        .Where(i => i.ProfileId.Equals(query));
            if (!result.Any())
            {
                throw new KeyNotFoundException("No result found");
            }

            return result;
        }

        public IEnumerable<Reply> SearchByTopicId(int query)
        {
            var result = base.GetAll()
                        .Where(i => i.TopicId.Equals(query));
            if (!result.Any())
            {
                throw new KeyNotFoundException("No result found");
            }

            return result;
        }
    }
}