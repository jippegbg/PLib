using System;
using System.Collections.Generic;
using System.Linq;


namespace PLib.Extensions.Core.GenericObject
{

	public static partial class GenericObjectExtensions
	{

		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me"></param>
		/// <param name="match"></param>
		/// <returns></returns>
		public static T NullIf<T>(this T me, Predicate<T> match) where T : class
		{
			if (match(me))
			{
				return null;
			}

			return me;
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static T NullIfEquals<T>(this T me, T value) where T : class
		{
			return me.NullIf(value.Equals);
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public static T NullIfEqualsAny<T>(this T me, IEnumerable<T> values) where T : class
		{
			return values.Contains(me) ? null : me;
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public static T NullIfEqualsAll<T>(this T me, IEnumerable<T> values) where T : class
		{
			return values.All(me.Equals) ? null : me;
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public static T NullIfEqualsNone<T>(this T me, IEnumerable<T> values) where T : class
		{
			return values.Contains(me) ? me : null;
		}

	}

}
