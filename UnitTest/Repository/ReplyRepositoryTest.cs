using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Models;
using DataAccess;
using System.Linq;
using System.Collections.Generic;

namespace UnitTest
{
    public class ReplyRepositoryTest
    {
        readonly DbContextOptions<PawpersDbContext> _options;
        public ReplyRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<PawpersDbContext>()
                .UseSqlite("Filename = ReplyRepository.db; Foreign Keys=False").Options;
            Seed();
        }

        [Fact]
        public void SearchByProfileIdShouldReturnResults()
        {
            using (var context = new PawpersDbContext(_options))
            {
                IReplyRepository repository = new ReplyRepository(context);
                var reply = repository.SearchByProfileId(1);

                Assert.NotEmpty(reply);
            }
        }

        void Seed()
        {
            using (var context = new PawpersDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Replies.Add(
                    new Reply
                    {
                        ReplyId = 1,
                        ReplyMessage = "test",
                        ReplyTimestamp = System.DateTime.Now,
                        ProfileId = 1
                    }
                );

                context.SaveChanges();
            }
        }
    }
}