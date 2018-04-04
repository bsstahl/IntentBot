using System;
using System.Collections.Generic;
using IntentBot.Entities;
using IntentBot.Interfaces;

namespace IntentBot.FakeIntentProvider
{
    [Serializable]
    public class Engine : IIntentProvider
    {
        IServiceProvider _serviceProvider;
        public Engine(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Intent GetIntent(string utterance)
        {
            return new Intent()
            {
                Name = "FakeIntent",
                IntentEntities = new List<IntentEntity>()
                {
                    new IntentEntity()
                        {
                        Name = "FakeEntity",
                        Type= "FakeEntityType"
                    }
                },
                IntentResponse = "{ jsonResponse }",
                Score = 0.74,
                Utterance = utterance
            };
        }
    }
}
