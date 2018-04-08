using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IntentBot.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Connector;
using Microsoft.Extensions.Configuration;


namespace IntentBot.Orchestrator
{
    // [BotAuthentication]
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private readonly IConfiguration configuration;

        public MessagesController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // POST api/values
        [HttpPost]
        public async Task<OkResult> Post([FromServices]IIntentProvider intentProvider, [FromServices]IIntentRouter intentRouter, [FromBody] Activity activity)
        {
            var appCredentials = new MicrosoftAppCredentials(
                configuration.GetSection(MicrosoftAppCredentials.MicrosoftAppIdKey)?.Value,
                configuration.GetSection(MicrosoftAppCredentials.MicrosoftAppPasswordKey)?.Value);
            var client = new ConnectorClient(new Uri(activity.ServiceUrl), appCredentials);

            var reply = activity.CreateReply();
            if (activity.Type == ActivityTypes.Message)
            {
                Console.WriteLine($"Calling intent provider '{intentProvider.GetType().FullName}' with '{activity.Text}'");
                var intent = await intentProvider.GetIntentAsync(activity.Text);
                Console.WriteLine($"Intent provider returned '{intent.Name}'");

                // TODO: Add real user data to request
                // TODO: Add real source data to request
                var request = new IntentBot.UserRequestBuilder()
                    .AddIntent(intent)
                    .AddUser("FakeUserId", "PHX")
                    .AddSource("FakeRequestSource")
                    .Build();

                Console.WriteLine($"Routing request to '{intentRouter.GetType().FullName}'");
                var routingResult = await intentRouter.RouteToHandlerAsync(request);
                Console.WriteLine($"Service returned '{routingResult.ResponseText}'");

                reply.Text = routingResult.ResponseText;
            }
            else
            {
                reply.Text = $"activity type: {activity.Type}";
            }

            await client.Conversations.ReplyToActivityAsync(reply);
            return Ok();
        }
    }
}
