using System;
using System.Linq;

using Merchant.Conversion;
using Merchant.Exchanges;
using Merchant.Interpretation;
using Merchant.Response;
using Merchant.Text;
using Merchant.Tools;

namespace Merchant.Query
{
    public class InterpretMonetaryValueQuery : ConvertGalaxyToRoman, IInterpret
    {
        private readonly IConvertRomanNumeral _convertRoman;
        private readonly ICalculateMineralValue _calculate;
        private readonly IValueMineral _priceMineral;

        public InterpretMonetaryValueQuery(
            IConvertGalaxyToRoman convertGalaxy, 
            IConvertRomanNumeral convertRoman, 
            ICalculateMineralValue calculate,
            IValueMineral priceMineral)
            : base(convertGalaxy)
        {
            _convertRoman = convertRoman;
            _calculate = calculate;
            _priceMineral = priceMineral;
        }

        public QueryResponse Value(string queryText)
        {
            var queryWithoutQuestionParts = 
                    queryText
                    .Replace(A.QuestionOfQuantity, string.Empty)
                    .Replace(A.QuestionMark, string.Empty);

            var mineralName =
                    queryWithoutQuestionParts
                    .Split(A.TokenSeperator, StringSplitOptions.RemoveEmptyEntries)
                    .Last();

            var galaxyNumerals = queryWithoutQuestionParts.Replace(mineralName, string.Empty);
            var roman = GetRomanNumerals(galaxyNumerals);
            var arabic = _convertRoman.FromRoman(roman);
            var mineralValue = _priceMineral.Value(mineralName);

            return new QueryResponse(galaxyNumerals, mineralName, _calculate.CreditValue(arabic, mineralValue));
        }

        public QueryResponse Execute(string instruction)
        {
            return Value(instruction);
        }
    }
}