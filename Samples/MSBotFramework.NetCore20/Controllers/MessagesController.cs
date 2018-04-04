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
                // TODO: Make the call to Intent Provider async
                // TODO: Make the call to Intent Router async

                var intent = intentProvider.GetIntent(activity.Text);

                // TODO: Add user data to request
                // TODO: Add source data to request
                var request = new IntentBot.UserRequestBuilder().AddIntent(intent).Build();
                var routingResult = intentRouter.RouteToHandler(request);
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
