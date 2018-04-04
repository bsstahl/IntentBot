using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using IntentBot.Entities;
using IntentBot.Interfaces;

namespace IntentBot.SoftRouter
{
    [Serializable]
    public class Engine : IIntentRouter
    {
        const string _defaultIntentName = "default";

        IServiceProvider _serviceProvider;
        IEnumerable<IntentRoute> _routes;

        public Engine(IServiceProvider serviceProvider, IEnumerable<IntentRoute> routes)
        {
            _serviceProvider = serviceProvider;
            _routes = routes;
        }

        public CommandResponse RouteToHandler(UserRequest request)
        {
            string uri;
            if (_routes.Any(r => r.IntentName == request.Intent.Name))
                uri = _routes.Single(r => r.IntentName == request.Intent.Name).Uri;
            else if (_routes.Any(r => r.IntentName == _defaultIntentName))
                uri = _routes.Single(r => r.IntentName == _defaultIntentName).Uri;
            else
                throw new Exceptions.MissingRouteException(_defaultIntentName);

            var handler = _serviceProvider.GetService<ICommandProcessor>();
            var response = handler.Process(uri, request);

            return response;
        }
    }
}
