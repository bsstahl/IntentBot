using IntentBot.Entities;
using Microsoft.Extensions.Configuration;
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
            foreach (var configItem in configSection.GetChildren())
            {
                var c = configItem.GetChildren().FirstOrDefault();
                results.Add(new IntentRoute() { IntentName = c.Key, Uri = c.Value });
            }
            return results;
        }
    }
}
