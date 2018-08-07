using System;
using System.Collections.Generic;


namespace PLib.Extensions.Core {

	public static partial class GenericArrayExtensions
	{

		/// <summary>
		///     Searches for an element that matches the conditions defined by the
		///     specified predicate, and returns the zero-based index of the first
		///     occurrence within the current array.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="match">
		///     The <see cref="Predicate{T}"/> that defines the conditions of the elements
		///     to search for.
		/// </param>
		/// <returns>
		///     The zero-based index of the first occurrence of an element that matches the
		///     conditions defined by match, if found; otherwise, -1.
		/// </returns>
		public static int FindIndex<T>(this T[] me, Predicate<T> match)
		{
			return Array.FindIndex(me, match);
		}



		/// <summary>
		///     Searches for an element that matches the conditions defined by the
		///     specified predicate, and returns the zero-based index of the first
		///     occurrence within the range of elements in the current array that extends
		///     from the specified index to the last element.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="startIndex">The zero-based starting index of the search.</param>
		/// <param name="match">
		///     The <see cref="Predicate{T}"/> that defines the conditions of the elements
		///     to search for.
		/// </param>
		/// <returns>
		///     The zero-based index of the first occurrence of an element that matches the
		///     conditions defined by match, if found; otherwise, -1.
		/// </returns>
		public static int FindIndex<T>(this T[] me, int startIndex, Predicate<T> match)
		{
			return Array.FindIndex(me, startIndex, match);
		}



		/// <summary>
		///     Searches for an element that matches the conditions defined by the
		///     specified predicate, and returns the zero-based index of the first
		///     occurrence within the range of elements in the current array that starts at
		///     the specified index and contains the specified number of elements.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="startIndex">The zero-based starting index of the search.</param>
		/// <param name="count">The number of elements in the section to search.</param>
		/// <param name="match">
		///     The <see cref="Predicate{T}"/> that defines the conditions of the elements
		///     to search for.
		/// </param>
		/// <returns>
		///     The zero-based index of the first occurrence of an element that matches the
		///     conditions defined by <paramref name="match"/>, if found; otherwise, -1.
		/// </returns>
		public static int FindIndex<T>(this T[] me, int startIndex, int count, Predicate<T> match)
		{
			return Array.FindIndex(me, startIndex, count, match);
		}



		/// <summary>
		///     Searches for an element that matches the conditions defined by the
		///     specified predicate, and returns the zero-based index of the last
		///     occurrence within the current array.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="match">
		///     The <see cref="Predicate{T}"/> that defines the conditions of the elements
		///     to search for.
		/// </param>
		/// <returns>
		///     The zero-based index of the last occurrence of an element that matches the
		///     conditions defined by match, if found; otherwise, –1.
		/// </returns>
		public static int FindLastIndex<T>(this T[] me, Predicate<T> match)
		{
			return Array.FindLastIndex(me, match);
		}



		/// <summary>
		///     Searches for an element that matches the conditions defined by the
		///     specified predicate, and returns the zero-based index of the last
		///     occurrence within the range of elements in the current array that extends
		///     from the first element to the specified index.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="startIndex">
		///     The zero-based starting index of the backward search.
		/// </param>
		/// <param name="match">
		///     The <see cref="Predicate{T}"/> that defines the conditions of the elements
		///     to search for.
		/// </param>
		/// <returns>
		///     The zero-based index of the last occurrence of an element that matches the
		///     conditions defined by match, if found; otherwise, –1.
		/// </returns>
		public static int FindLastIndex<T>(this T[] me, int startIndex, Predicate<T> match)
		{
			return Array.FindLastIndex(me, startIndex, match);
		}



		/// <summary>
		///     Searches for an element that matches the conditions defined by the
		///     specified predicate, and returns the zero-based index of the last
		///     occurrence within the range of elements in the current array that contains
		///     the specified number of elements and ends at the specified index.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="startIndex">
		///     The zero-based starting index of the backward search.
		/// </param>
		/// <param name="count">The number of elements in the section to search.</param>
		/// <param name="match">
		///     The <see cref="Predicate{T}"/> that defines the conditions of the elements
		///     to search for.
		/// </param>
		/// <returns>
		///     The zero-based index of the last occurrence of an element that matches the
		///     conditions defined by match, if found; otherwise, –1.
		/// </returns>
		public static int FindLastIndex<T>(this T[] me, int startIndex, int count, Predicate<T> match)
		{
			return Array.FindLastIndex(me, startIndex, count, match);
		}



		/// <summary>
		///     Retrieves all the zero-based indexes for the elements that match the conditions
		///     defined by the specified predicate.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="match">
		///     The <see cref="Predicate{T}"/> that defines the conditions of the elements to search for.
		/// </param>
		/// <returns>
		///     An array containing all the zero-based indexes for the elements that match the
		///     conditions defined by the specified predicate, if found; otherwise, an empty array.
		/// </returns>
		public static int[] FindAllIndex<T>(this T[] me, Predicate<T> match)
		{
			List<int> indexes = new List<int>();

			for (int i = 0; i < me.Length; i++)
			{
				if (match(me[i]))
				{
					indexes.Add(i);
				}
			}

			return indexes.ToArray();
		}

	}

}