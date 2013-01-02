using NUnit.Framework;
using System;

namespace Tutor.CPUArchitecture
{
	[TestFixture]
	public class CPUTest
	{
		private CPU cpu;

		[TestFixtureSetUp]
		public void setup() {
			cpu = new CPU();
		}

		[Test]
		public void FindRegisterNotNullTestCaes()
		{
			Assert.IsNotNull(cpu.FindRegister("eax"));
			Assert.IsNotNull(cpu.FindRegister("ebx"));
			Assert.IsNotNull(cpu.FindRegister("ecx"));
			Assert.IsNotNull(cpu.FindRegister("edx"));
			Assert.IsNotNull(cpu.FindRegister("esp"));
			Assert.IsNotNull(cpu.FindRegister("ebp"));
			Assert.IsNotNull(cpu.FindRegister("esi"));
			Assert.IsNotNull(cpu.FindRegister("edi"));
			Assert.IsNotNull(cpu.FindRegister("eip"));
			Assert.IsNotNull(cpu.FindRegister("ax"));
			Assert.IsNotNull(cpu.FindRegister("bx"));
			Assert.IsNotNull(cpu.FindRegister("cx"));
			Assert.IsNotNull(cpu.FindRegister("dx"));
			Assert.IsNotNull(cpu.FindRegister("sp"));
			Assert.IsNotNull(cpu.FindRegister("bp"));
			Assert.IsNotNull(cpu.FindRegister("ip"));
			Assert.IsNotNull(cpu.FindRegister("ah"));
			Assert.IsNotNull(cpu.FindRegister("bh"));
			Assert.IsNotNull(cpu.FindRegister("ch"));
			Assert.IsNotNull(cpu.FindRegister("dh"));
			Assert.IsNotNull(cpu.FindRegister("al"));
			Assert.IsNotNull(cpu.FindRegister("bl"));
			Assert.IsNotNull(cpu.FindRegister("cl"));
			Assert.IsNotNull(cpu.FindRegister("dl"));
		}

		[Test]
		public void FindIdenticalRegisterTestCase ()
		{
			Assert.AreSame(cpu.FindRegister("eax"), cpu.FindRegister("ax"));
			Assert.AreSame(cpu.FindRegister("ebx"), cpu.FindRegister("bx"));
			Assert.AreSame(cpu.FindRegister("ecx"), cpu.FindRegister("cx"));
			Assert.AreSame(cpu.FindRegister("edx"), cpu.FindRegister("dx"));
			Assert.AreSame(cpu.FindRegister("eax"), cpu.FindRegister("al"));
			Assert.AreSame(cpu.FindRegister("ebx"), cpu.FindRegister("bl"));
			Assert.AreSame(cpu.FindRegister("ecx"), cpu.FindRegister("cl"));
			Assert.AreSame(cpu.FindRegister("edx"), cpu.FindRegister("dl"));
			Assert.AreSame(cpu.FindRegister("eax"), cpu.FindRegister("ah"));
			Assert.AreSame(cpu.FindRegister("ebx"), cpu.FindRegister("bh"));
			Assert.AreSame(cpu.FindRegister("ecx"), cpu.FindRegister("ch"));
			Assert.AreSame(cpu.FindRegister("edx"), cpu.FindRegister("dh"));
			Assert.AreSame(cpu.FindRegister("eip"), cpu.FindRegister("ip"));
			Assert.AreSame(cpu.FindRegister("esp"), cpu.FindRegister("sp"));
			Assert.AreSame(cpu.FindRegister("ebp"), cpu.FindRegister("bp"));
		}

		[Test]
		public void FindRegisterNotIdenticalTestCase()
		{
			Assert.AreNotSame(cpu.FindRegister("eax"), cpu.FindRegister("ebx"));
			Assert.AreNotSame(cpu.FindRegister("ebx"), cpu.FindRegister("ecx"));
			Assert.AreNotSame(cpu.FindRegister("ecx"), cpu.FindRegister("edx"));
			Assert.AreNotSame(cpu.FindRegister("edx"), cpu.FindRegister("esp"));
			Assert.AreNotSame(cpu.FindRegister("esp"), cpu.FindRegister("ebp"));
			Assert.AreNotSame(cpu.FindRegister("ebp"), cpu.FindRegister("esi"));
			Assert.AreNotSame(cpu.FindRegister("esi"), cpu.FindRegister("edi"));
			Assert.AreNotSame(cpu.FindRegister("edi"), cpu.FindRegister("eip"));
		}
	}
}

