using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;


namespace PLib.Extensions.Core
{

	public static partial class ObjectExtensions
	{

		/// <summary>
		///     Converts the current object into a specified target type.
		/// </summary>
		/// <typeparam name="T">The target type to convert to.</typeparam>
		/// <param name="me">The current object.</param>
		/// <returns>
		///     The current object as is if it's null, already is of the target type, or cannot
		///     be converted. Else the current object converted to the target type.
		/// </returns>
		/// <remarks>Note that this is a conversion and not a cast operation.</remarks>
		public static T ConvertTo<T>(this object me)
		{
			return (T)me.ConvertTo(typeof(T));
		}



		/// <summary>
		/// </summary>
		/// <typeparam name="T">The target type to convert to.</typeparam>
		/// <param name="me">The current object.</param>
		/// <param name="value">
		///     The current object converted to type <typeparamref name="T"/> if conversion succeeds;
		///     otherwise, the default value of type <typeparamref name="T"/>, if it fails.
		/// </param>
		/// <returns>
		///     <see langword="true"/> if the current object was converted successfully; otherwise, <see langword="false"/>.
		/// </returns>
		/// <seealso cref="ConvertTo{T}(object)"/>
		public static bool TryConvertTo<T>(this object me, out T value)
		{
			Exception exception;
			return TryConvertTo(me, out value, out exception);
		}



		/// <summary>
		///     Tries to convert the current object into a specified target type.
		///     A return value indicates whether the conversion succeeded.
		/// </summary>
		/// <typeparam name="T">The target type to convert to.</typeparam>
		/// <param name="me">The current object.</param>
		/// <param name="value">
		///     The current object converted to type <typeparamref name="T"/> if conversion succeeds;
		///     otherwise, the default value of type <typeparamref name="T"/>, if it fails.
		/// </param>
		/// <param name="exception">
		///     An <see cref="Exception"/> describing the cause if the conversion fails, or
		///     <see langword="null"/> if it succeeds.
		/// </param>
		/// <returns>
		///     <see langword="true"/> if the current object was converted
		///     successfully; otherwise, <see langword="false"/>.
		/// </returns>
		/// <seealso cref="ConvertTo{T}(object)"/>
		[SuppressMessage("ReSharper", "CatchAllClause")]
		public static bool TryConvertTo<T>(this object me, out T value, out Exception exception)
		{
			try
			{
				value     = ConvertTo<T>(me);
				exception = null;
				return true;
			}
			catch (Exception e)
			{
				value     = default(T);
				exception = e;
				return false;
			}
		}



		/// <summary>
		///     Converts the current object into a specified target type.
		/// </summary>
		/// <param name="me">The current object.</param>
		/// <param name="targetType">The target type to convert to.</param>
		/// <returns>
		///     The current object as is if it's null, already is of the target type, or cannot
		///     be converted. Else the current object converted to the target type.
		/// </returns>
		/// <remarks>Note that this is a conversion and not a cast operation.</remarks>
		public static object ConvertTo(this object me, Type targetType)
		{
			if (me == null || me.GetType() == targetType)
			{
				return me;
			}

			TypeConverter sourceConverter = TypeDescriptor.GetConverter(me);
			if (sourceConverter.CanConvertTo(targetType))
			{
				return sourceConverter.ConvertTo(me, targetType);
			}

			TypeConverter targetConverter = TypeDescriptor.GetConverter(targetType);
			if (targetConverter.CanConvertFrom(me.GetType()))
			{
				return targetConverter.ConvertFrom(me);
			}

			if (me == DBNull.Value)
			{
				return null;
			}

			return me;
		}



		/// <summary>
		///     Tries to convert the current object into a specified target type.
		///     A return value indicates whether the conversion succeeded.
		/// </summary>
		/// <param name="me">The current object.</param>
		/// <param name="targetType">The type to convert to.</param>
		/// <param name="value">
		///     The current object converted to type <paramref name="targetType"/> if conversion succeeds;
		///     otherwise, the default value of type <paramref name="targetType"/>, if it fails.
		/// </param>
		/// <returns>
		///     <see langword="true"/> if the current object was converted
		///     successfully; otherwise, <see langword="false"/>.
		/// </returns>
		[SuppressMessage("ReSharper", "CatchAllClause")]
		public static bool ConvertTo(this object me, Type targetType, out object value)
		{
			Exception exception;
			return ConvertTo(me, targetType, out value, out exception);
		}



		/// <summary>
		///     Tries to convert the current object into a specified target type.
		///     A return value indicates whether the conversion succeeded.
		/// </summary>
		/// <param name="me">The current object.</param>
		/// <param name="targetType">The type to convert to.</param>
		/// <param name="value">
		///     The current object converted to type <paramref name="targetType"/> if conversion succeeds;
		///     otherwise, the default value of type <paramref name="targetType"/>, if it fails.
		/// </param>
		/// <param name="exception">
		///     An <see cref="Exception"/> describing the cause if the conversion fails, or
		///     <see langword="null"/> if it succeeds.
		/// </param>
		/// <returns>
		///     <see langword="true"/> if the current object was converted
		///     successfully; otherwise, <see langword="false"/>.
		/// </returns>
		[SuppressMessage("ReSharper", "CatchAllClause")]
		public static bool ConvertTo(this object me, Type targetType, out object value, out Exception exception)
		{
			try
			{
				value     = ConvertTo(me, targetType);
				exception = null;
				return true;
			}
			catch (Exception e)
			{
				value     = null;
				exception = e;
				return false;
			}
		}

	}

}
