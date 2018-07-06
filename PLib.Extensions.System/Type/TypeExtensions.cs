using System;
using System.Collections.Generic;
using System.Linq;


namespace PLib.Extensions.System
{

	/// <summary>
	/// 
	/// </summary>
	/// TODO Edit XML Comment Template for TypeExtensions
	public static partial class TypeExtensions
	{

		public static bool IsAssignableTo<T>(this Type me)
		{
			return typeof(T).IsAssignableFrom(me);
		}



		public static bool IsAssignableTo(this Type me, Type target)
		{
			return target.IsAssignableFrom(me);
		}



		public static bool IsAssignableToAny(this Type me, IEnumerable<Type> targets)
		{
			return targets.Any(t => t.IsAssignableFrom(me));
		}



		public static bool IsAssignableToAll(this Type me, IEnumerable<Type> targets)
		{
			return targets.All(t => t.IsAssignableFrom(me));
		}

	}

}
