using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Linq;
using IntentBot.Interfaces;
using IntentBot.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace IntentBot.LuisIntentProvider
{
    public class Engine : IIntentProvider
    {
        const string _subscriptionKeyHeaderName = "Ocp-Apim-Subscription-Key";

        IServiceProvider _serviceProvider;
        string _subscriptionKey, _luisAppId, _baseServiceUri;

        public Engine(IServiceProvider serviceProvider, string luisSubscriptionKey, string luisAppId, string baseServiceUri)
        {
            _serviceProvider = serviceProvider;
            _subscriptionKey = luisSubscriptionKey;
            _luisAppId = luisAppId;
            _baseServiceUri = baseServiceUri;
        }

        public async Task<Intent> GetIntentAsync(string utterance)
        {
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>(_subscriptionKeyHeaderName, _subscriptionKey));

            string uri = CreateLuisQueryString(utterance, 0, true, false, true);

            var client = _serviceProvider.GetService<IHttpProxy>();
            var response = await client.GetAsync(uri, headers);
            var luisResponse = response.AsLuisResponse();

            var nextBestIntent = luisResponse.intents
                .OrderByDescending(i => i.score).Skip(1).Take(1).Single();

            var intentBuilder = new IntentBuilder()
                .AddName(luisResponse.topScoringIntent.intent)
                .AddScore(luisResponse.topScoringIntent.score, nextBestIntent.score)
                .AddResponse(luisResponse.AsJson())
                .AddUtterance(utterance);

            foreach (var luisEntity in luisResponse.entities)
            {
                var hasEntityValues = luisEntity?.resolution?.values?.Any();
                if (hasEntityValues.HasValue && hasEntityValues.Value)
                {
                    var values = new List<IntentEntityValue>();
                    foreach (var v in luisEntity.resolution.values)
                        values.Add(new IntentEntityValue()
                        {
                            // TODO: Put the real values for ValueType and Pattern back
                            ValueType = "unknown",
                            Value = v,
                            Pattern = ""
                        });
                    intentBuilder.AddEntity(luisEntity.entity, luisEntity.type, values);
                }
                else
                    intentBuilder.AddEntity(luisEntity.entity, luisEntity.type);
            }

            return intentBuilder.Build();
        }

        private string CreateLuisQueryString(string utterance, int timeZoneOffset, bool verbose, bool spellCheck, bool staging)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["q"] = utterance;
            queryString["timezoneOffset"] = timeZoneOffset.ToString();
            queryString["verbose"] = verbose.ToString();
            queryString["spellCheck"] = spellCheck.ToString();
            queryString["staging"] = staging.ToString();
            return $"{_baseServiceUri}{_luisAppId}?{queryString}";
        }
    }
}
