using Microsoft.Bot.Builder;
using state_management_chatbot.State;

namespace state_management_chatbot.Services.Abstractions
{
    public interface IResponseManagerService
    {
        string GetResponse(ConversationData conversationData, ITurnContext context);
    }
}
