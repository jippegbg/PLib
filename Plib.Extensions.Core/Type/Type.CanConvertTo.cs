using System;
using System.ComponentModel;


namespace PLib.Extensions.Core {

	public static partial class TypeExtensions
	{

		/// <summary>
		///     Determines whether an object of the current type can be converted to a specified type.
		/// </summary>
		/// <typeparam name="T">The type to convert to.</typeparam>
		/// <param name="me">The current (source) type.</param>
		/// <returns>
		///     <see langword="true"/> if an object of the current type can be converted to type
		///     <typeparamref name="T"/>; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool CanConvertTo<T>(this Type me)
		{
			return TypeDescriptor.GetConverter(me).CanConvertTo<T>();
		}



		/// <summary>
		///     Determines whether an object of the current type can be converted to a specified type.
		/// </summary>
		/// <param name="me">The current (source) type.</param>
		/// <param name="targetType">The type to convert to.</param>
		/// <returns>
		///     <see langword="true"/> if an object of the current type can be converted to type
		///     <paramref name="targetType"/>; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool CanConvertTo(this Type me, Type targetType)
		{
			return TypeDescriptor.GetConverter(me).CanConvertTo(targetType);
		}

	}

}