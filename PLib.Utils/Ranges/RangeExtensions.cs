using System;

using PLib.Extensions.Core;


namespace PLib.Utils.Ranges {

	/// <summary>
	///     A static class that provides extensions of the <see cref="Range"/> class, and
	///     extensions of other classes using the <see cref="Range"/> class.
	/// </summary>
	public static class RangeExtensions
	{

		/// <summary>
		///     Converts the current string into a new <see cref="Range"/>.
		/// </summary>
		/// <param name="this">The string expression to convert.</param>
		/// <returns>A new <see cref="Range"/> based on the <paramref name="this"/>.</returns>
		/// <exception cref="FormatException">
		///     If the format of the expression cannot be interpreted as a range.
		/// </exception>
		/// <exception cref="ArgumentNullException">If expression is null.</exception>
		/// <exception cref="TimeoutException">
		///     If there was a time-out when trying to match the expression against valid formats.
		/// </exception>
		public static Range ToRange(this string @this)
		{
			return Range.Parse(@this);
		}



		/// <summary>
		///     Converts the current range to a sequence that can be used to enumerate the values in
		///     the range from one boundary to the other.
		/// </summary>
		/// <param name="this">The current range to convert.</param>
		/// <param name="reverse">
		///     If set to <see langword="false"/>, the sequence will start at
		///     <see cref="Range.LowerBound"/> and end at <see cref="Range.UpperBound"/>.
		///     <para/>
		///     If set to <see langword="true"/>, the sequence will start at
		///     <see cref="Range.UpperBound"/> and end at <see cref="Range.LowerBound"/>.
		///     <para/>
		///     Optional. Default is <see langword="false"/>.
		/// </param>
		/// <returns>
		///     A sequence that starts at one bound of the range and ends at
		///     the other bound, in steps of one.
		/// </returns>
		public static Sequence ToSequence(this Range @this, bool reverse = false)
		{
			return reverse
				? new Sequence(@this.UpperBound, @this.LowerBound)
				: new Sequence(@this.LowerBound, @this.UpperBound);
		}



		/// <summary>
		///     Creates a new substring from the current string. The substring starts and ends at the
		///     positions specified by a given range.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="range">
		///     A range that specifies the inclusive start and end positions of the current string.
		/// </param>
		/// <returns>
		///     A string that is equivalent to the substring that begins and ends at the indexes
		///     specified by the <paramref name="range"/> in this instance.
		/// </returns>
		public static string Substring(this string @this, Range range)
		{
			return @this.Substring(range.LowerBound, range.Length);
		}



		/// <summary>
		///     Delimits a segment of the current array with new indexes, without making a copy of it.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="this">The curent array.</param>
		/// <param name="range">The range of the delimitation.</param>
		/// <returns>
		///     A structure that delimits the specified <paramref name="range"/> of the elements in
		///     the current array.
		/// </returns>
		public static ArraySegment<T> Segment<T>(this T[] @this, Range range)
		{
			return new ArraySegment<T>(@this, range.LowerBound, range.Length);
		}



		/// <summary>
		///     Retrieves a new subarray, copied from this instance. The subarray starts and ends at the
		///     positions specified by a given range.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="this">The curent array.</param>
		/// <param name="range">
		///     A range that specifies the inclusive start and end positions of the current array.
		/// </param>
		/// <returns>
		///     A new zero-base array with values copied from the specified index range of the
		///     current array.
		/// </returns>
		public static T[] Subarray<T>(this T[] @this, Range range)
		{
			return @this.Subarray(range.LowerBound, range.Length);
		}

	}

}