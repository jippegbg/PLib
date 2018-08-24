using System;


namespace PLib.Extensions.Core
{

	public static partial class ArrayExtensions
	{

		/// <summary>
		///     Searches for the specified object and returns the index of its first occurrence in
		///     the current one-dimensional array.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="value">The object to locate.</param>
		/// <returns>
		///     The index of the first occurrence of value in the current array, if found; otherwise, the lower
		///     bound of the current array minus 1.
		/// </returns>
		public static int IndexOf(this Array me, object value)
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
		///     The index of the first occurrence of value, if it’s found, within the range of
		///     elements in the current array that extends from <paramref name="startIndex"/> to the
		///     last element; otherwise, the lower bound of the array minus 1.
		/// </returns>
		public static int IndexOf(this Array me, object value, int startIndex)
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
		///     The index of the first occurrence of value, if it’s found in the array from
		///     <paramref name="startIndex"/> to <paramref name="startIndex"/> +
		///     <paramref name="count"/> - 1; otherwise, the lower bound of the array minus 1.
		/// </returns>
		public static int IndexOf(this Array me, object value, int startIndex, int count)
		{
			return Array.IndexOf(me, value, startIndex, count);
		}

	}

}
