using NUnit.Framework;
using System;

namespace Tutor.CPUArchitecture
{
	[TestFixture()]
	public class OperandTest
	{
		const int i = 1000;

		[Test()]
		public void TestImmediate ()
		{
			Immediate Imm;
			Operand op;

			Imm = new Immediate();
			Imm.SetERX(i);

			op = new Operand(Imm);

			Assert.NotNull(op);
			Assert.Null (op.register);
			Assert.AreEqual(Operand.Size.DWord, op.size);
			Assert.AreEqual(Operand.Type.Immediate, op.opType);
			Assert.AreEqual(i, op.immediate.GetERX());

			op = new Operand(Imm, Operand.Size.Byte);

			Assert.AreEqual(Operand.Size.Byte, op.size);
			Assert.AreEqual((i & 0xFF), op.immediate.GetRL());
		}

		[Test()]
		public void TestRegister ()
		{
			Operand op;

			op = new Operand("eax");

			Assert.NotNull (op);
			Assert.Null(op.immediate);
			Assert.AreEqual("EAX", op.register);
			Assert.AreEqual(Operand.Size.DWord, op.size);

			op = new Operand("ebx", Operand.Size.Byte);

			Assert.AreEqual("EBX", op.register);
		}
	}
}

