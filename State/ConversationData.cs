namespace state_management_chatbot.State
{
    public class ConversationData
    {
        public ConverstationStates CurrentState { get; set; } = ConverstationStates.Welcome;
        public string Name { get; set; }
        public string Age { get; set; }
    }
}