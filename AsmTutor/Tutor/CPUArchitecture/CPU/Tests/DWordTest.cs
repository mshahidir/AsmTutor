using NUnit.Framework;
using System;

namespace Tutor.CPUArchitecture
{
	[TestFixture]
	public class RegisterTest
	{
		Immediate testRegister = null;

		const UInt32 val32 = 5775833;
		const UInt16 val16 = 13236;
		const byte	 val8  = 254;

		[TestFixtureSetUp]
		public void SetUp ()
		{
			testRegister = new Immediate();
		}

		[Test]
		public void TestContext ()
		{
			Assert.NotNull(testRegister);
		}


		[Test]
		public void Test32PassThrough ()
		{
			testRegister.SetERX(val32);
			Assert.AreEqual(val32, testRegister.GetERX());
		}

		[Test]
		public void Test16PassThrough ()
		{
			testRegister.SetRX(val16);
			Assert.AreEqual(val16, testRegister.GetRX());
		}

		[Test]
		public void Test8PassThrough ()
		{
			testRegister.SetRH(val8);
			Assert.AreEqual(val8, testRegister.GetRH());
			testRegister.SetRL(val8);
			Assert.AreEqual(val8, testRegister.GetRL());
		}

		[Test]
		public void TestConversions ()
		{
			testRegister.SetERX((uint)((val8 << 8) & Convert.ToUInt32("0111111111111111", 2)));
			Assert.AreEqual((val8 << 8) & Convert.ToUInt32("0111111111111111", 2), testRegister.GetRX());

			testRegister.SetERX(0);
			Assert.AreEqual(0, testRegister.GetERX());

			testRegister.SetERX(val8 << 8);
			Assert.AreEqual(val8, testRegister.GetRH());

			testRegister.SetERX(val8);
			Assert.AreEqual(val8, testRegister.GetRL());
		}

		[Test]
		[ExpectedException("System.OverflowException")]
		public void TestSignedConversions()
		{
			testRegister.SetERX(Convert.ToUInt32(-1));
			Assert.AreEqual(-1, testRegister.GetSignedERX());
			Assert.AreNotEqual(-1, testRegister.GetSignedRX());

			testRegister.SetRX(Convert.ToUInt16(-1));
			Assert.AreEqual(-1, testRegister.GetSignedRX());
			Assert.AreNotEqual(-1, testRegister.GetSignedERX());
		}
	}
}

