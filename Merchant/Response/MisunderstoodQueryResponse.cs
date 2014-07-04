namespace Merchant.Response
{
    public class MisunderstoodQueryResponse : QueryResponse
    {
        public MisunderstoodQueryResponse()
        {
            Text = A.ConfusedResponse;
        }
    }
}