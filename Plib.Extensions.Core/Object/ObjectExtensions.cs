using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace PLib.Extensions.Core
{

	/// <summary>
	///     Extensions of the <see cref="Object"/> class.
	/// </summary>
	public static class ObjectExtensions
	{

		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me"></param>
		/// <returns></returns>
		public static T As<T>(this object me)
		{
			return (T)me;
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me"></param>
		/// <returns></returns>
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



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
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



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me"></param>
		/// <param name="defaultValueFactory"></param>
		/// <returns></returns>
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



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me"></param>
		/// <param name="defaultValueFactory"></param>
		/// <returns></returns>
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



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me"></param>
		/// <returns></returns>
		public static T ConvertTo<T>(this object me)
		{
			return (T)me.ConvertTo(typeof(T));
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <param name="me"></param>
		/// <param name="targetType"></param>
		/// <returns></returns>
		public static object ConvertTo(this object me, Type targetType)
		{
			if (me == null || me.GetType() == targetType)
			{
				return me;
			}

			TypeConverter toConverter = TypeDescriptor.GetConverter(me);
			if (toConverter.CanConvertTo(targetType))
			{
				return toConverter.ConvertTo(me, targetType);
			}

			TypeConverter fromConverter = TypeDescriptor.GetConverter(targetType);
			if (fromConverter.CanConvertFrom(me.GetType()))
			{
				return fromConverter.ConvertFrom(me);
			}

			if (me == DBNull.Value)
			{
				return null;
			}

			return me;
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me"></param>
		/// <returns></returns>
		public static bool IsAssignableTo<T>(this object me)
		{
			return me.GetType().IsAssignableTo<T>();
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <param name="me"></param>
		/// <param name="targetType"></param>
		/// <returns></returns>
		public static bool IsAssignableTo(this object me, Type targetType)
		{
			return me.GetType().IsAssignableTo(targetType);
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <param name="me"></param>
		/// <param name="targetTypes"></param>
		/// <returns></returns>
		public static bool IsAssignableToAny(this object me, IEnumerable<Type> targetTypes)
		{
			Type currentType = me.GetType();
			return targetTypes.Any(tt => currentType.IsAssignableTo(tt));
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <param name="me"></param>
		/// <param name="targetTypes"></param>
		/// <returns></returns>
		public static bool IsAssignableToAll(this object me, IEnumerable<Type> targetTypes)
		{
			Type currentType = me.GetType();
			return targetTypes.All(tt => currentType.IsAssignableTo(tt));
		}

	}

}
