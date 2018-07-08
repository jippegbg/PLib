using System;
using System.Threading;


namespace PLib.Functional
{

	public static class DelegateExtensions
	{

		/// <summary>
		///     Returns a specified function raised to the specified power.
		/// </summary>
		/// <typeparam name="T">The functions input and output type.</typeparam>
		/// <param name="this">The current function.</param>
		/// <param name="n">An integer number that specifies a exponent.</param>
		/// <returns>The function <paramref name="this"/> raised to the power <paramref name="n"/>.</returns>
		/// <remarks>
		///     The current function must have the same input as output type.
		///     If <paramref name="n"/> is zero or negative, the identity function (x => x) is returned,
		///     in analogy to a number raised to the power of zero returns one.
		///     If <paramref name="n"/> is one, the current function is returned,
		///     in analogy to a number raised to the power of one is the number itself.
		/// </remarks>
		public static Func<T, T> Power<T>(this Func<T, T> @this, int n)
		{
			if (n < 1)
			{
				return x => x;
			}

			Func<T, T> result = @this;
			for (int i = 1; i < n; i++)
			{
				result = result.Compose(@this);
			}

			return result;
		}



		/// <summary>
		///     Applies a function on an object and returns the result.
		/// </summary>
		/// <typeparam name="T">The type of the object to apply the function on.</typeparam>
		/// <typeparam name="R">The type of the result.</typeparam>
		/// <param name="this">The current object.</param>
		/// <param name="fn">The function to apply on the current object.</param>
		/// <returns>The return value of the function <paramref name="fn"/>.</returns>
		/// <example>
		///     <code>
		///         byte[] bytes = ...;
		///         string writtenToConsole = bytes.Map(Encoding.UTF8.GetString).Tee(Console.WriteLine);
		///     </code>
		/// </example>
		/// <remarks>
		///     Encapsulating a function like this makes it possible to call any static method like a member method.
		/// </remarks>
		public static R Map<T, R>(this T @this, Func<T, R> fn)
		{
			return fn(@this);
		}



		/// <summary>
		///     Applies an action on an object and returns the object untouched.
		/// </summary>
		/// <typeparam name="T">The type of the object to apply the action on.</typeparam>
		/// <param name="this">The current object.</param>
		/// <param name="act">The action to apply on the current object.</param>
		/// <returns>The current object as is.</returns>
		/// <example>
		///     <code>
		///         byte[] bytes = ...;
		///         string writtenToConsole = bytes.Map(Encoding.UTF8.GetString).Tee(Console.WriteLine);
		///     </code>
		/// </example>
		public static T Tee<T>(this T @this, Action<T> act)
		{
			act(@this);
			return @this;
		}



		/// <summary>
		///     Tries to execute an action several times, before bailing out.
		/// </summary>
		/// <param name="act">The current action.</param>
		/// <param name="numRetries">The maximum number time to retry to perform <paramref name="act"/>. Default 3 times.</param>
		/// <param name="delay">
		///     The number of milliseconds to wait between each retry. Default 500 ms.
		///     If <paramref name="numRetries"/> is less than 2 this value has no effect.
		/// </param>
		/// <exception cref="ArgumentOutOfRangeException">
		///     If <paramref name="numRetries"/> is less than 1, or if <paramref name="delay"/> is negative.
		/// </exception>
		/// <exception cref="Exception">If the <paramref name="act"/> did not succeed after the specified <paramref name="numRetries"/>.</exception>
		/// <example>
		///     <code>
		/// byte[] bytes = ...;
		/// Action act = () => File.WriteAllBytes("...", bytes);
		/// act.WithRetry();
		///     </code>
		/// </example>
		public static void InvokeWithRetry(this Action act, int numRetries = 3, int delay = 500)
		{
			if (numRetries < 1)
			{
				throw new ArgumentOutOfRangeException(nameof(numRetries), "Number of retries must be at least one.");
			}

			if (numRetries > 1 && delay < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(delay), "Delay must be positive, as it's impossible to retry in advance.");
			}

			int retryCount = 1;
			while (true)
			{
				try
				{
					act();
					break;
				}
				catch (Exception)
				{
					retryCount++;
					if (numRetries < retryCount)
					{
						throw;
					}

					Thread.CurrentThread.Join(delay);
				}
			}
		}



		/// <summary>
		///     Tries to execute a function several times, before bailing out.
		/// </summary>
		/// <typeparam name="T">The return type of <paramref name="fn"/>.</typeparam>
		/// <param name="fn">The current function.</param>
		/// <param name="numRetries">The maximum number of times to retry to perform <paramref name="fn"/>. Default is 3 times.</param>
		/// <param name="delay">
		///     The number of milliseconds to wait between each retry. Default 500 ms.
		///     If <paramref name="numRetries"/> is less than 2 this value has no effect.
		/// </param>
		/// <returns>The result of <paramref name="fn"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///     If <paramref name="numRetries"/> is less than 1, or if <paramref name="delay"/> is negative.
		/// </exception>
		/// <exception cref="Exception">
		///     If the <paramref name="fn"/> did not succeed after the specified <paramref name="numRetries"/>.
		/// </exception>
		/// <example>
		///     <code>
		/// Func&lt;byte[]&gt; fn = () =&gt; File.ReadAllBytes("...");
		/// byte[] bytes = fn.WithRetry(5, 1000);
		///     </code>
		/// </example>
		public static T InvokeWithRetry<T>(this Func<T> fn, int numRetries = 3, int delay = 500)
		{
			if (numRetries < 1)
			{
				throw new ArgumentOutOfRangeException(nameof(numRetries), "Number of retries must be at least one.");
			}

			if (numRetries > 1 && delay < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(delay), "Delay must be positive, as it's impossible to retry in advance.");
			}

			T result;

			int retryCount = 1;
			while (true)
			{
				try
				{
					result = fn();
					break;
				}
				catch (Exception)
				{
					retryCount++;
					if (numRetries < retryCount)
					{
						throw;
					}

					Thread.CurrentThread.Join(delay);
				}
			}

			return result;
		}

	}

}
