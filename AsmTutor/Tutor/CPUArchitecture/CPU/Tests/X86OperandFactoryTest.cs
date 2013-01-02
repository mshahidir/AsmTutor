using NUnit.Framework;
using System;
using Factory = Tutor.CPUArchitecture.Builders.X86OperandFactory;
using Sizes = Tutor.CPUArchitecture.Operand.Size;
using Types = Tutor.CPUArchitecture.Operand.Type;

namespace Tutor.CPUArchitecture.Builders
{
	[TestFixture]
	public class X86OperandFactoryTest
	{
		[Test]
		public void VariousRegistersTestCase ()
		{
			Assert.AreEqual( Types.Register, Factory.MakeRegisterOperand("EAX").opType );

			AssertSizeEqual( Sizes.Byte, Factory.MakeRegisterOperand("AL") );
			AssertSizeEqual( Sizes.Word, Factory.MakeRegisterOperand("Ax") );
			AssertSizeEqual( Sizes.Word, Factory.MakeRegisterOperand("Ax") );

			AssertSizeEqual( Sizes.Byte, Factory.MakeRegisterOperand("al") );
			AssertSizeEqual( Sizes.Byte, Factory.MakeRegisterOperand("bl") );
			AssertSizeEqual( Sizes.Byte, Factory.MakeRegisterOperand("cl") );
			AssertSizeEqual( Sizes.Byte, Factory.MakeRegisterOperand("dl") );
			
			AssertSizeEqual( Sizes.Byte, Factory.MakeRegisterOperand("ah") );
			AssertSizeEqual( Sizes.Byte, Factory.MakeRegisterOperand("bh") );
			AssertSizeEqual( Sizes.Byte, Factory.MakeRegisterOperand("ch") );
			AssertSizeEqual( Sizes.Byte, Factory.MakeRegisterOperand("dh") );

			AssertSizeEqual( Sizes.Word, Factory.MakeRegisterOperand("ax") );
			AssertSizeEqual( Sizes.Word, Factory.MakeRegisterOperand("bx") );
			AssertSizeEqual( Sizes.Word, Factory.MakeRegisterOperand("cx") );
			AssertSizeEqual( Sizes.Word, Factory.MakeRegisterOperand("dx") );

			AssertSizeEqual( Sizes.Word, Factory.MakeRegisterOperand("Ax") );
			AssertSizeEqual( Sizes.Word, Factory.MakeRegisterOperand("bX") );
			AssertSizeEqual( Sizes.Word, Factory.MakeRegisterOperand("CX") );
			AssertSizeEqual( Sizes.DWord, Factory.MakeRegisterOperand("eCX") );
			AssertSizeEqual( Sizes.DWord, Factory.MakeRegisterOperand("ECX") );

			AssertSizeEqual( Sizes.DWord, Factory.MakeRegisterOperand("eax") );
			AssertSizeEqual( Sizes.DWord, Factory.MakeRegisterOperand("ebx") );
			AssertSizeEqual( Sizes.DWord, Factory.MakeRegisterOperand("ecx") );
			AssertSizeEqual( Sizes.DWord, Factory.MakeRegisterOperand("edx") );

			AssertSizeEqual( Sizes.DWord, Factory.MakeRegisterOperand("esi") );
			AssertSizeEqual( Sizes.DWord, Factory.MakeRegisterOperand("edi") );
			AssertSizeEqual( Sizes.DWord, Factory.MakeRegisterOperand("esp") );
			AssertSizeEqual( Sizes.DWord, Factory.MakeRegisterOperand("ebp") );
			AssertSizeEqual( Sizes.DWord, Factory.MakeRegisterOperand("eip") );
		}

		public void AssertSizeEqual (Sizes expected, Operand against)
		{
			Assert.AreEqual(expected, against.size);
		}
	}
}

