using IntentBot.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntentBot.LuisIntentProvider
{
    public static class HttpResponseMessageExtensions
    {
        internal static LuisResponse AsLuisResponse(this IHttpResponseMessage responseMessage)
        {
            return JsonConvert.DeserializeObject<LuisResponse>(responseMessage.Content);
        }
    }
}
