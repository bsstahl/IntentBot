using IntentBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntentBot.ConfigRouter
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

    }
}
