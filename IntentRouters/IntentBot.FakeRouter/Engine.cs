using System;
using System.Collections.Generic;
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

        public CommandResponse RouteToHandler(UserRequest request)
        {
            var commandProcessor = _serviceProvider.GetService<ICommandProcessor>();
            return commandProcessor.Process("FakeUri", request);
        }
    }
}
