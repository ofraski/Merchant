using System;
using System.Linq;

using Merchant.Exchanges;
using Merchant.Interpretation;
using Merchant.Response;
using Merchant.Text;

namespace Merchant.Assignment
{
    public class InterpretUnitAssignment : IInterpret
    {
        private readonly IRecordGalaxyToRoman _exchange;

        public InterpretUnitAssignment(IRecordGalaxyToRoman exchange)
        {
            _exchange = exchange;
        }

        public void Add(string instruction)
        {
            var conversionParts = instruction.Split(new[] {A.Conversion}, StringSplitOptions.None);
            _exchange.Add(conversionParts.First(), conversionParts.Last());
        }

        public QueryResponse Execute(string instruction)
        {
            Add(instruction);

            return QueryResponse.NotRequired;
        }
    }
}