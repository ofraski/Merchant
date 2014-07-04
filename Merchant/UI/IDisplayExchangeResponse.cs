using Merchant.Reading;

namespace Merchant.UI
{
    public interface IDisplayExchangeResponse
    {
        void Info(string message);
        void DisplayResponse(object sender, GalaxyExchangeMessageHandlingCompleteEventArgs e);
    }
}