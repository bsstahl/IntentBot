using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntentBot.Interfaces
{
    /// <summary>
    /// Describes an object that can make HTTP calls
    /// </summary>
    public interface IHttpProxy
    {
        /// <summary>
        /// Issues an HTTP Get to the specified URI with the specified headers
        /// </summary>
        /// <param name="uri">The address of the service to post to</param>
        /// <param name="headers">A collection of name/value pairs to be added to the request as headers</param>
        /// <returns>A Task of type HttpResponseMessage that holds the result of the post operation</returns>
        Task<HttpResponseMessage> GetAsync(string uri, IEnumerable<KeyValuePair<string, string>> headers);

        /// <summary>
        /// Issues an HTTP Post of the content to the specified URI
        /// </summary>
        /// <param name="uri">The address of the service to post to</param>
        /// <param name="requestContent">The content to be posted</param>
        /// <returns>A Task of type HttpResponseMessage that holds the result of the post operation</returns>
        Task<HttpResponseMessage> PostAsync(string uri, HttpContent requestContent);
    }
}
