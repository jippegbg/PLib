using System;

using JetBrains.Annotations;


namespace PLib.Extensions.System
{

	public static partial class ArrayExtensions
	{

		/// <summary>
		///     Copies the entire current one-dimentional array into a new one.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="me">The current one-dimetional array.</param>
		/// <returns>A copy of the entire current one-dimetional array.</returns>
		/// <exception cref="ArgumentNullException">
		///     if <paramref name="me"/> is null.
		/// </exception>
		public static T[] GetCopy<T>([NotNull] this T[] me)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			T[] copy = new T[me.LongLength];
			Array.Copy(me, copy, me.LongLength);
			return copy;
		}



		/// <summary>
		///     Copies the entire current two-dimentional array into a new one.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current two-dimetional array.</param>
		/// <returns>A copy of the entire current two-dimetional array.</returns>
		/// <exception cref="ArgumentNullException">
		///     if <paramref name="me"/> is null.
		/// </exception>
		public static T[,] GetCopy<T>([NotNull] this T[,] me)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			T[,] copy = new T[me.GetLongLength(0), me.GetLongLength(1)];
			Array.Copy(me, copy, me.LongLength);
			return copy;
		}



		/// <summary>
		///     Copies a range of elements of the current one-dimentional array into a new
		///     one-dimentional array with the same length as the range.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="offset">The starting index of the section to copy.</param>
		/// <param name="length">The number of elements in the section to copy.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">
		///     <paramref name="me"/> is null.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     The <paramref name="offset"/> is outside the bounds of the current array.
		/// </exception>
		/// <exception cref="ArgumentException">
		///     The <paramref name="length"/> is greater than the number of elements from
		///     <paramref name="offset"/> to the end of the current array.
		/// </exception>
		public static T[] GetCopy<T>([NotNull] this T[] me, int offset, int length)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			if (offset < 0 || me.Length <= offset)
			{
				throw new ArgumentOutOfRangeException(nameof(offset));
			}

			if (me.Length < offset + length)
			{
				throw new ArgumentException("The length is greater than the number of elements from offset to the end of the current array.");
			}

			T[] copy = new T[length];
			Array.Copy(me, offset, copy, 0, length);
			return copy;
		}



		/// <summary>
		///     TODO Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="length">The length.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">
		///     <paramref name="me"/> is null.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     <paramref name="offset"/> is outside the bounds of the current array.
		/// </exception>
		/// <exception cref="ArgumentException">
		///     The <paramref name="length"/> length is greater than the number of elements
		///     from offset to the end of the current array.
		/// </exception>
		public static T[] GetCopy<T>([NotNull] this T[] me, long offset, long length)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			if (offset < 0 || me.Length <= offset)
			{
				throw new ArgumentOutOfRangeException(nameof(offset));
			}

			if (me.LongLength < offset + length)
			{
				throw new ArgumentException("The length is greater than the number of elements from offset to the end of the current array.");
			}

			T[] copy = new T[length];
			Array.Copy(me, offset, copy, 0, length);
			return copy;
		}



		/// <summary>
		///     TODO Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <returns></returns>
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
		public static T[] GetBlockCopy<T>([NotNull] this T[] me)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			T[] copy = new T[me.Length];
			Buffer.BlockCopy(me, 0, copy, 0, me.Length);
			return copy;
		}



		/// <summary>
		///     Gets the block copy.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current array.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">this</exception>
		/// TODO Edit XML Comment Template for GetBlockCopy`1
		public static T[,] GetBlockCopy<T>([NotNull] this T[,] me)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			T[,] copy = new T[me.GetLength(0), me.GetLength(1)];
			Buffer.BlockCopy(me, 0, copy, 0, me.Length);
			return copy;
		}

	}

}
