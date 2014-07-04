using System;
using Merchant.Response;

namespace Merchant.Reading
{
    public class GalaxyExchangeMessageHandlingCompleteEventArgs : EventArgs {
        public GalaxyExchangeResponse Response { get; set; }
    }
}