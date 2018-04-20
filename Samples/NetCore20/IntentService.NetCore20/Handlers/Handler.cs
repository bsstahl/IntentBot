using System;
using System.Threading.Tasks;
using IntentBot.Entities;

namespace IntentService.Handlers
{
    public class Handler : IntentBot.Interfaces.IIntentHandler
    {
        IServiceProvider _serviceProvider;

        public Handler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        Task<CommandResponse> IntentBot.Interfaces.IIntentHandler.HandleRequestAsync(UserRequest request)
        {
            // TODO: Handle request appropriately
            return Task.Run(() =>
            {
                return new CommandResponse()
                {
                    RequiresUserConfirmation = false,
                    IsAdditionalInformationAvailable = false,
                    UriResponse = string.Empty,
                    PhoneNumberResponse = string.Empty,
                    ResultStatus = Status.Success,
                    ResponseText = request.Intent.Utterance
                };
            });
        }
    }

}

