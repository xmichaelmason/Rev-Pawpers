using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models;
using Xunit;

namespace UnitTest
{
    public class DwellingsValidation
    {
        [Fact]
        public void TypeRequired()
        {
            var dwelling = new Dwelling
            {
                DwellingType = null,
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(dwelling, null, null);
            Assert.False(Validator.TryValidateObject(dwelling, ctx, validationResults, true));
        }
    }
}
