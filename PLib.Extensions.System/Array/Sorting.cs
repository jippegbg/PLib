using System;
using System.Collections.Generic;

using JetBrains.Annotations;


namespace PLib.Extensions.System
{

	public static partial class ArrayExtensions
	{

		/// <summary>
		/// Sorts the specified this.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The this.</param>
		/// <exception cref="ArgumentNullException">this</exception>
		/// TODO Edit XML Comment Template for Sort`1
		public static void Sort<T>([NotNull] this T[] me)
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
		/// TODO Edit XML Comment Template for Sort`1
		public static void Sort<T>([NotNull] this T[] me, [NotNull] IComparer<T> comparer)
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
		/// TODO Edit XML Comment Template for Sort`1
		public static void Sort<T>([NotNull] this T[] me, [NotNull] Comparison<T> comparison)
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
