using Merchant.Conversion;
using Merchant.Interpretation;
using Merchant.Response;
using Merchant.Text;

namespace Merchant.Query
{
    public class InterpretUnitQuery : IInterpret
    {
        private readonly IConvertGalaxyToRoman _exchange;

        public InterpretUnitQuery(IConvertGalaxyToRoman exchange)
        {
            _exchange = exchange;
        }

        public QueryResponse GalaxyValue(string message)
        {
            var removedNonNumeral = message.Replace(A.QuestionOfValue, string.Empty);
            var galaxyNumeral = removedNonNumeral.Replace(A.QuestionMark, string.Empty);

            return new QueryResponse(galaxyNumeral, _exchange.ConvertToRoman(galaxyNumeral));
        }

        public QueryResponse Execute(string instruction)
        {
            return GalaxyValue(instruction);
        }
    }
}