using System;
using System.Collections.Generic;
using System.Text;

namespace IntentBot.Entities
{
    /// <summary>
    /// Represents the user making a request to the IntentBot
    /// </summary>
    public class User
    {
        /// <summary>
        /// The AAID of the user
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The 3-letter IATA station code of the user's base
        /// </summary>
        public string BaseCode { get; set; }

        // TODO: Add additional information from the Authentication Provider response
    }
}
