using System;
using System.IO;

using Merchant.Messaging;
using Merchant.Reading;
using Merchant.Response;
using Merchant.UI;
using Moq;

using NUnit.Framework;

namespace Merchant.Tests.System 
{
    [TestFixture]
    class ProgramTests 
    {
        const string FakeTestFile = @"Merchant.Tests.System.ProgramTests.Setup";

        [SetUp]
        public void Setup()
        {
            try
            {
                if (!File.Exists(FakeTestFile)) {
                    File.Create(FakeTestFile);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Test]
        public void ApplicationFactory_creates_application()
        {
            var factory = new ApplicationFactory();
            var application = factory.Create();

            Assert.IsNotNull(application);
        }

        [Test]
        public void Application_checks_arguments() {
            var args = new string[0]; 
            var mockConsole = new Mock<IDisplayExchangeResponse>();
            var mockReader = new Mock<IReadGalaxyExchangeInstructions>();
            var mockHandler = new Mock<IHandleGalaxyExchangeQueries>();

            var application = new Application();
            application.Run(args, mockConsole.Object, mockReader.Object, mockHandler.Object);

            mockConsole.Verify(c => c.Info("To run this app try 'Merchant.Console.exe <filepath>'"));
        }

        [Test]
        public void Application_checks_file_path_not_empty() {
            var args = new string[] { string.Empty };
            var mockConsole = new Mock<IDisplayExchangeResponse>();
            var mockReader = new Mock<IReadGalaxyExchangeInstructions>();
            var mockHandler = new Mock<IHandleGalaxyExchangeQueries>();

            var application = new Application();
            application.Run(args, mockConsole.Object, mockReader.Object, mockHandler.Object);

            mockConsole.Verify(c => c.Info("To run this app try 'Merchant.Console.exe <filepath>'"));
        }

        [Test]
        public void Application_checks_file_path() {
            var args = new[] { "zzz" };
            var mockConsole = new Mock<IDisplayExchangeResponse>();
            var mockReader = new Mock<IReadGalaxyExchangeInstructions>();
            var mockHandler = new Mock<IHandleGalaxyExchangeQueries>();

            var application = new Application();
            application.Run(args, mockConsole.Object, mockReader.Object, mockHandler.Object);

            mockConsole.Verify(c => c.Info("Cannot find file: 'zzz'"));
        }

        [Test]
        public void Application_reads_file_from_file_path()
        {
            var args = new[] { FakeTestFile };
            var mockConsole = new Mock<IDisplayExchangeResponse>();
            var mockReader = new Mock<IReadGalaxyExchangeInstructions>();
            var mockHandler = new Mock<IHandleGalaxyExchangeQueries>();

            var application = new Application();
            application.Run(args, mockConsole.Object, mockReader.Object, mockHandler.Object);

            mockReader.Verify(reader => reader.Read(FakeTestFile));
        }

        [Test]
        public void Application_has_messaging_for_handling_new_messages_correctly_wired_up() {
            var args = new[] { FakeTestFile };
            var mockConsole = new Mock<IDisplayExchangeResponse>();
            var mockReader = new Mock<IReadGalaxyExchangeInstructions>();
            var mockHandler = new Mock<IHandleGalaxyExchangeQueries>();

            mockHandler
                .Setup(handler => handler.ReceiveMessage(It.IsAny<object>(), It.Is<GalaxyExchangeMessageReadingCompleteEventArgs>(e => e.Message == "fake instruction")))
                .Raises(handler => handler.NewResponse += null, new GalaxyExchangeMessageHandlingCompleteEventArgs { Response = new GalaxyExchangeResponse("fake response") });

            mockReader
                .Setup(reader => reader.Read(FakeTestFile))
                .Raises(reader => reader.NewMessage += null, new GalaxyExchangeMessageReadingCompleteEventArgs { Message = "fake instruction" });

            var application = new Application();
            application.Run(args, mockConsole.Object, mockReader.Object, mockHandler.Object);

            mockHandler.Verify(handler => handler.ReceiveMessage(It.IsAny<object>(), It.IsAny<GalaxyExchangeMessageReadingCompleteEventArgs>()));
        }

        [Test]
        public void Application_has_messaging_for_displaying_new_exhange_responses_correctly_wired_up() {
            var args = new[] { FakeTestFile };
            var mockConsole = new Mock<IDisplayExchangeResponse>();
            var mockReader = new Mock<IReadGalaxyExchangeInstructions>();
            var mockHandler = new Mock<IHandleGalaxyExchangeQueries>();

            mockHandler
                .Setup(handler => handler.ReceiveMessage(It.IsAny<object>(), It.Is<GalaxyExchangeMessageReadingCompleteEventArgs>(e => e.Message == "fake instruction")))
                .Raises(handler => handler.NewResponse += null, new GalaxyExchangeMessageHandlingCompleteEventArgs { Response = new GalaxyExchangeResponse("fake response") });

            mockReader
                .Setup(reader => reader.Read(FakeTestFile))
                .Raises(reader => reader.NewMessage += null, new GalaxyExchangeMessageReadingCompleteEventArgs { Message = "fake instruction" });

            var application = new Application();
            application.Run(args, mockConsole.Object, mockReader.Object, mockHandler.Object);

            mockConsole.Verify(console => console.DisplayResponse(It.IsAny<object>(), It.Is<GalaxyExchangeMessageHandlingCompleteEventArgs>(e => e.Response.Text == "fake response")));
        }

        [Test]
        public void Application_responds_correctly_given_test_input()
        {
            var args = new[] {@"System\testinput.txt"};

            var mockConsole = new Mock<IDisplayExchangeResponse>();

            var application = new Application();
            IReadGalaxyExchangeInstructions reading = new GalaxyExchangeInstructionReading();
            IHandleGalaxyExchangeQueries instructionHandler = new GalaxyExchangeInstructionHandler();
            application.Run(args, mockConsole.Object, reading, instructionHandler);

            var assert = new ConsoleAssertion(mockConsole);

            assert.Shown("pish tegj glob glob is 42");
            assert.Shown("glob prok Silver is 68 Credits");
            assert.Shown("glob prok Gold is 57800 Credits");
            assert.Shown("glob prok Iron is 782 Credits");
            assert.Shown("I have no idea what you are talking about");
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                if (File.Exists(FakeTestFile)) {
                    File.Delete(FakeTestFile);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
