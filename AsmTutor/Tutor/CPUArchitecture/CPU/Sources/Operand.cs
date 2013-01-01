using System;
using System.Text.RegularExpressions;

namespace Tutor.CPUArchitecture
{
	public class Operand
	{
		public string register { get; private set; }
		public Immediate immediate { get; private set; }
		public Size size { get; private set; }
		public Type opType { get; private set; }

		public enum Type {
			Register,
			Immediate
		}

		public enum Size {
			Byte,
			Word,
			DWord
		}

		public Operand (Immediate dword, Size size = Size.DWord)
		{
			this.immediate = dword;
			this.register = null;
			this.size = size;
			this.opType = Type.Immediate;
		}

		public Operand (string regName, Size size = Size.DWord)
		{
			this.immediate = null;
			this.register = regName.ToUpper();
			this.size = size;
			this.opType = Type.Register;
		}
	}
}

