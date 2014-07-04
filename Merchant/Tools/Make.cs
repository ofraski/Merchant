using Merchant.Conversion;

namespace Merchant.Tools
{
    public static class Make
    {
        public static IConvertRomanNumeral RomanNumeralConverter {
            get { return new RomanNumeralConverter(); }
        }

        public static ICalculateMineralValue MineralValueCalculator {
            get { return new MineralValueCalculator(); }
        }
    }
}