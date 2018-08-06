using System;


namespace PLib.Extensions.Core
{

	/// <summary>
	///     Extensions of the <see cref="Array"/> class.
	/// </summary>
	public static partial class ArrayExtensions
	{

		/// <summary>
		///     Returns the number of bytes in the current array.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <returns>The number of bytes in the current array.</returns>
		public static int ByteLength(this Array me)
		{
			return Buffer.ByteLength(me);
		}



		/// <summary>
		///     Retrieves the byte at a specified location in the current array.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="index">The location in the current array.</param>
		/// <returns>Returns the <paramref name="index"/> byte in the array.</returns>
		public static byte GetByte(this Array me, int index)
		{
			return Buffer.GetByte(me, index);
		}



		/// <summary>
		///     Assigns a specified value to a byte at a particular location in the current array.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="index">The location in the current array.</param>
		/// <param name="value">A value to assign.</param>
		public static void SetByte(this Array me, int index, byte value)
		{
			Buffer.SetByte(me, index, value);
		}

	}

}
