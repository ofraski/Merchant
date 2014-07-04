namespace Merchant
{
    public class ApplicationFactory : ICreateApplication
    {
        public IOrchestrateMerchantGalaxySystem Create()
        {
            return new Application();
        }
    }
}