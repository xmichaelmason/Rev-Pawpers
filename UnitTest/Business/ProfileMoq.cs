using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using DataAccess;
using Models;
using Moq;
using Xunit;

namespace UnitTest
{
    public class ProfileMoq
    {
        [Fact]
        public void GetByIdWithNavShouldReturnEntity()
        {
            // arrange
            var profileRepo = new Mock<IProfileRepository>();
            var profile = new Profile
            {
                ProfileId = 1,
                ProfileName = "test",
                ProfileStreetaddress = "123",
                ProfileCity = "test",
                ProfileStateid = 1,
                ProfileZipcode = "12345",
                ProfileAge = 10,
                ProfilePersonalphone = "123-456-7890",
                ProfileEmail = "123@test.com",
                ProfileOccupation = "test",
                ProfileChildren = 1,
                ProfileHasyard = 2,
                ProfileFamilyallergies = 2,
                ProfileResponsiblefordog = "test",
                ProfileAdoptionreason = "test",
                ProfileDogsleepat = "test",
                ProfileDogaggresive = "test",
                ProfileMedfordog = "test",
                ProfileNocaredog = "test"
            };

            profileRepo.Setup(t => t.GetByIdWithNav(1))
                .Returns(profile);

            // act
            var profileBL = new ProfileBL(profileRepo.Object);
            var result = profileBL.GetByIdWithNav(1);

            // assert
            Assert.Equal(result, profile);
        }

        [Fact]
        public void SearchByNameShouldReturnEntity()
        {
            // arrange
            var profileRepo = new Mock<IProfileRepository>();
            var profile = new Profile
            {
                ProfileId = 1,
                ProfileName = "test",
                ProfileStreetaddress = "123",
                ProfileCity = "test",
                ProfileStateid = 1,
                ProfileZipcode = "12345",
                ProfileAge = 10,
                ProfilePersonalphone = "123-456-7890",
                ProfileEmail = "123@test.com",
                ProfileOccupation = "test",
                ProfileChildren = 1,
                ProfileHasyard = 2,
                ProfileFamilyallergies = 2,
                ProfileResponsiblefordog = "test",
                ProfileAdoptionreason = "test",
                ProfileDogsleepat = "test",
                ProfileDogaggresive = "test",
                ProfileMedfordog = "test",
                ProfileNocaredog = "test"
            };

            profileRepo.Setup(t => t.SearchByProfileName("test"))
                .Returns(new List<Profile>
                {
                    profile
                });

            // act
            var profileBL = new ProfileBL(profileRepo.Object);
            var result = profileBL.SearchByProfileName("test");

            // assert
            Assert.Single(result);
        }

        // [Fact]
        // public void SearchByEmailShouldReturnEntity()
        // {
        //     // arrange
        //     var profileRepo = new Mock<IProfileRepository>();
        //     var profile = new Profile
        //     {
        //         ProfileId = 1,
        //         ProfileName = "test",
        //         ProfileStreetaddress = "123",
        //         ProfileCity = "test",
        //         ProfileStateid = 1,
        //         ProfileZipcode = "12345",
        //         ProfileAge = 10,
        //         ProfilePersonalphone = "123-456-7890",
        //         ProfileEmail = "123@test.com",
        //         ProfileOccupation = "test",
        //         ProfileChildren = 1,
        //         ProfileHasyard = 2,
        //         ProfileFamilyallergies = 2,
        //         ProfileResponsiblefordog = "test",
        //         ProfileAdoptionreason = "test",
        //         ProfileDogsleepat = "test",
        //         ProfileDogaggresive = "test",
        //         ProfileMedfordog = "test",
        //         ProfileNocaredog = "test"
        //     };

        //     profileRepo.Setup(t => t.GetEmail("123@test.com"))
        //         .Returns(new Profile
        //         {
        //             profile
        //         });

        //     // act
        //     var profileBL = new ProfileBL(profileRepo.Object);
        //     var result = profileBL.GetEmail("123@test.com");

        //     // assert
        //     Assert.Single(result);
        // }

        [Fact]
        public void SearchByPhoneShouldReturnEntity()
        {
            // arrange
            var profileRepo = new Mock<IProfileRepository>();
            var profile = new Profile
            {
                ProfileId = 1,
                ProfileName = "test",
                ProfileStreetaddress = "123",
                ProfileCity = "test",
                ProfileStateid = 1,
                ProfileZipcode = "12345",
                ProfileAge = 10,
                ProfilePersonalphone = "123-456-7890",
                ProfileEmail = "123@test.com",
                ProfileOccupation = "test",
                ProfileChildren = 1,
                ProfileHasyard = 2,
                ProfileFamilyallergies = 2,
                ProfileResponsiblefordog = "test",
                ProfileAdoptionreason = "test",
                ProfileDogsleepat = "test",
                ProfileDogaggresive = "test",
                ProfileMedfordog = "test",
                ProfileNocaredog = "test"
            };

            profileRepo.Setup(t => t.SearchByPhoneNumber("123-456-7890"))
                .Returns(new List<Profile>
                {
                    profile
                });

            // act
            var profileBL = new ProfileBL(profileRepo.Object);
            var result = profileBL.SearchByPhoneNumber("123-456-7890");

            // assert
            Assert.Single(result);
        }
    }
}