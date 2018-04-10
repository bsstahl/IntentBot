using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IntentBot.Entities;

namespace IntentService.Controllers
{
    [Route("/")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "IntentHandlerService";
        }

        // POST api/values
        [HttpPost]
        public async Task<CommandResponse> Post([FromServices]IntentBot.Interfaces.IIntentHandler handler, [FromBody]UserRequest request)
        {
            return await handler.HandleRequestAsync(request);
        }

    }
}
