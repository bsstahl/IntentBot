using System;
using System.Collections.Generic;
using System.Text;

namespace IntentBot.Entities
{
    /// <summary>
    /// Represents the requested intent of the user as determined by LUIS
    /// or other intent determination AI.
    /// </summary>
    public class Intent
    {
        /// <summary>
        /// The name of the intent as determined by LUIS or equivalent.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The confidence score for the intent.  The higher the score, the more confident
        /// we are that the request was correctly understood.
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// The statement made or question asked by the user that translated to this intent
        /// </summary>
        public string Utterance { get; set; }

        /// <summary>
        /// The collection of name-type pairs that describe the entities
        /// specified in the request.
        /// </summary>
        /// <example>Name=Italian, Type=Cuisine</example>
        public IEnumerable<IntentEntity> IntentEntities { get; set; }

        /// <summary>
        /// The full Json response received from LUIS or equivalent service.
        /// </summary>
        public string IntentResponse { get; set; }

        // TODO: Break-out any additional information that is likely to be useful
    }
}
