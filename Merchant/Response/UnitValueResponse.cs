using Merchant.Text;
using Merchant.Tools;

namespace Merchant.Response
{
    public class UnitValueResponse : GalaxyExchangeResponse
    {
        private readonly QueryResponse _response;

        public UnitValueResponse(QueryResponse response)
        {
            _response = response;
        }

        public override string Text
        {
            get {
                return _response.GalaxyNumerals + 
                       A.Conversion + 
                       Make.RomanNumeralConverter.FromRoman(_response.Text);
            }
        }
    }
}