using System;
using System.Collections;


namespace PLib.Extensions.Core
{

	public static partial class ArrayExtensions
	{

		/// <summary>
		///     Sorts all the elements in the current one-dimensional Array using the
		///     <see cref="IComparable"/> implementation of each element of the array.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <exception cref="ArgumentNullException">the current array is null.</exception>
		/// <exception cref="InvalidOperationException">
		///     One or more elements in the current array do not implement the
		///     <see cref="IComparable"/> interface.
		/// </exception>
		/// <exception cref="RankException">the current array is multidimensional.</exception>
		public static void Sort(this Array me)
		{
			Array.Sort(me);
		}



		/// <summary>
		///     Sorts a pair of one-dimensional array objects (the current that contains the keys and
		///     another that contains the corresponding items) based on the keys in the current array
		///     using the <see cref="IComparable"/> implementation of each key.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="items">
		///     The one-dimensional array that contains the items that correspond to each of the keys
		///     in the current array.<para/>
		///     -or-<para/>
		///     <see langword="null"/> to sort only the current array.
		/// </param>
		/// <exception cref="ArgumentNullException">the current array is null.</exception>
		/// <exception cref="ArgumentException">
		///     the <paramref name="items"/> array is not null, and the length of the current key array is greater
		///     than the length of the <paramref name="items"/> array.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		///     One or more elements in the the current key array do not
		///     implement the <see cref="IComparable"/> interface.
		/// </exception>
		/// <exception cref="RankException">
		///     The the current key array is multidimensional.<para/>
		///     -or-<para/>
		///     The <paramref name="items"/> array is multidimensional.
		/// </exception>
		public static void Sort(this Array me, Array items)
		{
			Array.Sort(me, items);
		}



		/// <summary>
		///     Sorts the elements in the current one-dimensional array using the specified <see cref="IComparer"/>.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="comparer">
		///     The implementation to use when comparing elements.<para/>
		///     -or-<para/>
		///     <see langword="null"/> to use the <see cref="IComparable"/> implementation of
		///      each element.
		/// </param>
		/// <exception cref="ArgumentNullException">the current array is null.</exception>
		/// <exception cref="InvalidOperationException">
		///     <paramref name="comparer"/> is null, and one or more elements in
		///     the current array do not implement the <see cref="IComparable"/> interface.
		/// </exception>
		/// <exception cref="ArgumentException">
		///     The implementation of <paramref name="comparer"/> caused an error during the sort.
		///     For example, <paramref name="comparer"/> might not return 0 when comparing an item
		///     with itself.
		/// </exception>
		/// <exception cref="RankException">the current array is multidimensional.</exception>
		public static void Sort(this Array me, IComparer comparer)
		{
			Array.Sort(me, comparer);
		}



		/// <summary>
		///     Sorts a pair of one-dimensional array objects (the current that contains the keys and
		///     another that contains the corresponding items) based on the keys in the current array
		///     using the specified <see cref="IComparer"/>.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="items">
		///     The one-dimensional array that contains the items that correspond to each of the keys
		///     in the current array.<para/>
		///     -or-<para/>
		///     <see langword="null"/> to sort only the current array.
		/// </param>
		/// <param name="comparer">
		///     The implementation to use when comparing elements.<para/>
		///     -or-<para/>
		///     <see langword="null"/> to use the <see cref="IComparable"/> implementation of each element.
		/// </param>
		/// <exception cref="ArgumentNullException">the current key array is null.</exception>
		/// <exception cref="ArgumentException">
		///     The <paramref name="items"/> array is not null, and the length of the current key array is
		///     greater than the length of the <paramref name="items"/> array.<para/>
		///     -or-<para/>
		///     The implementation of <paramref name="comparer"/> caused an error during the sort.
		///     For example, <paramref name="comparer"/> might not return 0 when comparing an item with itself.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		///     <paramref name="comparer"/> is null, and one or more elements in the
		///     the current key array do not implement the <see cref="IComparable"/> interface.
		/// </exception>
		/// <exception cref="RankException">
		///     The the current key array is multidimensional.<para/>
		///     -or-<para/>
		///     The <paramref name="items"/> array is multidimensional.
		/// </exception>
		public static void Sort(this Array me, Array items, IComparer comparer)
		{
			Array.Sort(me, items, comparer);
		}



		/// <summary>
		///     Sorts the elements in a range of elements in the current one-dimensional array using
		///     the <see cref="IComparable"/> implementation of each element of the Array.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="index">The starting index of the range to sort.</param>
		/// <param name="length">The number of elements in the range to sort.</param>
		/// <exception cref="ArgumentNullException">the current array is null.</exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     <paramref name="index"/> is less than the lower bound of
		///     the current array.<para/>
		///     -or-<para/>
		///     <paramref name="length"/> is less than zero.
		/// </exception>
		/// <exception cref="ArgumentException">
		///     <paramref name="index"/> and <paramref name="length"/> do not specify a valid range
		///     in the current array.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		///     One or more elements in the current array do not implement the
		///     <see cref="IComparable"/> interface.
		/// </exception>
		/// <exception cref="RankException">the current array is multidimensional.</exception>
		public static void Sort(this Array me, int index, int length)
		{
			Array.Sort(me, index, length);
		}



		/// <summary>
		///     Sorts a range of elements in a pair of one-dimensional Array objects (the current
		///     that contains the keys and another that contains the corresponding items) based on
		///     the keys in the current array using the <see cref="IComparable"/> implementation of
		///     each key.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="items">
		///     The one-dimensional array that contains the items that correspond to each of the keys
		///     in the current array.<para/>
		///     -or-<para/>
		///     <see langword="null"/> to sort only the current array.
		/// </param>
		/// <param name="index">The starting index of the range to sort.</param>
		/// <param name="length">The number of elements in the range to sort.</param>
		/// <exception cref="ArgumentNullException">the current key array is null.</exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     <paramref name="index"/> is less than the lower bound of the current key array.<para/>
		///     -or-<para/>
		///     <paramref name="length"/> is less than zero.
		/// </exception>
		/// <exception cref="ArgumentException">
		///     The <paramref name="items"/> array is not null, and the length of the current key array is
		///     greater than the length of <paramref name="items"/> array.<para/>
		///     -or-<para/>
		///     <paramref name="index"/> and <paramref name="length"/> do not specify a valid range
		///     in the the current key array.<para/>
		///     -or-<para/>
		///     <paramref name="items"/> array is not null, and
		///     <paramref name="index"/> and <paramref name="length"/> do not specify a
		///     valid range in the <paramref name="items"/> array.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		///     One or more elements in the the current key array do
		///     not implement the <see cref="IComparable"/> interface.
		/// </exception>
		/// <exception cref="RankException">
		///     The the current key array is multidimensional.<para/>
		///     -or-<para/>
		///     The <paramref name="items"/> array is multidimensional.
		/// </exception>
		public static void Sort(this Array me, Array items, int index, int length)
		{
			Array.Sort(me, items, index, length);
		}



		/// <summary>
		///     Sorts the elements in a range of elements in the current one-dimensional array using
		///     the specified <see cref="IComparer"/>.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="index">The starting index of the range to sort.</param>
		/// <param name="length">The number of elements in the range to sort.</param>
		/// <param name="comparer">
		///     The implementation to use when comparing elements.
		///     <para/>
		///     -or-
		///     <para/>
		///     <see langword="null"/> to use the <see cref="IComparable"/> implementation of each element.
		/// </param>
		/// <exception cref="ArgumentNullException">the current array is null.</exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     <paramref name="index"/> is less than the lower bound of the current array.
		///     <para/>
		///     -or-
		///     <para/>
		///     <paramref name="length"/> is less than zero.
		/// </exception>
		/// <exception cref="ArgumentException">
		///     <paramref name="index"/> and <paramref name="length"/> do not specify a valid range
		///     in the current array.
		///     <para/>
		///     -or-
		///     <para/>
		///     The implementation of <paramref name="comparer"/> caused an error during the sort.
		///     For example, <paramref name="comparer"/> might not return 0 when comparing an item
		///     with itself.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		///     <paramref name="comparer"/> is null, and one or more elements in the current array do
		///     not implement the <see cref="IComparable"/> interface.
		/// </exception>
		/// <exception cref="RankException">the current array is multidimensional.</exception>
		public static void Sort(this Array me, int index, int length, IComparer comparer)
		{
			Array.Sort(me, index, length, comparer);
		}



		/// <summary>
		///     Sorts a range of elements in a pair of one-dimensional Array objects (the current
		///     that contains the keys and another that contains the corresponding items) based on
		///     the keys in the current array using the specified <see cref="IComparer"/>.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="items">
		///     The one-dimensional array that contains the items that correspond to each of the keys
		///     in the current array.
		///     <para/>
		///     -or-
		///     <para/>
		///     <see langword="null"/> to sort only the current array.
		/// </param>
		/// <param name="index">The starting index of the range to sort.</param>
		/// <param name="length">The number of elements in the range to sort.</param>
		/// <param name="comparer">
		///     The implementation to use when comparing elements.
		///     <para/>
		///     -or-
		///     <para/>
		///     <see langword="null"/> to use the <see cref="IComparable"/> implementation of each element.
		/// </param>
		/// <exception cref="ArgumentNullException">the current key array is null.</exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     <paramref name="index"/> is less than the lower bound of the current key array.
		///     <para/>
		///     -or-
		///     <para/>
		///     <paramref name="length"/> is less than zero.
		/// </exception>
		/// <exception cref="ArgumentException">
		///     The <paramref name="items"/> array is not null, and the lower bound of the current key array
		///     does not match the lower bound of the <paramref name="items"/> array.
		///     <para/>
		///     -or-
		///     <para/>
		///     The <paramref name="items"/> array is not null, and the length of the current key array is
		///     greater than the length of the <paramref name="items"/> array.
		///     <para/>
		///     -or-
		///     <para/>
		///     <paramref name="index"/> and <paramref name="length"/> do not specify a valid range
		///     in the the current key array.
		///     <para/>
		///     -or-
		///     <para/>
		///     The <paramref name="items"/> array is not null, and <paramref name="index"/> and
		///     <paramref name="length"/> do not specify a valid range in the <paramref name="items"/> array.
		///     <para/>
		///     -or-
		///     <para/>
		///     The implementation of <paramref name="comparer"/> caused an error during the sort.
		///     For example, <paramref name="comparer"/> might not return 0 when comparing an item
		///     with itself.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		///     <paramref name="comparer"/> is null, and one or more elements in the the current key
		///     array do not implement the <see cref="IComparable"/> interface.
		/// </exception>
		/// <exception cref="RankException">
		///     The the current key array is multidimensional.
		///     <para/>
		///     -or-
		///     <para/>
		///     The <paramref name="items"/> array is multidimensional.
		/// </exception>
		public static void Sort(this Array me, Array items, int index, int length, IComparer comparer)
		{
			Array.Sort(me, items, index, length, comparer);
		}

	}

}
