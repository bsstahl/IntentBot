using IntentBot.Entities;
using System;
using System.Linq;
using TestHelperExtensions;
using Xunit;

namespace IntentBot.Test
{
    public class Builder_Build_Should
    {
        [Fact]
        public void ReturnAnIntentInstance()
        {
            var target = new IntentBuilder();
            var actual = target.Build();
            Assert.NotNull(actual);
        }

        [Fact]
        public void ReturnADefaultIntentIfNoBuilderMethodsAreCalled()
        {
            var target = new IntentBuilder();
            var actual = target.Build();

            Assert.Equal(string.Empty, actual.Name);
            Assert.Equal(0.0, actual.Score);
            Assert.Equal(string.Empty, actual.Utterance);
            Assert.Equal(string.Empty, actual.IntentResponse);
            Assert.Empty(actual.IntentEntities);
        }

        [Fact]
        public void ReturnAnIntentWithAName()
        {
            string expected = string.Empty.GetRandom();
            var target = new IntentBuilder();
            var actual = target.AddName(expected).Build();
            Assert.Equal(expected, actual.Name);
        }

        [Fact]
        public void ReturnAnIntentWithAnUtterance()
        {
            string expected = string.Empty.GetRandom();
            var target = new IntentBuilder();
            var actual = target.AddUtterance(expected).Build();
            Assert.Equal(expected, actual.Utterance);
        }

        [Fact]
        public void ReturnAnIntentWithAResponse()
        {
            string expected = string.Empty.GetRandom();
            var target = new IntentBuilder();
            var actual = target.AddResponse(expected).Build();
            Assert.Equal(expected, actual.IntentResponse);
        }

        [Fact]
        public void ReturnAnIntentWithAScore()
        {
            double expected = (1.0).GetRandom();
            var target = new IntentBuilder();
            var actual = target.AddScore(expected).Build();
            Assert.Equal(expected, actual.Score);
        }

        [Fact]
        public void ReturnAnIntentWithAnEntity()
        {
            string expectedName = string.Empty.GetRandom();
            string expectedType = string.Empty.GetRandom();

            var target = new IntentBuilder();
            var actual = target
                .AddEntity(expectedName, expectedType)
                .Build();

            var actualEntity = actual.IntentEntities.Single();
            Assert.Equal(expectedName, actualEntity.Name);
            Assert.Equal(expectedType, actualEntity.Type);
        }

        [Fact]
        public void ReturnAnIntentWithTwoEntities()
        {
            string expectedName1 = string.Empty.GetRandom();
            string expectedType1 = string.Empty.GetRandom();
            string expectedName2 = string.Empty.GetRandom();
            string expectedType2 = string.Empty.GetRandom();

            var target = new IntentBuilder();
            var actual = target
                .AddEntity(expectedName1, expectedType1)
                .AddEntity(expectedName2, expectedType2)
                .Build();

            var actualEntity1 = actual.IntentEntities.Single(e => e.Type == expectedType1);
            var actualEntity2 = actual.IntentEntities.Single(e => e.Type == expectedType2);

            Assert.Equal(expectedName1, actualEntity1.Name);
            Assert.Equal(expectedName2, actualEntity2.Name);
        }

        [Fact]
        public void ReturnAnIntentWithANameAndUtterance()
        {
            string expectedName = string.Empty.GetRandom();
            string expectedUtterance = string.Empty.GetRandom();

            var target = new IntentBuilder();
            var actual = target.AddUtterance(expectedUtterance)
                .AddName(expectedName).Build();

            Assert.Equal(expectedUtterance, actual.Utterance);
            Assert.Equal(expectedName, actual.Name);
        }

        [Fact]
        public void ReturnAnIntentWithAnUtteranceAndName()
        {
            string expectedName = string.Empty.GetRandom();
            string expectedUtterance = string.Empty.GetRandom();

            var target = new IntentBuilder();
            var actual = target.AddName(expectedName)
                .AddUtterance(expectedUtterance).Build();

            Assert.Equal(expectedName, actual.Name);
            Assert.Equal(expectedUtterance, actual.Utterance);
        }

        [Fact]
        public void ReturnAnIntentWithANameUtteranceAndResponse()
        {
            string expectedName = string.Empty.GetRandom();
            string expectedUtterance = string.Empty.GetRandom();
            string expectedResponse = string.Empty.GetRandom();

            var target = new IntentBuilder();
            var actual = target.AddUtterance(expectedUtterance)
                .AddName(expectedName)
                .AddResponse(expectedResponse).Build();

            Assert.Equal(expectedUtterance, actual.Utterance);
            Assert.Equal(expectedName, actual.Name);
            Assert.Equal(expectedResponse, actual.IntentResponse);
        }

        [Fact]
        public void ReturnAnIntentWithANameUtteranceResponseAndScore()
        {
            string expectedName = string.Empty.GetRandom();
            string expectedUtterance = string.Empty.GetRandom();
            string expectedResponse = string.Empty.GetRandom();
            double expectedScore = (1.0).GetRandom();

            var target = new IntentBuilder();
            var actual = target.AddUtterance(expectedUtterance)
                .AddName(expectedName)
                .AddResponse(expectedResponse)
                .AddScore(expectedScore).Build();

            Assert.Equal(expectedUtterance, actual.Utterance);
            Assert.Equal(expectedName, actual.Name);
            Assert.Equal(expectedResponse, actual.IntentResponse);
            Assert.Equal(expectedScore, actual.Score);
        }

        [Fact]
        public void ReturnAFullyPopulatedIntentIfRandomIsCalled()
        {
            var target = new IntentBuilder();
            var actual = target.Random().Build();

            Assert.NotEqual(string.Empty, actual.Name);
            Assert.NotEqual(0.0, actual.Score);
            Assert.NotEqual(string.Empty, actual.Utterance);
            Assert.NotEqual(string.Empty, actual.IntentResponse);
            Assert.NotEmpty(actual.IntentEntities);
        }

        [Fact]
        public void ReturnAFullyPopulatedIntentIfAddAllIsCalled()
        {
            string expectedName = string.Empty.GetRandom();
            string expectedUtterance = string.Empty.GetRandom();
            string expectedResponse = string.Empty.GetRandom();
            double expectedScore = (0.99).GetRandom();
            IntentEntity expectedEntity1 = new IntentEntity() { Name = string.Empty.GetRandom(), Type = string.Empty.GetRandom() };
            IntentEntity expectedEntity2 = new IntentEntity() { Name = string.Empty.GetRandom(), Type = string.Empty.GetRandom() };

            var target = new IntentBuilder();
            var actual = target
                .AddAll(expectedName, expectedScore,
                    expectedUtterance, expectedResponse,
                    expectedEntity1, expectedEntity2)
                .Build();

            Assert.Equal(expectedName, actual.Name);
            Assert.Equal(expectedScore, actual.Score);
            Assert.Equal(expectedUtterance, actual.Utterance);
            Assert.Equal(expectedResponse, actual.IntentResponse);
            Assert.Equal(2, actual.IntentEntities.Count());
            Assert.Equal(expectedEntity1.Name, actual.IntentEntities.Single(e => e.Type == expectedEntity1.Type).Name);
            Assert.Equal(expectedEntity2.Name, actual.IntentEntities.Single(e => e.Type == expectedEntity2.Type).Name);
        }
    }
}