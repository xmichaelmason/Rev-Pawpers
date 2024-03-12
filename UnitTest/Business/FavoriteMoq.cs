using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using DataAccess;
using Models;
using Moq;
using Xunit;

namespace UnitTest
{
    public class FavoriteMoq
    {

        [Fact]
        public void SearchByDogIdShouldReturnEntity()
        {
            // arrange
            var favoriteRepo = new Mock<IFavoriteRepository>();
            var favorite = new Favorite
            {
                FavId = 1,
                DogId = 1,
                IsAvailable = 1,
                ProfileId = 1
            };

            favoriteRepo.Setup(t => t.SearchByDogId(1))
                .Returns(new List<Favorite>
                {
                    favorite
                });

            // act
            var favoriteBL = new FavoriteBL(favoriteRepo.Object);
            var result = favoriteBL.SearchByDogId(1);

            // assert
            Assert.Single(result);
        }

        [Fact]
        public void SearchByProfileIdShouldReturnEntity()
        {
            // arrange
            var favoriteRepo = new Mock<IFavoriteRepository>();
            var favorite = new Favorite
            {
                FavId = 1,
                DogId = 1,
                IsAvailable = 1,
                ProfileId = 1
            };

            favoriteRepo.Setup(t => t.SearchByProfileId(1))
                .Returns(new List<Favorite>
                {
                    favorite
                });

            // act
            var favoriteBL = new FavoriteBL(favoriteRepo.Object);
            var result = favoriteBL.SearchByProfileId(1);

            // assert
            Assert.Single(result);
        }
    }
}