using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using IntentBot.Entities;
using IntentBot.Interfaces;

namespace IntentBot.DefaultCommandProcessor
{
    /// <summary>
    /// Extensions to convert data to and from JSON
    /// </summary>
    public static class ConversionExtensions
    {
        /// <summary>
        /// Converts an HTTP response to a CommandResponse object
        /// </summary>
        /// <param name="response">The HTTPResponseMessage that should consist of a JSON encoded CommandResponse object</param>
        /// <returns>The deserialized CommandResponse object</returns>
        public static CommandResponse AsCommandResponse(this IHttpResponseMessage response)
        {
            // TODO: Give a good error message if the object cannot be deserialized properly
            return JsonConvert.DeserializeObject<CommandResponse>(response.Content);
        }
    }
}
