using Merchant.Conversion;
using Merchant.Exchanges;
using Merchant.Query;
using Merchant.Tools;

using Moq;

using NUnit.Framework;

namespace Merchant.Tests {
    [TestFixture]
    class InterpretMonetaryValueQueryTests {
        [Test]
        public void Retrieves_first_exchange_rate()
        {
            var calculate = new Mock<ICalculateMineralValue>();
            var convertGalaxy = new Mock<IConvertGalaxyToRoman>();
            var convertRoman = new Mock<IConvertRomanNumeral>();
            var mineralExchange = new Mock<IValueMineral>();

            convertGalaxy.Setup(c => c.ConvertToRoman("ten")).Returns("X");
            convertRoman.Setup(c => c.FromRoman("X")).Returns(10);
            mineralExchange.Setup(c => c.Value("Zircon")).Returns(8);

            var query = new InterpretMonetaryValueQuery(convertGalaxy.Object, convertRoman.Object, calculate.Object, mineralExchange.Object);

            query.Value("how many Credits is ten Zircon ?");

            convertGalaxy.Verify(e => e.ConvertToRoman("ten"));
            convertRoman.Verify(c => c.FromRoman("X"));
            mineralExchange.Verify(e => e.Value("Zircon"));
            calculate.Verify(c => c.CreditValue(10, 8));
        }

        [Test]
        public void Retrieves_second_exchange_rate() {
            var calculate = new Mock<ICalculateMineralValue>();
            var convertGalaxy = new Mock<IConvertGalaxyToRoman>();
            var convertRoman = new Mock<IConvertRomanNumeral>();
            var mineralExchange = new Mock<IValueMineral>();

            convertGalaxy.Setup(c => c.ConvertToRoman("thousand")).Returns("M");
            convertRoman.Setup(c => c.FromRoman("M")).Returns(1000);
            mineralExchange.Setup(c => c.Value("Apatite")).Returns(3);

            var query = new InterpretMonetaryValueQuery(convertGalaxy.Object, convertRoman.Object, calculate.Object, mineralExchange.Object);

            query.Value("how many Credits is thousand Apatite ?");

            convertGalaxy.Verify(e => e.ConvertToRoman("thousand"));
            convertRoman.Verify(c => c.FromRoman("M"));
            mineralExchange.Verify(e => e.Value("Apatite"));
            calculate.Verify(c => c.CreditValue(1000, 3));
        }
    }
}
