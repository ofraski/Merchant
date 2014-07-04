using Merchant.Conversion;

using NUnit.Framework;

namespace Merchant.Tests
{
    [TestFixture]
    public class RomanNumeralConverterTests {
        [TestCase("I", 1)]
        [TestCase("V", 5)]
        [TestCase("X", 10)]
        [TestCase("L", 50)]
        [TestCase("C", 100)]
        [TestCase("D", 500)]
        [TestCase("M", 1000)]
        public void Parses_single_character_roman_numeral(string romanNumeral, decimal expectedIndoArabic) {
            AssertParsed(romanNumeral, expectedIndoArabic);
        }

        [TestCase("II", 2)]
        [TestCase("III", 3)]
        [TestCase("XX", 20)]
        [TestCase("XXX", 30)]
        [TestCase("CC", 200)]
        [TestCase("CCC", 300)]
        [TestCase("MM", 2000)]
        [TestCase("MMM", 3000)]
        public void Parses_multiple_character_roman_numerals(string romanNumeral, decimal expectedIndoArabic) {
            AssertParsed(romanNumeral, expectedIndoArabic);
        }

        [TestCase("IV", 4)]
        [TestCase("IX", 9)]
        [TestCase("XL", 40)]
        [TestCase("XC", 90)]
        [TestCase("CD", 400)]
        [TestCase("CM", 900)]
        public void Parses_mixed_character_roman_numerals(string romanNumeral, decimal expectedIndoArabic) {
            AssertParsed(romanNumeral, expectedIndoArabic);
        }

        [TestCase("XXXIX", 39)]
        [TestCase("CCCXC", 390)]
        [TestCase("MMMCM", 3900)]
        public void Parses_mixed_character_roman_numerals_of_four_repeated_characters(string romanNumeral, decimal expectedIndoArabic) {
            AssertParsed(romanNumeral, expectedIndoArabic);
        }

        [TestCase("IIII")]
        [TestCase("VVVV")]
        [TestCase("XXXX")]
        [TestCase("CCCC")]
        [TestCase("MMMM")]
        [TestCase("XXXVX")]
        [TestCase("CCCIC")]
        [TestCase("CCCVC")]
        [TestCase("CCCLC")]
        [TestCase("MMMIM")]
        [TestCase("MMMVM")]
        [TestCase("MMMXM")]
        [TestCase("MMMLM")]
        [TestCase("MMMDM")]
        public void Fails_to_parse_non_valid_roman_numerals_of_four_repeated_characters(string romanNumeral) {
            AssertFails(romanNumeral);
        }

        [TestCase("DD")]
        [TestCase("LL")]
        [TestCase("VV")]
        public void Fails_to_parse_non_valid_roman_numerals_of_disorder(string romanNumeral) {
            AssertFails(romanNumeral);
        }

        public void AssertParsed(string romanNumeral, decimal expectedIndoArabic) {
            var conversion = new RomanNumeralConverter();
            decimal actualIndoArabic =  conversion.FromRoman(romanNumeral);

            Assert.That(actualIndoArabic, Is.GreaterThan(0),
                string.Format("Failed to convert '{0}', expecting '{1}'", romanNumeral, expectedIndoArabic));

            Assert.AreEqual(expectedIndoArabic, actualIndoArabic,
                string.Format("Failed to correctly convert '{0}', expecting '{1}'", romanNumeral, expectedIndoArabic));
        }

        public void AssertFails(string invalid) {
            var conversion = new RomanNumeralConverter();
            decimal actualIndoArabic = conversion.FromRoman(invalid);

            Assert.That(actualIndoArabic, Is.EqualTo(0), 
                string.Format("Should have failed to parse '{0}'", invalid));
        }
    }
}