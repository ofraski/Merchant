using Merchant.Interpretation;
using Merchant.Text;

namespace Merchant.Messaging
{
    public class Instruction
    {
        public string Text { get; private set; }

        public Instruction(string instructionText)
        {
            Text = instructionText;
        }

        public InstructionType Type
        {
            get
            {
                if (Text.EndsWith(A.QuestionMark)) {
                    if (Text.StartsWith(A.QuestionOfValue))
                        return InstructionType.InterpretUnitQuery;

                    return Text.Contains(A.MonetaryUnit) ? 
                        InstructionType.InterpretMonetaryValueQuery : 
                        InstructionType.InvalidStatement;
                }

                if (Text.Contains(A.MonetaryUnit))
                    return InstructionType.InterpretMonetaryValueAssignment;

                return Text.Contains(A.Conversion) ? 
                    InstructionType.InterpretUnitAssignment : 
                    InstructionType.InvalidStatement;
            }
        }
    }
}