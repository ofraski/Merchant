using Merchant.Messaging;
using Merchant.Reading;
using Merchant.UI;

namespace Merchant
{
    public interface IOrchestrateMerchantGalaxySystem {
        string FilePath { get; }
        void Run(string[] args, IDisplayExchangeResponse userInterface, IReadGalaxyExchangeInstructions reader, IHandleGalaxyExchangeQueries instructionHandler);
    }
}