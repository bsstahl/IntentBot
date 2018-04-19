using System;
using System.Collections.Generic;
using System.Text;

namespace IntentBot.Entities
{
    /// <summary>
    /// Indicates if a request to a command processor 
    /// was successful, and if not, why it failed.
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// The command processed successfully
        /// </summary>
        Success,

        /// <summary>
        /// This processor does not understand this particular request or
        /// required information is missing
        /// </summary>
        RequestNotUnderstood,

        /// <summary>
        /// Indicates that the user specified in the request could not be located
        /// </summary>
        UserNotFound

        // TODO: Add additional statuses as necessary
    }
}
