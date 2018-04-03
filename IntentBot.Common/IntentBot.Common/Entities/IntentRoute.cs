using System;
using System.Collections.Generic;
using System.Text;

namespace IntentBot.Entities
{
    /// <summary>
    /// Defines a routing for an intent
    /// </summary>
    public class IntentRoute
    {
        /// <summary>
        /// The name of the intent being routed
        /// </summary>
        public string IntentName { get; set; }

        /// <summary>
        /// The url to which requests for the specified intent should be routed
        /// </summary>
        public string Uri { get; set; }
    }
}
