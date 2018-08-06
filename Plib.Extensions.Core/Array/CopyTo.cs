using System;


namespace PLib.Extensions.Core
{

	public static partial class ArrayExtensions
	{

		/// <summary>
		///     Copies all elements from the current array into another array.
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
		public static void CopyTo(this Array me, Array dstArray)
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
				throw new ArgumentException("The destination array is to short to fit the elements of the current array.");
			}

			Array.Copy(me, dstArray, me.LongLength);
		}



		/// <summary>
		///     Copies a number of elements from the current array starting at the first element and pastes
		///     them into another array starting at the first element.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="dstArray">The destination array.</param>
		/// <param name="length">The number of elements to copy.</param>
		/// <exception cref="ArgumentNullException">
		///     <paramref name="me"/> is null
		///     -or-
		///     <paramref name="dstArray"/>
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     if the <paramref name="length"/> is ouside the bound of either <paramref name="me"/>
		///     or <paramref name="dstArray"/>
		/// </exception>
		public static void CopyTo(this Array me, Array dstArray, int length)
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
		///     Copies a number of elements from the current array starting at the specified offset and
		///     pastes them to another array starting at the specified destination offset.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="index">The index in the current array at which copying begins.</param>
		/// <param name="dstArray">The destination array.</param>
		/// <param name="dstIndex">The index in the destination array at which storing begins.</param>
		/// <param name="length">The number of elements to copy.</param>
		/// <exception cref="ArgumentNullException">
		///     <paramref name="me"/> is null
		///     -or-
		///     <paramref name="dstArray"/> is null.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     <paramref name="index"/> is outside the bounds of the current array.
		///     -or-
		///     <paramref name="dstIndex"/> is outside the bound of the <paramref name="dstArray"/> array.
		/// </exception>
		/// <exception cref="ArgumentException">
		///     The <paramref name="length"/> length is greater than the number of elements from
		///     <paramref name="index"/> to the end of the current array
		///     -or-
		///     the <paramref name="length"/> is greater than the number of elements from
		///     <paramref name="dstIndex"/> to the end of the <paramref name="dstArray"/> array.
		/// </exception>
		public static void CopyTo(this Array me, int index, Array dstArray, int dstIndex, int length)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			if (dstArray == null)
			{
				throw new ArgumentNullException(nameof(dstArray));
			}

			if (index < 0 || me.Length <= index)
			{
				throw new ArgumentOutOfRangeException(nameof(index));
			}

			if (dstIndex < 0 || dstArray.Length <= dstIndex)
			{
				throw new ArgumentOutOfRangeException(nameof(dstIndex));
			}

			if (me.Length < index + length)
			{
				throw new ArgumentException("The length is greater than the number of elements from offset to the end of the current array.");
			}

			if (dstArray.Length < dstIndex + length)
			{
				throw new ArgumentException("The length is greater than the number of elements from destination offset to the end of the destination array.");
			}

			Array.Copy(me, index, dstArray, dstIndex, length);
		}



		/// <summary>
		///     Copies a number of elements from the current array starting at the first element and pastes
		///     them into another array starting at the first element.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="dstArray">The destination array.</param>
		/// <param name="length">The number of elements to copy.</param>
		/// <exception cref="ArgumentNullException">
		///     <paramref name="me"/> is null
		///     -or-
		///     <paramref name="dstArray"/>
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     if the <paramref name="length"/> is ouside the bound of either
		///     <paramref name="me"/> or <paramref name="dstArray"/>
		/// </exception>
		public static void CopyTo(this Array me, Array dstArray, long length)
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
		///     Copies a number of elements from the current array starting at the specified offset
		///     and pastes them to another array starting at the specified destination offset.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="index">The index in the current array at which copying begins.</param>
		/// <param name="dstArray">The destination array.</param>
		/// <param name="dstIndex">The index in the destination array at which storing begins.</param>
		/// <param name="length">The number of elements to copy.</param>
		/// <exception cref="ArgumentNullException">
		///     <paramref name="me"/> is null
		///     -or-
		///     <paramref name="dstArray"/> is null.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     <paramref name="index"/> is outside the bounds of the current array.
		///     -or-
		///     <paramref name="dstIndex"/> is outside the bound of the <paramref name="dstArray"/> array.
		/// </exception>
		/// <exception cref="ArgumentException">
		///     The <paramref name="length"/> length is greater than the number of elements from
		///     <paramref name="index"/> to the end of the current array
		///     -or-
		///     the <paramref name="length"/> is greater than the number of elements from
		///     <paramref name="dstIndex"/> to the end of the <paramref name="dstArray"/> array.
		/// </exception>
		public static void CopyTo(this Array me, long index, Array dstArray, long dstIndex, long length)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			if (dstArray == null)
			{
				throw new ArgumentNullException(nameof(dstArray));
			}

			if (index < 0L || me.LongLength <= index)
			{
				throw new ArgumentOutOfRangeException(nameof(index));
			}

			if (dstIndex < 0L || dstArray.LongLength <= dstIndex)
			{
				throw new ArgumentOutOfRangeException(nameof(dstIndex));
			}

			if (me.LongLength < index + length)
			{
				throw new ArgumentException("The length is greater than the number of elements from offset to the end of the current array.");
			}

			if (dstArray.LongLength < dstIndex + length)
			{
				throw new ArgumentException("The length is greater than the number of elements from destination offset to the end of the destination array.");
			}

			Array.Copy(me, index, dstArray, dstIndex, length);
		}

	}

}
