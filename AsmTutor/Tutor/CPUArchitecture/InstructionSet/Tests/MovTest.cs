using NUnit.Framework;
using System;
using Tutor.CPUArchitecture;
using Tutor.CPUArchitecture.Builders;

namespace Tutor.InstructionSet
{
	[TestFixture]
	public class MovTest
	{
		private CPU cpu;

		[TestFixtureSetUp]
		public void setup ()
		{
			cpu = new CPU();
		}

		public void executeInstructions (ICpuExecutable[] instructions)
		{
			foreach (ICpuExecutable instruction in instructions)
			{
				cpu.Execute(instruction);
			}
		}

		[Test]
		public void MovDWordTestCase ()
		{
			Mov[] instructions = {
				new Mov(
					X86OperandFactory.MakeRegisterOperand("eax"),
					new Operand( new Immediate(500), Operand.Size.DWord )
					),
				new Mov(
					X86OperandFactory.MakeRegisterOperand("ebx"),
					new Operand( new Immediate(500), Operand.Size.DWord )
					),
				new Mov(
					X86OperandFactory.MakeRegisterOperand("ecx"),
					new Operand( new Immediate(500), Operand.Size.DWord )
					),
				new Mov(
					X86OperandFactory.MakeRegisterOperand("edx"),
					new Operand( new Immediate(500), Operand.Size.DWord )
					),
			};
			
			executeInstructions(instructions);
			
			Assert.AreEqual(500, cpu.FindRegister("eax").GetERX());
			Assert.AreEqual(500, cpu.FindRegister("ebx").GetERX());
			Assert.AreEqual(500, cpu.FindRegister("ecx").GetERX());
			Assert.AreEqual(500, cpu.FindRegister("edx").GetERX());
		}

		[Test]
		public void MovWordTestCase ()
		{
			Mov[] instructions = {
				new Mov(
					X86OperandFactory.MakeRegisterOperand("ax"),
					new Operand( new Immediate(500), Operand.Size.Word )
					),
				new Mov(
					X86OperandFactory.MakeRegisterOperand("bx"),
					new Operand( new Immediate(500), Operand.Size.Word )
					),
				new Mov(
					X86OperandFactory.MakeRegisterOperand("cx"),
					new Operand( new Immediate(500), Operand.Size.Word )
					),
				new Mov(
					X86OperandFactory.MakeRegisterOperand("dx"),
					new Operand( new Immediate(500), Operand.Size.Word )
					),
			};
			
			executeInstructions(instructions);
			
			Assert.AreEqual(500, cpu.FindRegister("eax").GetERX());
			Assert.AreEqual(500, cpu.FindRegister("ebx").GetERX());
			Assert.AreEqual(500, cpu.FindRegister("ecx").GetERX());
			Assert.AreEqual(500, cpu.FindRegister("edx").GetERX());
			Assert.AreEqual(500, cpu.FindRegister("ax").GetERX());
			Assert.AreEqual(500, cpu.FindRegister("bx").GetERX());
			Assert.AreEqual(500, cpu.FindRegister("cx").GetERX());
			Assert.AreEqual(500, cpu.FindRegister("dx").GetERX());
		}


		[Test]
		public void MovByteTestCase ()
		{
			Mov[] instructions = {
				new Mov (
					X86OperandFactory.MakeRegisterOperand ("al"),
					new Operand (new Immediate (254), Operand.Size.Byte)
					),
				new Mov (
					X86OperandFactory.MakeRegisterOperand ("ah"),
					new Operand (new Immediate (255), Operand.Size.Byte)
					),
				new Mov (
					X86OperandFactory.MakeRegisterOperand ("bl"),
					new Operand (new Immediate (254), Operand.Size.Byte)
					),
				new Mov (
					X86OperandFactory.MakeRegisterOperand ("bh"),
					new Operand (new Immediate (255), Operand.Size.Byte)
					),
				new Mov (
					X86OperandFactory.MakeRegisterOperand ("cl"),
					new Operand (new Immediate (254), Operand.Size.Byte)
					),
				new Mov (
					X86OperandFactory.MakeRegisterOperand ("ch"),
					new Operand (new Immediate (255), Operand.Size.Byte)
					),
				new Mov (
					X86OperandFactory.MakeRegisterOperand ("dl"),
					new Operand (new Immediate (254), Operand.Size.Byte)
					),
				new Mov (
					X86OperandFactory.MakeRegisterOperand ("dh"),
					new Operand (new Immediate (255), Operand.Size.Byte)
					),
			};
			
			executeInstructions (instructions);
						
			Assert.AreEqual (254, cpu.FindRegister ("al").GetRL ());
			Assert.AreEqual (255, cpu.FindRegister ("ah").GetRH ());
			Assert.AreEqual (254, cpu.FindRegister ("bl").GetRL ());
			Assert.AreEqual (255, cpu.FindRegister ("bh").GetRH ());
			Assert.AreEqual (254, cpu.FindRegister ("cl").GetRL ());
			Assert.AreEqual (255, cpu.FindRegister ("ch").GetRH ());
			Assert.AreEqual (254, cpu.FindRegister ("dl").GetRL ());
			Assert.AreEqual (255, cpu.FindRegister ("dh").GetRH ());
		}

		[Test]
		public void MovByteCorruptionTestCase ()
		{
			Mov[] instructions = {
				new Mov(
					X86OperandFactory.MakeRegisterOperand("cl"),
					new Operand( new Immediate(254), Operand.Size.Byte )
					),
				new Mov(
					X86OperandFactory.MakeRegisterOperand("ch"),
					new Operand(new Immediate(255), Operand.Size.Byte )
					),
			};
			
			executeInstructions(instructions);

			Assert.AreEqual(254, cpu.FindRegister("cl").GetRL());
			Assert.AreEqual(255, cpu.FindRegister("ch").GetRH());
			Assert.AreNotEqual(255, cpu.FindRegister("cl").GetERX());
			Assert.AreNotEqual(255, cpu.FindRegister("ch").GetERX());
			Assert.AreNotEqual(254, cpu.FindRegister("cl").GetERX());
			Assert.AreNotEqual(254, cpu.FindRegister("ch").GetERX());
		}
	}
}

