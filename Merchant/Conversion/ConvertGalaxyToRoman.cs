using System;
using System.Linq;
using System.Text;

using Merchant.Text;

namespace Merchant.Conversion
{
    public abstract class ConvertGalaxyToRoman {
        private readonly IConvertGalaxyToRoman _convertGalaxy;

        protected ConvertGalaxyToRoman(IConvertGalaxyToRoman convertGalaxy)
        {
            _convertGalaxy = convertGalaxy;
        }

        protected string GetRomanNumerals(string galaxyNumerals) {
            var romanNumeralsBuffer = new StringBuilder();

            foreach (var romanNumeral
                in galaxyNumerals
                    .Split(A.TokenSeperator, StringSplitOptions.RemoveEmptyEntries)
                    .Select(galaxyNumeral => _convertGalaxy.ConvertToRoman(galaxyNumeral))) { romanNumeralsBuffer.Append(romanNumeral); }

            return romanNumeralsBuffer.ToString();
        }
    }
}