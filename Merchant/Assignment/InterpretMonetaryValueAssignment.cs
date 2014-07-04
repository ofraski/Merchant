using System;
using System.Linq;

using Merchant.Conversion;
using Merchant.Exchanges;
using Merchant.Interpretation;
using Merchant.Response;
using Merchant.Text;
using Merchant.Tools;

namespace Merchant.Assignment
{
    public class InterpretMonetaryValueAssignment : ConvertGalaxyToRoman, IInterpret
    {
        private readonly IConvertRomanNumeral _convertNumerals;
        private readonly ICalculateMineralValue _calculate;
        private readonly IRecordMineralValue _mineralExchange;

        public InterpretMonetaryValueAssignment(
            IConvertGalaxyToRoman convertGalaxy, 
            IConvertRomanNumeral convertNumerals, 
            ICalculateMineralValue calculate, 
            IRecordMineralValue mineralExchange) : base(convertGalaxy)
        {
            _convertNumerals = convertNumerals;
            _calculate = calculate;
            _mineralExchange = mineralExchange;
        }

        public void Add(string instruction)
        {
            var statementWithoutUnits = instruction.Replace(A.MonetaryUnit, string.Empty);
            var assignment = statementWithoutUnits.Split(new[] { A.Conversion }, StringSplitOptions.RemoveEmptyEntries);

            var creditValue = decimal.Parse(assignment.Last());
            var mineralName = assignment.First().Split(A.TokenSeperator, StringSplitOptions.RemoveEmptyEntries).Last();
            var galaxyNumerals = assignment.First().Replace(mineralName, string.Empty);

            var arabic = _convertNumerals.FromRoman(GetRomanNumerals(galaxyNumerals));
            var mineralValue = _calculate.MineralValue(arabic, creditValue);

            _mineralExchange.Add(mineralName, mineralValue);
        }

        public QueryResponse Execute(string instruction)
        {
            Add(instruction);

            return QueryResponse.NotRequired;
        }
    }
}