using System;


namespace PLib.Extensions.Core
{

	public static partial class GenericArrayExtensions
	{

		/// <summary>
		///     Searches for the specified object and returns the index of its first occurrence in
		///     the current one-dimensional array.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="value">The object to locate.</param>
		/// <returns>
		///     The zero-based index of the first occurrence of value in the entire array, if found;
		///     otherwise, –1.
		/// </returns>
		public static int IndexOf<T>(this T[] me, T value)
		{
			return Array.IndexOf(me, value);
		}



		/// <summary>
		///     Searches for the specified object in a range of elements in the current
		///     one-dimensional array, and returns the index of its first occurrence. The range
		///     extends from a specified index to the end of the array.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="value">The object to locate.</param>
		/// <param name="startIndex">
		///     The starting index of the search. 0 (zero) is valid in an empty array.
		/// </param>
		/// <returns>
		///     The zero-based index of the first occurrence of value within the range of elements in
		///     array that extends from <paramref name="startIndex"/> to the last element, if found; otherwise, –1.
		/// </returns>
		public static int IndexOf<T>(this T[] me, T value, int startIndex)
		{
			return Array.IndexOf(me, value, startIndex);
		}



		/// <summary>
		///     Searches for the specified object in a range of elements in the current
		///     one-dimensional array, and returns the index of ifs first occurrence. The range
		///     extends from a specified index for a specified number of elements.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="value">The object to locate.</param>
		/// <param name="startIndex">
		///     The starting index of the search. 0 (zero) is valid in an empty array.
		/// </param>
		/// <param name="count">The number of elements to search.</param>
		/// <returns>
		///     The zero-based index of the first occurrence of value within the range of elements in
		///     the current array that starts at <paramref name="startIndex"/> and contains the
		///     number of elements specified in <paramref name="count"/>, if found; otherwise, –1.
		/// </returns>
		public static int IndexOf<T>(this T[] me, T value, int startIndex, int count)
		{
			return Array.IndexOf(me, value, startIndex, count);
		}

	}

}
