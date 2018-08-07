using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace PLib.Extensions.Core
{

	/// <summary>
	///     Extensions of the <see cref="Object"/> class.
	/// </summary>
	public static class ObjectExtensions
	{

		/// <summary>
		///     Returns the current object casted to a specified type.
		/// </summary>
		/// <typeparam name="T">The target type to cast to.</typeparam>
		/// <param name="me">The current object.</param>
		/// <returns>The current object casted to the specified type.</returns>
		/// <exception cref="InvalidCastException">
		///     if the current object could not be casted to the specified type.
		/// </exception>
		public static T As<T>(this object me)
		{
			return (T)me;
		}



		/// <summary>
		///     Returns the current object casted to a specified type, or if not possible, the
		///     default value of the target type.
		/// </summary>
		/// <typeparam name="T">The target type to cast to.</typeparam>
		/// <param name="me">The current object.</param>
		/// <returns>
		///     the current object casted to the specified type, or if not possible, the default
		///     value of the target type.
		/// </returns>
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
		///     Returns the current object casted to a specified type, or if not possible, the
		///     specified default value.
		/// </summary>
		/// <typeparam name="T">The target type to cast to.</typeparam>
		/// <param name="me">The current object.</param>
		/// <param name="defaultValue">The default value to return if the cast is not possible.</param>
		/// <returns>
		///     The current object casted to the specified type, or if not possible, the specified
		///     default value.
		/// </returns>
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
		///     Returns the current object casted to a specified type, or if not possible, the value
		///     returned by a specified function.
		/// </summary>
		/// <typeparam name="T">The target type to cast to.</typeparam>
		/// <param name="me">The current object.</param>
		/// <param name="defaultValueFactory">
		///     A function to create a value to return if the cast operation is not possible.
		/// </param>
		/// <returns>
		///     The current object casted to the specified type, or if not possible, the value
		///     returned by the specified function.
		/// </returns>
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
		///     Returns the current object casted to a specified type, or if not possible, the value
		///     returned by a specified function.
		/// </summary>
		/// <typeparam name="T">The target type to cast to.</typeparam>
		/// <param name="me">The current object.</param>
		/// <param name="defaultValueFactory">
		///     A function to create a value to return if the cast operation is not possible. The
		///     function will be provided the current object as in-parameter.
		/// </param>
		/// <returns>
		///     The current object casted to the specified type, or if not possible, the value
		///     returned by the specified function.
		/// </returns>
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
		///     Converts the current object into a specified target type.
		/// </summary>
		/// <typeparam name="T">The target type to convert to.</typeparam>
		/// <param name="me">The current object.</param>
		/// <returns>
		///     The the current object as is if; it's null, already is of the target type, or cannot
		///     be converted. Else the current object converted to the target type.
		/// </returns>
		/// <remarks>Note that this is a conversion and not a cast operation.</remarks>
		public static T ConvertTo<T>(this object me)
		{
			return (T)me.ConvertTo(typeof(T));
		}



		/// <summary>
		///     Converts the current object into a specified target type.
		/// </summary>
		/// <param name="me">The current object.</param>
		/// <param name="targetType">The target type to convert to.</param>
		/// <returns>
		///     The the current object as is if; it's null, already is of the target type, or cannot
		///     be converted. Else the current object converted to the target type.
		/// </returns>
		/// <remarks>Note that this is a conversion and not a cast operation.</remarks>
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
		///     Determines whether the current object can be assigned to an instance of a specified type.
		/// </summary>
		/// <typeparam name="T">The target type.</typeparam>
		/// <param name="me">The current object.</param>
		/// <returns>
		///     <b>true</b> if the current object can be assigned to an instance of the specified
		///     type <typeparamref name="T"/>; otherwise, <b>false</b>.
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
		///     <b>true</b> if the object type can be assigned to an instance of the specified
		///     <paramref name="target"/> type; otherwise, <b>false</b>.
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
		///     <b>true</b> if the current object can be assigned to an instance of at least one of
		///     the specified target types; otherwise, <b>false</b>.
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
		///     <b>true</b> if the current object can be assigned to an instance of all of the
		///     specified target types; otherwise, <b>false</b>.
		/// </returns>
		public static bool IsAssignableToAll(this object me, IEnumerable<Type> targets)
		{
			Type currentType = me.GetType();
			return targets.All(tt => currentType.IsAssignableTo(tt));
		}

	}

}
