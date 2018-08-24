using System;


namespace PLib.Extensions.Core
{

	public static partial class ObjectExtensions
	{

		/// <summary>
		///     Determines if an object can be converted to a specified type.
		/// </summary>
		/// <typeparam name="T">The target type to convert to.</typeparam>
		/// <param name="me">The current object.</param>
		/// <returns></returns>
		public static bool CanConvertTo<T>(this object me)
		{
			return me.CanConvertTo(typeof(T));
		}



		/// <summary>
		///     Determines if an object can be converted to a specified type.
		/// </summary>
		/// <param name="me">The current object.</param>
		/// <param name="targetType">The target type to convert to.</param>
		/// <returns></returns>
		public static bool CanConvertTo(this object me, Type targetType)
		{
			if (me == null)
			{
				return false;
			}

			Type sourceType = me.GetType();

			return sourceType.CanConvertTo(targetType) || targetType.CanConvertFrom(sourceType);

			//return TypeDescriptor.GetConverter(sourceType).CanConvertTo(targetType) ||
			//       TypeDescriptor.GetConverter(targetType).CanConvertFrom(sourceType);
		}

	}

}