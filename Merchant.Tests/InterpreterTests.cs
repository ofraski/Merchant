using Merchant.Assignment;
using Merchant.Interpretation;
using Merchant.Messaging;
using Merchant.Query;
using Merchant.Response;

using NUnit.Framework;

namespace Merchant.Tests
{
    [TestFixture]
    public partial class InterpreterTests
    {
        [TestCase("one is I")]
        [TestCase("five is V")]
        [TestCase("ten is X")]
        public void Recognises_galaxy_to_roman_assignment(string instructionText)
        {
            var interpreter = new Interpreter().For(new Instruction(instructionText));
            Assert.That(interpreter, Is.InstanceOf<InterpretUnitAssignment>());
        }

        [TestCase("one Metal is 2 Credits")]
        [TestCase("one Alloy is 3 Credits")]
        public void Recognises_galaxy_mineral_calculation_assignment(string instruction)
        {
            var interpreter = new Interpreter().For(new Instruction(instruction));
            Assert.That(interpreter, Is.InstanceOf<InterpretMonetaryValueAssignment>());
        }

        [TestCase("how much is one ?")]
        [TestCase("how much is two ?")]
        public void Recognises_galaxy_value_query(string queryText)
        {
            var interpreter = new Interpreter().For(new Instruction(queryText));
            Assert.That(interpreter, Is.InstanceOf<InterpretUnitQuery>());
        }

        [TestCase("how many Credits is one Metal ?")]
        [TestCase("how many Credits is two Alloy ?")]
        public void Recognises_galaxy_mineral_calculation_query(string queryText)
        {
            var interpreter = new Interpreter().For(new Instruction(queryText));
            Assert.That(interpreter, Is.InstanceOf<InterpretMonetaryValueQuery>());
        }

        [TestCase("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?")]
        [TestCase("nada")]
        public void Recognises_invalid_statement(string invalidInstruction)
        {
            var interpreter = new Interpreter().For(new Instruction(invalidInstruction));
            Assert.That(interpreter, Is.InstanceOf<InvalidStatement>());
        }
    }
}
