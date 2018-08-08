using System;


namespace PLib.Extensions.Core.GenericObject
{

	public static partial class GenericObjectExtensions
	{

		/// <summary>
		///     Determines whether the current
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me">The current object.</param>
		/// <param name="values"></param>
		/// <returns></returns>
		public static bool In<T>(this T me, params T[] values)
		{
			return Array.IndexOf(values, me) != -1;
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me">The current object.</param>
		/// <returns></returns>
		public static bool IsDefault<T>(this T me)
		{
			return me.Equals(default(T));
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me">The current object.</param>
		/// <returns></returns>
		public static bool IsNotNull<T>(this T me) where T : class
		{
			return me != null;
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me">The current object.</param>
		/// <returns></returns>
		public static bool IsNull<T>(this T me) where T : class
		{
			return me == null;
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me">The current object.</param>
		/// <param name="values"></param>
		/// <returns></returns>
		public static bool NotIn<T>(this T me, params T[] values)
		{
			return Array.IndexOf(values, me) == -1;
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me">The current object.</param>
		/// <param name="minValue">The minimum value.</param>
		/// <param name="maxValue">The maximum value.</param>
		/// <returns></returns>
		public static bool Between<T>(this T me, T minValue, T maxValue) where T : IComparable<T>
		{
			return me.CompareTo(minValue) >= 0 && me.CompareTo(maxValue) <= 0;
		}

	}

}
