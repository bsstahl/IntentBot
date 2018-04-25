using IntentBot.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Moq;
using System.Collections.Generic;

namespace IntentBot.LuisIntentProvider.Test
{
    public class Engine_GetIntent_Should
    {
        const string _locationQueryJson = "{ \"query\": \"Where are you located at yyz\", \"topScoringIntent\": { \"intent\": \"LocationQuery\", \"score\": 0.63568802 }, \"intents\": [{ \"intent\": \"LocationQuery\", \"score\": 0.63568802 }, { \"intent\": \"None\", \"score\": 0.03482501 }, { \"intent\": \"Help\", \"score\": 0.0162989683 }, { \"intent\": \"Greeting\", \"score\": 0.0103316018 }, { \"intent\": \"Communication.Confirm\", \"score\": 0.00361752254 }, { \"intent\": \"GlobalThermonuclearWar\", \"score\": 0.00274142949 }, { \"intent\": \"Decline\", \"score\": 0.000870318443 }], \"entities\": [{ \"entity\": \"yyz\", \"type\": \"StationCode\", \"startIndex\": 16, \"endIndex\": 18, \"resolution\": { \"values\": [\"YYZ\"] } }]}";
        const string _activityTimeQueryJson = "{ \"query\": \"when do I have to arrive for activity 12130\", \"topScoringIntent\": { \"intent\": \"ActivityTimeQuery\", \"score\": 0.9738498 }, \"intents\": [{ \"intent\": \"ActivityTimeQuery\", \"score\": 0.9738498 }, { \"intent\": \"None\", \"score\": 0.00199040025 }, { \"intent\": \"Help\", \"score\": 0.00189759035 }, { \"intent\": \"Communication.Confirm\", \"score\": 0.000813062768 }, { \"intent\": \"Greeting\", \"score\": 0.000499124755 }, { \"intent\": \"GlobalThermonuclearWar\", \"score\": 0.000290831376 }, { \"intent\": \"Decline\", \"score\": 6.378161E-05 }], \"entities\": [{ \"entity\": \"12130\", \"type\": \"ActivityCode\", \"startIndex\": 26, \"endIndex\": 30, \"score\": 0.994951665 }]}";
        const string _nextWorkTimeQueryJson = "{ \"query\": \"when do I next have to be at work\", \"topScoringIntent\": { \"intent\": \"NextWorkTimeQuery\", \"score\": 0.9587233 }, \"intents\": [{ \"intent\": \"NextWorkTimeQuery\", \"score\": 0.9587233 }, { \"intent\": \"Communication.Confirm\", \"score\": 0.00163602247 }, { \"intent\": \"Decline\", \"score\": 0.00125440944 }, { \"intent\": \"Help\", \"score\": 0.00100284349 }, { \"intent\": \"GlobalThermonuclearWar\", \"score\": 0.0009988329 }, { \"intent\": \"Greeting\", \"score\": 0.0008735161 }, { \"intent\": \"None\", \"score\": 0.000414807146 }], \"entities\": []}";


        [Fact]
        public async void NotFailWhenParsingAnActivityTimeQuery()
        {
            var httpProxy = new Mock<IHttpProxy>();
            var httpResponseMessage = new Mock<IHttpResponseMessage>();

            httpProxy.Setup(h => h.GetAsync(It.IsAny<string>(), It.IsAny<IEnumerable<KeyValuePair<string, string>>>())).Returns(Task.Run(() => httpResponseMessage.Object));
            httpResponseMessage.SetupGet(h => h.Content).Returns(_activityTimeQueryJson);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IHttpProxy>(c => httpProxy.Object);

            var target = new Engine(serviceCollection.BuildServiceProvider(), string.Empty, string.Empty, string.Empty);
            var actual = await target.GetIntentAsync(string.Empty);
        }

        [Fact]
        public async void NotFailWhenParsingANextWorkTimeQuery()
        {
            var httpProxy = new Mock<IHttpProxy>();
            var httpResponseMessage = new Mock<IHttpResponseMessage>();

            httpProxy.Setup(h => h.GetAsync(It.IsAny<string>(), It.IsAny<IEnumerable<KeyValuePair<string, string>>>())).Returns(Task.Run(() => httpResponseMessage.Object));
            httpResponseMessage.SetupGet(h => h.Content).Returns(_nextWorkTimeQueryJson);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IHttpProxy>(c => httpProxy.Object);

            var target = new Engine(serviceCollection.BuildServiceProvider(), string.Empty, string.Empty, string.Empty);
            var actual = await target.GetIntentAsync(string.Empty);
        }

        [Fact]
        public async void NotFailWhenParsingALocationQuery()
        {
            var httpProxy = new Mock<IHttpProxy>();
            var httpResponseMessage = new Mock<IHttpResponseMessage>();

            httpProxy.Setup(h => h.GetAsync(It.IsAny<string>(), It.IsAny<IEnumerable<KeyValuePair<string, string>>>())).Returns(Task.Run(() => httpResponseMessage.Object));
            httpResponseMessage.SetupGet(h => h.Content).Returns(_locationQueryJson);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IHttpProxy>(c => httpProxy.Object);

            var target = new Engine(serviceCollection.BuildServiceProvider(), string.Empty, string.Empty, string.Empty);
            var actual = await target.GetIntentAsync(string.Empty);
        }

        [Fact]
        public async void ReturnTheProperEntityNameForAnActivityTimeQuery()
        {
            var httpProxy = new Mock<IHttpProxy>();
            var httpResponseMessage = new Mock<IHttpResponseMessage>();

            httpProxy.Setup(h => h.GetAsync(It.IsAny<string>(), It.IsAny<IEnumerable<KeyValuePair<string, string>>>())).Returns(Task.Run(() => httpResponseMessage.Object));
            httpResponseMessage.SetupGet(h => h.Content).Returns(_activityTimeQueryJson);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IHttpProxy>(c => httpProxy.Object);

            var target = new Engine(serviceCollection.BuildServiceProvider(), string.Empty, string.Empty, string.Empty);
            var actual = await target.GetIntentAsync(string.Empty);
            Assert.Equal("12130", actual.IntentEntities.Single(e => e.Type.ToLower() == "activitycode").Name);
        }

        [Fact]
        public async void ReturnTheProperEntityValueForALocationQuery()
        {
            var httpProxy = new Mock<IHttpProxy>();
            var httpResponseMessage = new Mock<IHttpResponseMessage>();

            httpProxy.Setup(h => h.GetAsync(It.IsAny<string>(), It.IsAny<IEnumerable<KeyValuePair<string, string>>>())).Returns(Task.Run(() => httpResponseMessage.Object));
            httpResponseMessage.SetupGet(h => h.Content).Returns(_locationQueryJson);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IHttpProxy>(c => httpProxy.Object);

            var target = new Engine(serviceCollection.BuildServiceProvider(), string.Empty, string.Empty, string.Empty);
            var actual = await target.GetIntentAsync(string.Empty);
            Assert.Equal("yyz", actual.IntentEntities.Single(e => e.Type.ToLower() == "stationcode").Name);
        }
    }
}
