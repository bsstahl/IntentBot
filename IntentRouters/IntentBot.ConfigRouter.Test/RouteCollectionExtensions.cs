using IntentBot.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntentBot.ConfigRouter.Test
{
    public static class RouteCollectionExtensions
    {
        public static IEnumerable<KeyValuePair<string, string>> AsKeyValuePairs(this IEnumerable<IntentRoute> routes, string sectionName = "")
        {
            int i = 0;
            var results = new List<KeyValuePair<string, string>>();
            foreach (var route in routes)
            {
                if (string.IsNullOrWhiteSpace(sectionName))
                    results.Add(new KeyValuePair<string, string>($"{i}:{route.IntentName}", route.Uri));
                else
                    results.Add(new KeyValuePair<string, string>($"{sectionName}:{i}:{route.IntentName}", route.Uri));
                i++;
            }
            return results;
        }
    }
}
