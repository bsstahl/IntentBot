using System;
using System.Threading.Tasks;
using System.Net.Http;
using Xunit;
using TestHelperExtensions;

namespace IntentBot.HttpProxy.IntegrationTest
{
    public class UnitTest1
    {

        string _baseGoogleUrl = "http://www.google.com";
        string _baseHttpBinUrl = "http://httpbin.org";

        [Fact]
        public async Task ReturnSuccessfullyIfContentIsPosted()
        {
            var target = new Client();
            string expected = string.Empty.GetRandom();
            var postData = expected.AsHttpContent();
            var actual = await target.PostAsync($"{_baseHttpBinUrl}/post", postData);
            var resultText = await actual.Content.ReadAsStringAsync();
            Console.WriteLine(resultText);
            Assert.True(actual.IsSuccessStatusCode);
        }

        [Fact]
        public async Task PostTheSpecifiedContent()
        {
            var target = new Client();
            string expected = string.Empty.GetRandom();
            var postData = expected.AsHttpContent();
            var actual = await target.PostAsync($"{_baseHttpBinUrl}/post", postData);
            var resultText = await actual.Content.ReadAsStringAsync();
            Console.WriteLine(resultText);
            Assert.Contains(expected, resultText);
        }

    }
}
