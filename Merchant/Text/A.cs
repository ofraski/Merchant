namespace Merchant.Text
{
    public static class A
    {
        public const string MonetaryUnit = "Credits";
        public const string QuestionMark = " ?";
        public const string QuestionOfValue = "how much is ";
        public const string QuestionOfQuantity = "how many Credits is ";
        public const string Conversion = " is ";
        public const string ConfusedResponse = "I have no idea what you are talking about";
        public const string TwoHundred = "OK";

        public static string[] TokenSeperator { get { return new []{" "}; } }
    }
}