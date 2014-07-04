using Merchant.Interpretation;
using Merchant.Text;

namespace Merchant.Response
{
    public class InvalidStatement : IInterpret 
    {
        public QueryResponse Execute(string instruction)
        {
            return new QueryResponse(instruction, A.ConfusedResponse);
        }
    }
}