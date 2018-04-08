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
        internal static LuisResponse AsLuisResponse(this HttpResponseMessage responseMessage)
        {
            var responseContentTask = responseMessage.Content.ReadAsStringAsync();
            Task.WaitAll(responseContentTask);
            return JsonConvert.DeserializeObject<LuisResponse>(responseContentTask.Result);
        }
    }
}
