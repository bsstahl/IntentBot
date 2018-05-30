using IntentBot.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntentBot.DataServiceRouter
{
    public static class RouteCollectionExtensions
    {
        public static bool Contains(this IEnumerable<IntentRoute> routes, string routeName)
        {
            return routes.Any(r => r.IntentName == routeName);
        }

        public static IntentRoute Find(this IEnumerable<IntentRoute> routes, string routeName)
        {
            return routes.Single(r => r.IntentName == routeName);
        }

        public static void LogEntries(this IEnumerable<IntentRoute> routes)
        {
            foreach (var route in routes)
                Console.WriteLine($"Intent '{route.IntentName}' routes to '{route.Uri}'.");
        }

        public static IEnumerable<IntentRoute> AsIntentRouteCollection(this string configData)
        {
            var results = new List<IntentRoute>();
            var dict = JArray.Parse(configData);
            foreach (var c in dict)
            {
                // var item = c.First() as JProperty;
                var item = JsonConvert.DeserializeObject<RouteData>(c.ToString());
                results.Add(new IntentRoute()
                {
                    IntentName = item.IntentName,
                    Uri = item.RouteUri
                });
            }

            return results;
        }

    }
}
