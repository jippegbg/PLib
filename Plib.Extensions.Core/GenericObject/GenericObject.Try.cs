using System;


namespace PLib.Extensions.Core.GenericObject
{

	public static partial class GenericObjectExtensions
	{

		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		public static bool Try<T>(this T me, Action<T> action)
		{
			try
			{
				action(me);
				return true;
			}
			catch
			{
				return false;
			}
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me"></param>
		/// <param name="action"></param>
		/// <param name="ex"></param>
		/// <returns></returns>
		public static bool Try<T>(this T me, Action<T> action, out Exception ex)
		{
			try
			{
				action(me);
				ex = null;
				return true;
			}
			catch (Exception e)
			{
				ex = e;
				return false;
			}
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="me"></param>
		/// <param name="function"></param>
		/// <returns></returns>
		public static TResult Try<T, TResult>(this T me, Func<T, TResult> function)
		{
			try
			{
				return function(me);
			}
			catch
			{
				return default(TResult);
			}
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="me"></param>
		/// <param name="function"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static TResult Try<T, TResult>(this T me, Func<T, TResult> function, TResult defaultValue)
		{
			try
			{
				return function(me);
			}
			catch
			{
				return defaultValue;
			}
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="me"></param>
		/// <param name="function"></param>
		/// <param name="defaultValueFactory"></param>
		/// <returns></returns>
		public static TResult Try<T, TResult>(this T me, Func<T, TResult> function, Func<T, TResult> defaultValueFactory)
		{
			try
			{
				return function(me);
			}
			catch
			{
				return defaultValueFactory(me);
			}
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="me"></param>
		/// <param name="function"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		public static bool Try<T, TResult>(this T me, Func<T, TResult> function, out TResult result)
		{
			try
			{
				result = function(me);
				return true;
			}
			catch
			{
				result = default(TResult);
				return false;
			}
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="me"></param>
		/// <param name="function"></param>
		/// <param name="result"></param>
		/// <param name="ex"></param>
		/// <returns></returns>
		public static bool Try<T, TResult>(this T me, Func<T, TResult> function, out TResult result, out Exception ex)
		{
			try
			{
				result = function(me);
				ex     = null;
				return true;
			}
			catch (Exception e)
			{
				result = default(TResult);
				ex     = e;
				return false;
			}
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="me"></param>
		/// <param name="function"></param>
		/// <param name="defaultValue"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		public static bool Try<T, TResult>(this T me, Func<T, TResult> function, TResult defaultValue, out TResult result)
		{
			try
			{
				result = function(me);
				return true;
			}
			catch
			{
				result = defaultValue;
				return false;
			}
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="me"></param>
		/// <param name="function"></param>
		/// <param name="defaultValue"></param>
		/// <param name="result"></param>
		/// <param name="ex"></param>
		/// <returns></returns>
		public static bool Try<T, TResult>(this T me, Func<T, TResult> function, TResult defaultValue, out TResult result, out Exception ex)
		{
			try
			{
				result = function(me);
				ex     = null;
				return true;
			}
			catch (Exception e)
			{
				result = defaultValue;
				ex     = e;
				return false;
			}
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="me"></param>
		/// <param name="function"></param>
		/// <param name="defaultValueFactory"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		public static bool Try<T, TResult>(this T me, Func<T, TResult> function, Func<T, TResult> defaultValueFactory, out TResult result)
		{
			try
			{
				result = function(me);
				return true;
			}
			catch
			{
				result = defaultValueFactory(me);
				return false;
			}
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="me"></param>
		/// <param name="function"></param>
		/// <param name="defaultValueFactory"></param>
		/// <param name="result"></param>
		/// <param name="ex"></param>
		/// <returns></returns>
		public static bool Try<T, TResult>(this T me, Func<T, TResult> function, Func<T, TResult> defaultValueFactory, out TResult result, out Exception ex)
		{
			try
			{
				result = function(me);
				ex     = null;
				return true;
			}
			catch (Exception e)
			{
				result = defaultValueFactory(me);
				ex     = e;
				return false;
			}
		}

	}

}
