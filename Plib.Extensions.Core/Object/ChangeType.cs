using System;


namespace PLib.Extensions.Core
{

	public static partial class ObjectExtensions
	{

		/// <summary>
		///     Returns the <see cref="TypeCode"/> for the current object.
		/// </summary>
		/// <param name="me">The current object.</param>
		/// <returns>
		///     The <see cref="TypeCode"/> for value, or <see cref="TypeCode.Empty"/> if value is null.
		/// </returns>
		public static TypeCode GetTypeCode(this object me)
		{
			return Convert.GetTypeCode(me);
		}



		/// <summary>
		///     Returns an object of the specified type whose value is equivalent to the current object.
		/// </summary>
		/// <param name="me">The current object.</param>
		/// <param name="typeCode">The type of object to return.</param>
		/// <returns>
		///     An object whose underlying type is <paramref name="typeCode"/> and whose value is equivalent to value.
		///     -or-
		///     A <b>null</b> reference, if value is <b>null</b> and <paramref name="typeCode"/>
		///     is <see cref="TypeCode.Empty"/>, <see cref="TypeCode.String"/>, or <see cref="TypeCode.Object"/>.
		/// </returns>
		public static object ChangeType(this object me, TypeCode typeCode)
		{
			return Convert.ChangeType(me, typeCode);
		}



		/// <summary>
		///     Returns an object of the specified type whose value is equivalent to the current object.
		///     A parameter supplies culture-specific formatting information.
		/// </summary>
		/// <param name="me">The current object.</param>
		/// <param name="typeCode">The type of object to return.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information. </param>
		/// <returns>
		///     An object whose underlying type is <paramref name="typeCode"/> and whose value is equivalent to value.
		///     -or-
		///     A <b>null</b> reference, if value is <b>null</b> and <paramref name="typeCode"/>
		///     is <see cref="TypeCode.Empty"/>, <see cref="TypeCode.String"/>, or <see cref="TypeCode.Object"/>.
		/// </returns>
		public static object ChangeType(this object me, TypeCode typeCode, IFormatProvider provider)
		{
			return Convert.ChangeType(me, typeCode, provider);
		}



		/// <summary>
		///     Returns an object of the specified type and whose value is equivalent to the current object.
		/// </summary>
		/// <param name="me">The current object.</param>
		/// <param name="conversionType">The type of object to return.</param>
		/// <returns>
		///     An object whose type is <paramref name="conversionType"/> and whose value is equivalent to value.
		///     -or-
		///     A null reference, if value is <b>null</b> and <paramref name="conversionType"/>
		///     is not a value type.
		/// </returns>
		public static object ChangeType(this object me, Type conversionType)
		{
			return Convert.ChangeType(me, conversionType);
		}



		/// <summary>
		///     Returns an object of the specified type and whose value is equivalent to the current object.
		///     A parameter supplies culture-specific formatting information.
		/// </summary>
		/// <param name="me">The current object.</param>
		/// <param name="conversionType">The type of object to return.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <returns>
		///     An object whose type is <paramref name="conversionType"/> and whose value is equivalent to value.
		///     -or-
		///     A null reference, if value is <b>null</b> and <paramref name="conversionType"/>
		///     is not a value type.
		/// </returns>
		public static object ChangeType(this object me, Type conversionType, IFormatProvider provider)
		{
			return Convert.ChangeType(me, conversionType, provider);
		}



		/// <summary>
		///     Returns a <typeparamref name="T"/> object whose value is equivalent to the current object.
		/// </summary>
		/// <typeparam name="T">The type of object to return.</typeparam>
		/// <param name="me">The current object.</param>
		/// <returns>
		///     An object whose type is <typeparamref name="T"/> and whose value is equivalent to value.
		///     -or-
		///     A null reference, if value is <b>null</b> and <typeparamref name="T"/>
		///     is not a value type.
		/// </returns>
		public static T ChangeType<T>(this object me)
		{
			return (T)Convert.ChangeType(me, typeof(T));
		}



		/// <summary>
		///     Returns a <typeparamref name="T"/> object whose value is equivalent to the current object.
		///     A parameter supplies culture-specific formatting information.
		/// </summary>
		/// <typeparam name="T">The type of object to return.</typeparam>
		/// <param name="me">The current object.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <returns>
		///     An object whose type is <typeparamref name="T"/> and whose value is equivalent to value.
		///     -or-
		///     A null reference, if value is <b>null</b> and <typeparamref name="T"/>
		///     is not a value type.
		/// </returns>
		public static T ChangeType<T>(this object me, IFormatProvider provider)
		{
			return (T)Convert.ChangeType(me, typeof(T), provider);
		}

	}

}
