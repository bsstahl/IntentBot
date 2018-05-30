using IntentBot.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntentBot.ConfigRouter
{
    public static class ConfigurationSectionExtensions
    {
        public static IEnumerable<IntentRoute> AsIntentRouteCollection(this IConfigurationSection configSection)
        {
            var results = new List<IntentRoute>();
            var dict = JArray.Parse(configSection.Value);
            foreach (var c in dict)
            {
                var item = c.First() as JProperty;
                results.Add(new IntentRoute()
                {
                    IntentName = item.Name,
                    Uri = item.Value.ToString()
                });
            }
            return results;
        }
    }
}
