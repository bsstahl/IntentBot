using System;
using System.Net.Http;
using System.Threading.Tasks;
using IntentBot.Entities;
using IntentBot.Interfaces;
using IntentBot.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace IntentBot.DefaultCommandProcessor
{
    /// <summary>
    /// The default processor for IntentBot commands
    /// </summary>
    public class Processor : ICommandProcessor
    {
        IServiceProvider _serviceProvider;

        /// <summary>
        /// The primary constructor of the Processor
        /// </summary>
        /// <param name="serviceProvider">The service provider to be used to provide dependencies</param>
        public Processor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Processes the user request using the specified URI
        /// </summary>
        /// <param name="uri">The URI to be used to process the request</param>
        /// <param name="request">The user request to be processed</param>
        /// <returns>An IntentBot.Entities.CommandResponse object representing the result of the processing</returns>
        public async Task<CommandResponse> ProcessAsync(string uri, UserRequest request)
        {
            var restProxy = _serviceProvider.GetService<IHttpProxy>();

            var jsonData = JsonConvert.SerializeObject(request);
            var requestContent = jsonData.AsIHttpContent("application/json");
            Console.WriteLine($"Issuing call to Command Processor '{uri}'");
            var response = await restProxy.PostAsync(uri, requestContent);
            if (response.IsSuccessStatusCode)
                Console.WriteLine("Response returned successfully from Command Processor");
            else
                throw new Exceptions.DataSourceException("Request to Command Processor failed", null); // TODO: Add data to exception

            return response.AsCommandResponse();
        }

    }
}
