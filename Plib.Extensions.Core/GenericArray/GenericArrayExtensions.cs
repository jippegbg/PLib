using System;


namespace PLib.Extensions.Core
{

	public static partial class GenericArrayExtensions
	{

		/// <summary>
		/// Indexes the of.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">this</exception>
		/// TODO: Edit XML Comment
		public static int IndexOf<T>(this T[] me, T value)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			return Array.IndexOf(me, value);
		}



		/// <summary>
		/// Lasts the index of.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">this</exception>
		/// TODO: Edit XML Comment
		public static int LastIndexOf<T>(this T[] me, T value)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			return Array.LastIndexOf(me, value);
		}



		/// <summary>
		/// Clears the specified this.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current array.</param>
		/// <exception cref="ArgumentNullException">this</exception>
		/// TODO: Edit XML Comment
		public static T[] Clear<T>(this T[] me)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			Array.Clear(me, 0, me.Length);

			return me;
		}



		/// <summary>
		/// Clears the specified offset.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="length">The length.</param>
		/// <exception cref="ArgumentNullException">this</exception>
		/// <exception cref="ArgumentOutOfRangeException">offset</exception>
		/// <exception cref="ArgumentException">The length is greater than the number of elements from offset to the end of the current array.</exception>
		/// TODO: Edit XML Comment
		public static T[] Clear<T>(this T[] me, int offset, int length)
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

			Array.Clear(me, offset, length);

			return me;
		}



		/// <summary>
		/// Determines whether [is within bounds] [the specified index].
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="index">The index.</param>
		/// <returns>
		///   <c>true</c> if [is within bounds] [the specified index]; otherwise, <c>false</c>.
		/// </returns>
		/// <exception cref="ArgumentNullException">this</exception>
		/// TODO: Edit XML Comment
		public static bool IsWithinBounds<T>(this T[] me, int index)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			return 0 <= index && index < me.Length;
		}



		/// <summary>
		/// Determines whether [is within bounds] [the specified index].
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="index">The index.</param>
		/// <returns>
		///   <c>true</c> if [is within bounds] [the specified index]; otherwise, <c>false</c>.
		/// </returns>
		/// <exception cref="ArgumentNullException">this</exception>
		/// TODO: Edit XML Comment
		public static bool IsWithinBounds<T>(this T[] me, long index)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			return 0L <= index && index < me.LongLength;
		}



		/// <summary>
		/// Resizes the specified new size.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="newSize">The new size.</param>
		/// <returns></returns>
		/// TODO: Edit XML Comment
		public static T[] Resize<T>(this T[] me, int newSize)
		{
			Array.Resize(ref me, newSize);
			return me;
		}

	}

}
