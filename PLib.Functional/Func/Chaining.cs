using System;
using System.Collections.Generic;


namespace PLib.Functional {

	public static partial class FuncExtensions
	{

		/// <summary>
		///     Composes two functions into a new function.
		/// </summary>
		/// <typeparam name="X">
		///     The input type of function <paramref name="f"/>, and the input type of the
		///     resulting function.
		/// </typeparam>
		/// <typeparam name="Y">
		///     The output type of function <paramref name="f"/> and the input type of
		///     function <paramref name="g"/>.
		/// </typeparam>
		/// <typeparam name="Z">
		///     The output type of function <paramref name="g"/>, and the output type of
		///     the resulting function.
		/// </typeparam>
		/// <param name="f">
		///     The first function in the chaining, i.e. the function to be applied to the argument.
		/// </param>
		/// <param name="g">
		///     The second function in the chaining, i.e the function to be applied to the
		///     return value of <paramref name="f"/>.
		/// </param>
		/// <returns>
		///     A function that it composed of two other functions in the reverse
		///     mathematical order.
		/// </returns>
		/// <remarks>
		///     This functional composes two functions in the reverse mathematical order,
		///     i.e. <c>a.Chain(b)(x)</c> = <i>(b ∘ a)(x) = b(a(x))</i>.
		/// </remarks>
		/// <example>
		///     In this example the type of X, Y and Z are all int.
		///     <code>
		/// Func&lt;int, int&gt; f = x =&gt; x * x; // f(x) = x^2
		/// Func&lt;int, int&gt; g = x =&gt; x - 3; // g(x) = x - 3
		/// Func&lt;int, int&gt; h = f.Chain(g);  // h(x) = (g ∘ f)(x) = x^2 - 3;
		/// Func&lt;int, int&gt; j = g.Chain(f);  // j(x) = (f ∘ g)(x) = (x - 3)^2;
		///     </code>
		///     As also can be seen from this example, the ∘ operator is not commutative
		///     even when all types are the same.
		/// </example>
		public static Func<X, Z> Chain<X, Y, Z>(this Func<X, Y> f, Func<Y, Z> g)
		{
			return x => g(f(x));
		}



		/// <summary>
		///     Chains a list of functions into one.
		/// </summary>
		/// <typeparam name="T">The in and out type of the functions in the list.</typeparam>
		/// <param name="this">A list functions.</param>
		/// <returns>
		///     A function that will do the work of all functions in the list, in the same
		///     order. I.e. the first function in the list will be applied to the argument,
		///     and the last function in the list will return the result.
		/// </returns>
		/// <remarks>
		///     The functions in the list will be applied in the reverse mathematical order
		///     <i>(fn[n] ∘ fn[n-1] ∘ ... ∘ fn[0])(x) = fn[n](fn[n-1](...fn[0](x)...))</i>.
		///     All functions in the list must have the same input as output types. If the
		///     list is null or have no elements, this functional returns the identity
		///     function (x =&gt; x).
		/// </remarks>
		public static Func<T, T> Chain<T>(this IList<Func<T, T>> @this)
		{
			if (@this == null || @this.Count == 0)
			{
				return x => x;
			}

			Func<T, T> result = @this[0];
			for (int i = 1; i < @this.Count; i++)
			{
				result = result.Chain(@this[i]);
			}

			return result;
		}



		/// <summary>
		///     Chains the invocation list elements of a multicast delegate into one
		///     function, so that the output of one delegate is the input to the next.
		/// </summary>
		/// <typeparam name="T">The in and out type of the multicast delegate.</typeparam>
		/// <param name="this">A multicast delegate.</param>
		/// <returns>
		///     A function that will do the work of all delegates in the invocation list of
		///     the multicast delegate.
		/// </returns>
		/// <remarks>
		///     The functions in the invocation list will be applied in the reverse
		///     mathematical order, i.e. the fist item in the invocation list will be
		///     applied to the argument first, and finally the last item. This is in
		///     contrast to invoking the multicast delegate directly, where the delegates
		///     are combined (not composed) and where they all will have the same input,
		///     and the final output will be that of the last delegate in the invocation
		///     list alone. If the multicast delegate is null, or has no delegates in its
		///     invocation list, this functional will return the identity function (x =&gt; x).
		/// </remarks>
		public static Func<T, T> Chain<T>(this Func<T, T> @this)
		{
			if (@this == null)
			{
				return x => x;
			}

			Delegate[] delegates = @this.GetInvocationList();

			// Note that if the invocation list's length is 0, the delegate is also null.
			// So there is no need to check for 0 delegates in the invocation list if @this
			// is not null.

			Func<T, T> result = (Func<T, T>)delegates[0];
			for (int i = 1; i < delegates.Length; i++)
			{
				result = result.Chain((Func<T, T>)delegates[i]);
			}

			return result;
		}

	}

}