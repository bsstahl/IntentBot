using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IntentBot.Entities;

namespace IntentBot.Interfaces
{
    /// <summary>
    /// Defines a service that processes a specific request
    /// made to the IntentBot by a user
    /// </summary>
    public interface ICommandProcessor
    {
        /// <summary>
        /// Process a user request to the command bot for the specific
        /// intent that is handled by the service implementation.
        /// </summary>
        /// <param name="uri">The Uri of the handler for the request.  The request will 
        /// be routed to the handler at this Uri.</param>
        /// <param name="request">The UserRequest information assembled by the Bot from the source request</param>
        /// <returns>A Task of type CommandResponse containing the result of the processing</returns>
        Task<CommandResponse> ProcessAsync(string uri, UserRequest request);
    }
}
