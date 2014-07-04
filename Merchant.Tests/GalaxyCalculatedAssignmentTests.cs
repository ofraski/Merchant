using Merchant.Assignment;
using Merchant.Conversion;
using Merchant.Exchanges;
using Merchant.Tools;

using Moq;
using NUnit.Framework;

namespace Merchant.Tests
{
    [TestFixture]
    public class GalaxyCalculatedAssignmentTests
    {
        [Test]
        public void Adds_first_calculation_to_exchange()
        {
            var calculate = new Mock<ICalculateMineralValue>();
            var convertGalaxy = new Mock<IConvertGalaxyToRoman>();
            var convertRoman = new Mock<IConvertRomanNumeral>();

            var mineralExchange = new Mock<IRecordMineralValue>();
            var assignment = new InterpretMonetaryValueAssignment(convertGalaxy.Object, convertRoman.Object, calculate.Object, mineralExchange.Object);

            convertGalaxy.Setup(c => c.ConvertToRoman("one")).Returns("I");
            convertRoman.Setup(c => c.FromRoman("II")).Returns(2);
            calculate.Setup(c => c.MineralValue(2, 10)).Returns(5);

            assignment.Add("one one Mint is 10 Credits");

            convertGalaxy.Verify(c => c.ConvertToRoman("one"), Times.Exactly(2));
            convertRoman.Verify(c => c.FromRoman("II"));
            calculate.Verify(c => c.MineralValue(2, 10));
            mineralExchange.Verify(e => e.Add("Mint", 5));
        }

        [Test]
        public void Adds_second_calculation_to_exchange() {
            var calculate = new Mock<ICalculateMineralValue>();
            var convertGalaxy = new Mock<IConvertGalaxyToRoman>();
            var convertRoman = new Mock<IConvertRomanNumeral>();

            var mineralExchange = new Mock<IRecordMineralValue>();
            var assignment = new InterpretMonetaryValueAssignment(convertGalaxy.Object, convertRoman.Object, calculate.Object, mineralExchange.Object);

            convertGalaxy.Setup(c => c.ConvertToRoman("one")).Returns("I");
            convertGalaxy.Setup(c => c.ConvertToRoman("ten")).Returns("X");

            convertRoman.Setup(c => c.FromRoman("IX")).Returns(9);
            calculate.Setup(c => c.MineralValue(9, 27)).Returns(3);

            assignment.Add("one ten Mercury is 27 Credits");

            convertGalaxy.Verify(c => c.ConvertToRoman("one"), Times.Exactly(1));
            convertGalaxy.Verify(c => c.ConvertToRoman("ten"), Times.Exactly(1));

            convertRoman.Verify(c => c.FromRoman("IX"));
            calculate.Verify(c => c.MineralValue(9, 27));
            mineralExchange.Verify(e => e.Add("Mercury", 3));
        }

    }
}