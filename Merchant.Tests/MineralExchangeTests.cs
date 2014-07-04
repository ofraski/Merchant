using System.Collections.Generic;

using Merchant.Exchanges;
using NUnit.Framework;

namespace Merchant.Tests
{
    [TestFixture]
    public class MineralExchangeTests
    {
        [Test]
        public void Records_and_retrieves_first_mineral_value()
        {
            var existingExchangeRecords = new Dictionary<string, decimal>();
            var exchange = new MineralExchange(existingExchangeRecords);
            exchange.Add("Quartz", 3m);

            Assert.AreEqual(3m, exchange.Value("Quartz"));
        }

        [Test]
        public void Records_and_retrieves_second_mineral_value() {
            var existingExchangeRecords = new Dictionary<string, decimal>();
            var exchange = new MineralExchange(existingExchangeRecords);
            exchange.Add("Topaz", 8m);

            Assert.AreEqual(8m, exchange.Value("Topaz"));
        }
    }
}