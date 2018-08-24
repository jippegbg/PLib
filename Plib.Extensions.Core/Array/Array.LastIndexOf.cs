using System;


namespace PLib.Extensions.Core
{

	public static partial class ArrayExtensions
	{

		/// <summary>
		///     Searches for the specified object and returns the index of the last occurrence within
		///     the current one-dimensional Array.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="value">The object to locate.</param>
		/// <returns>
		///     The index of the last occurrence of value within the current array, if found;
		///     otherwise, the lower bound of the array minus 1.
		/// </returns>
		public static int LastIndexOf(this Array me, object value)
		{
			return Array.LastIndexOf(me, value);
		}



		/// <summary>
		///     Searches for the specified object and returns the index of the last occurrence within
		///     the range of elements in the current one-dimensional Array that extends from the
		///     first element to the specified index.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="value">The object to locate.</param>
		/// <param name="startIndex">The starting index of the backward search.</param>
		/// <returns>
		///     The index of the last occurrence of value within the range of elements in the current
		///     array that extends from the first element to <paramref name="startIndex"/>, if found; otherwise, the
		///     lower bound of the array minus 1.
		/// </returns>
		public static int LastIndexOf(this Array me, object value, int startIndex)
		{
			return Array.LastIndexOf(me, value, startIndex);
		}



		/// <summary>
		///     Searches for the specified object and returns the index of the last occurrence within
		///     the range of elements in the current one-dimensional array that contains the
		///     specified number of elements and ends at the specified index.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="value">The object to locate.</param>
		/// <param name="startIndex">The starting index of the backward search.</param>
		/// <param name="count">The number of elements in the section to search.</param>
		/// <returns>
		///     The index of the last occurrence of value within the range of elements in the current
		///     array that contains the number of elements specified in <paramref name="count"/> and
		///     ends at <paramref name="startIndex"/>, if found; otherwise, the lower bound of the
		///     array minus 1.
		/// </returns>
		public static int LastIndexOf(this Array me, object value, int startIndex, int count)
		{
			return Array.LastIndexOf(me, value, startIndex, count);
		}

	}

}
