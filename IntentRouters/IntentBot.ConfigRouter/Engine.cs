using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using IntentBot.Entities;
using IntentBot.Interfaces;
using System.Threading.Tasks;

namespace IntentBot.ConfigRouter
{
    [Serializable]
    public class Engine : IIntentHandler
    {
        const string _defaultIntentName = "default";

        IServiceProvider _serviceProvider;
        IEnumerable<IntentRoute> _routes = new List<IntentRoute>();

        public Engine(IServiceProvider serviceProvider, string routeConfigKey = "intentRoutes")
        {
            _serviceProvider = serviceProvider;
            var config = _serviceProvider.GetService<IConfiguration>();
            _routes = config.GetSection(routeConfigKey).AsIntentRouteCollection();
            _routes.LogEntries();
            if (!_routes.Contains(_defaultIntentName))
                throw new Exceptions.MissingRouteException(_defaultIntentName);
        }

        public async Task<CommandResponse> HandleRequestAsync(UserRequest request)
        {
            string uri;
            if (_routes.Contains(request.Intent.Name))
                uri = _routes.Find(request.Intent.Name).Uri;
            else
                uri = _routes.Find(_defaultIntentName).Uri;

            var handler = _serviceProvider.GetService<ICommandProcessor>();
            var response = await handler.ProcessAsync(uri, request);

            return response;
        }
    }
}
