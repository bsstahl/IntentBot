using System;
using System.Threading.Tasks;
using System.Net.Http;
using Xunit;
using TestHelperExtensions;
using IntentBot.Extensions;

namespace IntentBot.HttpProxy.IntegrationTest
{
    public class Client_PostAsync_Should
    {

        string _baseGoogleUrl = "http://www.google.com";
        string _baseHttpBinUrl = "http://httpbin.org";

        [Fact]
        public async Task ReturnSuccessfullyIfContentIsPosted()
        {
            var target = new Client();
            string expected = string.Empty.GetRandom();
            var postData = expected.AsIHttpContent("application/json");
            var actual = await target.PostAsync($"{_baseHttpBinUrl}/post", postData);
            var resultText = actual.Content;
            Console.WriteLine(resultText);
            Assert.True(actual.IsSuccessStatusCode);
        }

        [Fact]
        public async Task PostTheSpecifiedContent()
        {
            var target = new Client();
            string expected = string.Empty.GetRandom();
            var postData = expected.AsIHttpContent("application/json");
            var actual = await target.PostAsync($"{_baseHttpBinUrl}/post", postData);
            var resultText = actual.Content;
            Console.WriteLine(resultText);
            Assert.Contains(expected, resultText);
        }

        [Fact]
        public async Task PostToTheAuthService()
        {
            string testUrl = "http://TestAuthService.cfapps.io/chatbot/values";
            string requestData = "{\"ChannelName\": \"slack\", \"UniqueName\": \"barry.stahl\"}";
            string expectedContent = "stahl";

            var target = new Client();
            var postData = requestData.AsIHttpContent("", "application/json");
            var actual = await target.PostAsync(testUrl, postData);

            var resultText = actual.Content;
            Console.WriteLine(resultText);
            Assert.Contains(expectedContent, resultText);
        }

        [Fact]
        public async Task PostToATargetService()
        {
            // string testUrl = "http://test-nextreporttimeservice.cfapps.io/";
            string testUrl = "http://localhost:50294/";
            string requestData = "{ \"User\": { \"Id\": \"100370\", \"FirstName\": \"Barry\", \"LastName\": \"Stahl\", \"AdditionalData\": null }, \"Intent\": { \"Name\": \"NextReportTimeQuery\", \"Score\": 0.95822387933731079, \"Lead\": 0.72927674651145935, \"Utterance\": \"when do I next need to report\", \"IntentEntities\": [], \"IntentResponse\": \"{}\" }, \"Source\": \"{}\", \"RequestDateTimeUtc\": \"2018-04-25T19:34:51.7530153Z\"}";
            string expectedContent = "stahl";

            var target = new Client();
            var postData = requestData.AsIHttpContent("", "application/json");
            var actual = await target.PostAsync(testUrl, postData);

            var resultText = actual.Content;
            Console.WriteLine(resultText);
            Assert.Contains(expectedContent, resultText);
        }
    }
}
