using System.Collections.Generic;
using Merchant.Exchanges;
using NUnit.Framework;

namespace Merchant.Tests
{
    [TestFixture]
    public class GalaxyRomanExchangeTests
    {
        [Test]
        public void Returns_first_mapped_galaxy_to_roman_values()
        {
            var existingConversions = new Dictionary<string, string> { { "one", "I" } };

            var exchange = new GalaxyRomanExchange(existingConversions);
            Assert.AreEqual("I", exchange.ConvertToRoman("one"));
        }

        [Test]
        public void Returns_second_mapped_galaxy_to_roman_values()
        {
            var existingConversions = new Dictionary<string, string>
            {
                { "five", "V" }, 
                { "ten", "X" }
            };

            var exchange = new GalaxyRomanExchange(existingConversions);
            Assert.AreEqual("X", exchange.ConvertToRoman("ten"));
        }

        [Test]
        public void Returns_jointly_mapped_galaxy_to_roman_values() {
            var existingConversions = new Dictionary<string, string>
            {
                { "one", "I" }, 
                { "five", "V" }, 
                { "ten", "X" }
            };

            var exchange = new GalaxyRomanExchange(existingConversions);
            Assert.AreEqual("XVI", exchange.ConvertToRoman("ten five one"));
        }

        [Test]
        public void Keys_contains_first_added_galaxy_numeral()
        {
            var noExistingConversions = new Dictionary<string, string>();
            var exchange = new GalaxyRomanExchange(noExistingConversions);
            exchange.Add("fifty ", "D");
            Assert.Contains("fifty ", exchange.KnownGalaxyNumerals);
        }

        [Test]
        public void Keys_contains_second_added_galaxy_numeral()
        {
            var noExistingConversions = new Dictionary<string, string>();
            var exchange = new GalaxyRomanExchange(noExistingConversions);
            exchange.Add("hundred ", "C");
            Assert.Contains("hundred ", exchange.KnownGalaxyNumerals);
        }
    }
}