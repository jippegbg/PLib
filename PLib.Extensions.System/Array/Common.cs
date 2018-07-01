using System;

using JetBrains.Annotations;


namespace PLib.Extensions.System
{

	/// <summary>
	/// 
	/// </summary>
	/// TODO Edit XML Comment Template for Extensions
	public static partial class ArrayExtensions
	{

		/// <summary>
		/// Indexes the of.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="this">The current array.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">this</exception>
		/// TODO Edit XML Comment Template for IndexOf`1
		public static int IndexOf<T>([NotNull] this T[] @this, T value)
		{
			if (@this == null)
			{
				throw new ArgumentNullException(nameof(@this));
			}

			return Array.IndexOf(@this, value);
		}



		/// <summary>
		/// Lasts the index of.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="this">The current array.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">this</exception>
		/// TODO Edit XML Comment Template for LastIndexOf`1
		public static int LastIndexOf<T>([NotNull] this T[] @this, T value)
		{
			if (@this == null)
			{
				throw new ArgumentNullException(nameof(@this));
			}

			return Array.LastIndexOf(@this, value);
		}



		/// <summary>
		/// Clears the specified this.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="this">The current array.</param>
		/// <exception cref="ArgumentNullException">this</exception>
		/// TODO Edit XML Comment Template for Clear`1
		public static void Clear<T>([NotNull] this T[] @this)
		{
			if (@this == null)
			{
				throw new ArgumentNullException(nameof(@this));
			}

			Array.Clear(@this, 0, @this.Length);
		}



		/// <summary>
		/// Clears the specified offset.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="this">The current array.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="length">The length.</param>
		/// <exception cref="ArgumentNullException">this</exception>
		/// <exception cref="ArgumentOutOfRangeException">offset</exception>
		/// <exception cref="ArgumentException">The length is greater than the number of elements from offset to the end of the current array.</exception>
		/// TODO Edit XML Comment Template for Clear`1
		public static void Clear<T>([NotNull] this T[] @this, int offset, int length)
		{
			if (@this == null)
			{
				throw new ArgumentNullException(nameof(@this));
			}

			if (offset < 0 || @this.Length <= offset)
			{
				throw new ArgumentOutOfRangeException(nameof(offset));
			}

			if (@this.Length < offset + length)
			{
				throw new ArgumentException("The length is greater than the number of elements from offset to the end of the current array.");
			}

			Array.Clear(@this, offset, length);
		}



		/// <summary>
		/// Determines whether [is within bounds] [the specified index].
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="this">The current array.</param>
		/// <param name="index">The index.</param>
		/// <returns>
		///   <c>true</c> if [is within bounds] [the specified index]; otherwise, <c>false</c>.
		/// </returns>
		/// <exception cref="ArgumentNullException">this</exception>
		/// TODO Edit XML Comment Template for IsWithinBounds`1
		public static bool IsWithinBounds<T>([NotNull] this T[] @this, int index)
		{
			if (@this == null)
			{
				throw new ArgumentNullException(nameof(@this));
			}

			return 0 <= index && index < @this.Length;
		}



		/// <summary>
		/// Determines whether [is within bounds] [the specified index].
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="this">The current array.</param>
		/// <param name="index">The index.</param>
		/// <returns>
		///   <c>true</c> if [is within bounds] [the specified index]; otherwise, <c>false</c>.
		/// </returns>
		/// <exception cref="ArgumentNullException">this</exception>
		/// TODO Edit XML Comment Template for IsWithinBounds`1
		public static bool IsWithinBounds<T>([NotNull] this T[] @this, long index)
		{
			if (@this == null)
			{
				throw new ArgumentNullException(nameof(@this));
			}

			return 0L <= index && index < @this.LongLength;
		}



		/// <summary>
		///     Reverses the sequence of the elements in the entire current one-dimensional array.
		/// </summary>
		/// <param name="this">The current array.</param>
		/// <returns>The current array after the elements have been reversed.</returns>
		public static Array Reverse(this Array @this)
		{
			Array.Reverse(@this);
			return @this;
		}



		/// <summary>
		///     Reverses the sequence of the elements in a section of elements in the current
		///     one-dimensional array.
		/// </summary>
		/// <param name="this">The current array.</param>
		/// <param name="offset">The starting index of the section to reverse.</param>
		/// <param name="length">The number of elements in the section to reverse.</param>
		/// <returns>The current array after the elements have been reversed.</returns>
		public static Array Reverse(this Array @this, int offset, int length)
		{
			Array.Reverse(@this, offset, length);
			return @this;
		}

	}

}
