using System;

namespace Merchant.Reading
{
    public interface IReadGalaxyExchangeInstructions {
        event EventHandler<GalaxyExchangeMessageReadingCompleteEventArgs> NewMessage;
        void Read(string filePath);
    }
}