using System;
using System.Collections.Generic;
using System.Text;
using IntentBot.Entities;

namespace IntentBot.Interfaces
{
    /// <summary>
    /// Routes user intents to the appropriate intent processor.
    /// </summary>
    public interface IIntentRouter
    {
        /// <summary>
        /// Selects the appropriate ICommandProcessor for the Intent. Routes the
        /// request to that processor and returns the results from that processor.
        /// </summary>
        /// <param name="request">The request to be processed by the handler as received by the IntentBot.</param>
        /// with intent determined by the Intent Provider
        /// <returns>The response provided by the selected handler to which the request was routed</returns>
        CommandResponse RouteToHandler(UserRequest request);
    }
}
