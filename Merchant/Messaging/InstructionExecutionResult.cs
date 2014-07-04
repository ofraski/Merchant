using Merchant.Interpretation;
using Merchant.Response;

namespace Merchant.Messaging
{
    public class InstructionExecutionResult
    {
        public InstructionExecutionResult(string queryText)
        {
            Instruction = new Instruction(queryText);
        }

        public Instruction Instruction { get; private set; }

        public QueryResponse Respond()
        {
            return new Interpreter()
                .For(Instruction)
                .Execute(Instruction.Text);
        }
    }
}