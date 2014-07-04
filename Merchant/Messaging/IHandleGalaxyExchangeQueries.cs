using System;
using Merchant.Reading;
using Merchant.Response;

namespace Merchant.Messaging
{
    public interface IHandleGalaxyExchangeQueries
    {
        GalaxyExchangeResponse Response(string queryText);
        event EventHandler<GalaxyExchangeMessageHandlingCompleteEventArgs> NewResponse;
        void ReceiveMessage(object sender, GalaxyExchangeMessageReadingCompleteEventArgs e);
    }
}