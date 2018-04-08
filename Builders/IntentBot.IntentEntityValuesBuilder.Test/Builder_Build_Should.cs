using System;
using System.Linq;
using TestHelperExtensions;
using Xunit;

namespace IntentBot.Test
{
    public class Builder_Build_Should
    {
        [Fact]
        public void ReturnAnEmptyListIfNothingHasBeenAdded()
        {
            var target = new IntentEntityValuesBuilder().Build();
            Assert.False(target.Any());
        }

        [Fact]
        public void ReturnAListWithASingleValueIfOneIsAdded()
        {
            string expectedPattern = string.Empty.GetRandom();
            string expectedValueType = string.Empty.GetRandom();
            string expectedValue = string.Empty.GetRandom();

            var target = new IntentEntityValuesBuilder()
                .Add(expectedValueType, expectedValue, expectedPattern)
                .Build();

            Assert.Single(target);
        }

        [Fact]
        public void ReturnAListWithASingleValueAndAnEmptyPatternIfNoPatternIsProvided()
        {
            string expectedValueType = string.Empty.GetRandom();
            string expectedValue = string.Empty.GetRandom();

            var target = new IntentEntityValuesBuilder()
                .Add(expectedValueType, expectedValue)
                .Build();

            var actualValue = target.Single();

            Assert.True(String.IsNullOrWhiteSpace(actualValue.Pattern));
        }

        [Fact]
        public void ReturnAListWithOneInstanceOfTheFirstValue()
        {
            string expectedValueType1 = string.Empty.GetRandom();
            string expectedValue1 = string.Empty.GetRandom();
            string expectedPattern1 = string.Empty.GetRandom();

            string expectedValueType2 = string.Empty.GetRandom();
            string expectedValue2 = string.Empty.GetRandom();
            string expectedPattern2 = string.Empty.GetRandom();

            string expectedValueType3 = string.Empty.GetRandom();
            string expectedValue3 = string.Empty.GetRandom();
            string expectedPattern3 = string.Empty.GetRandom();

            var target = new IntentEntityValuesBuilder()
                .Add(expectedValueType1, expectedValue1, expectedPattern1)
                .Add(expectedValueType2, expectedValue2, expectedPattern2)
                .Add(expectedValueType3, expectedValue3, expectedPattern3)
                .Build();

            var actualValue = target.SingleOrDefault(v => v.Value == expectedValue1);
            Assert.NotNull(actualValue);
        }

        [Fact]
        public void ReturnAListWhereTheFirstValueHasTheCorrectValueType()
        {
            string expectedValueType1 = string.Empty.GetRandom();
            string expectedValue1 = string.Empty.GetRandom();
            string expectedPattern1 = string.Empty.GetRandom();

            string expectedValueType2 = string.Empty.GetRandom();
            string expectedValue2 = string.Empty.GetRandom();
            string expectedPattern2 = string.Empty.GetRandom();

            string expectedValueType3 = string.Empty.GetRandom();
            string expectedValue3 = string.Empty.GetRandom();
            string expectedPattern3 = string.Empty.GetRandom();

            var target = new IntentEntityValuesBuilder()
                .Add(expectedValueType1, expectedValue1, expectedPattern1)
                .Add(expectedValueType2, expectedValue2, expectedPattern2)
                .Add(expectedValueType3, expectedValue3, expectedPattern3)
                .Build();

            var actualValue = target.SingleOrDefault(v => v.Value == expectedValue1);
            Assert.Equal(expectedValueType1, actualValue.ValueType);
        }

        [Fact]
        public void ReturnAListWhereTheFirstValueHasTheCorrectPattern()
        {
            string expectedValueType1 = string.Empty.GetRandom();
            string expectedValue1 = string.Empty.GetRandom();
            string expectedPattern1 = string.Empty.GetRandom();

            string expectedValueType2 = string.Empty.GetRandom();
            string expectedValue2 = string.Empty.GetRandom();
            string expectedPattern2 = string.Empty.GetRandom();

            string expectedValueType3 = string.Empty.GetRandom();
            string expectedValue3 = string.Empty.GetRandom();
            string expectedPattern3 = string.Empty.GetRandom();

            var target = new IntentEntityValuesBuilder()
                .Add(expectedValueType1, expectedValue1, expectedPattern1)
                .Add(expectedValueType2, expectedValue2, expectedPattern2)
                .Add(expectedValueType3, expectedValue3, expectedPattern3)
                .Build();

            var actualValue = target.SingleOrDefault(v => v.Value == expectedValue1);
            Assert.Equal(expectedPattern1, actualValue.Pattern);
        }


        [Fact]
        public void ReturnAListWithOneInstanceOfTheSecondValue()
        {
            string expectedValueType1 = string.Empty.GetRandom();
            string expectedValue1 = string.Empty.GetRandom();
            string expectedPattern1 = string.Empty.GetRandom();

            string expectedValueType2 = string.Empty.GetRandom();
            string expectedValue2 = string.Empty.GetRandom();
            string expectedPattern2 = string.Empty.GetRandom();

            string expectedValueType3 = string.Empty.GetRandom();
            string expectedValue3 = string.Empty.GetRandom();
            string expectedPattern3 = string.Empty.GetRandom();

            var target = new IntentEntityValuesBuilder()
                .Add(expectedValueType1, expectedValue1, expectedPattern1)
                .Add(expectedValueType2, expectedValue2, expectedPattern2)
                .Add(expectedValueType3, expectedValue3, expectedPattern3)
                .Build();

            var actualValue = target.SingleOrDefault(v => v.Value == expectedValue2);
            Assert.NotNull(actualValue);
        }

        [Fact]
        public void ReturnAListWhereTheSecondValueHasTheCorrectValueType()
        {
            string expectedValueType1 = string.Empty.GetRandom();
            string expectedValue1 = string.Empty.GetRandom();
            string expectedPattern1 = string.Empty.GetRandom();

            string expectedValueType2 = string.Empty.GetRandom();
            string expectedValue2 = string.Empty.GetRandom();
            string expectedPattern2 = string.Empty.GetRandom();

            string expectedValueType3 = string.Empty.GetRandom();
            string expectedValue3 = string.Empty.GetRandom();
            string expectedPattern3 = string.Empty.GetRandom();

            var target = new IntentEntityValuesBuilder()
                .Add(expectedValueType1, expectedValue1, expectedPattern1)
                .Add(expectedValueType2, expectedValue2, expectedPattern2)
                .Add(expectedValueType3, expectedValue3, expectedPattern3)
                .Build();

            var actualValue = target.SingleOrDefault(v => v.Value == expectedValue2);
            Assert.Equal(expectedValueType2, actualValue.ValueType);
        }

        [Fact]
        public void ReturnAListWhereTheSecondValueHasTheCorrectPattern()
        {
            string expectedValueType1 = string.Empty.GetRandom();
            string expectedValue1 = string.Empty.GetRandom();
            string expectedPattern1 = string.Empty.GetRandom();

            string expectedValueType2 = string.Empty.GetRandom();
            string expectedValue2 = string.Empty.GetRandom();
            string expectedPattern2 = string.Empty.GetRandom();

            string expectedValueType3 = string.Empty.GetRandom();
            string expectedValue3 = string.Empty.GetRandom();
            string expectedPattern3 = string.Empty.GetRandom();

            var target = new IntentEntityValuesBuilder()
                .Add(expectedValueType1, expectedValue1, expectedPattern1)
                .Add(expectedValueType2, expectedValue2, expectedPattern2)
                .Add(expectedValueType3, expectedValue3, expectedPattern3)
                .Build();

            var actualValue = target.SingleOrDefault(v => v.Value == expectedValue2);
            Assert.Equal(expectedPattern2, actualValue.Pattern);
        }

        [Fact]
        public void ReturnAListWithOneInstanceOfTheThirdValue()
        {
            string expectedValueType1 = string.Empty.GetRandom();
            string expectedValue1 = string.Empty.GetRandom();
            string expectedPattern1 = string.Empty.GetRandom();

            string expectedValueType2 = string.Empty.GetRandom();
            string expectedValue2 = string.Empty.GetRandom();
            string expectedPattern2 = string.Empty.GetRandom();

            string expectedValueType3 = string.Empty.GetRandom();
            string expectedValue3 = string.Empty.GetRandom();
            string expectedPattern3 = string.Empty.GetRandom();

            var target = new IntentEntityValuesBuilder()
                .Add(expectedValueType1, expectedValue1, expectedPattern1)
                .Add(expectedValueType2, expectedValue2, expectedPattern2)
                .Add(expectedValueType3, expectedValue3, expectedPattern3)
                .Build();

            var actualValue = target.SingleOrDefault(v => v.Value == expectedValue3);
            Assert.NotNull(actualValue);
        }

        [Fact]
        public void ReturnAListWhereTheThirdValueHasTheCorrectValueType()
        {
            string expectedValueType1 = string.Empty.GetRandom();
            string expectedValue1 = string.Empty.GetRandom();
            string expectedPattern1 = string.Empty.GetRandom();

            string expectedValueType2 = string.Empty.GetRandom();
            string expectedValue2 = string.Empty.GetRandom();
            string expectedPattern2 = string.Empty.GetRandom();

            string expectedValueType3 = string.Empty.GetRandom();
            string expectedValue3 = string.Empty.GetRandom();
            string expectedPattern3 = string.Empty.GetRandom();

            var target = new IntentEntityValuesBuilder()
                .Add(expectedValueType1, expectedValue1, expectedPattern1)
                .Add(expectedValueType2, expectedValue2, expectedPattern2)
                .Add(expectedValueType3, expectedValue3, expectedPattern3)
                .Build();

            var actualValue = target.SingleOrDefault(v => v.Value == expectedValue3);
            Assert.Equal(expectedValueType3, actualValue.ValueType);
        }

        [Fact]
        public void ReturnAListWhereTheThirdValueHasTheCorrectPattern()
        {
            string expectedValueType1 = string.Empty.GetRandom();
            string expectedValue1 = string.Empty.GetRandom();
            string expectedPattern1 = string.Empty.GetRandom();

            string expectedValueType2 = string.Empty.GetRandom();
            string expectedValue2 = string.Empty.GetRandom();
            string expectedPattern2 = string.Empty.GetRandom();

            string expectedValueType3 = string.Empty.GetRandom();
            string expectedValue3 = string.Empty.GetRandom();
            string expectedPattern3 = string.Empty.GetRandom();

            var target = new IntentEntityValuesBuilder()
                .Add(expectedValueType1, expectedValue1, expectedPattern1)
                .Add(expectedValueType2, expectedValue2, expectedPattern2)
                .Add(expectedValueType3, expectedValue3, expectedPattern3)
                .Build();

            var actualValue = target.SingleOrDefault(v => v.Value == expectedValue3);
            Assert.Equal(expectedPattern3, actualValue.Pattern);
        }


    }
}
