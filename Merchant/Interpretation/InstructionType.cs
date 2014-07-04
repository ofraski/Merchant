namespace Merchant.Interpretation
{
    public enum InstructionType
    {
        InvalidStatement = 0,
        InterpretUnitAssignment,
        InterpretUnitQuery,
        InterpretMonetaryValueAssignment,
        InterpretMonetaryValueQuery
    }
}