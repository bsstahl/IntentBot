using System;
using System.Linq;
using TestHelperExtensions;
using Xunit;

namespace IntentBot.Test
{
    public class UserBuilder_Build_Should
    {
        [Fact]
        public void ReturnAValidInstance()
        {
            var actual = new UserBuilder().Build();
            Assert.NotNull(actual);
        }

        [Fact]
        public void ReturnAnEmptyIdIfNoneIsSpecified()
        {
            var actual = new UserBuilder().Build();
            Assert.True(string.IsNullOrEmpty(actual.Id));
        }

        [Fact]
        public void ReturnAnEmptyFirstNameIfNoneIsSpecified()
        {
            var actual = new UserBuilder().Build();
            Assert.True(string.IsNullOrEmpty(actual.FirstName));
        }

        [Fact]
        public void ReturnAnEmptyLastNameIfNoneIsSpecified()
        {
            var actual = new UserBuilder().Build();
            Assert.True(string.IsNullOrEmpty(actual.LastName));
        }

        [Fact]
        public void ReturnAnEmptyAdditionalDataCollectionIfNoneAreSpecified()
        {
            var actual = new UserBuilder().Build();
            Assert.Empty(actual.AdditionalData);
        }

        [Fact]
        public void ReturnTheIdIfOneIsSpecified()
        {
            var expected = string.Empty.GetRandom();
            var actual = new UserBuilder().AddId(expected).Build();
            Assert.Equal(expected, actual.Id);
        }

        [Fact]
        public void ReturnTheFirstNameIfOneIsSpecified()
        {
            var expected = string.Empty.GetRandom();
            var actual = new UserBuilder().AddFirstName(expected).Build();
            Assert.Equal(expected, actual.FirstName);
        }

        [Fact]
        public void ReturnTheLastNameIfOneIsSpecified()
        {
            var expected = string.Empty.GetRandom();
            var actual = new UserBuilder().AddLastName(expected).Build();
            Assert.Equal(expected, actual.LastName);
        }

        [Fact]
        public void ReturnTheFirstAndLastNameIfBothAreSpecifiedTogether()
        {
            var expectedFirstName = string.Empty.GetRandom();
            var expectedLastName = string.Empty.GetRandom();
            var actual = new UserBuilder().AddName(expectedFirstName, expectedLastName).Build();
            Assert.Equal(expectedFirstName, actual.FirstName);
            Assert.Equal(expectedLastName, actual.LastName);
        }

        [Fact]
        public void ReturnTheCorrectNumberOfAdditionalDataItems()
        {
            int expectedCount = 255.GetRandom(3);
            var builder = new UserBuilder();
            for (int i = 0; i < expectedCount; i++)
                builder.AddAdditionalDataItem(string.Empty.GetRandom(), string.Empty.GetRandom());
            var actual = builder.Build();
            Assert.Equal(expectedCount, actual.AdditionalData.Count());
        }

        [Fact]
        public void ReturnTheCorrectValueForAnAdditionalDataItemKey()
        {
            var expectedKey = string.Empty.GetRandom();
            var expectedValue = string.Empty.GetRandom();

            var builder = new UserBuilder();
            for (int i = 0; i < 10.GetRandom(3); i++)
                builder.AddAdditionalDataItem(string.Empty.GetRandom(), string.Empty.GetRandom());
            builder.AddAdditionalDataItem(expectedKey, expectedValue);
            for (int i = 0; i < 10.GetRandom(3); i++)
                builder.AddAdditionalDataItem(string.Empty.GetRandom(), string.Empty.GetRandom());
            var actual = builder.Build();
            var result = actual.AdditionalData.Where(d => d.Key == expectedKey).Single();
            Assert.Equal(expectedValue, result.Value);
        }

        [Fact]
        public void ReturnAFullyPopulatedInstanceIfRandomIsSpecified()
        {
            var actual = new UserBuilder().Random().Build();
            Assert.False(string.IsNullOrWhiteSpace(actual.Id));
            Assert.False(string.IsNullOrWhiteSpace(actual.FirstName));
            Assert.False(string.IsNullOrWhiteSpace(actual.LastName));
            Assert.True(actual.AdditionalData.Any());
        }

    }
}
