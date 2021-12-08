using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using state_management_chatbot.Services.Abstractions;
using state_management_chatbot.State;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace state_management_chatbot.Bots
{
    public class StateBot : ActivityHandler
    {
        private readonly BotState _conversationState;
        private readonly IResponseManagerService _responseManager;

        public StateBot(ConversationState conversationState, 
            IResponseManagerService responseManager)
        {
            _conversationState = conversationState;
            _responseManager = responseManager;
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            await SendCurrentState(turnContext, cancellationToken);
        }

        public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
        {
            await base.OnTurnAsync(turnContext, cancellationToken);

            await _conversationState.SaveChangesAsync(turnContext, false, cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            await SendCurrentState(turnContext, cancellationToken);
        }

        private async Task SendCurrentState(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            var conversationStateAccessors = _conversationState.CreateProperty<ConversationData>(nameof(ConversationData));
            var conversationData = await conversationStateAccessors.GetAsync(turnContext, () => new ConversationData());

            var response = _responseManager.GetResponse(conversationData, turnContext);

            await turnContext.SendActivityAsync(response);
        }
    }
}
