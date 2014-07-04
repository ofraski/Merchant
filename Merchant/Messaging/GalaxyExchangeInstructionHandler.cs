using System;
using Merchant.Interpretation;
using Merchant.Reading;
using Merchant.Response;

namespace Merchant.Messaging
{
    public class GalaxyExchangeInstructionHandler : IHandleGalaxyExchangeQueries
    {
        public event EventHandler<GalaxyExchangeMessageHandlingCompleteEventArgs> NewResponse;

        public GalaxyExchangeResponse Response(string queryText)
        {
            if (string.IsNullOrWhiteSpace(queryText)) 
                return GalaxyExchangeResponse.None;

            var execution = new InstructionExecutionResult(queryText);

            switch (execution.Instruction.Type)
            {
                case InstructionType.InvalidStatement:
                    return new GalaxyExchangeResponse(execution.Respond().Text);
                
                case InstructionType.InterpretUnitAssignment:
                case InstructionType.InterpretMonetaryValueAssignment:
                    execution.Respond();
                    break;

                case InstructionType.InterpretUnitQuery:
                    return new UnitValueResponse(execution.Respond());

                case InstructionType.InterpretMonetaryValueQuery:
                    return new MonetaryValueResponse(execution.Respond());
            }

            return GalaxyExchangeResponse.None;
        }

        public void ReceiveMessage(object sender, GalaxyExchangeMessageReadingCompleteEventArgs e)
        {
            if (NewResponse == null) return;

            NewResponse(this, new GalaxyExchangeMessageHandlingCompleteEventArgs { Response = Response(e.Message)});
        }
    }
}