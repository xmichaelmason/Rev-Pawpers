using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace DataAccess
{
    public class TopicRepository : Repository<Topic>, ITopicRepository
    {
        readonly PawpersDbContext repository;
        public TopicRepository(PawpersDbContext context) : base(context)
        {
            repository = context;
        }

        /// <summary>
        /// Queries DB to find single item based on the primary key 
        /// loads nav properties of the entity
        /// </summary>
        /// <param name="query">int </param>
        /// <returns>query which will be topic ID</returns>
        public Topic GetByIdWithNav(int query)
        {
            var topic = repository.Topics
                .Include(t => t.Replies)
                .Single(t => t.TopicId.Equals(query));

            return topic;
        }

        public IEnumerable<Topic> GetAllWithNav()
        {
            var topics = repository.Topics
                .Include(t => t.Replies);

            return topics;
        }

        /// <summary>
        /// Queries DB to find list of topics based on topic model's TopicBody field 
        /// retrieves search results of topics with matching TopicBody
        /// </summary>
        /// <param name="query">string </param>
        /// <returns>query which will be TopicBody</returns>
        public IEnumerable<Topic> SearchByBody(string query)
        {
            var topics = GetAll().Where(b => b.TopicBody.Contains(query));
            if (!topics.Any())
            {
                throw new KeyNotFoundException("Topic not found.");
            }
            else
            {
                return topics;
            }
        }

        /// <summary>
        /// Queries DB to find list of topics based on topic model's CategoryId field 
        /// retrieves search results of topics with matching CategoryId
        /// </summary>
        /// <param name="query">int </param>
        /// <returns>query which will be CategoryId</returns>
        public IEnumerable<Topic> ListByCategoryId(int query)
        {
            var topics = GetAll().Where(b => b.CategoryId.Equals(query));
            if (!topics.Any())
            {
                throw new KeyNotFoundException("Topic not found.");
            }
            else
            {
                return topics;
            }
        }

        /// <summary>
        /// Queries DB to find list of topics based on topic model's TopicName field 
        /// retrieves search results of topics with matching TopicName
        /// </summary>
        /// <param name="query">string </param>
        /// <returns>query which will be TopicName</returns>
        public IEnumerable<Topic> SearchByName(string query)
        {
            var topics = GetAll().Where(b => b.TopicName.Equals(query));
            if (!topics.Any())
            {
                throw new KeyNotFoundException("Topic not found.");
            }
            else
            {
                return topics;
            }
        }

        /// <summary>
        /// Queries DB to find list of topics based on topic model's ProfileId field 
        /// retrieves search results of topics with matching ProfileId
        /// </summary>
        /// <param name="query">int </param>
        /// <returns>query which will be ProfileId</returns>
        public IEnumerable<Topic> SearchByProfileId(int query)
        {
            var topics = GetAll().Where(b => b.ProfileId.Equals(query));
            if (!topics.Any())
            {
                throw new KeyNotFoundException("Topic not found.");
            }
            else
            {
                return topics;
            }
        }
    }
}