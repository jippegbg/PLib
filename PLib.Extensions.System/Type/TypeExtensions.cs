using System;
using System.Collections.Generic;
using System.Linq;


namespace PLib.Extensions.System
{

	/// <summary>
	///     TODO: Edit XML Comment
	/// </summary>
	public static partial class TypeExtensions
	{

		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">Me.</param>
		/// <returns>
		///     <c>true</c> if [is assignable to] [the specified me]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsAssignableTo<T>(this Type me)
		{
			return typeof(T).IsAssignableFrom(me);
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <param name="me">Me.</param>
		/// <param name="target">The target.</param>
		/// <returns>
		///     <c>true</c> if [is assignable to] [the specified target]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsAssignableTo(this Type me, Type target)
		{
			return target.IsAssignableFrom(me);
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <param name="me">Me.</param>
		/// <param name="targets">The targets.</param>
		/// <returns>
		///     <c>true</c> if [is assignable to any] [the specified targets]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsAssignableToAny(this Type me, IEnumerable<Type> targets)
		{
			return targets.Any(t => t.IsAssignableFrom(me));
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <param name="me">Me.</param>
		/// <param name="targets">The targets.</param>
		/// <returns>
		///     <c>true</c> if [is assignable to all] [the specified targets]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsAssignableToAll(this Type me, IEnumerable<Type> targets)
		{
			return targets.All(t => t.IsAssignableFrom(me));
		}

	}

}
