using System;


namespace PLib.Extensions.Core {

	public static partial class ObjectExtensions
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

	}

}