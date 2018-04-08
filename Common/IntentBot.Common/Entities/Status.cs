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
        /// This processor does not understand this particular request
        /// </summary>
        RequestNotUnderstood

        // TODO: Add additional statuses as necessary
    }
}
