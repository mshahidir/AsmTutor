using System;
using Tutor.CPUArchitecture;

namespace Tutor.InstructionSet
{
	public class Mov : ICpuExecutable
	{
		Operand[] operands { get; set; }

		public Mov (Operand op1, Operand op2)
		{
			operands = new Operand[] {
				op1, op2
			};
		}

		public void Execute (CPU cpu)
		{
			if (operands [0].opType == Operand.Type.Register &&
			    operands [1].opType == Operand.Type.Immediate) {

				if (operands[0].size != operands[1].size) {
					throw new ArgumentException("Size Mismatch");
				}

				Immediate Reg = cpu.FindRegister(operands[0].register);

				switch (operands[0].size) {
				case Operand.Size.Byte:
					if (operands[0].register.Contains("l") ||
					    operands[0].register.Contains("h"))
					{
						Reg.SetRL((byte) operands[1].immediate.GetERX());
					} else {
						Reg.SetRH((byte) operands[1].immediate.GetERX());
					}
					break;
				case Operand.Size.Word:
					Reg.SetRX ((ushort) operands[1].immediate.GetERX());
					break;
				case Operand.Size.DWord:
					Reg.SetERX(operands[1].immediate.GetERX());
					break;
				default:
					throw new NotImplementedException();
				}
			}
		}
	}
		
}