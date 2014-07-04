namespace Merchant.Tools
{
    public interface ICalculateMineralValue 
    {
        decimal MineralValue(decimal quantity, decimal creditValue);
        decimal CreditValue(decimal quantity, decimal mineralValue);
    }
}