using Merchant.Interpretation;
using Merchant.Messaging;
using Merchant.Response;

namespace Merchant.Tests
{
    internal static class Interpreted
    {
        public static QueryResponse For(string instructionText)
        {
            var instruction = new Instruction(instructionText);

            return new Interpreter()
                .For(instruction)
                .Execute(instructionText);
        }
    }
}