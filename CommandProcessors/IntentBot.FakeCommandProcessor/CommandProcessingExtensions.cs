using System;
using System.Collections.Generic;
using System.Text;
using IntentBot.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for configuring the Fake Command Processor
    /// </summary>
    public static class CommandProcessingExtensions
    {
        /// <summary>
        /// Adds the fake command processor to the specified services collection
        /// </summary>
        /// <param name="servicesCollection">The services collection to which the instance should be added.</param>
        public static void AddFakeCommandProcessing(this IServiceCollection servicesCollection)
        {
            servicesCollection.AddScoped<ICommandProcessor>(c => new IntentBot.FakeCommandProcessor.Processor(c));
        }
    }
}
