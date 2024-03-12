using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Models;
using DataAccess;
using System.Linq;
using System.Collections.Generic;

namespace UnitTest
{
    public class FavoriteRepositoryTest
    {
        readonly DbContextOptions<PawpersDbContext> _options;
        public FavoriteRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<PawpersDbContext>()
                .UseSqlite("Filename = FavoriteRepository.db; Foreign Keys=False").Options;
            Seed();
        }

        [Fact]
        public void SearchByDogIdShouldReturnResults()
        {
            using (var context = new PawpersDbContext(_options))
            {
                IFavoriteRepository repository = new FavoriteRepository(context);
                var favorite = repository.SearchByDogId(1);

                Assert.NotEmpty(favorite);
            }
        }

        [Fact]
        public void SearchByDogIdShouldThrowNullExceptionOnNoResults()
        {
            using (var context = new PawpersDbContext(_options))
            {
                IFavoriteRepository repository = new FavoriteRepository(context);

                Assert.Throws<KeyNotFoundException>(() => repository.SearchByDogId(3));
            }
        }

        [Fact]
        public void SearchByProfileIdShouldReturnResults()
        {
            using (var context = new PawpersDbContext(_options))
            {
                IFavoriteRepository repository = new FavoriteRepository(context);
                var favorite = repository.SearchByProfileId(1);

                Assert.NotEmpty(favorite);
            }
        }

        [Fact]
        public void SearchByProfileIdShouldThrowNullExceptionOnNoResults()
        {
            using (var context = new PawpersDbContext(_options))
            {
                IFavoriteRepository repository = new FavoriteRepository(context);

                Assert.Throws<KeyNotFoundException>(() => repository.SearchByProfileId(3));
            }
        }

        void Seed()
        {
            using (var context = new PawpersDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Profiles.Add(
                    new Profile
                    {
                        ProfileId = 1,
                        ProfileName = "lkjh",
                        ProfileStreetaddress = "123",
                        ProfileCity = "jkahfjh",
                        ProfileStateid = 1,
                        ProfileZipcode = "00000",
                        ProfileAge = 11,
                        ProfileHomephone = "1114567890",
                        ProfilePersonalphone = "1112341234",
                        ProfileEmail = "aaa@aaa.com",
                        ProfileOccupation = "jhlkjhf",
                        ProfileChildren = 3,
                        ProfileHasyard = 0,
                        ProfileFamilyallergies = 0,
                        ProfileResponsiblefordog = "joe",
                        ProfileAdoptionreason = "ajklsdhf",
                        ProfileDogsleepat = "lakjhf",
                        ProfileDogaggresive = "kjahf",
                        ProfileMedfordog = "lkjahlfjh",
                        ProfileNocaredog = "kljahfkj"
                    }
                );

                context.Favorites.AddRange(
                    new Favorite
                    {
                        DogId = 1,
                        IsAvailable = 1,
                        ProfileId = 1
                    },
                    new Favorite
                    {
                        DogId = 2,
                        IsAvailable = 1,
                        ProfileId = 1
                    }
                );

                context.SaveChanges();
            }
        }
    }
}