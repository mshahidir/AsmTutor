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
				return eax;
			case "ebx":
				return ebx;
			case "ecx":
				return ecx;
			case "edx":
				return edx;
			case "esp":
				return esp;
			case "ebp":
				return ebp;
			case "esi":
				return esi;
			case "edi":
				return edi;
			case "eip":
				return eip;
			default:
				throw new NotImplementedException ();
			}
		}
	}
}

