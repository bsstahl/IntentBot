using System;
using System.Collections.Generic;
using System.Text;

namespace IntentBot.Entities
{
    /// <summary>
    /// The primary data transfer object for a IntentBot request. This object
    /// is used to pass request information from the IntentBot to the services
    /// processing the request.
    /// </summary>
    public class UserRequest
    {
        /// <summary>
        /// Represents the user making the request
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Represents the requested intent of the user as determined by LUIS
        /// or other intent determination AI.
        /// </summary>
        public Intent Intent { get; set; }

        /// <summary>
        /// Represents the data provided by source of the request. This data may come
        /// from Siri, Slack, SMS, etc. and may contain additional information
        /// about the request
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// The UTC Date and Time that the request was received by the IntentBot.
        /// </summary>
        public DateTime RequestDateTimeUtc { get; set; }

        // TODO: Add any additional metadata required

    }
}
