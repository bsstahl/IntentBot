using System;
using System.Collections.Generic;
using System.Text;

namespace IntentBot.Interfaces
{
    /// <summary>
    /// Content to be passed to an HTTP request or received from an HTTPResponse
    /// </summary>
    public interface IHttpContent
    {
        /// <summary>
        /// Gets the HTTP content headers as defined in RFC 2616.
        /// </summary>
        IEnumerable<KeyValuePair<string, string>> Headers { get; }

        /// <summary>
        /// The content in string format
        /// </summary>
        string Content { get; set; }
    }
}
