using Merchant.Messaging;
using Merchant.Reading;
using Merchant.UI;

using Moq;
using NUnit.Framework;

namespace Merchant.Client.Tests 
{
    [TestFixture]
    class ProgramTests 
    {
        [Test]
        public void Runs_application_with_supplied_arguments()
        {
            var args = new[] { @"fake\file\path" };
            var mockApplicationFactory = new Mock<ICreateApplication>();
            var mockApplication = new Mock<IOrchestrateMerchantGalaxySystem>();

            mockApplicationFactory.Setup(f => f.Create()).Returns(mockApplication.Object);

            Program.OrchestrationFactory = mockApplicationFactory.Object;
            Program.Go(args);

            mockApplication.Verify(a => a.Run(args, It.IsAny<IDisplayExchangeResponse>(), It.IsAny<IReadGalaxyExchangeInstructions>(), It.IsAny<IHandleGalaxyExchangeQueries>()));
        }
    }
}
