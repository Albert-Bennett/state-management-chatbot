namespace state_management_chatbot
{
    public class ResponseManager
    {
        static readonly string NAME_TOKEN = "[NAME]";
        static readonly string AGE_TOKEN = "[AGE]";

        public static string Welcome = Responses.Welcome;
        public static string AskAge = Responses.AskAge;

        public static string SayNameAndAge(string age, string name)
        {
            return Responses.SayNameAndAge
                .Replace(AGE_TOKEN, age)
                .Replace(NAME_TOKEN, name);
        }
    }
}
