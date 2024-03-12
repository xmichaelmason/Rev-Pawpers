using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models;
using Xunit;

namespace UnitTest
{
    public class CategoriesValidation
    {
        [Fact]
        public void NameRequired()
        {
            var category = new Category
            {
                CategoryName = null,
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(category, null, null);
            Assert.False(Validator.TryValidateObject(category, ctx, validationResults, true));
        }
    }
}
