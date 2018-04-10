using System;
using System.Collections.Generic;
using System.Text;
using IntentBot.Entities;
using IntentBot.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IntentRouterExtensions
    {
        public static void AddSoftRouter(this IServiceCollection servicesCollection, IEnumerable<IntentRoute> routes)
        {
            servicesCollection.AddScoped<IIntentHandler>(c => new IntentBot.SoftRouter.Engine(c, routes));
        }
    }
}
