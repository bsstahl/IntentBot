using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestHelperExtensions;
using Xunit;

namespace IntentBot.HttpProxy.IntegrationTest
{
    public class Client_GetAsync_Should
    {
        // Note: These tests will fail if there is no internet connectivity

        string _baseGoogleUrl = "http://www.google.com";
        string _baseHttpBinUrl = "http://httpbin.org";

        [Fact]
        public async Task ReturnSuccessfullyIfHeadersIsNull()
        {
            var target = new Client();
            var actual = await target.GetAsync(_baseGoogleUrl, null);
            var resultText = await actual.Content.ReadAsStringAsync();
            Console.WriteLine(resultText);
            Assert.True(actual.IsSuccessStatusCode);
        }

        [Fact]
        public async Task ReturnSuccessfullyIfHeadersIsEmpty()
        {
            var target = new Client();
            var headers = new List<KeyValuePair<string, string>>();
            var actual = await target.GetAsync(_baseGoogleUrl, headers);
            var resultText = await actual.Content.ReadAsStringAsync();
            Console.WriteLine(resultText);
            Assert.True(actual.IsSuccessStatusCode);
        }

        [Fact]
        public async Task SendTheHeaderIfOneHeaderIsSupplied()
        {
            string expected = string.Empty.GetRandom();

            var target = new Client();
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("Accept", $"text/html,application/{expected}"));
            var actual = await target.GetAsync($"{_baseHttpBinUrl}/headers", headers);

            var resultText = await actual.Content.ReadAsStringAsync();
            Console.WriteLine(resultText);

            Assert.Contains(expected, resultText);
        }

        [Fact]
        public async Task SendAllHeadersIfMultipleHeadersAreSupplied()
        {
            string expectedAcceptHeader = string.Empty.GetRandom();
            string expectedDeviceId = string.Empty.GetRandom();
            string expectedCorrelationId = string.Empty.GetRandom();

            var target = new Client();
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("Accept", $"text/html,application/{expectedAcceptHeader}"));
            headers.Add(new KeyValuePair<string, string>("X-ATT-DeviceId", expectedDeviceId));
            headers.Add(new KeyValuePair<string, string>("X-Correlation-ID", expectedCorrelationId));
            var actual = await target.GetAsync($"{_baseHttpBinUrl}/headers", headers);

            var resultText = await actual.Content.ReadAsStringAsync();
            Console.WriteLine(resultText);

            Assert.Contains(expectedAcceptHeader, resultText);
            Assert.Contains(expectedDeviceId, resultText);
            Assert.Contains(expectedCorrelationId, resultText);

        }

        // headers.Add(new KeyValuePair<string, string>("X-Request-ID", string.Empty.GetRandom()));
    }
}
