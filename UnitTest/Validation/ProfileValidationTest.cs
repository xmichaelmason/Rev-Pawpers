using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models;
using Xunit;

namespace UnitTest
{
    public class ProfilesValidation
    {
        [Fact]
        public void NameRequired()
        {
            var profile = new Profile
            {
                ProfileName = null,
                ProfileStreetaddress = "123",
                ProfileCity = "jkahfjh",
                ProfileStateid = 1,
                ProfileZipcode = "00000",
                ProfileAge = 11,
                ProfileHomephone = "111-456-7890",
                ProfilePersonalphone = "111-234-1234",
                ProfileEmail = "aaa@aaa.com",
                ProfileChildren = 3,
                ProfileHasyard = 0,
                ProfileFamilyallergies = 0,
                ProfileResponsiblefordog = "joe",
                ProfileAdoptionreason = "ajklsdhf",
                ProfileDogsleepat = "lakjhf",
                ProfileDogaggresive = "kjahf",
                ProfileMedfordog = "lkjahlfjh",
                ProfileNocaredog = "kljahfkj"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(profile, null, null);
            Assert.False(Validator.TryValidateObject(profile, ctx, validationResults, true));
        }

        [Fact]
        public void StreetAddressRequired()
        {
            var profile = new Profile
            {
                ProfileName = "kljhafk",
                ProfileStreetaddress = null,
                ProfileCity = "jkahfjh",
                ProfileStateid = 1,
                ProfileZipcode = "00000",
                ProfileAge = 11,
                ProfileHomephone = "111-456-7890",
                ProfilePersonalphone = "111-234-1234",
                ProfileEmail = "aaa@aaa.com",
                ProfileChildren = 3,
                ProfileHasyard = 0,
                ProfileFamilyallergies = 0,
                ProfileResponsiblefordog = "joe",
                ProfileAdoptionreason = "ajklsdhf",
                ProfileDogsleepat = "lakjhf",
                ProfileDogaggresive = "kjahf",
                ProfileMedfordog = "lkjahlfjh",
                ProfileNocaredog = "kljahfkj"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(profile, null, null);
            Assert.False(Validator.TryValidateObject(profile, ctx, validationResults, true));
        }

        [Fact]
        public void CityRequired()
        {
            var profile = new Profile
            {
                ProfileName = "ajkdfh",
                ProfileStreetaddress = "123",
                ProfileCity = null,
                ProfileStateid = 1,
                ProfileZipcode = "00000",
                ProfileAge = 11,
                ProfileHomephone = "111-456-7890",
                ProfilePersonalphone = "111-234-1234",
                ProfileEmail = "aaa@aaa.com",
                ProfileChildren = 3,
                ProfileHasyard = 0,
                ProfileFamilyallergies = 0,
                ProfileResponsiblefordog = "joe",
                ProfileAdoptionreason = "ajklsdhf",
                ProfileDogsleepat = "lakjhf",
                ProfileDogaggresive = "kjahf",
                ProfileMedfordog = "lkjahlfjh",
                ProfileNocaredog = "kljahfkj"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(profile, null, null);
            Assert.False(Validator.TryValidateObject(profile, ctx, validationResults, true));
        }

        [Fact]
        public void StateRequired()
        {
            var profile = new Profile
            {
                ProfileName = "lkjafh",
                ProfileStreetaddress = "123",
                ProfileCity = "jkahfjh",
                ProfileState = null,
                ProfileZipcode = "00000",
                ProfileAge = 11,
                ProfileHomephone = "111-456-7890",
                ProfilePersonalphone = "111-234-1234",
                ProfileEmail = "aaa@aaa.com",
                ProfileChildren = 3,
                ProfileHasyard = 0,
                ProfileFamilyallergies = 0,
                ProfileResponsiblefordog = "joe",
                ProfileAdoptionreason = "ajklsdhf",
                ProfileDogsleepat = "lakjhf",
                ProfileDogaggresive = "kjahf",
                ProfileMedfordog = "lkjahlfjh",
                ProfileNocaredog = "kljahfkj"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(profile, null, null);
            Assert.False(Validator.TryValidateObject(profile, ctx, validationResults, true));
        }

        [Fact]
        public void ZipRequired()
        {
            var profile = new Profile
            {
                ProfileName = "ljafh",
                ProfileStreetaddress = "123",
                ProfileCity = "jkahfjh",
                ProfileStateid = 1,
                ProfileZipcode = null,
                ProfileAge = 11,
                ProfileHomephone = "111-456-7890",
                ProfilePersonalphone = "111-234-1234",
                ProfileEmail = "aaa@aaa.com",
                ProfileChildren = 3,
                ProfileHasyard = 0,
                ProfileFamilyallergies = 0,
                ProfileResponsiblefordog = "joe",
                ProfileAdoptionreason = "ajklsdhf",
                ProfileDogsleepat = "lakjhf",
                ProfileDogaggresive = "kjahf",
                ProfileMedfordog = "lkjahlfjh",
                ProfileNocaredog = "kljahfkj"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(profile, null, null);
            Assert.False(Validator.TryValidateObject(profile, ctx, validationResults, true));
        }

        [Fact]
        public void AgeRequired()
        {
            var profile = new Profile
            {
                ProfileName = "jkasfhjk",
                ProfileStreetaddress = "123",
                ProfileCity = "jkahfjh",
                ProfileStateid = 1,
                ProfileZipcode = "00000",
                ProfileAge = 0,
                ProfileHomephone = "111-456-7890",
                ProfilePersonalphone = "111-234-1234",
                ProfileEmail = "aaa@aaa.com",
                ProfileChildren = 3,
                ProfileHasyard = 0,
                ProfileFamilyallergies = 0,
                ProfileResponsiblefordog = "joe",
                ProfileAdoptionreason = "ajklsdhf",
                ProfileDogsleepat = "lakjhf",
                ProfileDogaggresive = "kjahf",
                ProfileMedfordog = "lkjahlfjh",
                ProfileNocaredog = "kljahfkj"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(profile, null, null);
            Assert.False(Validator.TryValidateObject(profile, ctx, validationResults, true));
        }

        [Fact]
        public void HomePhoneRequired()
        {
            var profile = new Profile
            {
                ProfileName = "lkjHFD",
                ProfileStreetaddress = "123",
                ProfileCity = "jkahfjh",
                ProfileStateid = 1,
                ProfileZipcode = "00000",
                ProfileAge = 11,
                ProfileHomephone = null,
                ProfilePersonalphone = "111-234-1234",
                ProfileEmail = "aaa@aaa.com",
                ProfileChildren = 3,
                ProfileHasyard = 0,
                ProfileFamilyallergies = 0,
                ProfileResponsiblefordog = "joe",
                ProfileAdoptionreason = "ajklsdhf",
                ProfileDogsleepat = "lakjhf",
                ProfileDogaggresive = "kjahf",
                ProfileMedfordog = "lkjahlfjh",
                ProfileNocaredog = "kljahfkj"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(profile, null, null);
            Assert.False(Validator.TryValidateObject(profile, ctx, validationResults, true));
        }

        [Fact]
        public void EmailRequired()
        {
            var profile = new Profile
            {
                ProfileName = "ljkahf",
                ProfileStreetaddress = "123",
                ProfileCity = "jkahfjh",
                ProfileStateid = 1,
                ProfileZipcode = "00000",
                ProfileAge = 11,
                ProfileHomephone = "111-456-7890",
                ProfilePersonalphone = "111-234-1234",
                ProfileEmail = null,
                ProfileChildren = 3,
                ProfileHasyard = 0,
                ProfileFamilyallergies = 0,
                ProfileResponsiblefordog = "joe",
                ProfileAdoptionreason = "ajklsdhf",
                ProfileDogsleepat = "lakjhf",
                ProfileDogaggresive = "kjahf",
                ProfileMedfordog = "lkjahlfjh",
                ProfileNocaredog = "kljahfkj"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(profile, null, null);
            Assert.False(Validator.TryValidateObject(profile, ctx, validationResults, true));
        }

        [Fact]
        public void ChildrenRequired()
        {
            var profile = new Profile
            {
                ProfileName = null,
                ProfileStreetaddress = "123",
                ProfileCity = "jkahfjh",
                ProfileStateid = 1,
                ProfileZipcode = "00000",
                ProfileAge = 11,
                ProfileHomephone = "111-456-7890",
                ProfilePersonalphone = "111-234-1234",
                ProfileEmail = "aaa@aaa.com",
                ProfileChildren = 0,
                ProfileHasyard = 0,
                ProfileFamilyallergies = 0,
                ProfileResponsiblefordog = "joe",
                ProfileAdoptionreason = "ajklsdhf",
                ProfileDogsleepat = "lakjhf",
                ProfileDogaggresive = "kjahf",
                ProfileMedfordog = "lkjahlfjh",
                ProfileNocaredog = "kljahfkj"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(profile, null, null);
            Assert.False(Validator.TryValidateObject(profile, ctx, validationResults, true));
        }

        [Fact]
        public void ResponsibleRequired()
        {
            var profile = new Profile
            {
                ProfileName = "jlkahsf",
                ProfileStreetaddress = "123",
                ProfileCity = "jkahfjh",
                ProfileStateid = 1,
                ProfileZipcode = "00000",
                ProfileAge = 11,
                ProfileHomephone = "111-456-7890",
                ProfilePersonalphone = "111-234-1234",
                ProfileEmail = "aaa@aaa.com",
                ProfileChildren = 3,
                ProfileHasyard = 0,
                ProfileFamilyallergies = 0,
                ProfileResponsiblefordog = null,
                ProfileAdoptionreason = "ajklsdhf",
                ProfileDogsleepat = "lakjhf",
                ProfileDogaggresive = "kjahf",
                ProfileMedfordog = "lkjahlfjh",
                ProfileNocaredog = "kljahfkj"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(profile, null, null);
            Assert.False(Validator.TryValidateObject(profile, ctx, validationResults, true));
        }

        [Fact]
        public void AdoptionReasonRequired()
        {
            var profile = new Profile
            {
                ProfileName = "jkahf",
                ProfileStreetaddress = "123",
                ProfileCity = "jkahfjh",
                ProfileStateid = 1,
                ProfileZipcode = "00000",
                ProfileAge = 11,
                ProfileHomephone = "111-456-7890",
                ProfilePersonalphone = "111-234-1234",
                ProfileEmail = "aaa@aaa.com",
                ProfileChildren = 3,
                ProfileResponsiblefordog = "joe",
                ProfileAdoptionreason = null,
                ProfileDogsleepat = "lakjhf",
                ProfileDogaggresive = "kjahf",
                ProfileMedfordog = "lkjahlfjh",
                ProfileNocaredog = "kljahfkj"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(profile, null, null);
            Assert.False(Validator.TryValidateObject(profile, ctx, validationResults, true));
        }

        [Fact]
        public void SleepAtRequired()
        {
            var profile = new Profile
            {
                ProfileName = "ajkfh",
                ProfileStreetaddress = "123",
                ProfileCity = "jkahfjh",
                ProfileStateid = 1,
                ProfileZipcode = "00000",
                ProfileAge = 11,
                ProfileHomephone = "111-456-7890",
                ProfilePersonalphone = "111-234-1234",
                ProfileEmail = "aaa@aaa.com",
                ProfileChildren = 3,
                ProfileHasyard = 0,
                ProfileFamilyallergies = 0,
                ProfileResponsiblefordog = "joe",
                ProfileAdoptionreason = "ajklsdhf",
                ProfileDogsleepat = null,
                ProfileDogaggresive = "kjahf",
                ProfileMedfordog = "lkjahlfjh",
                ProfileNocaredog = "kljahfkj"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(profile, null, null);
            Assert.False(Validator.TryValidateObject(profile, ctx, validationResults, true));
        }

        [Fact]
        public void AggressiveRequired()
        {
            var profile = new Profile
            {
                ProfileName = "jahsfh",
                ProfileStreetaddress = "123",
                ProfileCity = "jkahfjh",
                ProfileStateid = 1,
                ProfileZipcode = "00000",
                ProfileAge = 11,
                ProfileHomephone = "111-456-7890",
                ProfilePersonalphone = "111-234-1234",
                ProfileEmail = "aaa@aaa.com",
                ProfileChildren = 3,
                ProfileHasyard = 0,
                ProfileFamilyallergies = 0,
                ProfileResponsiblefordog = "joe",
                ProfileAdoptionreason = "ajklsdhf",
                ProfileDogsleepat = "lakjhf",
                ProfileDogaggresive = null,
                ProfileMedfordog = "lkjahlfjh",
                ProfileNocaredog = "kljahfkj"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(profile, null, null);
            Assert.False(Validator.TryValidateObject(profile, ctx, validationResults, true));
        }

        [Fact]
        public void MedRequired()
        {
            var profile = new Profile
            {
                ProfileName = "lkjahf",
                ProfileStreetaddress = "123",
                ProfileCity = "jkahfjh",
                ProfileStateid = 1,
                ProfileZipcode = "00000",
                ProfileAge = 11,
                ProfileHomephone = "111-456-7890",
                ProfilePersonalphone = "111-234-1234",
                ProfileEmail = "aaa@aaa.com",
                ProfileChildren = 3,
                ProfileHasyard = 0,
                ProfileFamilyallergies = 0,
                ProfileResponsiblefordog = "joe",
                ProfileAdoptionreason = "ajklsdhf",
                ProfileDogsleepat = "lakjhf",
                ProfileDogaggresive = "kjahf",
                ProfileMedfordog = null,
                ProfileNocaredog = "kljahfkj"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(profile, null, null);
            Assert.False(Validator.TryValidateObject(profile, ctx, validationResults, true));
        }

        [Fact]
        public void NoCareRequired()
        {
            var profile = new Profile
            {
                ProfileName = "lkjhaf",
                ProfileStreetaddress = "123",
                ProfileCity = "jkahfjh",
                ProfileStateid = 1,
                ProfileZipcode = "00000",
                ProfileAge = 11,
                ProfileHomephone = "111-456-7890",
                ProfilePersonalphone = "111-234-1234",
                ProfileEmail = "aaa@aaa.com",
                ProfileChildren = 3,
                ProfileHasyard = 0,
                ProfileFamilyallergies = 0,
                ProfileResponsiblefordog = "joe",
                ProfileAdoptionreason = "ajklsdhf",
                ProfileDogsleepat = "lakjhf",
                ProfileDogaggresive = "kjahf",
                ProfileMedfordog = "lkjahlfjh",
                ProfileNocaredog = null
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(profile, null, null);
            Assert.False(Validator.TryValidateObject(profile, ctx, validationResults, true));
        }
    }
}
