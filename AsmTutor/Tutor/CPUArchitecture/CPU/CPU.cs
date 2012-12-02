using System;

namespace Tutor
{
	namespace CPUArchitecture
	{   
		public class Register
		{
			
			private byte a, b, c, d; // [a | b | c | d] quadrants of the dword
			public Register()
			{

			}
			
			/* Get register segments from the register R, where R is
             * a general register a, b, c, or d. */
			
			/* Get the full 32 bit register */
			public Int32 GetERX()
			{
				return a << (24) + b << (16)  + c << (8) + d;
			}
			
			/* Get the second 16 bits of the register */
			public Int16 GetRX()
			{
				//return c << (8)) + d;
				return 0;
			}
			
			/* Get the second 8 bits of RX */
			public byte GetRH()
			{
				return c;
			}
			
			/* Get the first 8 bits of RX */
			public byte GetRL()
			{
				return d;
			}
			
			public void SetERX(Int32 v)
			{
				a = (byte) (v >> 24);
				b = (byte) (v >> 16);
				c = (byte) (v >> 8);
				d = (byte)  v;
			}

			public void SetRX(Int16 v)
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
				c = v;
			}
		}
		
		public class CPU 
		{
			/* @TODO There needs to be a way we can implement AX, AL and AH 
             * from EAX and the other registers 
             */
			protected Register
				EAX,
				EBX,
				ECX,
				EDX,
				ESP,
				EBP,
				ESI,
				EDI;
			
			/* Constructor. */
			public CPU ()
			{
				
			}
			
			
			public void Execute(IInstruction op)
			{
				op.Execute(this);
			}
		}

		public interface IInstruction
		{
			void Execute(CPU c);
		}
	}
}