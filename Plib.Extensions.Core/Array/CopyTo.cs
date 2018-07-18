using System;

using JetBrains.Annotations;


namespace PLib.Extensions.Core
{

	public static partial class ArrayExtensions
	{

		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="dstArray">The destination array.</param>
		/// <exception cref="ArgumentNullException">
		///     <paramref name="me"/> is null
		///     -or-
		///     <paramref name="dstArray"/> is null.
		/// </exception>
		/// <exception cref="ArgumentException">
		///     The destination array is to short to fit the element of the current array.
		/// </exception>
		public static void CopyTo([NotNull] this Array me, [NotNull] Array dstArray)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			if (dstArray == null)
			{
				throw new ArgumentNullException(nameof(dstArray));
			}

			if (dstArray.LongLength < me.LongLength)
			{
				throw new ArgumentException("The destination array is to short to fit the element of the current array.");
			}

			Array.Copy(me, dstArray, me.LongLength);
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="dstArray">The destination array.</param>
		/// <param name="length">The length.</param>
		/// <exception cref="ArgumentNullException">
		///     <paramref name="me"/> is null
		///     -or-
		///     <paramref name="dstArray"/>
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     if the <paramref name="length"/> is ouside the bound of either
		///     <paramref name="me"/> or <paramref name="dstArray"/>
		/// </exception>
		public static void CopyTo([NotNull] this Array me, [NotNull] Array dstArray, int length)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			if (dstArray == null)
			{
				throw new ArgumentNullException(nameof(dstArray));
			}

			if (length < 0 || me.Length < length || dstArray.Length < length)
			{
				throw new ArgumentOutOfRangeException(nameof(length));
			}

			Array.Copy(me, dstArray, length);
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="dstArray">The destination array.</param>
		/// <param name="dstOffset">The destination offest.</param>
		/// <param name="length">The length.</param>
		/// <exception cref="ArgumentNullException">
		///     <paramref name="me"/> is null
		///     -or-
		///     <paramref name="dstArray"/> is null.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     <paramref name="offset"/> is outside the bounds of the current array. -or-
		///     <paramref name="dstOffset"/> is outside the bound of the
		///     <paramref name="dstArray"/> array.
		/// </exception>
		/// <exception cref="ArgumentException">
		///     The <paramref name="length"/> length is greater than the number of elements
		///     from <paramref name="offset"/> to the end of the current array
		///     -or-
		///     the <paramref name="length"/> is greater than the number of elements
		///     from <paramref name="dstOffset"/> to the end of the
		///     <paramref name="dstArray"/> array.
		/// </exception>
		public static void CopyTo([NotNull] this Array me, int offset, [NotNull] Array dstArray, int dstOffset, int length)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			if (dstArray == null)
			{
				throw new ArgumentNullException(nameof(dstArray));
			}

			if (offset < 0 || me.Length <= offset)
			{
				throw new ArgumentOutOfRangeException(nameof(offset));
			}

			if (dstOffset < 0 || dstArray.Length <= dstOffset)
			{
				throw new ArgumentOutOfRangeException(nameof(dstOffset));
			}

			if (me.Length < offset + length)
			{
				throw new ArgumentException("The length is greater than the number of elements from offset to the end of the current array.");
			}

			if (dstArray.Length < dstOffset + length)
			{
				throw new ArgumentException("The length is greater than the number of elements from destination offset to the end of the destination array.");
			}

			Array.Copy(me, offset, dstArray, dstOffset, length);
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="dstArray">The destination array.</param>
		/// <param name="length">The length.</param>
		/// <exception cref="ArgumentNullException">
		///     <paramref name="me"/> is null
		///     -or-
		///     <paramref name="dstArray"/>
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     if the <paramref name="length"/> is ouside the bound of either
		///     <paramref name="me"/> or <paramref name="dstArray"/>
		/// </exception>
		public static void CopyTo([NotNull] this Array me, [NotNull] Array dstArray, long length)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			if (dstArray == null)
			{
				throw new ArgumentNullException(nameof(dstArray));
			}

			if (length < 0 || me.LongLength < length || dstArray.LongLength < length)
			{
				throw new ArgumentOutOfRangeException(nameof(length));
			}

			Array.Copy(me, dstArray, length);
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="dstArray">The destination array.</param>
		/// <param name="dstOffset">The destination offset.</param>
		/// <param name="length">The length.</param>
		public static void CopyTo([NotNull] this Array me, long offset, [NotNull] Array dstArray, long dstOffset, long length)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			if (dstArray == null)
			{
				throw new ArgumentNullException(nameof(dstArray));
			}

			if (offset < 0L || me.LongLength <= offset)
			{
				throw new ArgumentOutOfRangeException(nameof(offset));
			}

			if (dstOffset < 0L || dstArray.LongLength <= dstOffset)
			{
				throw new ArgumentOutOfRangeException(nameof(dstOffset));
			}

			if (me.LongLength < offset + length)
			{
				throw new ArgumentException("The length is greater than the number of elements from offset to the end of the current array.");
			}

			if (dstArray.LongLength < dstOffset + length)
			{
				throw new ArgumentException("The length is greater than the number of elements from destination offset to the end of the destination array.");
			}

			Array.Copy(me, offset, dstArray, dstOffset, length);
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="dstArray">The destination array.</param>
		/// <remarks>
		///     <para>
		///         This method provides better performance for copying primitive types
		///         than the other copy methods.
		///     </para>
		///     <para>
		///         Only applicable to arrays of <see cref="Boolean"/>, <see cref="Char"/>,
		///         <see cref="SByte"/>, <see cref="Byte"/>, <see cref="Int16"/>,
		///         <see cref="UInt16"/>, <see cref="Int32"/>, <see cref="UInt32"/>,
		///         <see cref="Int64"/>, <see cref="UInt64"/>, <see cref="IntPtr"/>,
		///         <see cref="UIntPtr"/>, <see cref="Single"/>, and <see cref="Double"/>.
		///     </para>
		/// </remarks>
		public static void BlockCopyTo([NotNull] this Array me, [NotNull] Array dstArray)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			Buffer.BlockCopy(me, 0, dstArray, 0, me.Length);
		}

	}

}
