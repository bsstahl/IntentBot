using System;
using System.Collections.Generic;
using System.Text;
using IntentBot.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IntentProviderExtensions
    {
        public static void AddLuisIntentProvider(this IServiceCollection servicesCollection)
        {
            servicesCollection.AddScoped<IIntentProvider>(c => new IntentBot.LuisIntentProvider.Engine(c));
        }
    }
}
