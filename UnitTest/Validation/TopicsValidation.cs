using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models;
using Xunit;

namespace UnitTest
{
    public class TopicsValidation
    {
        [Fact]
        public void TopicNameRequired()
        {
            var topic = new Topic
            {
                TopicName = null,
                TopicBody = "jkhakf",
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(topic, null, null);
            Assert.False(Validator.TryValidateObject(topic, ctx, validationResults, true));
        }

        [Fact]
        public void TopicBodyRequired()
        {
            var topic = new Topic
            {
                TopicName = "lkahfsjlahf",
                TopicBody = null,
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(topic, null, null);
            Assert.False(Validator.TryValidateObject(topic, ctx, validationResults, true));
        }
    }
}
