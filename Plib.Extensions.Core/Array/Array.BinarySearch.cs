using System;
using System.Collections;


namespace PLib.Extensions.Core
{

	public static partial class ArrayExtensions
	{

		/// <summary>
		///     Searches the current one-dimensional sorted array for a specific element, using the
		///     <see cref="IComparable"/> interface implemented by each element of the array and by
		///     the specified object.
		/// </summary>
		/// <param name="me">The current one-dimensional sorted array.</param>
		/// <param name="value">The object to search for.</param>
		/// <returns>
		///     The index of the specified value in the specified array, if value is found;
		///     otherwise, a negative number. If value is not found and value is less than one or
		///     more elements in array, the negative number returned is the bitwise complement of the
		///     index of the first element that is larger than value. If value is not found and value
		///     is greater than all elements in array, the negative number returned is the bitwise
		///     complement of (the index of the last element plus 1). If this method is called with a
		///     non-sorted array, the return value can be incorrect and a negative number could be
		///     returned, even if value is present in array.
		/// </returns>
		/// <exception cref="RankException">the current array is multidimensional.</exception>
		/// <exception cref="ArgumentNullException">the current array is null.</exception>
		/// <exception cref="ArgumentException">
		///     <paramref name="value"/> is of a type that is not compatible with the elements of the
		///     current array.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		///     <paramref name="value"/> does not implement the <see cref="IComparable"/> interface,
		///     and the search encounters an element that does not implement the
		///     <see cref="IComparable"/> interface.
		/// </exception>
		public static int BinarySearch(this Array me, object value)
		{
			return Array.BinarySearch(me, value);
		}



		/// <summary>
		///     Searches the current one-dimensional sorted array for a value using the specified
		///     <see cref="IComparer"/> interface.
		/// </summary>
		/// <param name="me">The current one-dimensional sorted array.</param>
		/// <param name="value">The object to search for.</param>
		/// <param name="comparer">
		///     The IComparer implementation to use when comparing elements.
		///     <para/>-or-<para/> <see langword="null"/> to use the <see cref="IComparable"/> implementation of
		///     each element.
		/// </param>
		/// <returns>
		///     The index of the specified value in the specified array, if value is found;
		///     otherwise, a negative number. If value is not found and value is less than one or
		///     more elements in array, the negative number returned is the bitwise complement of the
		///     index of the first element that is larger than value. If value is not found and value
		///     is greater than all elements in array, the negative number returned is the bitwise
		///     complement of (the index of the last element plus 1). If this method is called with a
		///     non-sorted array, the return value can be incorrect and a negative number could be
		///     returned, even if value is present in array.
		/// </returns>
		/// <exception cref="ArgumentNullException">the current array is null.</exception>
		/// <exception cref="ArgumentException">
		///     <paramref name="comparer"/> is null, and <paramref name="value"/> is of a type that
		///     is not compatible with the elements of the current array.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		///     <paramref name="comparer"/> is null, <paramref name="value"/> does not implement the
		///     <see cref="IComparable"/> interface, and the search encounters an element that does
		///     not implement the <see cref="IComparable"/> interface.
		/// </exception>
		/// <exception cref="RankException">the current array is multidimensional.</exception>
		public static int BinarySearch(this Array me, object value, IComparer comparer)
		{
			return Array.BinarySearch(me, value, comparer);
		}



		/// <summary>
		///     Searches a range of elements in a one-dimensional sorted array for a value, using the
		///     <see cref="IComparable"/> interface implemented by each element of the array and by
		///     the specified value.
		/// </summary>
		/// <param name="me">The current one-dimensional sorted array.</param>
		/// <param name="index">The starting index of the range to search.</param>
		/// <param name="length">The length of the range to search.</param>
		/// <param name="value">The object to search for.</param>
		/// <returns>
		///     The index of the specified value in the specified array, if value is found;
		///     otherwise, a negative number. If value is not found and value is less than one or
		///     more elements in array, the negative number returned is the bitwise complement of the
		///     index of the first element that is larger than value. If value is not found and value
		///     is greater than all elements in array, the negative number returned is the bitwise
		///     complement of (the index of the last element plus 1). If this method is called with a
		///     non-sorted array, the return value can be incorrect and a negative number could be
		///     returned, even if value is present in array.
		/// </returns>
		/// <exception cref="RankException">the current array is multidimensional.</exception>
		/// <exception cref="ArgumentNullException">the current array is null.</exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     <paramref name="index"/> is less than the lower bound of the current array.<para/>-or-<para/>
		///     <paramref name="length"/> is less than zero.
		/// </exception>
		/// <exception cref="ArgumentException">
		///     <paramref name="index"/> and <paramref name="length"/> do not specify a valid range
		///     in the current array.<para/>-or-<para/> <paramref name="value"/> is of a type that is not
		///     compatible with the elements of the current array.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		///     <paramref name="value"/> does not implement the <see cref="IComparable"/> interface,
		///     and the search encounters an element that does not implement the
		///     <see cref="IComparable"/> interface.
		/// </exception>
		public static int BinarySearch(this Array me, int index, int length, object value)
		{
			return Array.BinarySearch(me, index, length, value);
		}



		/// <summary>
		///     Searches a range of the current one-dimensional sorted array for a value, using the
		///     specified <see cref="IComparer"/> interface.
		/// </summary>
		/// <param name="me">The current one-dimensional sorted array.</param>
		/// <param name="index">The starting index of the range to search.</param>
		/// <param name="length">The length of the range to search.</param>
		/// <param name="value">The object to search for.</param>
		/// <param name="comparer">
		///     The IComparer implementation to use when comparing elements.
		///     <para/>-or-<para/> <see langword="null"/> to use the <see cref="IComparable"/> implementation of
		///     each element.
		/// </param>
		/// <returns>
		///     The index of the specified value in the specified array, if value is found;
		///     otherwise, a negative number. If value is not found and value is less than one or
		///     more elements in array, the negative number returned is the bitwise complement of the
		///     index of the first element that is larger than value. If value is not found and value
		///     is greater than all elements in array, the negative number returned is the bitwise
		///     complement of (the index of the last element plus 1). If this method is called with a
		///     non-sorted array, the return value can be incorrect and a negative number could be
		///     returned, even if value is present in array.
		/// </returns>
		/// <exception cref="ArgumentNullException">the current array is null.</exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     <paramref name="index"/> is less than the lower bound of the current array.<para/>-or-<para/>
		///     <paramref name="length"/> is less than zero.
		/// </exception>
		/// <exception cref="ArgumentException">
		///     <paramref name="index"/> and <paramref name="length"/> do not specify a valid range
		///     in the current array.<para/>-or-<para/> <paramref name="comparer"/> is null, and
		///     <paramref name="value"/> is of a type that is not compatible with the elements of the
		///     current array.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		///     <paramref name="comparer"/> is null, <paramref name="value"/> does not implement the
		///     <see cref="IComparable"/> interface, and the search encounters an element that does
		///     not implement the <see cref="IComparable"/> interface.
		/// </exception>
		/// <exception cref="RankException">the current array is multidimensional.</exception>
		public static int BinarySearch(this Array me, int index, int length, object value, IComparer comparer)
		{
			return Array.BinarySearch(me, index, length, value, comparer);
		}

	}

}
