using System;
using System.Collections.Generic;
using System.Linq;


namespace PLib.Extensions.Core
{

	/// <summary>
	///     Extensions of the <see cref="Type"/> class.
	/// </summary>
	public static class TypeExtensions
	{

		/// <summary>
		///     Determines whether an instance of the current type can be assigned to an instance of
		///     a specified type.
		/// </summary>
		/// <typeparam name="T">The target type.</typeparam>
		/// <param name="me">The current type.</param>
		/// <returns>
		///     <c>true</c> if an instance of the current type can be assigned to an instance of the
		///     specified type <typeparamref name="T"/>; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsAssignableTo<T>(this Type me)
		{
			return typeof(T).IsAssignableFrom(me);
		}



		/// <summary>
		///     Determines whether an instance of the current type can be assigned to an instance of
		///     a specified type.
		/// </summary>
		/// <param name="me">The current type.</param>
		/// <param name="target">The target type.</param>
		/// <returns>
		///     <c>true</c> if an instance of the current type can be assigned to an instance of the
		///     specified <paramref name="target"/> type; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsAssignableTo(this Type me, Type target)
		{
			return target.IsAssignableFrom(me);
		}



		/// <summary>
		///     Determines whether an instance of the current type can be assigned to an instance of
		///     at least one of the specified types.
		/// </summary>
		/// <param name="me">The current type.</param>
		/// <param name="targets">The target types.</param>
		/// <returns>
		///     <c>true</c> if an instance of the current type can be assigned to an instance of at least one of the
		///     specified target types; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsAssignableToAny(this Type me, IEnumerable<Type> targets)
		{
			return targets.Any(t => t.IsAssignableFrom(me));
		}



		/// <summary>
		///     Determines whether an instance of the current type can be assigned to an instance of
		///     all of the specified types.
		/// </summary>
		/// <param name="me">The current type.</param>
		/// <param name="targets">The target types.</param>
		/// <returns>
		///     <c>true</c> if an instance of the current type can be assigned to an instance of all of the
		///     specified target types; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsAssignableToAll(this Type me, IEnumerable<Type> targets)
		{
			return targets.All(t => t.IsAssignableFrom(me));
		}

	}

}
