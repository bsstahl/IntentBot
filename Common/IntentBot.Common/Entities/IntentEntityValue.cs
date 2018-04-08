using System;
using System.Collections.Generic;
using System.Text;

namespace IntentBot.Entities
{
    /// <summary>
    /// Details of a possible value of an Entity from an Utterance
    /// </summary>
    public class IntentEntityValue
    {
        /// <summary>
        /// A pattern that can be used to extract additional information from the value
        /// </summary>
        /// <example>For date values, the pattern might be a timex code</example>
        public string Pattern { get; set; }

        /// <summary>
        /// The data type of the entity value
        /// </summary>
        public string ValueType { get; set; }

        /// <summary>
        /// The actual value of the entity in a text format
        /// </summary>
        public string Value { get; set; }
    }

}
