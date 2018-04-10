using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IntentBot.Entities;

namespace IntentBot.Interfaces
{
    /// <summary>
    /// Routes user intents to the appropriate intent processor.
    /// </summary>
    public interface IIntentHandler
    {
        /// <summary>
        /// Process the selected UserRequest via an implementation of an Intent handler. 
        /// This may be handled by routing to the appropriate handler and returning the
        /// results, or by handling the request directly.
        /// </summary>
        /// <param name="request">The request to be processed by the handler as received by the IntentBot.</param>
        /// with intent determined by the Intent Provider
        /// <returns>A Task of type CommandResponse that holds the response provided by the handler</returns>
        Task<CommandResponse> HandleRequestAsync(UserRequest request);
    }
}
