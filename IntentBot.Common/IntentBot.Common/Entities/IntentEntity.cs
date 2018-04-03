using System;
using System.Collections.Generic;
using System.Text;

namespace IntentBot.Entities
{
    /// <summary>
    /// A name-type pair that describes an entity within a user intent
    /// </summary>
    public class IntentEntity
    {
        /// <summary>
        /// The name of the entity. This is the data that is being provided to the service.
        /// </summary>
        /// <example>Italian</example>
        public string Name { get; set; }

        /// <summary>
        /// The type of the entity. This is the category that the data falls into.
        /// </summary>
        /// <example>Cuisine</example>
        public string Type { get; set; }
    }
}
