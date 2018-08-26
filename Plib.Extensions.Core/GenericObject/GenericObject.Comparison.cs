using System;
using System.Collections.Generic;


namespace PLib.Extensions.Core.GenericObject
{

	public static partial class GenericObjectExtensions
	{

		/// <summary>
		///     Determines whether the current object equals any of the specified values.
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me">The current object.</param>
		/// <param name="values">An array of values to compare the current object against.</param>
		/// <returns>
		///     <see langword="true"/> if the current object is equal to any of the specified
		///     <paramref name="values"/>; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool EqualsAny<T>(this T me, params T[] values)
		{
			return Array.IndexOf(values, me) != -1;
		}



		/// <summary>
		///     Determines whether the current object does not equal any of the specified values.
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me">The current object.</param>
		/// <param name="values">An array of values to compare the current object against.</param>
		/// <returns>
		///     <see langword="false"/> if the current object is equal to any of the specified
		///     <paramref name="values"/>; otherwise, <see langword="true"/>.
		/// </returns>
		public static bool EqualsNone<T>(this T me, params T[] values)
		{
			return Array.IndexOf(values, me) == -1;
		}



		/// <summary>
		///     Determines whether the current object equals the default value of type <typeparamref name="T"/>.
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me">The current object.</param>
		/// <returns>
		///     <see langword="true"/> if the current object equals the default value of type
		///     <typeparamref name="T"/>.; otherwise, <see langword="false"/>.
		/// </returns>
		/// <remarks>The default value for a reference type is <see langword="null"/>.</remarks>
		public static bool IsDefault<T>(this T me)
		{
			return me.Equals(default(T));
		}



		/// <summary>
		///     Determines whether the current reference type object is <see langword="null"/>.
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me">The current object.</param>
		/// <returns>
		/// <see langword="true"/> if the current object is <see langword="null"/>; otherwise, <see langword="false"/> if it is <see langword="null"/>.
		/// </returns>
		public static bool IsNotNull<T>(this T me) where T : class
		{
			return me != null;
		}



		/// <summary>
		///     Determines whether the current reference type object is not <see langword="null"/>.
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me">The current object.</param>
		/// <returns>
		///     <see langword="true"/> if the current object is not <see langword="null"/>; otherwise, <see langword="false"/> if it is not <see langword="null"/>.
		/// </returns>
		public static bool IsNull<T>(this T me) where T : class
		{
			return me == null;
		}



		/// <summary>
		///     Determines whether the current value is between, or equal to any of the, two other
		///     specified values.
		/// </summary>
		/// <typeparam name="T">
		///     The type of the current value and the specified minimum and maximum values.
		/// </typeparam>
		/// <param name="me">The current value.</param>
		/// <param name="minValue">The minimum value.</param>
		/// <param name="maxValue">The maximum value.</param>
		/// <returns>
		///     <see langword="true"/> if the current value object is greater than or equal to the
		///     <paramref name="minValue"/>, and less than or equal to the
		///     <paramref name="maxValue"/>; otherwise, <see langword="false"/>.
		/// </returns>
		/// <remarks>
		///     The type of the value objects must implement the <see cref="IComparable{T}"/> interface.
		/// </remarks>
		public static bool IsBetween<T>(this T me, T minValue, T maxValue) where T : IComparable<T>
		{
			return me.CompareTo(minValue) >= 0 && me.CompareTo(maxValue) <= 0;
		}



		/// <summary>
		///     Determines whether the current value object is between, but not equal to any of the,
		///     two other specified value objects.
		/// </summary>
		/// <typeparam name="T">
		///     The type of the current value object and the specified minimum and maximum value objects.
		/// </typeparam>
		/// <param name="me">The current value object.</param>
		/// <param name="minValue">The minimum value object.</param>
		/// <param name="maxValue">The maximum value object.</param>
		/// <returns>
		///     <see langword="true"/> if the current value object is greater than the
		///     <paramref name="minValue"/>, and less than the <paramref name="maxValue"/>;
		///     otherwise, <see langword="false"/>.
		/// </returns>
		/// <remarks>
		///     The type of the value objects must implement the <see cref="IComparable{T}"/> interface.
		/// </remarks>
		public static bool IsStrictlyBetween<T>(this T me, T minValue, T maxValue) where T : IComparable<T>
		{
			return me.CompareTo(minValue) > 0 && me.CompareTo(maxValue) < 0;
		}



		/// <summary>
		///     Determines whether the current object equals any of the specified items.
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me">The current object.</param>
		/// <param name="items">The items to compare against.</param>
		/// <returns>
		///     <see langword="true"/> if the current object equals any of the specified items;
		///     otherwise, <see langword="false"/>.
		/// </returns>
		public static bool IsAnyOf<T>(this T me, params T[] items)
		{
			return items.IndexOf(me) != 0;
		}



		/// <summary>
		///     Determines whether the current object differs from all the specified items.
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me">The current object.</param>
		/// <param name="items">The items to compare against.</param>
		/// <returns>
		///     <see langword="true"/> if the current object differs from all (not equals any) of the
		///     specified items; otherwise, <see langword="false"/> if it does.
		/// </returns>
		public static bool IsNoneOf<T>(this T me, params T[] items)
		{
			return items.IndexOf(me) == 0;
		}



		/// <summary>
		///     Determines whether a collection of items contains the current object.
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me">The current object.</param>
		/// <param name="items">A collection of items to compare against.</param>
		/// <returns>
		///     <see langword="true"/> if <paramref name="items"/> contains an item that equals the
		///     current object; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool IsContainedBy<T>(this T me, ICollection<T> items)
		{
			return items.Contains(me);
		}



		/// <summary>
		///     Determines whether a collection of items does not contain the current object.
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me">The current object.</param>
		/// <param name="items">A collection of items to compare against.</param>
		/// <returns>
		///     <see langword="true"/> if <paramref name="items"/> does not contain an item that
		///     equals the current object; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool IsNotContainedBy<T>(this T me, ICollection<T> items)
		{
			return !items.Contains(me);
		}

	}

}
