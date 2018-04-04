using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestHelperExtensions;
using Xunit;

namespace IntentBot.Test
{
    public class RouteCollectionBuilder_Build_Should
    {
        [Fact]
        public void ReturnACollectionWithARouteWithTheSpecifiedName()
        {
            string expectedName = string.Empty.GetRandom();
            string expectedUri = $"http://{string.Empty.GetRandom()}";

            var target = new RouteCollectionBuilder(string.Empty.GetRandom());
            var actual = target
                .Add(expectedName, expectedUri)
                .Build();

            Assert.Equal(1, actual.Count(c => c.IntentName == expectedName));
        }

        [Fact]
        public void ReturnACollectionWithARouteWithTheSpecifiedNameSubmittedAsObject()
        {
            string expectedName = string.Empty.GetRandom();
            string expectedUri = $"http://{string.Empty.GetRandom()}";
            var newRoute = new Entities.IntentRoute() { IntentName = expectedName, Uri = expectedUri };

            var target = new RouteCollectionBuilder(string.Empty.GetRandom());
            var actual = target
                .Add(newRoute)
                .Build();

            Assert.Equal(1, actual.Count(c => c.IntentName == expectedName));
        }

        [Fact]
        public void ReturnACollectionWithTheCorrectNumberOfRoutes()
        {
            var expectedCount = 99.GetRandom(3);

            var target = new RouteCollectionBuilder(string.Empty.GetRandom());
            for (int i = 0; i < expectedCount; i++)
            {
                target.Add(string.Empty.GetRandom(), string.Empty.GetRandom());
            }

            var actual = target.Build();
            Assert.Equal(expectedCount + 1, actual.Count());
        }

        [Fact]
        public void ReturnACollectionWithTheCorrectNumberOfRoutesSubmittedInDifferentWays()
        {
            var halfExpectedCount = 99.GetRandom(3);

            var target = new RouteCollectionBuilder(string.Empty.GetRandom());
            for (int i = 0; i < halfExpectedCount; i++)
            {
                target.Add(string.Empty.GetRandom(), string.Empty.GetRandom());
                target.Add(new Entities.IntentRoute() { IntentName = string.Empty.GetRandom(), Uri = string.Empty.GetRandom() });
            }

            var actual = target.Build();
            Assert.Equal((halfExpectedCount * 2) + 1, actual.Count());
        }

        [Fact]
        public void ReturnTheCorrectUriForTheRouteWithTheSpecifiedName()
        {
            string expectedName = string.Empty.GetRandom();
            string expectedUri = $"http://{string.Empty.GetRandom()}";

            var target = new RouteCollectionBuilder(string.Empty.GetRandom());
            var actual = target
                .Add(expectedName, expectedUri)
                .Build();

            var actualRoute = actual.Single(c => c.IntentName == expectedName);
            Assert.Equal(expectedUri, actualRoute.Uri);
        }

        [Fact]
        public void ReturnTheCorrectUriForTheRouteWithTheSpecifiedNameSubmittedAsObject()
        {
            string expectedName = string.Empty.GetRandom();
            string expectedUri = $"http://{string.Empty.GetRandom()}";
            var newRoute = new Entities.IntentRoute() { IntentName = expectedName, Uri = expectedUri };

            var target = new RouteCollectionBuilder(string.Empty.GetRandom());
            var actual = target
                .Add(newRoute)
                .Build();

            var actualRoute = actual.Single(c => c.IntentName == expectedName);
            Assert.Equal(expectedUri, actualRoute.Uri);
        }

        [Fact]
        public void ReturnTheCorrectUriForARouteInTheMiddleOfALargeNumberOfRoutes()
        {
            var expectedCountPart1 = 99.GetRandom(3);
            var expectedCountPart2 = 99.GetRandom(3);
            var expectedCountPart3 = 99.GetRandom(3);

            string expectedName1 = string.Empty.GetRandom();
            string expectedName2 = string.Empty.GetRandom();

            string expectedUri1 = $"http://{string.Empty.GetRandom()}";
            string expectedUri2 = $"http://{string.Empty.GetRandom()}";

            var target = new RouteCollectionBuilder(string.Empty.GetRandom());
            for (int i = 0; i < expectedCountPart1; i++)
            {
                target.Add(string.Empty.GetRandom(), string.Empty.GetRandom());
                target.Add(new Entities.IntentRoute() { IntentName = string.Empty.GetRandom(), Uri = string.Empty.GetRandom() });
            }

            target.Add(new Entities.IntentRoute() { IntentName = expectedName1, Uri = expectedUri1 });

            for (int i = 0; i < expectedCountPart2; i++)
            {
                target.Add(new Entities.IntentRoute() { IntentName = string.Empty.GetRandom(), Uri = string.Empty.GetRandom() });
                target.Add(string.Empty.GetRandom(), string.Empty.GetRandom());
            }

            target.Add(expectedName2, expectedUri2);

            for (int i = 0; i < expectedCountPart2; i++)
            {
                target.Add(new Entities.IntentRoute() { IntentName = string.Empty.GetRandom(), Uri = string.Empty.GetRandom() });
                target.Add(string.Empty.GetRandom(), string.Empty.GetRandom());
            }

            var actual = target.Build();

            Assert.Equal(expectedUri1, actual.Single(c => c.IntentName == expectedName1).Uri);
            Assert.Equal(expectedUri2, actual.Single(c => c.IntentName == expectedName2).Uri);
        }

        [Fact]
        public void ThrowsADuplicateRouteExceptionIfADuplicateNameIsAdded()
        {
            string expectedName = string.Empty.GetRandom();

            var target = new RouteCollectionBuilder(string.Empty.GetRandom());

            Assert.Throws<Exceptions.DuplicateRouteException>(() =>
            target
                .Add(new Entities.IntentRoute() { IntentName = expectedName, Uri = string.Empty.GetRandom() })
                .Add(string.Empty.GetRandom(), string.Empty.GetRandom())
                .Add(expectedName, string.Empty.GetRandom())
                .Build());
        }

        [Fact]
        public void ThrowsADuplicateRouteExceptionIfADuplicateNameIsSubmittedUsingObject()
        {
            string expectedName = string.Empty.GetRandom();

            var target = new RouteCollectionBuilder(string.Empty.GetRandom());

            Assert.Throws<Exceptions.DuplicateRouteException>(() =>
            target
                .Add(expectedName, string.Empty.GetRandom())
                .Add(string.Empty.GetRandom(), string.Empty.GetRandom())
                .Add(new Entities.IntentRoute() { IntentName = expectedName, Uri = string.Empty.GetRandom() })
                .Build());
        }

        [Fact]
        public void ThrowsADuplicateRouteExceptionIfAnotherRouteNamedDefaultIsAdded()
        {
            var target = new RouteCollectionBuilder(string.Empty.GetRandom());

            Assert.Throws<Exceptions.DuplicateRouteException>(() =>
            target
                .Add(string.Empty.GetRandom(), string.Empty.GetRandom())
                .Add("default", string.Empty.GetRandom())
                .Build());
        }
    }
}
