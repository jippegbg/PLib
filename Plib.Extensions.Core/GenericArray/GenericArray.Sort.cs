using System;
using System.Collections.Generic;


namespace PLib.Extensions.Core
{

	public static partial class GenericArrayExtensions
	{

		/// <summary>
		///     Sorts the elements in the current array using the
		///     <see cref="IComparable{T}"/> generic interface implementation of each
		///     element of the Array.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <returns>The current array after it's sorted.</returns>
		public static T[] Sort<T>(this T[] me)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			Array.Sort(me);

			return me;
		}



		/// <summary>
		///     Sorts the elements in the current array using the specified
		///     <see cref="IComparer{T}"/> generic interface.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="comparer">
		///     The <see cref="IComparer{T}"/> generic interface implementation to use when
		///     comparing elements, or null to use the <see cref="IComparable{T}"/> generic
		///     interface implementation of each element.
		/// </param>
		/// <returns>The current array after it's sorted.</returns>
		public static T[] Sort<T>(this T[] me, IComparer<T> comparer)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			if (comparer == null)
			{
				throw new ArgumentNullException(nameof(comparer));
			}

			Array.Sort(me, comparer);

			return me;
		}



		/// <summary>
		///     Sorts the elements in an Array using the specified <see cref="Comparison{T}"/>.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="comparison">
		///     The <see cref="Comparison{T}"/> to use when comparing elements.
		/// </param>
		/// <returns>The current array after it's sorted.</returns>
		public static T[] Sort<T>(this T[] me, Comparison<T> comparison)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			if (comparison == null)
			{
				throw new ArgumentNullException(nameof(comparison));
			}

			Array.Sort(me, comparison);

			return me;
		}



		/// <summary>
		///     Sorts the elements in a range of elements in an Array using the
		///     <see cref="IComparable{T}"/> generic interface implementation of each
		///     element of the Array.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="index">The starting index of the range to sort.</param>
		/// <param name="length">The number of elements in the range to sort.</param>
		/// <returns>The current array after it's sorted.</returns>
		public static T[] Sort<T>(this T[] me, int index, int length)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			Array.Sort(me, index, length);

			return me;
		}



		/// <summary>
		///     Sorts the elements in a range of elements in an Array using the specified
		///     <see cref="IComparer{T}"/> generic interface.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="index">The starting index of the range to sort.</param>
		/// <param name="length">The number of elements in the range to sort.</param>
		/// <param name="comparer">
		///     The <see cref="IComparer{T}"/> generic interface implementation to use when
		///     comparing elements, or null to use the <see cref="IComparable{T}"/> generic
		///     interface implementation of each element.
		/// </param>
		/// <returns>The current array after it's sorted.</returns>
		public static T[] Sort<T>(this T[] me, int index, int length, IComparer<T> comparer)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			Array.Sort(me, index, length, comparer);

			return me;
		}



		/// <summary>
		///     Sorts a pair of array objects (the current that contains the keys and
		///     another that contains the corresponding items) based on the keys in the
		///     current array using the <see cref="IComparable{T}"/> generic interface
		///     implementation of each key.
		/// </summary>
		/// <typeparam name="TKey">
		///     The type of the elements of the current key array.
		/// </typeparam>
		/// <typeparam name="TValue">The type of the elements of the items array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="items">
		///     The one-dimensional array that contains the items that correspond to each
		///     of the keys in the current array, or null to only sort the current array.
		/// </param>
		/// <returns>The current array after it's sorted.</returns>
		public static TKey[] Sort<TKey, TValue>(this TKey[] me, TValue[] items)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			Array.Sort(me, items);

			return me;
		}



		/// <summary>
		///     Sorts a pair of array objects (the current that contains the keys and
		///     another that contains the corresponding items) based on the keys in the
		///     current array using the specified <see cref="IComparer{T}"/> generic interface.
		/// </summary>
		/// <typeparam name="TKey">
		///     The type of the elements of the current key array.
		/// </typeparam>
		/// <typeparam name="TValue">The type of the elements of the items array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="items">
		///     The one-dimensional array that contains the items that correspond to each
		///     of the keys in the current array, or null to only sort the current array.
		/// </param>
		/// <param name="comparer">
		///     The <see cref="IComparer{T}"/> generic interface implementation to use when
		///     comparing elements, or null to use the <see cref="IComparable{T}"/> generic
		///     interface implementation of each element.
		/// </param>
		/// <returns>The current array after it's sorted.</returns>
		public static TKey[] Sort<TKey, TValue>(this TKey[] me, TValue[] items, IComparer<TKey> comparer)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			Array.Sort(me, items, comparer);

			return me;
		}



		/// <summary>
		///     Sorts a range of elements in a pair of array objects (the current that
		///     contains the keys and another that contains the corresponding items) based
		///     on the keys in the current array using the <see cref="IComparable{T}"/>
		///     generic interface implementation of each key.
		/// </summary>
		/// <typeparam name="TKey">
		///     The type of the elements of the current key array.
		/// </typeparam>
		/// <typeparam name="TValue">The type of the elements of the items array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="items">
		///     The one-dimensional array that contains the items that correspond to each
		///     of the keys in the current array, or null to only sort the current array.
		/// </param>
		/// <param name="index">The starting index of the range to sort.</param>
		/// <param name="length">The number of elements in the range to sort.</param>
		/// <returns>The current array after it's sorted.</returns>
		public static TKey[] Sort<TKey, TValue>(TKey[] me, TValue[] items, int index, int length)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			Array.Sort(me, items, index, length);

			return me;
		}



		/// <summary>
		///     Sorts a range of elements in a pair of array objects (the current that
		///     contains the keys and another that contains the corresponding items) based
		///     on the keys in the current array using the specified
		///     <see cref="IComparer{T}"/> generic interface.
		/// </summary>
		/// <typeparam name="TKey">
		///     The type of the elements of the current key array.
		/// </typeparam>
		/// <typeparam name="TValue">The type of the elements of the items array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="items">
		///     The one-dimensional array that contains the items that correspond to each
		///     of the keys in the current array, or null to only sort the current array.
		/// </param>
		/// <param name="index">The starting index of the range to sort.</param>
		/// <param name="length">The number of elements in the range to sort.</param>
		/// <param name="comparer">
		///     The <see cref="IComparer{T}"/> generic interface implementation to use when
		///     comparing elements, or null to use the <see cref="IComparable{T}"/> generic
		///     interface implementation of each element.
		/// </param>
		/// <returns>The current array after it's sorted.</returns>
		public static TKey[] Sort<TKey, TValue>(TKey[] me, TValue[] items, int index, int length, IComparer<TKey> comparer)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			Array.Sort(me, items, index, length, comparer);

			return me;
		}

	}

}
