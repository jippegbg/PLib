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
		///     in the current array.
		///     -or-
		///     <b>null</b> to sort only the current array.
		/// </param>
		public static void Sort(this Array me, Array items)
		{
			Array.Sort(me, items);
		}



		/// <summary>
		///     Sorts the elements in the current one-dimensional array using the specified <see cref="IComparer"/>.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="comparer">
		///     The implementation to use when comparing elements.
		///     -or-
		///     <b>null</b> to use the <see cref="IComparable"/> implementation of each element.
		/// </param>
		public static void Sort(this Array me, IComparer comparer)
		{
			Array.Sort(me, comparer);
		}



		/// <summary>
		///     Sorts a pair of one-dimensional array objects (the current that contains the keys and
		///     another that contains the corresponding items) based on the keys in the current array using the
		///     specified <see cref="IComparer"/>.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="items">
		///     The one-dimensional array that contains the items that correspond to each of the keys
		///     in the current array.
		///     -or-
		///     <b>null</b> to sort only the current array.
		/// </param>
		/// <param name="comparer">
		///     The implementation to use when comparing elements.
		///     -or-
		///     <b>null</b> to use the <see cref="IComparable"/> implementation of each element.
		/// </param>
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
		///     in the current array.
		///     -or-
		///     <b>null</b> to sort only the current array.
		/// </param>
		/// <param name="index">The starting index of the range to sort.</param>
		/// <param name="length">The number of elements in the range to sort.</param>
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
		///     -or-
		///     <b>null</b> to use the <see cref="IComparable"/> implementation of each element.
		/// </param>
		public static void Sort(this Array me, int index, int length, IComparer comparer)
		{
			Array.Sort(me, index, length, comparer);
		}



		/// <summary>
		/// Sorts a range of elements in a pair of one-dimensional Array objects (the current
		///     that contains the keys and another that contains the corresponding items) based on
		///     the keys in the current array using the specified <see cref="IComparer"/>.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="items">
		///     The one-dimensional array that contains the items that correspond to each of the keys
		///     in the current array.
		///     -or-
		///     <b>null</b> to sort only the current array.
		/// </param>
		/// <param name="index">The starting index of the range to sort.</param>
		/// <param name="length">The number of elements in the range to sort.</param>
		/// <param name="comparer">
		///     The implementation to use when comparing elements.
		///     -or-
		///     <b>null</b> to use the <see cref="IComparable"/> implementation of each element.
		/// </param>
		public static void Sort(this Array me, Array items, int index, int length, IComparer comparer)
		{
			Array.Sort(me, items, index, length, comparer);
		}

	}

}
