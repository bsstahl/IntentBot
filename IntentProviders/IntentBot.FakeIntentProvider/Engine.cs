using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<Intent> GetIntentAsync(string utterance)
        {
            await Task.Yield();
            var entityValues = new IntentEntityValuesBuilder()
                .Add("FakeValueType", "FakeValue", "FakePattern")
                .Build();

            return new IntentBuilder()
                .AddName("FakeIntent")
                .AddScore(0.909579635, 0.0500833727)
                .AddUtterance(utterance)
                .AddEntity("FakeEntity", "FakeEntityType", entityValues)
                .AddResponse($"{{ \"query\": \"{utterance}\", \"topScoringIntent\": {{ \"intent\": \"FakeIntent\", \"score\": 0.909579635 }}, \"intents\": [ {{ \"intent\": \"FakeIntent\", \"score\": 0.909579635 }}, {{ \"intent\": \"AnotherFakeIntent\", \"score\": 0.0500833727 }} ], \"entities\": [ {{ \"entity\": \"april 6th\", \"type\": \"builtin.datetimeV2.date\", \"startIndex\": 20, \"endIndex\": 28, \"resolution\": {{ \"values\": [ {{ \"timex\": \"XXXX-04-06\", \"type\": \"date\", \"value\": \"2017-04-06\" }}, {{ \"timex\": \"XXXX-04-06\", \"type\": \"date\", \"value\": \"2018-04-06\" }} ] }} }} ]}}")
                .Build();
        }
    }
}
