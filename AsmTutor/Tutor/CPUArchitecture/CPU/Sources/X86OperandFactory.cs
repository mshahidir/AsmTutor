using System;
using System.Collections.Generic;
using Tutor.CPUArchitecture;
using System.Text.RegularExpressions;

namespace Tutor.CPUArchitecture.Builders
{
	public static class X86OperandFactory
	{
		public static Operand MakeRegisterOperand (string name)
		{
			Regex x86 = new Regex ("(e[a-d]x)|([a-d][lhx])|(e([sb]p)|[sd]i)|(eip)");
			Regex Special = new Regex ("e[sdbi][ip]");
			Regex size32 = new Regex ("e[a-dsi][xip]");
			Regex size16 = new Regex ("[a-d]x");
			Regex size8 = new Regex ("[a-d][lh]");
			Regex low = new Regex ("[a-d]l");
			Regex high = new Regex ("[a-d]h");

			if (name == null) {
				throw new ArgumentNullException ();
			}

			name = name.ToLower ();

			if (!x86.IsMatch (name) || name.Length <= 1 || name.Length >= 4) {
				throw new NotSupportedException ("Register " + name + " is not known.");
			}

			if (size32.IsMatch (name)) {
				return new Operand(name, Operand.Size.DWord);
			} else if (size16.IsMatch (name)) {
				return new Operand(name, Operand.Size.Word);
			} else if (size8.IsMatch (name)) {
				return new Operand(name, Operand.Size.Byte);
			} else {
				throw new NotSupportedException ("Register " + name + " is not known.");
			}
		}
	}
}

