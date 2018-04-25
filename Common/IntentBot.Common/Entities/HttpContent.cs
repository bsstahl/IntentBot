using System;
using System.Collections.Generic;
using IntentBot.Interfaces;

namespace IntentBot.Entities
{
    /// <summary>
    /// An instance of an object implementing
    /// the IHttpContent interface
    /// </summary>
    public class HttpContent : IHttpContent
    {
        List<KeyValuePair<string, string>> _headers;

        /// <summary>
        /// Creates an HttpContent object
        /// </summary>
        public HttpContent()
        {
            _headers = new List<KeyValuePair<string, string>>();
        }

        /// <summary>
        /// Creates an HttpContent object containing
        /// the specified content
        /// </summary>
        /// <param name="content"></param>
        public HttpContent(string content):this()
        {
            this.Content = content;
        }

        /// <summary>
        /// The collection of http headers to be supplied
        /// with the request in the form of key-value pairs
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> Headers { get => _headers; }

        /// <summary>
        /// The content to be passed along with the request
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Adds a header (key-value pair) to the
        /// collection of headers
        /// </summary>
        /// <param name="key">The name of the header</param>
        /// <param name="value">The value of the header</param>
        public void AddHeader(string key, string value)
        {
            _headers.Add(new KeyValuePair<string, string>(key, value));
        }
    }
}
