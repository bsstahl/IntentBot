using System;
using System.Collections.Generic;
using System.Linq;
using IntentBot.Entities;

namespace IntentBot
{
    public class RouteCollectionBuilder
    {
        List<IntentRoute> _routes;

        public RouteCollectionBuilder(string defaultRouteUri)
        {
            _routes = new List<IntentRoute>();
            Add("default", defaultRouteUri);
        }

        public IEnumerable<IntentRoute> Build()
        {
            return _routes;
        }

        public RouteCollectionBuilder Add(IntentRoute route)
        {
            ValidateName(route.IntentName);
            _routes.Add(route);
            return this;
        }

        public RouteCollectionBuilder Add(string intentName, string routeUri)
        {
            ValidateName(intentName);
            _routes.Add(new IntentRoute()
            {
                IntentName = intentName,
                Uri = routeUri
            });

            return this;
        }

        private void ValidateName(string intentName)
        {
            if (_routes.Any(r => r.IntentName == intentName))
                throw new Exceptions.DuplicateRouteException(intentName);
        }
    }
}
