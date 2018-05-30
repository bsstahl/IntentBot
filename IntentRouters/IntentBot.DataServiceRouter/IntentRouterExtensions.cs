using System;
using System.Collections.Generic;
using System.Text;
using IntentBot.Entities;
using IntentBot.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IntentRouterExtensions
    {
        public static void AddDataServiceRouter(this IServiceCollection servicesCollection, string routeDataServiceUrl)
        {
            servicesCollection.AddDefaultCommandProcessing();
            servicesCollection.AddScoped<IIntentHandler>(c => new IntentBot.DataServiceRouter.Engine(c, routeDataServiceUrl));
        }
    }
}
