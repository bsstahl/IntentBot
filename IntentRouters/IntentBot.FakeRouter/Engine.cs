using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IntentBot.Entities;
using IntentBot.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IntentBot.FakeRouter
{
    [Serializable]
    public class Engine : IIntentRouter
    {
        IServiceProvider _serviceProvider;
        public Engine(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<CommandResponse> RouteToHandlerAsync(UserRequest request)
        {
            var commandProcessor = _serviceProvider.GetService<ICommandProcessor>();
            return await commandProcessor.ProcessAsync("FakeUri", request);
        }
    }
}
