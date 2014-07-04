using Merchant.Messaging;
using Merchant.Reading;
using Merchant.UI;
using Moq;

namespace Merchant.Tests.System
{
    internal class ConsoleAssertion
    {
        private readonly Mock<IDisplayExchangeResponse> _mockConsole;

        public ConsoleAssertion(Mock<IDisplayExchangeResponse> mockConsole)
        {
            _mockConsole = mockConsole;
        }

        public void Shown(string message)
        {
            _mockConsole.Verify(c => c.DisplayResponse(It.IsAny<GalaxyExchangeInstructionHandler>(), It.Is<GalaxyExchangeMessageHandlingCompleteEventArgs>(e => e.Response.Text == message)));
        }
    }
}