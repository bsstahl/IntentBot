using System;
using Xunit;
using TestHelperExtensions;
using System.Linq;

namespace IntentBot.Test
{
    public class UserRequestBuilder_Build_Should
    {
        [Fact]
        public void ReturnAValidInstance()
        {
            var actual = new UserRequestBuilder().Build();
            Assert.NotNull(actual);
        }

        [Fact]
        public void ReturnTheCurrentUtcDateTimeByDefault()
        {
            var actual = new UserRequestBuilder().Build();
            Assert.Equal(DateTime.UtcNow.ToMinutePrecision(), actual.RequestDateTimeUtc.ToMinutePrecision());
        }

        [Fact]
        public void ReturnAUserRequestWithTheSpecifiedIntent()
        {
            var intent = new IntentBuilder().Random().Build();
            var actual = new UserRequestBuilder().AddIntent(intent).Build();
            Assert.Equal(intent.Name, actual.Intent.Name);
        }

        [Fact]
        public void ReturnAUserRequestWithTheSpecifiedSource()
        {
            string expected = string.Empty.GetRandom();
            var actual = new UserRequestBuilder().AddSource(expected).Build();
            Assert.Equal(expected, actual.Source);
        }

        [Fact]
        public void ReturnAUserRequestWithTheSpecifiedDateTime()
        {
            DateTime expected = DateTime.MaxValue.GetRandom().ToMinutePrecision();
            var actual = new UserRequestBuilder().AddRequestUtcDateTime(expected).Build();
            Assert.Equal(expected, actual.RequestDateTimeUtc);
        }

        [Fact]
        public void ReturnAUserRequestWithTheSpecifiedUser()
        {
            var expected = (new UserBuilder().Random().Build());
            var actual = new UserRequestBuilder().AddUser(expected).Build();
            Assert.Equal(expected.Id, actual.User.Id);
            Assert.Equal(expected.FirstName, actual.User.FirstName);
            Assert.Equal(expected.LastName, actual.User.LastName);
            Assert.Equal(expected.AdditionalData.Count(), actual.User.AdditionalData.Count());
        }

        [Fact]
        public void ReturnAFullyPopulatedInstanceIfRandomIsSpecified()
        {
            var actual = new UserRequestBuilder().Random().Build();
            Assert.NotNull(actual.User);
            Assert.False(string.IsNullOrWhiteSpace(actual.Source));
            Assert.NotEqual(DateTime.MinValue, actual.RequestDateTimeUtc);
            Assert.NotNull(actual.Intent);
        }

    }
}
