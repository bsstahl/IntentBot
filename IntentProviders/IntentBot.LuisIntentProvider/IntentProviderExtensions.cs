using System;
using System.Collections.Generic;
using System.Text;
using IntentBot.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IntentProviderExtensions
    {
        public static void AddLuisIntentProvider(this IServiceCollection servicesCollection, string luisSubscriptionKey, string luisAppId, string baseServiceUri)
        {
            servicesCollection.AddScoped<IHttpProxy>(c => new IntentBot.HttpProxy.Client());
            servicesCollection.AddScoped<IIntentProvider>(c => new IntentBot.LuisIntentProvider.Engine(c, luisSubscriptionKey, luisAppId, baseServiceUri));
        }
    }
}
