using System.Collections.Generic;

using Merchant.Exchanges;

namespace Merchant.Tools
{
    public sealed class ExchangesFactory {
        private static readonly Dictionary<string, decimal> NoExchangeRecords = new Dictionary<string, decimal>();
        private static readonly Dictionary<string, string> NoGalaxyConversions = new Dictionary<string, string>();
        
        private static readonly ExchangesFactory ExchangeFactory = new ExchangesFactory(NoExchangeRecords, NoGalaxyConversions);

        private readonly MineralExchange _mineralExchange;
        private readonly GalaxyRomanExchange _galaxyRomanExchange;

        private ExchangesFactory(Dictionary<string, decimal> exchangeRecords, Dictionary<string, string> galaxyConversions)
        {
            _mineralExchange = new MineralExchange(exchangeRecords);
            _galaxyRomanExchange = new GalaxyRomanExchange(galaxyConversions);
        }

        public MineralExchange MineralExchange
        {
            get { return _mineralExchange; }
        }

        public GalaxyRomanExchange GalaxyRomanExchange
        {
            get { return _galaxyRomanExchange; }
        }

        public static ExchangesFactory Instance 
        {
            get { return ExchangeFactory; }
        }
    }
}