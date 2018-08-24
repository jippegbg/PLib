using System;


namespace PLib.Extensions.Core {

	public static partial class ArrayExtensions
	{

		/// <summary>
		///     Copies all bytes from the current array to a destination array.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="dstArray">The destination array.</param>
		/// <exception cref="ArgumentNullException">
		///     <paramref name="me"/> is null
		///     <para/>-or-<para/>
		///     <paramref name="dstArray"/> is null.
		/// </exception>
		/// <exception cref="ArgumentException">
		///     The destination array is to short to fit the element of the current array.
		/// </exception>
		/// <remarks>
		///     <para>
		///         This method provides better performance for copying primitive types than the
		///         other copy methods.
		///     </para>
		///     <para>
		///         Only applicable to arrays of <see cref="Boolean"/>, <see cref="Char"/>,
		///         <see cref="SByte"/>, <see cref="Byte"/>, <see cref="Int16"/>,
		///         <see cref="UInt16"/>, <see cref="Int32"/>, <see cref="UInt32"/>,
		///         <see cref="Int64"/>, <see cref="UInt64"/>, <see cref="IntPtr"/>,
		///         <see cref="UIntPtr"/>, <see cref="Single"/>, and <see cref="Double"/>.
		///     </para>
		/// </remarks>
		public static void BlockCopyTo(this Array me, Array dstArray)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			if (dstArray == null)
			{
				throw new ArgumentNullException(nameof(dstArray));
			}

			Buffer.BlockCopy(me, 0, dstArray, 0, Buffer.ByteLength(me));
		}



		/// <summary>
		///     Copies a number of elements from the current array starting at the first element and pastes
		///     them into another array starting at the first element.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="dstArray">The destination array.</param>
		/// <param name="count">The number of bytes to copy.</param>
		/// <exception cref="ArgumentNullException">
		///     <paramref name="me"/> is null
		///     <para/>-or-<para/>
		///     <paramref name="dstArray"/>
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     if the <paramref name="count"/> is ouside the bound of either <paramref name="me"/>
		///     or <paramref name="dstArray"/>
		/// </exception>
		/// <remarks>
		///     <para>
		///         This method provides better performance for copying primitive types than the
		///         other copy methods.
		///     </para>
		///     <para>
		///         Only applicable to arrays of <see cref="Boolean"/>, <see cref="Char"/>,
		///         <see cref="SByte"/>, <see cref="Byte"/>, <see cref="Int16"/>,
		///         <see cref="UInt16"/>, <see cref="Int32"/>, <see cref="UInt32"/>,
		///         <see cref="Int64"/>, <see cref="UInt64"/>, <see cref="IntPtr"/>,
		///         <see cref="UIntPtr"/>, <see cref="Single"/>, and <see cref="Double"/>.
		///     </para>
		/// </remarks>
		public static void BlockCopyTo(this Array me, Array dstArray, int count)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			if (dstArray == null)
			{
				throw new ArgumentNullException(nameof(dstArray));
			}

			if (count < 0 || me.Length < count || dstArray.Length < count)
			{
				throw new ArgumentOutOfRangeException(nameof(count));
			}

			Buffer.BlockCopy(me, 0, dstArray, 0, count);
		}



		/// <summary>
		///     Copies a number of bytes from the current array starting at the specified offset
		///     and pastes them to another array starting at the specified destination offset.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="offset">The zero-based byte offset of the current array at which copying begins.</param>
		/// <param name="dstArray">The destination array.</param>
		/// <param name="dstOffset">The zero-based byte offset of the destination array at which storing begins.</param>
		/// <param name="count">The number of bytes to copy.</param>
		/// <exception cref="ArgumentNullException">
		///     <paramref name="me"/> is null
		///     <para/>-or-<para/>
		///     <paramref name="dstArray"/> is null.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     <paramref name="offset"/> is outside the bounds of the current array.
		///     <para/>-or-<para/>
		///     <paramref name="dstOffset"/> is outside the bound of the <paramref name="dstArray"/> array.
		/// </exception>
		/// <exception cref="ArgumentException">
		///     The <paramref name="count"/> length is greater than the number of elements from
		///     <paramref name="offset"/> to the end of the current array
		///     <para/>-or-<para/>
		///     the <paramref name="count"/> is greater than the number of elements from
		///     <paramref name="dstOffset"/> to the end of the <paramref name="dstArray"/> array.
		/// </exception>
		/// <remarks>
		///     <para>
		///         This method provides better performance for copying primitive types than the
		///         other copy methods.
		///     </para>
		///     <para>
		///         Only applicable to arrays of <see cref="Boolean"/>, <see cref="Char"/>,
		///         <see cref="SByte"/>, <see cref="Byte"/>, <see cref="Int16"/>,
		///         <see cref="UInt16"/>, <see cref="Int32"/>, <see cref="UInt32"/>,
		///         <see cref="Int64"/>, <see cref="UInt64"/>, <see cref="IntPtr"/>,
		///         <see cref="UIntPtr"/>, <see cref="Single"/>, and <see cref="Double"/>.
		///     </para>
		/// </remarks>
		public static void BlockCopyTo(this Array me, int offset, Array dstArray, int dstOffset, int count)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			if (dstArray == null)
			{
				throw new ArgumentNullException(nameof(dstArray));
			}

			int srcLength = Buffer.ByteLength(me);
			int dstLength = Buffer.ByteLength(dstArray);

			if (offset < 0 || srcLength <= offset)
			{
				throw new ArgumentOutOfRangeException(nameof(offset));
			}

			if (dstOffset < 0 || dstLength <= dstOffset)
			{
				throw new ArgumentOutOfRangeException(nameof(dstOffset));
			}

			if (srcLength < offset + count)
			{
				throw new ArgumentException("The length is greater than the number of bytes from offset to the end of the current array.");
			}

			if (dstLength < dstOffset + count)
			{
				throw new ArgumentException("The length is greater than the number of bytes from destination offset to the end of the destination array.");
			}

			Buffer.BlockCopy(me, offset, dstArray, dstOffset, count);
		}

	}

}