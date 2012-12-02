using System;
using Tutor;
using Tutor.CPUArchitecture;

namespace Tutor
{
	namespace CPUArchitecture
	{
		public enum Type
		{
			ONE, TWO
		}

		public class Register
		{

		}

		public class Operand
		{

		}


		public abstract class Instruction : CPU, IInstruction
		{
			Type instructionType = Type.ONE;
			Register lhs;
			Register rhs;
			
			public Instruction(Register lhs, Register rhs)
			{
				this.lhs = lhs;
				this.rhs = rhs;
				this.instructionType = Type.ONE;
			}
			
			public void Execute(CPU cpu)
			{
				// Mov instruction
				//Operand a = cpu.GetOperand(this.lhs);
				//Operand b = cpu.GetOperand(this.rhs);
				//a.setValue(b.getValue());
			}
		}

		/*
		public abstract class TwinOpInstruction : Instruction
		{
			TwinOpInstruction();
		}

		public abstract class MonoOpInstruction : Instruction
		{
			MonoOpInstruction();
		}

		public class Mov : Instruction
		{
			Mov();
		}
		*/		
				
	}
}