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
		/// <param name="this">The this.</param>
		/// <exception cref="ArgumentNullException">this</exception>
		/// TODO Edit XML Comment Template for Sort`1
		public static void Sort<T>([NotNull] this T[] @this)
		{
			if (@this == null)
			{
				throw new ArgumentNullException(nameof(@this));
			}

			Array.Sort(@this);
		}



		/// <summary>
		/// Sorts the specified comparer.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="this">The this.</param>
		/// <param name="comparer">The comparer.</param>
		/// <exception cref="ArgumentNullException">
		/// this
		/// -or-
		/// comparer
		/// </exception>
		/// TODO Edit XML Comment Template for Sort`1
		public static void Sort<T>([NotNull] this T[] @this, [NotNull] IComparer<T> comparer)
		{
			if (@this == null)
			{
				throw new ArgumentNullException(nameof(@this));
			}

			if (comparer == null)
			{
				throw new ArgumentNullException(nameof(comparer));
			}

			Array.Sort(@this, comparer);
		}



		/// <summary>
		/// Sorts the specified comparison.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="this">The this.</param>
		/// <param name="comparison">The comparison.</param>
		/// <exception cref="ArgumentNullException">
		/// this
		/// -or-
		/// comparison
		/// </exception>
		/// TODO Edit XML Comment Template for Sort`1
		public static void Sort<T>([NotNull] this T[] @this, [NotNull] Comparison<T> comparison)
		{
			if (@this == null)
			{
				throw new ArgumentNullException(nameof(@this));
			}

			if (comparison == null)
			{
				throw new ArgumentNullException(nameof(comparison));
			}

			Array.Sort(@this, comparison);
		}

	}

}
