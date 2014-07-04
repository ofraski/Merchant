using System;
using System.Linq;

namespace Merchant.Conversion
{
    public class RomanNumeralConverter : IConvertRomanNumeral
    {
        // ReSharper disable UnusedMember.Local
        private enum RomanSymbols {
            M = 1000,
            CM = 900,
            D = 500,
            CD = 400,
            C = 100,
            XC = 90,
            L = 50,
            XL = 40,
            X = 10,
            IX = 9,
            V = 5,
            IV = 4,
            I = 1
        }
        // ReSharper restore UnusedMember.Local

        private static decimal GetArabic(string roman) {
            return (from RomanSymbols symbol
                in Enum.GetValues(typeof(RomanSymbols))
                where roman == symbol.ToString()
                select GetArabic(symbol)).FirstOrDefault();
        }

        private static decimal GetArabic(RomanSymbols numeral) {
            return (decimal)numeral;
        }

        private static class SequenceLength {
            public static string One(string roman) {
                return roman.Substring(0, 1);
            }

            public static string Two(string roman) {
                return roman.Substring(0, 2);
            }
        }

        public decimal FromRoman(string roman) {
            decimal arabic = 0;

            while (roman.Any()) {
                if (RomanNumeralExceptions.FoundInvalid(roman)) {
                    return 0;
                }
                if (roman.Length <= 1) {
                    arabic += GetArabic(SequenceLength.One(roman));
                    roman = roman.Substring(1);
                    continue;
                }
                var foundArabic = GetArabic(SequenceLength.Two(roman));

                if (foundArabic > 0) {
                    arabic += foundArabic;
                    roman = roman.Substring(2);
                    continue;
                }
                arabic += GetArabic(SequenceLength.One(roman));
                roman = roman.Substring(1);
            }

            return arabic;
        }
    }
}