using Merchant.Assignment;
using Merchant.Messaging;
using Merchant.Query;
using Merchant.Response;
using Merchant.Tools;

namespace Merchant.Interpretation
{
    public class Interpreter
    {
        public IInterpret For(Instruction instruction)
        {
            switch (instruction.Type)
            {
                case InstructionType.InterpretUnitAssignment:
                    return new InterpretUnitAssignment(RetrieveExisting.GalaxyNumeralLedger);

                case InstructionType.InterpretMonetaryValueAssignment:
                    return new InterpretMonetaryValueAssignment(RetrieveExisting.GalaxyNumeralConverter, Make.RomanNumeralConverter, Make.MineralValueCalculator, RetrieveExisting.MineralValueLedger);

                case InstructionType.InterpretUnitQuery:
                    return new InterpretUnitQuery(RetrieveExisting.GalaxyNumeralConverter);

                case InstructionType.InterpretMonetaryValueQuery:
                    return new InterpretMonetaryValueQuery(RetrieveExisting.GalaxyNumeralConverter, Make.RomanNumeralConverter, Make.MineralValueCalculator, RetrieveExisting.MineralValuation);

                default:
                    return new InvalidStatement();
            }
        }
    }
}