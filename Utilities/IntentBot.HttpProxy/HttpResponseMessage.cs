using System;
using System.Collections.Generic;
using System.Text;
using IntentBot.Interfaces;

namespace IntentBot.HttpProxy
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpResponseMessage : IHttpResponseMessage
    {
        /// <summary>
        /// The content returned from the server
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// The collection of http headers in the form of key-value pairs
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> Headers { get; internal set; }

        /// <summary>
        /// True if the http result status indicates success
        /// </summary>
        public bool IsSuccessStatusCode { get; set; }

        /// <summary>
        /// The http reason phrase returned by the server
        /// </summary>
        public string ReasonPhrase { get; set; }

        /// <summary>
        /// The request message sent to the server
        /// </summary>
        public string RequestMessage { get; set; }

        /// <summary>
        /// The http status code.
        /// </summary>
        /// <example>200 indicates OK</example>
        public int StatusCode { get; set; }

        /// <summary>
        /// The http version number.  Default is 1.1.
        /// </summary>
        public float Version { get; set; }
    }
}
