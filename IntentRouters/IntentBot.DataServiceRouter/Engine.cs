using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using IntentBot.Entities;
using IntentBot.Interfaces;
using System.Threading.Tasks;

namespace IntentBot.DataServiceRouter
{
    [Serializable]
    public class Engine : IIntentHandler
    {
        const string _defaultIntentName = "default";

        IServiceProvider _serviceProvider;
        IEnumerable<IntentRoute> _routes = new List<IntentRoute>();

        public Engine(IServiceProvider serviceProvider, string routeDataServiceUrl)
        {
            _serviceProvider = serviceProvider;
            var configProxy = _serviceProvider.GetService<IHttpProxy>();
            var configTask = configProxy.GetAsync(routeDataServiceUrl, null);
            Task.WaitAll(configTask);
            var config = configTask.Result;
            _routes = config.Content.AsIntentRouteCollection();
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
