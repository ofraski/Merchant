using Merchant.Text;

namespace Merchant.Response
{
    public class QueryResponse 
    {
        public string GalaxyNumerals { get; private set; }
        public decimal Value { get; private set; }
        public string Text { get; private set; }

        public QueryResponse(string galaxyNumerals, string mineralName, decimal value)
        {
            GalaxyNumerals = galaxyNumerals;
            Text = mineralName;
            Value = value;
        }

        public QueryResponse(string galaxyNumerals, string romanNumerals) {
            GalaxyNumerals = galaxyNumerals;
            Text = romanNumerals;
        }

        public static QueryResponse NotRequired
        {
            get { return new QueryResponse(string.Empty, A.TwoHundred); }
        }
    }
}