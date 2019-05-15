//  Project : ecs
// Contacts : Pix - ask@pixeye.games

using System;
using System.Runtime.InteropServices;

namespace Pixeye.Framework
{
	[StructLayout(LayoutKind.Sequential)]
	public struct BufferComponents
	{

		public ushort[] ids;
		public byte length;
		public byte ageCache;  // caching age of entity for retrivieng it in future. ( ParseBy method )

		public ref ushort Get(int id)
		{
			return ref ids[id];
		}

		public BufferComponents(int size)
		{
			ids = new ushort[size];
			length = 0;
			ageCache = 0;
		}

		public void Setup(byte ageCache)
		{
			length = 0;
			this.ageCache = ageCache;
			if (ids == null) ids = new ushort[1];
		}

		public void Clear()
		{
			length = 0;
		}

		
		public void Add(int type)
		{
			if (length == ids.Length)
				Array.Resize(ref ids, length << 1);

			ids[length++] = (ushort) type;
		}

		public void Remove(int type)
		{
			var typeConverted = (ushort) type;

			for (int i = 0; i < length; i++)
			{
				if (ids[i] == typeConverted)
				{
					RemoveAt(i);
					break;
				}
			}
		}

		public void RemoveAt(int index)
		{
			for (int i = index; i < length - 1; ++i)
				SetElement(i, ids[i + 1]);

			length--;
		}

		public void SetElement(int index, int arg)
		{
			ids[index] = (ushort) arg;
		}
  
	}
}