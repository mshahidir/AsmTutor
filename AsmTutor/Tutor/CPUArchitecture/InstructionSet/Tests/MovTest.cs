using NUnit.Framework;
using NUnit.Mocks;
using System;
using Tutor.CPUArchitecture;
using Tutor.CPUArchitecture.Builders;

namespace Tutor.InstructionSet
{
	[TestFixture()]
	public class MovTest
	{
		[Test()]
		public void MovTestCase ()
		{
			Mov line = new Mov(
				X86OperandFactory.MakeRegisterOperand("eax"),
				new Operand( new Immediate(500), Operand.Size.DWord )
				);

			CPU cpu = new CPU();

			cpu.Execute(line);
		}
	}
}

