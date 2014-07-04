using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Merchant.Conversion;
using Merchant.Text;

namespace Merchant.Exchanges
{
    public class GalaxyRomanExchange : IConvertGalaxyToRoman, IRecordGalaxyToRoman
    {
        private readonly Dictionary<string, string> _existing;

        public GalaxyRomanExchange(Dictionary<string, string> existing)
        {
            _existing = existing;
        }

        public ICollection KnownGalaxyNumerals
        {
            get { return _existing.Keys; }
        }

        public void Add(string galaxyNumeral, string romanNumeral)
        {
            _existing[galaxyNumeral] = romanNumeral;
        }

        public string ConvertToRoman(string galaxyNumerals)
        {
            var romanBuffer = new StringBuilder();
            foreach (var galaxyNumeral in galaxyNumerals.Split(A.TokenSeperator, StringSplitOptions.RemoveEmptyEntries))
            {
                romanBuffer.Append(_existing[galaxyNumeral]);
            }

            return romanBuffer.ToString();
        }
    }
}