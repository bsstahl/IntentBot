﻿using IntentBot.Entities;
using IntentBot.Interfaces;
using System;

namespace IntentBot.FakeCommandProcessor
{
    /// <summary>
    /// A fake implementation of an IntentBot Command Processor
    /// that can be used for testing installations
    /// </summary>
    public class Processor : ICommandProcessor
    {
        IServiceProvider _serviceProvider;

        /// <summary>
        /// The primary constructor for the processor
        /// </summary>
        /// <param name="serviceProvider"></param>
        public Processor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Processes the request
        /// </summary>
        /// <param name="uri">The URI to use to process the request</param>
        /// <param name="request">The details of the user request</param>
        /// <returns></returns>
        public CommandResponse Process(string uri, UserRequest request)
        {
            return new CommandResponse()
            {
                ResponseText = $"Called '{uri}' for intent '{request.Intent.Name}'",
                ResultStatus = Status.Success
            };
        }
    }
}
