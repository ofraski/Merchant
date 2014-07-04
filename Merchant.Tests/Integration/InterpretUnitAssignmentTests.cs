using System.Collections.Generic;

using Merchant.Assignment;
using Merchant.Conversion;
using Merchant.Exchanges;
using Merchant.Tools;

using NUnit.Framework;

namespace Merchant.Tests.Integration
{
    [TestFixture]
    class InterpretUnitAssignmentTests
    {
        [Test]
        public void Calculates_mineral_value_given_instruction_with_single_galaxy_numeral() {
            var calculate = new MineralValueCalculator();
            var noExistingConversions = new Dictionary<string, string>();
            var convertGalaxy = new GalaxyRomanExchange(noExistingConversions);
            var convertRoman = new RomanNumeralConverter();

            var existingExchangeListings = new Dictionary<string, decimal>();
            var mineralExchange = new MineralExchange(existingExchangeListings);
            var assignment = new InterpretMonetaryValueAssignment(convertGalaxy, convertRoman, calculate, mineralExchange);

            convertGalaxy.Add("hundred", "C");

            assignment.Add("hundred hundred Manganese is 1400 Credits");

            Assert.AreEqual(7, mineralExchange.Value("Manganese"));
        }

        [Test]
        public void Calculates_mineral_value_given_instruction_with_multiple_galaxy_numerals() {
            var calculate = new MineralValueCalculator();
            var noExistingConversions = new Dictionary<string, string>();
            var convertGalaxy = new GalaxyRomanExchange(noExistingConversions);
            var convertRoman = new RomanNumeralConverter();

            var existingExchangeListings = new Dictionary<string, decimal>();
            var mineralExchange = new MineralExchange(existingExchangeListings);
            var assignment = new InterpretMonetaryValueAssignment(convertGalaxy, convertRoman, calculate, mineralExchange);

            convertGalaxy.Add("ten", "X");
            convertGalaxy.Add("fifty", "L");
            convertGalaxy.Add("thousand", "M");

            assignment.Add("thousand fifty ten Moles is 2120 Credits");

            Assert.AreEqual(2, mineralExchange.Value("Moles"));
        }
    }
}