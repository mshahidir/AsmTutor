using System;
using System.Collections.Generic;

namespace Tutor.CPUArchitecture
{
	public class Memory
	{
		private Dictionary<string, long> byName;
		private byte[] mem;
		private const long TWO_MEG = 2 * 1024 * 1024;


		public Memory ()
		{
			byName = new Dictionary<string, long>();
			mem = new byte[TWO_MEG];
		}


		public long Lookup (string name)
		{
			long value = -1;
			if (byName.TryGetValue (name, out value)) {
				return value;
			} else {
				return -1;
			}
		}


		public void alloc (string name, long n)
		{
			byName.Add(name, n);
		}


		public UInt32 GetDWord (long addr)
		{
			MemoryAddrAssertions(addr);
			return (UInt32) ((mem[addr] << 24) + (mem[addr+1] << 16) + (mem[addr+2] << 8) + (mem[addr+3]));
		}


		public UInt32 GetUnsignedLong (long addr)
		{
			MemoryAddrAssertions(addr);
			return (UInt32) ((mem[addr]) + (mem[addr+3] << 24) + (mem[addr+2] << 16) + (mem[addr+1] << 8));
		}


		public Int32 GetLong (long addr)
		{
			return (Int32) GetUnsignedLong(addr);
		}


		public void SetDWord (long addr, ulong dword)
		{
			MemoryAddrAssertions(addr);
			mem[addr] = (byte) (dword >> 24);
			mem[addr+1] = (byte) (dword >> 16);
			mem[addr+2] = (byte) (dword >> 8);
			mem[addr+3] = (byte) (dword);
		}


		public void SetUnsignedLong (long addr, ulong unsignedLong)
		{
			MemoryAddrAssertions(addr);
			mem[addr+3] = (byte) (unsignedLong >> 24);
			mem[addr+2] = (byte) (unsignedLong >> 16);
			mem[addr+1] = (byte) (unsignedLong >> 8);
			mem[addr] = (byte) unsignedLong;
		}


		public void SetLong (long addr, long Long)
		{
			SetUnsignedLong(addr, (ulong) Long);
		}


		public byte GetByte (long addr)
		{
			MemoryAddrAssertions(addr);
			return mem[addr];
		}


		public void SetByte (long addr, byte b)
		{
			MemoryAddrAssertions(addr);
			mem[addr] = b;
		}

		public UInt16 GetWord (long addr)
		{
			MemoryAddrAssertions(addr);
			return (UInt16) ((mem[addr] << 8) + (mem[addr+1]));
		}

		public void SetWord (long addr, ushort w)
		{
			MemoryAddrAssertions(addr);
			mem[addr] = (byte) (w >> 8);
			mem[addr] = (byte) (w);
		}

		private void MemoryAddrAssertions (long addr)
		{
			if (!(addr < TWO_MEG || addr >= 0)) {
				throw new IndexOutOfRangeException ("Memory addr out of range");
			}
		}
	}
}

