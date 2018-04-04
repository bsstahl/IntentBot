using System;
using System.Collections.Generic;
using System.Text;
using IntentBot.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for using the IntentBot Default Command Processor
    /// </summary>
    public static class CommandProcessingExtensions
    {
        /// <summary>
        /// Add the default command processor to the specified services collection
        /// </summary>
        /// <param name="servicesCollection"></param>
        public static void AddDefaultCommandProcessing(this IServiceCollection servicesCollection)
        {
            servicesCollection.AddScoped<ICommandProcessor>(c => new IntentBot.DefaultCommandProcessor.Processor(c));
        }
    }
}
