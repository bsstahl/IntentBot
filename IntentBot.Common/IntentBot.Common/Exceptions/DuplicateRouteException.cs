using System;
using System.Collections.Generic;
using System.Text;

namespace IntentBot.Exceptions
{
    /// <summary>
    /// An error indicating that a route name has been duplicated
    /// </summary>
    [Serializable]
    public class DuplicateRouteException : Exception
    {
        /// <summary>
        /// The primary constructor of the DuplicateRouteException
        /// </summary>
        /// <param name="routeName">The name of the route that has been duplicated.</param>
        public DuplicateRouteException(string routeName) : base($"Duplicate route: '{routeName}'") { }
    }
}
