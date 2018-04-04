using System;
using System.Collections.Generic;
using System.Text;
using IntentBot.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IntentProviderExtensions
    {
        public static void AddFakeIntentProvider(this IServiceCollection servicesCollection)
        {
            servicesCollection.AddScoped<IIntentProvider>(c => new IntentBot.FakeIntentProvider.Engine(c));
        }
    }
}
