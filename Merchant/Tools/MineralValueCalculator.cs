namespace Merchant.Tools
{
    public class MineralValueCalculator : ICalculateMineralValue
    {
        public decimal MineralValue(decimal quantity, decimal creditValue)
        {
            return creditValue/quantity;
        }

        public decimal CreditValue(decimal quantity, decimal mineralValue)
        {
            return quantity*mineralValue;
        }
    }
}