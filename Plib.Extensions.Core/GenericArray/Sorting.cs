using System;
using System.Collections.Generic;


namespace PLib.Extensions.Core
{

	public static partial class GenericArrayExtensions
	{

		/// <summary>
		/// Sorts the specified this.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The this.</param>
		/// <exception cref="ArgumentNullException">this</exception>
		/// TODO: Edit XML Comment
		public static void Sort<T>(this T[] me)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			Array.Sort(me);
		}



		/// <summary>
		/// Sorts the specified comparer.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The this.</param>
		/// <param name="comparer">The comparer.</param>
		/// <exception cref="ArgumentNullException">
		/// this
		/// -or-
		/// comparer
		/// </exception>
		/// TODO: Edit XML Comment
		public static void Sort<T>(this T[] me, IComparer<T> comparer)
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
		}



		/// <summary>
		/// Sorts the specified comparison.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The this.</param>
		/// <param name="comparison">The comparison.</param>
		/// <exception cref="ArgumentNullException">
		/// this
		/// -or-
		/// comparison
		/// </exception>
		/// TODO: Edit XML Comment
		public static void Sort<T>(this T[] me, Comparison<T> comparison)
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
		}

	}

}
