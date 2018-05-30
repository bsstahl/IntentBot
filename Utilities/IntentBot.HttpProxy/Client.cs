using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IntentBot.Interfaces;

namespace IntentBot.HttpProxy
{
    /// <summary>
    /// An object that can make HTTP REST calls
    /// </summary>
    public class Client : IHttpProxy
    {
        /// <summary>
        /// Issues an HTTP Get to the specified URI with the specified headers
        /// </summary>
        /// <param name="uri">The address of the service to post to</param>
        /// <param name="headers">A collection of name/value pairs to be added to the request as headers</param>
        /// <returns>A Task containing an HttpResponseMessage that holds the result of the post operation</returns>
        public async Task<IHttpResponseMessage> GetAsync(string uri, IEnumerable<KeyValuePair<string, string>> headers)
        {
            var client = new HttpClient();
            client.AddHeaders(headers);

            Console.WriteLine($"Issuing an HTTP Get to '{uri}'.");
            var response = await client.GetAsync(uri);
            var responseText = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response returned from HTTP Get request: {responseText}");

            return response.AsIHttpResponseMessage();
        }

        /// <summary>
        /// Issues an HTTP Post of the content to the specified URI
        /// </summary>
        /// <param name="uri">The address of the service to post to</param>
        /// <param name="requestContent">The content to be posted</param>
        /// <returns>A Task containing an HttpResponseMessage that holds the result of the post operation</returns>
        public async Task<IHttpResponseMessage> PostAsync(string uri, IHttpContent requestContent)
        {
            var client = new HttpClient();
            var sendContent = requestContent.AsHttpContent();

            Console.WriteLine($"Issuing an HTTP Post to '{uri}' with data '{requestContent.Content}'.");
            var response = await client.PostAsync(uri, sendContent);
            Console.WriteLine("Response received from HTTP Post request -- needs to be deserialized");

            var receivedMessage = response.AsIHttpResponseMessage();
            Console.WriteLine($"Deserialized response from HTTP Post request: {receivedMessage.Content}");

            return receivedMessage;
        }

    }
}
