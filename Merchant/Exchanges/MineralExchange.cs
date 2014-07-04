using System.Collections.Generic;

namespace Merchant.Exchanges
{
    public class MineralExchange : IRecordMineralValue, IValueMineral
    {
        private readonly Dictionary<string, decimal> _existingExchangeRecords;

        public MineralExchange(Dictionary<string, decimal> existingExchangeRecords)
        {
            _existingExchangeRecords = existingExchangeRecords;
        }

        public void Add(string mineralName, decimal mineralValue)
        {
            _existingExchangeRecords.Add(mineralName, mineralValue);
        }

        public decimal Value(string mineralName)
        {
            return _existingExchangeRecords[mineralName];
        }
    }
}