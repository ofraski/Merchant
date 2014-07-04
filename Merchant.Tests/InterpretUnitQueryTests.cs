using Merchant.Conversion;
using Merchant.Query;
using Moq;
using NUnit.Framework;

namespace Merchant.Tests
{
    [TestFixture]
    public class InterpretUnitQueryTests
    {
        [Test]
        public void Retrieves_first_exchange_rate()
        {
            var exchange = new Mock<IConvertGalaxyToRoman>();
            var query = new InterpretUnitQuery(exchange.Object);

            query.GalaxyValue("how much is one ?");
            exchange.Verify(e => e.ConvertToRoman("one"));
        }

        [Test]
        public void Retrieves_second_exchange_rate()
        {
            var exchange = new Mock<IConvertGalaxyToRoman>();
            var query = new InterpretUnitQuery(exchange.Object);

            query.GalaxyValue("how much is two ?");
            exchange.Verify(e => e.ConvertToRoman("two"));
        }
    }
}