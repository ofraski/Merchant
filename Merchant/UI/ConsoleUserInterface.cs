using System;
using Merchant.Reading;
using Merchant.Response;

namespace Merchant.UI
{
    public class ConsoleUserInterface : IDisplayExchangeResponse 
    {
        internal void Output(GalaxyExchangeResponse response) 
        {
            if (string.IsNullOrWhiteSpace(response.Text))
                return;

            Console.WriteLine(response.Text);
        }

        public void Info(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayResponse(object sender, GalaxyExchangeMessageHandlingCompleteEventArgs e)
        {
            Output(e.Response);
        }
    }
}