using System;
using System.Collections.Generic;
using System.Linq;


namespace PLib.Extensions.Core {

	public static partial class ObjectExtensions
	{

		/// <summary>
		///     Determines whether the current object can be assigned to an instance of a specified type.
		/// </summary>
		/// <typeparam name="T">The target type.</typeparam>
		/// <param name="me">The current object.</param>
		/// <returns>
		///     <see langword="true"/> if the current object can be assigned to an instance of the specified
		///     type <typeparamref name="T"/>; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool IsAssignableTo<T>(this object me)
		{
			return me.GetType().IsAssignableTo<T>();
		}



		/// <summary>
		///     Determines whether the current object can be assigned to an instance of a specified type.
		/// </summary>
		/// <param name="me">The current object.</param>
		/// <param name="target">The target type.</param>
		/// <returns>
		///     <see langword="true"/> if the object type can be assigned to an instance of the specified
		///     <paramref name="target"/> type; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool IsAssignableTo(this object me, Type target)
		{
			return me.GetType().IsAssignableTo(target);
		}



		/// <summary>
		///     Determines whether the current object can be assigned to an instance of at least one
		///     of the specified types.
		/// </summary>
		/// <param name="me">The current object.</param>
		/// <param name="targets">The target types.</param>
		/// <returns>
		///     <see langword="true"/> if the current object can be assigned to an instance of at least one of
		///     the specified target types; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool IsAssignableToAny(this object me, IEnumerable<Type> targets)
		{
			Type currentType = me.GetType();
			return targets.Any(tt => currentType.IsAssignableTo(tt));
		}



		/// <summary>
		///     Determines whether the current object can be assigned to an instance of all of the
		///     specified types.
		/// </summary>
		/// <param name="me">The current object.</param>
		/// <param name="targets">The target types.</param>
		/// <returns>
		///     <see langword="true"/> if the current object can be assigned to an instance of all of the
		///     specified target types; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool IsAssignableToAll(this object me, IEnumerable<Type> targets)
		{
			Type currentType = me.GetType();
			return targets.All(tt => currentType.IsAssignableTo(tt));
		}

	}

}