using IntentBot.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IntentBot.DataServiceRouter.Test
{
    public static class RouteCollectionExtensions
    {
        public static string AsJsonString(this IEnumerable<IntentRoute> routes)
        {
            var jPairs = new JArray();
            foreach (var route in routes)
            {
                var token = JObject.Parse($"{{\"{route.IntentName}\":\"{route.Uri}\"}}");
                jPairs.Add(token);
            }
            return JsonConvert.SerializeObject(jPairs);
        }
    }
}
