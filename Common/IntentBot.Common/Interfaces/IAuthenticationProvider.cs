using IntentBot.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IntentBot.Interfaces
{
    /// <summary>
    /// Identifies a user from the information passed by an endpoint source 
    /// such as Twilio or Slack and returns a User object ready for processing
    /// by the Bot engine.
    /// </summary>
    public interface IAuthenticationProvider
    {
        /// <summary>
        /// Identify the user from the information passed by the endpoint
        /// </summary>
        /// <param name="identityTypeCode">Identifies the type of identifer. 
        /// May be the endpoint name, may be something generic like 'email'.</param>
        /// <param name="userIdentifier">The information identifying the user</param>
        /// <returns>A User object containing basic information about the requesting user</returns>
        Task<User> AuthenticateAsync(string identityTypeCode, string userIdentifier);
    }
}
