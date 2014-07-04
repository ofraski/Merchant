using Merchant.Assignment;
using Merchant.Exchanges;

using Moq;
using NUnit.Framework;

namespace Merchant.Tests
{
    [TestFixture]
    public class GalaxyToRomanAssignmentTests
    {
        [Test]
        public void Adds_first_assignment_to_exchange()
        {
            var exchange = new Mock<IRecordGalaxyToRoman>();
            var assignment = new InterpretUnitAssignment(exchange.Object);

            assignment.Add("one is I");
            exchange.Verify(e => e.Add("one", "I"));
        }

        [Test]
        public void Adds_second_assignment_to_exchange()
        {
            var exchange = new Mock<IRecordGalaxyToRoman>();
            var assignment = new InterpretUnitAssignment(exchange.Object);

            assignment.Add("five is V");
            exchange.Verify(e => e.Add("five", "V"));
        }
    }
}