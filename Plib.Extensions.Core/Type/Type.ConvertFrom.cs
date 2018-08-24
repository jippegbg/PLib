using System;
using System.ComponentModel;


namespace PLib.Extensions.Core {

	public static partial class TypeExtensions
	{

		/// <summary>
		///     Converts a specifoed object to the current type.
		/// </summary>
		/// <param name="me">The current type.</param>
		/// <param name="obj">The source object to convert.</param>
		/// <returns>
		///     The source object <paramref name="obj"/> as is if it's null, already is of the current type, or cannot
		///     be converted. Else the source object <paramref name="obj"/> converted to the current type.
		/// </returns>
		public static object ConvertFrom(this Type me, object obj)
		{
			return TypeDescriptor.GetConverter(me).ConvertFrom(obj);
		}

	}

}