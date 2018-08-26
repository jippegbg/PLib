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
		/// <param name="me">The current array.</param>
		/// <param name="converter">
		///     A <see cref="Converter{TInput, TOutput}"/> that converts each element from
		///     one type to another type.
		/// </param>
		/// <returns>
		///     An array of the target type containing the converted elements from the
		///     current array.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///     <paramref name="me"/> is <see langword="null"/><br/>
		///     -or-<br/>
		///     <paramref name="converter"/> is <see langword="null"/>.
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
		///     Determines whether the specified array contains elements that match the conditions
		///     defined by the specified predicate.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="match">
		///     The <see cref="Predicate{T}"/> that defines the conditions of the elements to search for.
		/// </param>
		/// <returns>
		///     <see langword="true"/> if the current array contains one or more elements that match
		///     the conditions defined by the specified predicate; otherwise, <see langword="false"/>.
		/// </returns>
		/// <remarks>This method could also be called "TrueForAny".</remarks>
		public static bool Exists<T>(this T[] me, Predicate<T> match)
		{
			return Array.Exists(me, match);
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
		///     Determines whether every element in the array matches the conditions defined by the
		///     specified predicate.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="match">
		///     The predicate that defines the conditions to check against the elements.
		/// </param>
		/// <returns>
		///     <see langword="true"/> if every element in the current array matches the conditions defined by
		///     the specified predicate; otherwise, <see langword="false"/>. If there are no elements in the
		///     current array, the return value is <see langword="true"/>.
		/// </returns>
		/// <remarks>
		///     To find if any element matches the predicate (like <c>TrueForAny</c>),
		///     use <see cref="Exists{T}(T[], Predicate{T})"/>.
		/// </remarks>
		public static bool TrueForAll<T>(this T[] me, Predicate<T> match)
		{
			return Array.TrueForAll(me, match);
		}

	}

}
