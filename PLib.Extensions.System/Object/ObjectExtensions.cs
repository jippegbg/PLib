using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;


namespace PLib.Extensions.System
{

	/// <summary>
	/// 
	/// </summary>
	/// TODO Edit XML Comment Template for ObjectExtensions
	public static partial class ObjectExtensions
	{

		public static T As<T>(this object me)
		{
			return (T)me;
		}



		public static T AsOrDefault<T>(this object me)
		{
			try
			{
				return (T)me;
			}
			catch (Exception)
			{
				return default(T);
			}
		}



		public static T AsOrDefault<T>(this object me, T defaultValue)
		{
			try
			{
				return (T)me;
			}
			catch (Exception)
			{
				return defaultValue;
			}
		}



		public static T AsOrDefault<T>(this object me, Func<T> defaultValueFactory)
		{
			try
			{
				return (T)me;
			}
			catch (Exception)
			{
				return defaultValueFactory();
			}
		}



		public static T AsOrDefault<T>(this object me, Func<object, T> defaultValueFactory)
		{
			try
			{
				return (T)me;
			}
			catch (Exception)
			{
				return defaultValueFactory(me);
			}
		}



		public static bool IsAssignableTo<T>(this object me)
		{
			return me.GetType().IsAssignableTo<T>();
		}



		public static bool IsAssignableTo(this object me, Type targetType)
		{
			return me.GetType().IsAssignableTo(targetType);
		}



		public static bool IsAssignableToAny(this object me, IEnumerable<Type> targetTypes)
		{
			Type currentType = me.GetType();
			return targetTypes.Any(tt => currentType.IsAssignableTo(tt));
		}



		public static bool IsAssignableToAll(this object me, IEnumerable<Type> targetTypes)
		{
			Type currentType = me.GetType();
			return targetTypes.All(tt => currentType.IsAssignableTo(tt));
		}

	}

}
