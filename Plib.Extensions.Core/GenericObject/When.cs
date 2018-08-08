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
		/// <param name="match"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		public static T When<T>(this T me, Predicate<T> match, Action<T> action)
		{
			if (match(me))
			{
				action?.Invoke(me);
			}

			return me;
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="me"></param>
		/// <param name="match"></param>
		/// <param name="function"></param>
		/// <returns></returns>
		public static TResult When<T, TResult>(this T me, Predicate<T> match, Func<T, TResult> function)
		{
			return match(me) && function != null ? function(me) : default(TResult);
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="me"></param>
		/// <param name="match"></param>
		/// <param name="function"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static TResult When<T, TResult>(this T me, Predicate<T> match, Func<T, TResult> function, TResult defaultValue)
		{
			return match(me) && function != null ? function(me) : defaultValue;
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="me"></param>
		/// <param name="match"></param>
		/// <param name="function"></param>
		/// <param name="defaultValueFactory"></param>
		/// <returns></returns>
		public static TResult When<T, TResult>(this T me, Predicate<T> match, Func<T, TResult> function, Func<T, TResult> defaultValueFactory)
		{
			if (match(me) && function != null)
			{
				return function(me);
			}

			if (defaultValueFactory != null)
			{
				return defaultValueFactory(me);
			}

			return default(TResult);
		}

	}

}
