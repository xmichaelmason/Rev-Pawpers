using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using DataAccess;
using Models;
using Moq;
using Xunit;

namespace UnitTest
{
    public class TopicMoq
    {
        [Fact]
        public void GetByIdWithNavShouldReturnEntity()
        {
            // arrange
            var topicRepo = new Mock<ITopicRepository>();
            var topic = new Topic
            {
                TopicId = 1,
                TopicName = "test",
                TopicBody = "test",
                ProfileId = 1,
                PostTimestamp = System.DateTime.Now,
                CategoryId = 1
            };

            topicRepo.Setup(t => t.GetByIdWithNav(1))
                .Returns(topic);

            // act
            var topicBL = new TopicBL(topicRepo.Object);
            var result = topicBL.GetByIdWithNav(1);

            // assert
            Assert.Equal(result, topic);
        }

        [Fact]
        public void SearchByBodyShouldReturnEntity()
        {
            // arrange
            var topicRepo = new Mock<ITopicRepository>();
            var topic = new Topic
            {
                TopicId = 1,
                TopicName = "test",
                TopicBody = "test",
                ProfileId = 1,
                PostTimestamp = System.DateTime.Now,
                CategoryId = 1
            };

            topicRepo.Setup(t => t.SearchByBody("test"))
                .Returns(new List<Topic>
                {
                    topic
                });

            // act
            var topicBL = new TopicBL(topicRepo.Object);
            var result = topicBL.SearchByBody("test");

            // assert
            Assert.Single(result);
        }

        [Fact]
        public void SearchByNameShouldReturnEntity()
        {
            // arrange
            var topicRepo = new Mock<ITopicRepository>();
            var topic = new Topic
            {
                TopicId = 1,
                TopicName = "test",
                TopicBody = "test",
                ProfileId = 1,
                PostTimestamp = System.DateTime.Now,
                CategoryId = 1
            };

            topicRepo.Setup(t => t.SearchByName("test"))
                .Returns(new List<Topic>
                {
                    topic
                });

            // act
            var topicBL = new TopicBL(topicRepo.Object);
            var result = topicBL.SearchByName("test");

            // assert
            Assert.Single(result);
        }

        [Fact]
        public void SearchByProfileIdShouldReturnEntity()
        {
            // arrange
            var topicRepo = new Mock<ITopicRepository>();
            var topic = new Topic
            {
                TopicId = 1,
                TopicName = "test",
                TopicBody = "test",
                ProfileId = 1,
                PostTimestamp = System.DateTime.Now,
                CategoryId = 1
            };

            topicRepo.Setup(t => t.SearchByProfileId(1))
                .Returns(new List<Topic>
                {
                    topic
                });

            // act
            var topicBL = new TopicBL(topicRepo.Object);
            var result = topicBL.SearchByProfileId(1);

            // assert
            Assert.Single(result);
        }

        [Fact]
        public void ListByCategoryIdShouldReturnEntity()
        {
            // arrange
            var topicRepo = new Mock<ITopicRepository>();
            var topic = new Topic
            {
                TopicId = 1,
                TopicName = "test",
                TopicBody = "test",
                ProfileId = 1,
                PostTimestamp = System.DateTime.Now,
                CategoryId = 1
            };

            topicRepo.Setup(t => t.ListByCategoryId(1))
                .Returns(new List<Topic>
                {
                    topic
                });

            // act
            var topicBL = new TopicBL(topicRepo.Object);
            var result = topicBL.ListByCategoryId(1);

            // assert
            Assert.Single(result);
        }
    }
}