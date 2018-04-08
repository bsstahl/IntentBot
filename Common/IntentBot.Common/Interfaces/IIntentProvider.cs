using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IntentBot.Entities;

namespace IntentBot.Interfaces
{
    /// <summary>
    /// Provides intent determination services.  Converts a user utterance
    /// to an intent (command) and entities (objects of the intent)
    /// </summary>
    /// <example>The utterance "What is my schedule for December 2nd?" could return
    /// an intent of "ScheduleQuery" and an entity of type [date] that has a 
    /// value of December 2nd of the current year.</example>
    public interface IIntentProvider
    {
        /// <summary>
        /// Does the work of converting an utterance into an intent
        /// </summary>
        /// <param name="utterance">The utterance for which the intent is to be determined</param>
        /// <returns>A Task of type Intent that represents the goal of the user's utterance</returns>
        Task<Intent> GetIntentAsync(string utterance);
    }
}
