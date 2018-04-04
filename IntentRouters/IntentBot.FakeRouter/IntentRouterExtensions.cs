using System;
using System.Collections.Generic;
using System.Text;
using IntentBot.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IntentRouterExtensions
    {
        public static void AddFakeRouter(this IServiceCollection servicesCollection)
        {
            servicesCollection.AddScoped<IIntentRouter>(c => new IntentBot.FakeRouter.Engine(c));
        }
    }
}
