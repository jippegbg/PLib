using System;

using JetBrains.Annotations;


namespace PLib.Extensions.Core
{

	public static partial class GenericArrayExtensions
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
		public static T[] GetCopy<T>(this T[] me)
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
		public static T[,] GetCopy<T>(this T[,] me)
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
		/// <param name="length">The number of elements to copy.</param>
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
		public static T[] GetCopy<T>(this T[] me, int offset, int length)
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
		///     Copies a range of elements of the current one-dimentional array into a new
		///     one-dimentional array with the same length as the range.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="length">The number of elements to copy.</param>
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
		public static T[] GetCopy<T>(this T[] me, long offset, long length)
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

	}

}
