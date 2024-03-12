using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace BusinessLogic
{

    public class TopicBL : BaseBL<Topic>, ITopicBL
    {
        protected readonly ITopicRepository topicRepository;

        public TopicBL(ITopicRepository topicRepository) : base(topicRepository)
        {
            this.topicRepository = topicRepository;
        }

        public Topic GetByIdWithNav(int query)
        {
            return topicRepository.GetByIdWithNav(query);
        }

        public IEnumerable<Topic> GetAllWithNav()
        {
            return topicRepository.GetAllWithNav();
        }

        public IEnumerable<Topic> ListByCategoryId(int query)
        {
            return topicRepository.ListByCategoryId(query);
        }

        public IEnumerable<Topic> SearchByBody(string query)
        {
            return topicRepository.SearchByBody(query);
        }

        public IEnumerable<Topic> SearchByName(string query)
        {
            return topicRepository.SearchByName(query);
        }

        public IEnumerable<Topic> SearchByProfileId(int query)
        {
            return topicRepository.SearchByProfileId(query);
        }
    }
}