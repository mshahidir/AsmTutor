using System;

namespace Tutor.CPUArchitecture
{
	public class Immediate
	{
		private byte a, b, c, d; // [a | b | c | d] quadrants of the dword

		public Immediate()
		{
			a = b = c = d = 0;
		}

		public Immediate (byte v)
		{
			a = b = c = d = 0;
			d = (byte) v;
		}

		public Immediate (short v)
		{
			a = b = c = d = 0;
			c = (byte) (v >> 8);
			d = (byte)  v;
		}

		public Immediate (long v)
		{
			a = b = c = d = 0;
			a = (byte) (v >> 24);
			b = (byte) (v >> 16);
			c = (byte) (v >> 8);
			d = (byte)  v;
		}
		
		/* Get register segments from the register R, where R is
         * a general register a, b, c, or d. */
		
		/* Get the full 32 bit register */
		public UInt32 GetERX()
		{
			return (UInt32)((a << 24) + (b << 16)  + (c << 8) + d);
		}
		
		/* Get the second 16 bits of the register */
		public UInt16 GetRX()
		{
			//return c << (8)) + d;
			return (UInt16)((c << 8) + d);
		}
		
		/* Get the first 8 bits of RX */
		public byte GetRH()
		{
			return c;
		}
		
		/* Get the second 8 bits of RX */
		public byte GetRL()
		{
			return d;
		}

		public Int32 GetSignedERX ()
		{
			return (Int32)this.GetERX ();
		}

		public Int16 GetSignedRX ()
		{
			return (Int16)this.GetRX ();
		}

		public void SetERX(UInt32 v)
		{
			a = (byte) (v >> 24);
			b = (byte) (v >> 16);
			c = (byte) (v >> 8);
			d = (byte)  v;
		}
		
		public void SetRX(UInt16 v)
		{
			c = (byte) (v >> 8);
			d = (byte)  v;
		}
		
		public void SetRH(byte v)
		{
			c = v;
		}

		public void SetRL(byte v)
		{
			d = v;
		}
	}
}
