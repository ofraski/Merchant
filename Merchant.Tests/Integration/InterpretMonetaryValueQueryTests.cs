using System.Collections.Generic;

using Merchant.Conversion;
using Merchant.Exchanges;
using Merchant.Query;
using Merchant.Tools;

using NUnit.Framework;

namespace Merchant.Tests.Integration {
    [TestFixture]
    class InterpretMonetaryValueQueryTests {
        [Test]
        public void Retrieves_first_exchange_rate()
        {
            const int expectedValue = 80;
            const string expectedGalaxyNumerals = "ten ";

            var calculate = new MineralValueCalculator();
            var listed = new Dictionary<string, string> {{"ten", "X"}};
            var convertGalaxy = new GalaxyRomanExchange(listed);
            var convertRoman = new RomanNumeralConverter();
            var existingExchangeRecords = new Dictionary<string, decimal> {{"Gypsum", 8m}};
            var mineralExchange = new MineralExchange(existingExchangeRecords);

            var query = new InterpretMonetaryValueQuery(convertGalaxy, convertRoman, calculate, mineralExchange);
            var result = query.Value("how many Credits is ten Gypsum ?");

            Assert.AreEqual(expectedValue, result.Value);
            Assert.AreEqual(expectedGalaxyNumerals, result.GalaxyNumerals);
        }

        [Test]
        public void Retrieves_second_exchange_rate() {
            const int expectedValue = 11000;
            const string expectedGalaxyNumerals = "thousand hundred ";

            var calculate = new MineralValueCalculator();
            var listed = new Dictionary<string, string>
            {
                { "hundred", "C"}, 
                { "thousand", "M" }
            };

            var convertGalaxy = new GalaxyRomanExchange(listed);
            var convertRoman = new RomanNumeralConverter();
            var existingExchangeRecords = new Dictionary<string, decimal> { { "Flourite", 10m } };
            var mineralExchange = new MineralExchange(existingExchangeRecords);

            var query = new InterpretMonetaryValueQuery(convertGalaxy, convertRoman, calculate, mineralExchange);
            var result = query.Value("how many Credits is thousand hundred Flourite ?");

            Assert.AreEqual(expectedValue, result.Value);
            Assert.AreEqual(expectedGalaxyNumerals, result.GalaxyNumerals);
        }
    }
}
