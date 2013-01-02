using System;
using Tutor.CPUArchitecture;
using OType = Tutor.CPUArchitecture.Operand.Type;
using OSize = Tutor.CPUArchitecture.Operand.Size;


namespace Tutor.InstructionSet
{
	public class Mov : ICpuExecutable
	{
		//private Operand[] operands { get; set; }

		private Operand op1, op2;

		public bool underHeavyDev { get; set; }
		private MovType movType = MovType.unsupported;
		private CPU cpu = null;

		public enum MovType
		{
			unsupported,

			r8_To_r8,
			r8_To_m8,
			r16_To_r16,
			r16_To_m16,
			r32_To_r32,
			r32_To_m32,

		}


		public Mov (Operand op1, Operand op2)
		{
			this.op1 = op1;
			this.op2 = op2;

			movType = determineType();

			underHeavyDev = true;
		}

		public void Execute (CPU cpu)
		{
			this.cpu = cpu;
			if (underHeavyDev || movType == MovType.unsupported) {
				playtoy ();
			} else {
				Move ();
			}
		}

		private int Move ()
		{
			switch (movType) {
			case MovType.r8_To_r8:
				return r8_To_r8 ();
			case MovType.r8_To_m8:
				return r8_To_m8 ();
			case MovType.r16_To_r16:
				return r16_To_r16 ();
			case MovType.r16_To_m16:
				return r16_To_m16 ();
			case MovType.r32_To_r32:
				return r32_To_r32 ();
			case MovType.r32_To_m32:
				return r32_To_m32 ();
			default:
				return (0);
			}
		}


		private int r8_To_r8 ()
		{
			Immediate leftReg = cpu.FindRegister (op1.register);
			Immediate rightReg = cpu.FindRegister (op2.register);
			
			byte value;

			if (op2.register.EndsWith ("l")) {
				value = rightReg.GetRL ();
			} else {
				value = rightReg.GetRH ();
			}

			if (op1.register.EndsWith ("l")) {
				leftReg.SetRL (value);
			} else {
				leftReg.SetRH (value);
			}

			return 0;
		}


		private int r8_To_m8 ()
		{
			Immediate rightReg = cpu.FindRegister (op2.register);

			if (op2.register.EndsWith ("l")) {
				cpu.Mem.SetByte( op1.immediate.GetERX(), rightReg.GetRL ());
			} else {
				cpu.Mem.SetByte( op1.immediate.GetERX(), rightReg.GetRH ());
			}

			return 0;
		}


		private int r16_To_r16 ()
		{
			Immediate leftReg = cpu.FindRegister (op1.register);
			Immediate rightReg = cpu.FindRegister (op2.register);
			
			leftReg.SetRX(rightReg.GetRX());
			
			return 0;
		}

		
		private int r16_To_m16 ()
		{
			Immediate rightReg = cpu.FindRegister(op2.register);

			cpu.Mem.SetWord( op1.immediate.GetERX(), rightReg.GetRX() );

			return 0;
		}
		

		private int r32_To_r32 ()
		{
			Immediate leftReg = cpu.FindRegister (op1.register);
			Immediate rightReg = cpu.FindRegister (op2.register);
			
			leftReg.SetERX(rightReg.GetERX());
			
			return 0;
		}


		private int r32_To_m32 ()
		{
			Immediate rightReg = cpu.FindRegister(op2.register);
			
			cpu.Mem.SetDWord( op1.immediate.GetERX(), rightReg.GetERX() );
			
			return 0;
		}


		private int playtoy ()
		{
			if (op1.opType == Operand.Type.Register &&
			    op2.opType == Operand.Type.Immediate) {
				
				if (op1.size != op2.size) {
					throw new ArgumentException("Size Mismatch");
				}
				
				Immediate Reg = cpu.FindRegister(op1.register);
				
				switch (op1.size) {
				case Operand.Size.Byte:
					if (op1.register.ToLower().Contains("l"))
					{
						Reg.SetRL((byte) op2.immediate.GetERX());
					} else if (op1.register.ToLower().Contains("h")) {
						Reg.SetRH((byte) op2.immediate.GetERX());
					} else {
						throw new NotSupportedException();
					}
					break;
				case Operand.Size.Word:
					Reg.SetRX ((ushort) op2.immediate.GetERX());
					break;
				case Operand.Size.DWord:
					Reg.SetERX(op2.immediate.GetERX());
					break;
				default:
					throw new NotImplementedException();
				}
			}
			return (0);
		}


		public MovType determineType ()
		{
			if (op1 == null || op2 == null) {
				return MovType.unsupported;
			} else if (AreRegister (op1, op2) && AreByte (op1, op2)) {
				return MovType.r8_To_r8;
			} else if (AreRegister (op2) && AreMemory (op1) && AreByte (op2, op1)) {
				return MovType.r8_To_m8;
			} else if (AreRegister (op1, op2) && AreWord (op1, op2)) {
				return MovType.r16_To_r16;
			} else if (AreRegister (op2) && AreMemory (op1) && AreWord (op1, op2)) {
				return MovType.r16_To_m16;
			} else if (AreRegister (op1, op2) && AreDWord (op1, op2)) {
				return MovType.r32_To_r32;
			} else if (AreRegister (op2) && AreMemory (op1) && AreDWord (op1, op2)) {
				return MovType.r32_To_m32;
			} else {
				return MovType.unsupported;
			}
		}


		private bool AreRegister (params Operand[] args)
		{
			bool allAre = true;
			foreach (Operand o in args) {
				allAre = allAre && (o.opType == OType.Register);
			}
			return allAre;
		}


		private bool AreImmediate (params Operand[] args)
		{
			bool allAre = true;
			foreach (Operand o in args) {
				allAre = allAre && (o.opType == OType.Immediate);
			}
			return allAre;
		}


		private bool AreMemory (params Operand[] args)
		{
			bool allAre = true;
			foreach (Operand o in args) {
				allAre = allAre && (o.opType == OType.Memory);
			}
			return allAre;
		}

		private bool AreByte (params Operand[] args)
		{
			bool allAre = true;
			foreach (Operand o in args) {
				allAre = allAre && (o.size == OSize.Byte);
			}
			return allAre;
		}


		private bool AreWord (params Operand[] args)
		{
			bool allAre = true;
			foreach (Operand o in args) {
				allAre = allAre && (o.size == OSize.Word);
			}
			return allAre;
		}


		private bool AreDWord(params Operand[] args)
		{
			bool allAre = true;
			foreach (Operand o in args) {
				allAre = allAre && (o.size == OSize.DWord);
			}
			return allAre;
		}

	}
}