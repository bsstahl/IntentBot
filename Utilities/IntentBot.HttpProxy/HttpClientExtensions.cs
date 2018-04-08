using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace IntentBot.HttpProxy
{
    /// <summary>
    /// Extensions to the HttpClient object
    /// </summary>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Adds the headers in the specified collection to the HTTPClient object
        /// </summary>
        /// <param name="client">The client to which the headers should be added</param>
        /// <param name="headers">A collection of name value pairs. Each pair represents 
        /// the name and value of an http header to be added to the client.</param>
        public static void AddHeaders(this HttpClient client, IEnumerable<KeyValuePair<string, string>> headers)
        {
            if (headers != null)
                foreach (var header in headers)
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
        }
    }
}
