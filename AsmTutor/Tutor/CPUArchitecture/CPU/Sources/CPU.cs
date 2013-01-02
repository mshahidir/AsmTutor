using System;

namespace Tutor.CPUArchitecture
{
	public class CPU
	{
		private Immediate
			eax = new Immediate(),
			ebx = new Immediate(),
			ecx = new Immediate(),
			edx = new Immediate(),
			esp = new Immediate(),
			ebp = new Immediate(),
			esi = new Immediate(),
			edi = new Immediate(),
			eip = new Immediate();

		public Memory Mem {	get; private set; }

		public CPU ()
		{
		}
		
		public void Execute(ICpuExecutable op)
		{
			op.Execute(this);
		}

		public Immediate FindRegister (string register)
		{
			switch (register.ToLower ()) {
			case "eax":
			case "ax":
			case "ah":
			case "al":
				return eax;
			case "ebx":
			case "bx":
			case "bh":
			case "bl":
				return ebx;
			case "ecx":
			case "cx":
			case "ch":
			case "cl":
				return ecx;
			case "edx":
			case "dx":
			case "dh":
			case "dl":
				return edx;
			case "esp":
			case "sp":
				return esp;
			case "ebp":
			case "bp":
				return ebp;
			case "esi":
				return esi;
			case "edi":
				return edi;
			case "eip":
			case "ip":
				return eip;
			default:
				throw new NotImplementedException ();
			}
		}
	}
}

