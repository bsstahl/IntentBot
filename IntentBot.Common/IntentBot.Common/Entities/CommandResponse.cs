using System;
using System.Collections.Generic;
using System.Text;

namespace IntentBot.Entities
{
    /// <summary>
    /// Defines the response returned by a command processor
    /// to the Bot as a result of having processed a user request
    /// </summary>
    public class CommandResponse
    {
        /// <summary>
        /// Indicates if a request to a command processor 
        /// was successful, and if not, why it failed.
        /// </summary>
        public Status ResultStatus { get; set; }

        /// <summary>
        /// The response as it should be returned to the user
        /// </summary>
        /// <remarks>This response may not be used if a standard ResultStatus 
        /// indicating a common error is specified since those may have a 
        /// default response from the IntentBot.</remarks>
        public string ResponseText { get; set; }

        /// <summary>
        /// A URL path to be displayed to the user following the response
        /// </summary>
        public string UriToDisplay { get; set; }

        /// <summary>
        /// Indicates that a user confirmation is required and should be returned
        /// to the command processor before any action will be taken.
        /// </summary>
        public bool RequiresUserConfirmation { get; set; }
    }
}
