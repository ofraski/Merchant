using System.Linq;
using Merchant.Text;

namespace Merchant.Response
{
    public class MonetaryValueResponse : GalaxyExchangeResponse
    {
        private readonly QueryResponse _response;

        public MonetaryValueResponse(QueryResponse response)
        {
            _response = response;
        }

        public override string Text {
            get
            {
                return _response.GalaxyNumerals +
                       _response.Text +
                       A.Conversion +
                       _response.Value.ToString("G29") +
                       A.TokenSeperator.Single() +
                       A.MonetaryUnit;
            }
        }
    }
}