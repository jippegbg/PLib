using System;
using System.ComponentModel;


namespace PLib.Extensions.Core {

	public static partial class ObjectExtensions
	{

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

	}

}