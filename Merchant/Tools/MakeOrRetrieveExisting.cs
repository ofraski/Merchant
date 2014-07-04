using Merchant.Conversion;
using Merchant.Exchanges;

namespace Merchant.Tools
{
    public static class RetrieveExisting
    {
        public static IConvertGalaxyToRoman GalaxyNumeralConverter
        {
            get { return ExchangesFactory.Instance.GalaxyRomanExchange; }
        }

        public static IRecordGalaxyToRoman GalaxyNumeralLedger 
        {
            get { return ExchangesFactory.Instance.GalaxyRomanExchange; }
        }

        public static IRecordMineralValue MineralValueLedger
        {
            get { return ExchangesFactory.Instance.MineralExchange; }
        }

        public static IValueMineral MineralValuation
        { 
            get { return ExchangesFactory.Instance.MineralExchange; }
        }
    }
}