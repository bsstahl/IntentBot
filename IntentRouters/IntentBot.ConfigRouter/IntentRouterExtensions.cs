using System;
using System.Collections.Generic;
using System.Text;
using IntentBot.Entities;
using IntentBot.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IntentRouterExtensions
    {
        public static void AddConfigRouter(this IServiceCollection servicesCollection)
        {
            servicesCollection.AddDefaultCommandProcessing();
            servicesCollection.AddScoped<IIntentHandler>(c => new IntentBot.ConfigRouter.Engine(c));
        }

        public static void AddConfigRouter(this IServiceCollection servicesCollection, string routeConfigKey)
        {
            servicesCollection.AddDefaultCommandProcessing();
            servicesCollection.AddScoped<IIntentHandler>(c => new IntentBot.ConfigRouter.Engine(c, routeConfigKey));
        }
    }
}
