using System;
using System.Collections.Generic;
using System.Text;

namespace IntentBot.Exceptions
{
    /// <summary>
    /// Indicates that a requested route is missing from the route configuration
    /// </summary>
    public class MissingRouteException : Exception
    {
        /// <summary>
        /// The primary constructor of the MissingRouteException
        /// </summary>
        /// <param name="routeName">The name of the route that has been requested but was not found in configuration</param>
        public MissingRouteException(string routeName) : base($"Missing route: '{routeName}'") { }
    }
}
