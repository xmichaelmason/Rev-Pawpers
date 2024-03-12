using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models;
using Xunit;

namespace UnitTest
{
    public class RepliesValidation
    {
        [Fact]
        public void ReplyMessageRequired()
        {
            var reply = new Reply
            {
                ReplyMessage = null,
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(reply, null, null);
            Assert.False(Validator.TryValidateObject(reply, ctx, validationResults, true));
        }
    }
}
