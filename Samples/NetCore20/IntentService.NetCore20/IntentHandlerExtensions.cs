using IntentBot.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IntentHandlerExtensions
    {
        public static void AddHandler(this IServiceCollection servicesCollection)
        {
            servicesCollection.AddScoped<IIntentHandler>(c => new IntentService.IntentHandler.Handler(c));
        }

    }
}
