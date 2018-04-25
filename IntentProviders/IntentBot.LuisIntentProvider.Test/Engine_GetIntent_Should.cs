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
        [Fact]
        public async void NotFailWhenParsingATripReportTimeQuery()
        {
            string json = "{ \"query\": \"when do I report for trip 12130\", \"topScoringIntent\": { \"intent\": \"TripReportTimeQuery\", \"score\": 0.9738498 }, \"intents\": [ {	 \"intent\": \"TripReportTimeQuery\",	 \"score\": 0.9738498 }, {	 \"intent\": \"NextReportTimeQuery\",	 \"score\": 0.0915000439 }, {	 \"intent\": \"EtbLayoverQuery\",	 \"score\": 0.003221945 }, {	 \"intent\": \"None\",	 \"score\": 0.00199040025 }, {	 \"intent\": \"Help\",	 \"score\": 0.00189759035 }, {	 \"intent\": \"Communication.Confirm\",	 \"score\": 0.000813062768 }, {	 \"intent\": \"Greeting\",	 \"score\": 0.000499124755 }, {	 \"intent\": \"GlobalThermonuclearWar\",	 \"score\": 0.000290831376 }, {	 \"intent\": \"Decline\",	 \"score\": 6.378161E-05 } ], \"entities\": [ {	 \"entity\": \"12130\",	 \"type\": \"TripCode\",	 \"startIndex\": 26,	 \"endIndex\": 30,	 \"score\": 0.994951665 } ]}";

            var httpProxy = new Mock<IHttpProxy>();
            var httpResponseMessage = new Mock<IHttpResponseMessage>();

            httpProxy.Setup(h => h.GetAsync(It.IsAny<string>(), It.IsAny<IEnumerable<KeyValuePair<string, string>>>())).Returns(Task.Run(() => httpResponseMessage.Object));
            httpResponseMessage.SetupGet(h => h.Content).Returns(json);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IHttpProxy>(c => httpProxy.Object);

            var target = new Engine(serviceCollection.BuildServiceProvider(), string.Empty, string.Empty, string.Empty);
            var actual = await target.GetIntentAsync(string.Empty);
        }

        [Fact]
        public async void NotFailWhenParsingANextReportTimeQuery()
        {
            string json = "{ \"query\": \"when do I next report\", \"topScoringIntent\": { \"intent\": \"NextReportTimeQuery\", \"score\": 0.9587233 }, \"intents\": [ { \"intent\": \"NextReportTimeQuery\", \"score\": 0.9587233 }, { \"intent\": \"TripReportTimeQuery\", \"score\": 0.0781200454 }, { \"intent\": \"Communication.Confirm\", \"score\": 0.00163602247 }, { \"intent\": \"Decline\", \"score\": 0.00125440944 }, { \"intent\": \"Help\", \"score\": 0.00100284349 }, { \"intent\": \"GlobalThermonuclearWar\", \"score\": 0.0009988329 }, { \"intent\": \"Greeting\", \"score\": 0.0008735161 }, { \"intent\": \"None\", \"score\": 0.000414807146 }, { \"intent\": \"EtbLayoverQuery\", \"score\": 6.778803E-05 } ], \"entities\": []}";

            var httpProxy = new Mock<IHttpProxy>();
            var httpResponseMessage = new Mock<IHttpResponseMessage>();

            httpProxy.Setup(h => h.GetAsync(It.IsAny<string>(), It.IsAny<IEnumerable<KeyValuePair<string, string>>>())).Returns(Task.Run(() => httpResponseMessage.Object));
            httpResponseMessage.SetupGet(h => h.Content).Returns(json);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IHttpProxy>(c => httpProxy.Object);

            var target = new Engine(serviceCollection.BuildServiceProvider(), string.Empty, string.Empty, string.Empty);
            var actual = await target.GetIntentAsync(string.Empty);
        }

        [Fact]
        public async void NotFailWhenParsingAKCMQuery()
        {
            string json = "{ \"query\": \"Where is kcm at yyz\", \"topScoringIntent\": { \"intent\": \"None\", \"score\": 0.06356882 }, \"intents\": [ { \"intent\": \"None\", \"score\": 0.06356882 }, { \"intent\": \"EtbLayoverQuery\", \"score\": 0.03482501 }, { \"intent\": \"Help\", \"score\": 0.0162989683 }, { \"intent\": \"Greeting\", \"score\": 0.0103316018 }, { \"intent\": \"NextReportTimeQuery\", \"score\": 0.009379909 }, { \"intent\": \"Communication.Confirm\", \"score\": 0.00361752254 }, { \"intent\": \"TripReportTimeQuery\", \"score\": 0.0030851746 }, { \"intent\": \"GlobalThermonuclearWar\", \"score\": 0.00274142949 }, { \"intent\": \"Decline\", \"score\": 0.000870318443 } ], \"entities\": [ { \"entity\": \"yyz\", \"type\": \"StationCode\", \"startIndex\": 16, \"endIndex\": 18, \"resolution\": { \"values\": [ \"YYZ\" ] } } ]}";

            var httpProxy = new Mock<IHttpProxy>();
            var httpResponseMessage = new Mock<IHttpResponseMessage>();

            httpProxy.Setup(h => h.GetAsync(It.IsAny<string>(), It.IsAny<IEnumerable<KeyValuePair<string, string>>>())).Returns(Task.Run(() => httpResponseMessage.Object));
            httpResponseMessage.SetupGet(h => h.Content).Returns(json);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IHttpProxy>(c => httpProxy.Object);

            var target = new Engine(serviceCollection.BuildServiceProvider(), string.Empty, string.Empty, string.Empty);
            var actual = await target.GetIntentAsync(string.Empty);
        }
    }
}
