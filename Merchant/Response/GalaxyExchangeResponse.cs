namespace Merchant.Response
{
    public class GalaxyExchangeResponse
    {
        protected readonly string Message = string.Empty;

        public GalaxyExchangeResponse()
        { }

        public GalaxyExchangeResponse(string message)
        {
            Message = message;
        }

        public virtual string Text
        {
            get { return Message; }
        }

        public static GalaxyExchangeResponse None
        {
            get { return new GalaxyExchangeResponse(); }
        }
    }
}