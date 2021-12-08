using Microsoft.Bot.Builder;
using state_management_chatbot.Services.Abstractions;
using state_management_chatbot.State;

namespace state_management_chatbot.Services
{
    public class ResponseManagerService : IResponseManagerService
    {
        public string GetResponse(ConversationData conversationData, ITurnContext context)
        {
            var userInput = context.Activity.Text;

            switch (conversationData.CurrentState)
            {
                case ConverstationStates.AskAge:
                    {
                        conversationData.Name = userInput;
                        conversationData.CurrentState = ConverstationStates.SayNameAndAge;

                        return ResponseManager.AskAge;
                    }

                case ConverstationStates.SayNameAndAge:
                    {
                        conversationData.Age = userInput;
                        conversationData.CurrentState = ConverstationStates.Welcome;

                        return ResponseManager.SayNameAndAge(conversationData.Age, conversationData.Name);
                    }

                default:
                    {
                        conversationData.CurrentState = ConverstationStates.AskAge;
                        return ResponseManager.Welcome;
                    }
            }
        }
    }
}
