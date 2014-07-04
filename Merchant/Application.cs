using System.IO;
using System.Linq;

using Merchant.Messaging;
using Merchant.Reading;
using Merchant.UI;

namespace Merchant
{
    public class Application : IOrchestrateMerchantGalaxySystem
    {
        public string FilePath { get; private set; }

        public void Run(string[] args, IDisplayExchangeResponse userInterface, IReadGalaxyExchangeInstructions reader, IHandleGalaxyExchangeQueries instructionHandler)
        {
            if (!args.Any()) 
            {
                ShowInstructions(userInterface);
                return;
            }

            FilePath = args[0];

            if (!FilePath.Any()) 
            {
                ShowInstructions(userInterface);
                return;
            }

            if (!File.Exists(FilePath))
            {
                ShowMissingFile(userInterface);
                return;
            }

            instructionHandler.NewResponse += userInterface.DisplayResponse;
            reader.NewMessage += instructionHandler.ReceiveMessage;

            reader.Read(FilePath);
        }

        private void ShowMissingFile(IDisplayExchangeResponse userInterface)
        {
            userInterface.Info("Cannot find file: '" + FilePath + "'");
        }

        private static void ShowInstructions(IDisplayExchangeResponse userInterface) 
        {
            userInterface.Info("To run this app try 'Merchant.Console.exe <filepath>'");
        }
    }
}