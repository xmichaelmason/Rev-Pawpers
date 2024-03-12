using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using DataAccess;
using Models;
using Moq;
using Xunit;

namespace UnitTest
{
    public class BaseMoq
    {
        [Fact]
        public void CreateShouldBeCallable()
        {
            // arrange
            var topicRepo = new Mock<ITopicRepository>();
            var topic = new Topic
            {
                TopicName = "test",
                TopicBody = "test",
                PostTimestamp = System.DateTime.Now,
                CategoryId = 1
            };

            topicRepo.Setup(t => t.Create(topic))
                .Verifiable();

            // act
            var topicBL = new TopicBL(topicRepo.Object);
            topicBL.Create(topic);

            // assert
            topicRepo.VerifyAll();
        }

        [Fact]
        public void UpdateShouldBeCallable()
        {
            // arrange
            var topicRepo = new Mock<ITopicRepository>();
            var topic = new Topic
            {
                TopicName = "test",
                TopicBody = "test",
                PostTimestamp = System.DateTime.Now,
                CategoryId = 1
            };

            topicRepo.Setup(t => t.Update(topic))
                .Verifiable();

            // act
            var topicBL = new TopicBL(topicRepo.Object);
            topic.TopicName = "test1";
            topicBL.Update(topic);

            // assert
            topicRepo.VerifyAll();
        }

        [Fact]
        public void GetAllShouldReturnEntities()
        {
            // arrange
            var topicRepo = new Mock<ITopicRepository>();
            var topic = new Topic
            {
                TopicName = "test",
                TopicBody = "test",
                PostTimestamp = System.DateTime.Now,
                CategoryId = 1
            };

            topicRepo.Setup(t => t.GetAll())
                .Returns(new List<Topic>
                {
                    topic
                });

            // act
            var topicBL = new TopicBL(topicRepo.Object);
            var result = topicBL.GetAll();

            // assert
            Assert.Single(result);
        }

        [Fact]
        public void GetByPrimaryKeyShouldReturnEntity()
        {
            // arrange
            var topicRepo = new Mock<ITopicRepository>();
            var topic = new Topic
            {
                TopicId = 1,
                TopicName = "test",
                TopicBody = "test",
                PostTimestamp = System.DateTime.Now,
                CategoryId = 1
            };

            topicRepo.Setup(t => t.GetByPrimaryKey(1))
                .Returns(topic);

            // act
            var topicBL = new TopicBL(topicRepo.Object);
            var result = topicBL.GetByPrimaryKey(1);

            // assert
            Assert.Equal(result, topic);
        }

        [Fact]
        public void DeleteShouldBeCallable()
        {
            // arrange
            var topicRepo = new Mock<ITopicRepository>();
            var topic = new Topic
            {
                TopicName = "test",
                TopicBody = "test",
                PostTimestamp = System.DateTime.Now,
                CategoryId = 1
            };

            topicRepo.Setup(t => t.Delete(topic))
                .Verifiable();

            // act
            var topicBL = new TopicBL(topicRepo.Object);
            topicBL.Delete(topic);

            // assert
            topicRepo.VerifyAll();
        }

        [Fact]
        public void SaveShouldBeCallable()
        {
            // arrange
            var topicRepo = new Mock<ITopicRepository>();

            topicRepo.Setup(t => t.Save())
                .Verifiable();

            // act
            var topicBL = new TopicBL(topicRepo.Object);
            topicBL.Save();

            // assert
            topicRepo.VerifyAll();
        }
    }
}