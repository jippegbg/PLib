using System;

using JetBrains.Annotations;


namespace PLib.Extensions.Core
{

	/// <summary>
	/// Extensions of the <see cref="Array"/> class.
	/// </summary>
	public static partial class ArrayExtensions
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
		public static int IndexOf<T>([NotNull] this T[] me, T value)
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
		public static int LastIndexOf<T>([NotNull] this T[] me, T value)
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
		public static T[] Clear<T>([NotNull] this T[] me)
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
		public static T[] Clear<T>([NotNull] this T[] me, int offset, int length)
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
		public static bool IsWithinBounds<T>([NotNull] this T[] me, int index)
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
		public static bool IsWithinBounds<T>([NotNull] this T[] me, long index)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			return 0L <= index && index < me.LongLength;
		}



		/// <summary>
		///     Reverses the sequence of the elements in the entire current one-dimensional array.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <returns>The current array after the elements have been reversed.</returns>
		public static Array Reverse(this Array me)
		{
			Array.Reverse(me);
			return me;
		}



		/// <summary>
		///     Reverses the sequence of the elements in a section of elements in the current
		///     one-dimensional array.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="offset">The starting index of the section to reverse.</param>
		/// <param name="length">The number of elements in the section to reverse.</param>
		/// <returns>The current array after the elements have been reversed.</returns>
		public static Array Reverse(this Array me, int offset, int length)
		{
			Array.Reverse(me, offset, length);
			return me;
		}



		/// <summary>
		/// Resizes the specified new size.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">Me.</param>
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
