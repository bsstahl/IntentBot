using System;
using IntentBot.Entities;
using IntentBot.Interfaces;

namespace IntentBot.DefaultCommandProcessor
{
    /// <summary>
    /// The default processor for IntentBot commands
    /// </summary>
    public class Processor : ICommandProcessor
    {
        IServiceProvider _serviceProvider;

        /// <summary>
        /// The primary constructor of the Processor
        /// </summary>
        /// <param name="serviceProvider">The service provider to be used to provide dependencies</param>
        public Processor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Processes the user request using the specified URI
        /// </summary>
        /// <param name="uri">The URI to be used to process the request</param>
        /// <param name="request">The user request to be processed</param>
        /// <returns>An IntentBot.Entities.CommandResponse object representing the result of the processing</returns>
        public CommandResponse Process(string uri, UserRequest request)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}
