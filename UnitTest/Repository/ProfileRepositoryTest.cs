using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Models;
using DataAccess;
using System.Linq;
using System.Collections.Generic;

namespace UnitTest
{
    public class ProfileRepositoryTest
    {
        readonly DbContextOptions<PawpersDbContext> _options;
        public ProfileRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<PawpersDbContext>()
                .UseSqlite("Filename = ProfileRepository.db; Foreign Keys=False").Options;
            Seed();
        }

        [Fact]
        public void GetByIdWithNavShouldPopulateNavProps()
        {
            using (var context = new PawpersDbContext(_options))
            {
                IProfileRepository repository = new ProfileRepository(context);
                var profile = repository.GetByIdWithNav(1);

                Assert.NotNull(profile.ProfileDwelling);
            }
        }

        // [Fact]
        // public void SearchByEmailShouldReturnResults()
        // {
        //     using (var context = new PawpersDbContext(_options))
        //     {
        //         IProfileRepository repository = new ProfileRepository(context);
        //         var profile = repository.SearchByEmail("test@test.com");

        //         Assert.NotNull(profile);
        //     }
        // }

        // [Fact]
        // public void SearchByEmailShouldThrowNullExceptionOnNoResults()
        // {
        //     using (var context = new PawpersDbContext(_options))
        //     {
        //         IProfileRepository repository = new ProfileRepository(context);

        //         Assert.Throws<KeyNotFoundException>(() => repository.SearchByEmail("lajkdfhlajksfhlajksfhalskjfhlakfjh"));
        //     }
        // }

        [Fact]
        public void SearchByPhoneShouldReturnResults()
        {
            using (var context = new PawpersDbContext(_options))
            {
                IProfileRepository repository = new ProfileRepository(context);
                var profile = repository.SearchByPhoneNumber("1234567890");

                Assert.NotEmpty(profile);
            }
        }

        [Fact]
        public void SearchByPhoneShouldThrowNullExceptionOnNoResults()
        {
            using (var context = new PawpersDbContext(_options))
            {
                IProfileRepository repository = new ProfileRepository(context);

                Assert.Throws<KeyNotFoundException>(() => repository.SearchByPhoneNumber("lajkdfhlajksfhlajksfhalskjfhlakfjh"));
            }
        }

        [Fact]
        public void SearchByNameShouldReturnResults()
        {
            using (var context = new PawpersDbContext(_options))
            {
                IProfileRepository repository = new ProfileRepository(context);
                var profile = repository.SearchByProfileName("test");

                Assert.NotNull(profile);
            }
        }

        [Fact]
        public void SearchByNameShouldThrowNullExceptionOnNoResults()
        {
            using (var context = new PawpersDbContext(_options))
            {
                IProfileRepository repository = new ProfileRepository(context);

                Assert.Throws<KeyNotFoundException>(() => repository.SearchByProfileName("lajkdfhlajksfhlajksfhalskjfhlakfjh"));
            }
        }

        void Seed()
        {
            using (var context = new PawpersDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Dwellings.Add(
                    new Dwelling
                    {
                        DwellingId = 1,
                        DwellingType = "house"
                    }
                );

                context.Profiles.AddRange(
                    new Profile
                    {
                        ProfileId = 1,
                        ProfileName = "lkjh",
                        ProfileStreetaddress = "123",
                        ProfileCity = "jkahfjh",
                        ProfileStateid = 1,
                        ProfileZipcode = "00000",
                        ProfileAge = 11,
                        ProfileHomephone = "1234567890",
                        ProfilePersonalphone = "1234567890",
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
                        ProfileNocaredog = "kljahfkj",
                        ProfileDwellingid = 1
                    },
                    new Profile
                    {
                        ProfileName = "test2",
                        ProfileStreetaddress = "123",
                        ProfileCity = "jkahfjh",
                        ProfileStateid = 1,
                        ProfileZipcode = "00000",
                        ProfileAge = 11,
                        ProfileHomephone = "1234567890",
                        ProfilePersonalphone = "1234567890",
                        ProfileEmail = "test@test.com",
                        ProfileOccupation = "jhlkjhf",
                        ProfileChildren = 3,
                        ProfileHasyard = 0,
                        ProfileFamilyallergies = 0,
                        ProfileResponsiblefordog = "joe",
                        ProfileAdoptionreason = "ajklsdhf",
                        ProfileDogsleepat = "lakjhf",
                        ProfileDogaggresive = "kjahf",
                        ProfileMedfordog = "lkjahlfjh",
                        ProfileNocaredog = "kljahfkj",
                        ProfileDwellingid = 1
                    }
                );

                context.SaveChanges();
            }
        }
    }
}