using Merchant.Response;

namespace Merchant.Interpretation
{
    public interface IInterpret
    {
        QueryResponse Execute(string instruction);
    }
}