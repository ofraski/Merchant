using System;
using Merchant.Messaging;
using Merchant.Reading;
using Merchant.UI;

namespace Merchant.Client 
{
    public class Program
    {
        public static ICreateApplication OrchestrationFactory = new ApplicationFactory();

        static void Main(string[] args)
        {
            Go(args);

#if DEBUG
            Console.ReadLine();
#endif
        }

        public static void Go(string[] args)
        {
            var userInterface = new ConsoleUserInterface();
            var reading = new GalaxyExchangeInstructionReading();
            var instructionHandler = new GalaxyExchangeInstructionHandler();

            var instance = OrchestrationFactory.Create();
            instance.Run(args, userInterface, reading, instructionHandler);
        }
    }
}
