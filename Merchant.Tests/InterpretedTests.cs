using NUnit.Framework;

namespace Merchant.Tests
{
    [TestFixture]
    public partial class InterpreterTests
    {
        [Test]
        public void Maintains_link_with_galaxy_exchange_across_different_interpreters() {
            Interpreted.For("fifty is L");
            Interpreted.For("hundred is C");

            Assert.AreEqual("L", Interpreted.For("how much is fifty ?").Text);
            Assert.AreEqual("C", Interpreted.For("how much is hundred ?").Text);
        }
    }
}