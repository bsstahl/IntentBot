using System;
using IntentBot.Entities;
using IntentBot.Interfaces;

namespace IntentBot.LuisIntentProvider
{
    public class Engine : IIntentProvider
    {
        IServiceProvider _serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Intent GetIntent(string utterance)
        {
            throw new NotImplementedException();
        }
    }
}
