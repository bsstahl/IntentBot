using IntentBot.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IntentBot.DefaultCommandProcessor
{
    /// <summary>
    /// Extensions to convert data to and from JSON
    /// </summary>
    public static class ConversionExtensions
    {
        /// <summary>
        /// Converts a UserRequest object to an HttpContent object
        /// </summary>
        /// <param name="request">The UserRequest object to be converted</param>
        /// <returns>A json encoded HttpContent object</returns>
        public static HttpContent AsHttpContent(this UserRequest request)
        {
            var myContent = JsonConvert.SerializeObject(request);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);

            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return byteContent;
        }

        /// <summary>
        /// Converts an HTTP response to a CommandResponse object
        /// </summary>
        /// <param name="response">The HTTPResponseMessage that should consist of a JSON encoded CommandResponse object</param>
        /// <returns>The deserialized CommandResponse object</returns>
        public async static Task<CommandResponse> AsCommandResponse(this HttpResponseMessage response)
        {
            // TODO: Give a good error message if the object cannot be deserialized properly
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CommandResponse>(responseString);
        }

    }
}
