using System;
using System.IO;

namespace Merchant.Reading
{
    public class GalaxyExchangeInstructionReading : IReadGalaxyExchangeInstructions
    {
        public event EventHandler<GalaxyExchangeMessageReadingCompleteEventArgs> NewMessage;

        public void Read(string filePath)
        {
            var message = String.Empty;
            using (var reader = new StreamReader(filePath)) {
                while (message != null) {
                    message = reader.ReadLine();

                    if (message != null)
                    {
                        NewMessage(this, new GalaxyExchangeMessageReadingCompleteEventArgs { Message = message });
                    }
                }
            }
        }
    }
}