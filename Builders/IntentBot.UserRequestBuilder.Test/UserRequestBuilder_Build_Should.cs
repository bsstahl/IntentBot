using System;
using Xunit;
using TestHelperExtensions;

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
        public void ReturnAUserRequestWithTheSpecifiedUserId()
        {
            string expectedId = string.Empty.GetRandom();
            string expectedBase = string.Empty.GetRandom(3);

            var user = new Entities.User() { Id = expectedId, BaseCode = expectedBase };
            var actual = new UserRequestBuilder().AddUser(user).Build();

            Assert.Equal(expectedId, actual.User.Id);
        }

        [Fact]
        public void ReturnAUserRequestWithTheSpecifiedUserBaseCode()
        {
            string expectedId = string.Empty.GetRandom();
            string expectedBase = string.Empty.GetRandom(3);

            var user = new Entities.User() { Id = expectedId, BaseCode = expectedBase };
            var actual = new UserRequestBuilder().AddUser(user).Build();

            Assert.Equal(expectedBase, actual.User.BaseCode);
        }

        [Fact]
        public void ReturnAUserRequestWithTheSpecifiedUserIdIfElementsAreAddedIndividually()
        {
            string expectedId = string.Empty.GetRandom();
            string expectedBase = string.Empty.GetRandom(3);

            var actual = new UserRequestBuilder().AddUser(expectedId, expectedBase).Build();

            Assert.Equal(expectedId, actual.User.Id);
        }

        [Fact]
        public void ReturnAUserRequestWithTheSpecifiedUserBaseCodeIfElementsAreAddedIndividually()
        {
            string expectedId = string.Empty.GetRandom();
            string expectedBase = string.Empty.GetRandom(3);

            var actual = new UserRequestBuilder().AddUser(expectedId, expectedBase).Build();

            Assert.Equal(expectedBase, actual.User.BaseCode);
        }

        [Fact]
        public void ReturnAUserRequestWithTheSpecifiedDateTime()
        {
            DateTime expected = DateTime.MaxValue.GetRandom().ToMinutePrecision();
            var actual = new UserRequestBuilder().AddRequestUtcDateTime(expected).Build();
            Assert.Equal(expected, actual.RequestDateTimeUtc);
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
