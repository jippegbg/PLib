using System;


namespace PLib.Extensions.Core {

	public static partial class GenericArrayExtensions
	{

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

	}

}