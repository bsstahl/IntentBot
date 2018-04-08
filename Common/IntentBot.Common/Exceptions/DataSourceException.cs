using System;
using System.Collections.Generic;
using System.Text;

namespace IntentBot.Exceptions
{
    /// <summary>
    /// The Exception thrown when the system is unable to reach
    /// or access the data store containing the requested information
    /// </summary>
    public class DataSourceException : Exception
    {
        /// <summary>
        /// The primary constructor for the DataSourceException
        /// </summary>
        /// <param name="message">An error message describing the exception</param>
        /// <param name="innerException">The exception that caused this exception to be thrown</param>
        public DataSourceException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
