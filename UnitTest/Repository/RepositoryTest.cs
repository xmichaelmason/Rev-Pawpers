using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Models;
using DataAccess;
using System.Linq;

namespace UnitTest
{
    public class RepositoryTest
    {
        readonly DbContextOptions<PawpersDbContext> _options;
        public RepositoryTest()
        {
            _options = new DbContextOptionsBuilder<PawpersDbContext>()
                .UseSqlite("Filename = Repository.db").Options;
            Seed();
        }

        [Fact]
        public void CreateTopicShouldCreateTopic()
        {
            using (var context = new PawpersDbContext(_options))
            {
                IRepository<Topic> repository = new Repository<Topic>(context);
                Topic newTopic = new ()
                {
                    TopicName = "Test 3",
                    TopicBody = "Testing",
                    PostTimestamp = DateTime.Now
                };
                repository.Create(newTopic);
                repository.Save();

                Assert.Equal(newTopic.TopicName, repository.GetByPrimaryKey(3).TopicName);
            }
        }

        [Fact]
        public void GetAllTopicsShouldReturnAllTopics()
        {
            using (var context = new PawpersDbContext(_options))
            {
                IRepository<Topic> repository = new Repository<Topic>(context);

                var testList = repository.GetAll();

                Assert.True(testList.Any());
            }
        }

        [Fact]
        public void GetTopicByPrimaryKeyShouldReturnTopic()
        {
            using (var context = new PawpersDbContext(_options))
            {
                IRepository<Topic> repository = new Repository<Topic>(context);

                Assert.Equal("test topic 1", repository.GetByPrimaryKey(1).TopicName);
            }
        }

        [Fact]
        public void UpdateTopicshouldUpdateTopic()
        {
            using (var context = new PawpersDbContext(_options))
            {
                IRepository<Topic> repository = new Repository<Topic>(context);
                var testTopic = repository.GetByPrimaryKey(1);
                testTopic.TopicName = "Test Topic 1";
                repository.Update(testTopic);
                repository.Save();

                Assert.Equal("Test Topic 1", repository.GetByPrimaryKey(1).TopicName);
            }
        }

        [Fact]
        public void DeleteTopicshouldDeleteTopic()
        {
            using (var context = new PawpersDbContext(_options))
            {
                IRepository<Topic> repository = new Repository<Topic>(context);
                var testTopic = repository.GetByPrimaryKey(2);
                repository.Delete(testTopic);
                repository.Save();

                var result = repository.GetAll();
                
                Assert.Single(result);
            }
        }

        void Seed()
        {
            using (var context = new PawpersDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Categories.Add(
                    new Category
                    {
                        CategoryName = "Things"
                    }
                );

                context.Topics.AddRange(
                    new Topic
                    {
                        TopicName = "test topic 1",
                        TopicBody = "Testing",
                        PostTimestamp = DateTime.Now,
                    },
                    new Topic
                    {
                        TopicName = "test topic 2",
                        TopicBody = "Testing",
                        PostTimestamp = DateTime.Now,
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
