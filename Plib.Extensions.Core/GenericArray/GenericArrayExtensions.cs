using System;


namespace PLib.Extensions.Core
{

	/// <summary>
	///     Extensions of generic arrays.
	/// </summary>
	public static partial class GenericArrayExtensions
	{

		/// <summary>
		///     Converts the current array an array of another type.
		/// </summary>
		/// <typeparam name="TIn">The type of the elements of the current array.</typeparam>
		/// <typeparam name="TOut">The type of the elements of the target array.</typeparam>
		/// <param name="me">Me.</param>
		/// <param name="converter">
		///     A <see cref="Converter{TInput, TOutput}"/> that converts each element from
		///     one type to another type.
		/// </param>
		/// <returns>
		///     An array of the target type containing the converted elements from the
		///     current array.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///     <paramref name="me"/> is <b>null</b><br/>
		///     -or-<br/>
		///     <paramref name="converter"/> is <b>null</b>.
		/// </exception>
		public static TOut[] ConvertAll<TIn, TOut>(this TIn[] me, Converter<TIn, TOut> converter)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			if (converter == null)
			{
				throw new ArgumentNullException(nameof(converter));
			}

			return Array.ConvertAll(me, converter);
		}



		/// <summary>
		///     Determines whether the specified array contains elements that match the
		///     conditions defined by the specified predicate.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="match">
		///     The <see cref="Predicate{T}"/> that defines the conditions of the elements
		///     to search for.
		/// </param>
		/// <returns></returns>
		public static bool Exists<T>(this T[] me, Predicate<T> match)
		{
			return Array.Exists(me, match);
		}



		/// <summary>
		///     Searches for an element that matches the conditions defined by the
		///     specified predicate, and returns the first occurrence within the entire Array.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="match">
		///     The <see cref="Predicate{T}"/> that defines the conditions of the elements
		///     to search for.
		/// </param>
		/// <returns>
		///     The first element that matches the conditions defined by the specified
		///     predicate, if found; otherwise, the default value for type T.
		/// </returns>
		public static T Find<T>(this T[] me, Predicate<T> match)
		{
			return Array.Find(me, match);
		}



		/// <summary>
		///     Retrieves all the elements that match the conditions defined by the
		///     specified predicate.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="match">
		///     The <see cref="Predicate{T}"/> that defines the conditions of the elements
		///     to search for.
		/// </param>
		/// <returns>
		///     An array containing all the elements that match the conditions defined by
		///     the specified predicate, if found; otherwise, an empty array.
		/// </returns>
		public static T[] FindAll<T>(this T[] me, Predicate<T> match)
		{
			return Array.FindAll(me, match);
		}



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
		///     specified predicate, and returns the last occurrence within the current array.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="match">
		///     The <see cref="Predicate{T}"/> that defines the conditions of the elements
		///     to search for.
		/// </param>
		/// <returns>
		///     The last element that matches the conditions defined by the specified
		///     predicate, if found; otherwise, the default value for type T.
		/// </returns>
		public static T FindLast<T>(this T[] me, Predicate<T> match)
		{
			return Array.FindLast(me, match);
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
		///     Performs the specified action on each element of the current array.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="action">
		///     The <see cref="Action{T}"/> to perform on each element of the current array.
		/// </param>
		/// <returns>
		///     The current array after the action has been performed on each element.
		/// </returns>
		public static T[] ForEach<T>(this T[] me, Action<T> action)
		{
			Array.ForEach(me, action);
			return me;
		}



		/// <summary>
		///     Resizes the current array to a new size.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="newSize">The new size.</param>
		/// <returns>The current array after it has been resized.</returns>
		public static T[] Resize<T>(this T[] me, int newSize)
		{
			Array.Resize(ref me, newSize);
			return me;
		}



		/// <summary>
		///     Determines whether every element in the array matches the conditions
		///     defined by the specified predicate.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="match">
		///     The predicate that defines the conditions to check against the elements.
		/// </param>
		/// <returns>
		///     <b>true</b> if every element in the current array matches the conditions
		///     defined by the specified predicate; otherwise, <b>false</b>. If there are
		///     no elements in the current array, the return value is <b>true</b>.
		/// </returns>
		public static bool TrueForAll<T>(this T[] me, Predicate<T> match)
		{
			return Array.TrueForAll(me, match);
		}

	}

}
