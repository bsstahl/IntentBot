﻿using IntentBot.Entities;
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
        /// <param name="mediaTypeHeader">The media-type content header to be supplied with the content</param>
        /// <returns>An object implementing the IHttpContent interface</returns>
        public static IHttpContent AsIHttpContent(this string request, string mediaTypeHeader)
        {
            var result = new HttpContent(request);
            result.AddHeader("media-type", mediaTypeHeader);
            return result;
        }
    }
}
