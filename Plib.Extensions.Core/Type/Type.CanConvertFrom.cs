using System;
using System.ComponentModel;


namespace PLib.Extensions.Core {

	public static partial class TypeExtensions
	{

		/// <summary>
		///     Determines whether an object of a specified type can be converted to the current type.
		/// </summary>
		/// <typeparam name="T">The type to convert from.</typeparam>
		/// <param name="me">The current (target) type.</param>
		/// <returns>
		///     <see langword="true"/> if an object of type <typeparamref name="T"/> can be converted
		///     to the current type; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool CanConvertFrom<T>(this Type me)
		{
			return me.CanConvertFrom(typeof(T));
		}



		/// <summary>
		///     Determines whether an object of a specified type can be converted to the current type.
		/// </summary>
		/// <param name="me">The current (target) type.</param>
		/// <param name="sourceType">The type to convert from.</param>
		/// <returns>
		///     <see langword="true"/> if an object of type <paramref name="sourceType"/> can be
		///     converted to the current type; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool CanConvertFrom(this Type me, Type sourceType)
		{
			return TypeDescriptor.GetConverter(me).CanConvertFrom(sourceType);
		}

	}

}