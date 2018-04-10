using System;
using System.Threading.Tasks;
using IntentBot.Entities;

namespace IntentService.EchoIntentHandler
{
    public class Handler : IntentBot.Interfaces.IIntentHandler
    {
        IServiceProvider _serviceProvider;

        public Handler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<CommandResponse> HandleRequestAsync(UserRequest request)
        {
            await Task.Yield();
            return new CommandResponse()
            {
                RequiresUserConfirmation = false,
                UriResponse = string.Empty,
                ResultStatus = Status.Success,
                ResponseText = request.Intent.Utterance
            };
        }

    }
}
