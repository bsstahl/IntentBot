using System;
using System.Collections.Generic;
using System.Text;

namespace IntentBot.Interfaces
{
    /// <summary>
    ///     Represents a HTTP response message including the status code and data.
    /// </summary>
    public interface IHttpResponseMessage
    {
        /// <summary>
        ///     Gets the content of a HTTP response message.
        /// </summary>
        string Content { get; }

        /// <summary>
        /// Gets the collection of HTTP response headers.
        /// </summary>
        IEnumerable<KeyValuePair<string, string>> Headers { get; }

        /// <summary>
        /// Gets a value that indicates if the HTTP response was successful.
        /// </summary>
        bool IsSuccessStatusCode { get; }

        /// <summary>
        /// Gets or sets the reason phrase which typically is sent by servers together with the status code.
        /// </summary>
        string ReasonPhrase { get; set; }

        /// <summary>
        /// Gets the request message which led to this response message.
        /// </summary>
        string RequestMessage { get; }

        /// <summary>
        /// Gets or sets the status code of the HTTP response.
        /// </summary>
        int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the HTTP message version.
        /// </summary>
        /// <example>The default is 1.1.</example>
        Single Version { get; set; }
    }
}
