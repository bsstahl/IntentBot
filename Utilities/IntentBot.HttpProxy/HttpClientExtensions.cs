using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntentBot.Interfaces;

namespace IntentBot.HttpProxy
{
    /// <summary>
    /// Extensions to the HttpClient object
    /// </summary>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Converts from a System.Net.HttpResponseMessage to an object that
        /// implements the IHttpResponseMessage interface
        /// </summary>
        /// <param name="responseMessage">The message received from the http request</param>
        /// <returns>An instance of an IHttpResponseMessage containing
        /// the data from the request</returns>
        public static IHttpResponseMessage AsIHttpResponseMessage(this System.Net.Http.HttpResponseMessage responseMessage)
        {
            var contentTask = responseMessage.Content.ReadAsStringAsync();
            var requestContentTask = responseMessage.RequestMessage?.Content?.ReadAsStringAsync();
            var taskList = new List<Task>() { contentTask };
            if (requestContentTask != null)
                taskList.Add(requestContentTask);
            Task.WaitAll(taskList.ToArray());

            Single version = 1.1f;
            if (responseMessage.Version == System.Net.HttpVersion.Version10)
                version = 1.0f;

            var headers = new List<KeyValuePair<string, string>>();
            foreach (var header in responseMessage.Headers)
                headers.Add(new KeyValuePair<string, string>(header.Key, header.Value.First()));

            return new HttpResponseMessage()
            {
                Content = contentTask.Result,
                IsSuccessStatusCode = responseMessage.IsSuccessStatusCode,
                ReasonPhrase = responseMessage.ReasonPhrase,
                RequestMessage = (requestContentTask == null) ? string.Empty : requestContentTask.Result,
                StatusCode = Convert.ToInt32(responseMessage.StatusCode),
                Version = version,
                Headers = headers
            };
        }

        /// <summary>
        /// Converts from an an IHTTPContext object to System.Web.HttpContext implementation
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static System.Net.Http.HttpContent AsHttpContent(this IHttpContent content)
        {
            var result = new System.Net.Http.StringContent(content.Content);
            foreach (var header in content.Headers)
            {
                if (result.Headers.Contains(header.Key))
                    result.Headers.Remove(header.Key);
                result.Headers.Add(header.Key, header.Value);
            }
            return result;
        }

        /// <summary>
        /// Adds the headers in the specified collection to the HTTPClient object
        /// </summary>
        /// <param name="client">The client to which the headers should be added</param>
        /// <param name="headers">A collection of name value pairs. Each pair represents 
        /// the name and value of an http header to be added to the client.</param>
        public static void AddHeaders(this System.Net.Http.HttpClient client, IEnumerable<KeyValuePair<string, string>> headers)
        {
            if (headers != null)
                foreach (var header in headers)
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
        }
    }
}
