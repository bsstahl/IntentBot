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
        /// The UserID of the user if known. Empty if unknown.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The first name of the authenticated user if known. Empty if unknown.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the authenticated user if known. Empty if unknown.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// A collection of additional user data stored in key-value pairs
        /// </summary>
        /// <example>Key: homecity, Value: Phoenix</example>
        public IEnumerable<KeyValuePair<string, string>> AdditionalData { get; set; }
    }
}
