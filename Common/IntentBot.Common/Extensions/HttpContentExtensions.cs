using IntentBot.Entities;
using IntentBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntentBot.Extensions
{
    /// <summary>
    /// Extensions involving the IntentBot.Entities.HttpContent object
    /// </summary>
    public static class HttpContentExtensions
    {
        /// <summary>
        /// Returns an object that implements the IHttpContent interface
        /// with the specified request content and media-type header
        /// </summary>
        /// <param name="request">json formatted request data</param>
        /// <param name="mediaTypeHeaderValue">The value of the media type http header</param>
        /// <param name="contentTypeHeaderValue">The value of the content type http header</param>
        /// <returns>An object implementing the IHttpContent interface</returns>
        public static IHttpContent AsIHttpContent(this string request, string mediaTypeHeaderValue = "", string contentTypeHeaderValue = "")
        {
            var result = new HttpContent(request);
            if (!string.IsNullOrWhiteSpace(mediaTypeHeaderValue))
                result.AddHeader("media-type", mediaTypeHeaderValue);
            if (!string.IsNullOrWhiteSpace(contentTypeHeaderValue))
                result.AddHeader("content-type", contentTypeHeaderValue);
            return result;
        }

    }
}
