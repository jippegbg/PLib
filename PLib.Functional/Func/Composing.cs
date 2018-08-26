using System;
using System.Collections.Generic;


namespace PLib.Functional {

	public static partial class FuncExtensions
	{

		/// <summary>
		///     Composes two functions into a new function.
		/// </summary>
		/// <typeparam name="X">
		///     The input type of function <paramref name="g"/>, and the input type of the
		///     resulting function.
		/// </typeparam>
		/// <typeparam name="Y">
		///     The output type of function <paramref name="g"/> and the input type of
		///     function <paramref name="f"/>.
		/// </typeparam>
		/// <typeparam name="Z">
		///     The output type of function <paramref name="f"/>, and the output type of
		///     the resulting function.
		/// </typeparam>
		/// <param name="f">
		///     The first function in the composition, i.e. the function to be applied to
		///     the return value of <paramref name="g"/>.
		/// </param>
		/// <param name="g">
		///     The second function in the composition, i.e. the function to be applied to
		///     the argument.
		/// </param>
		/// <returns>
		///     A function that is composed of two other functions int the forward
		///     matrhematical order.
		/// </returns>
		/// <remarks>
		///     This functional composes two functions in the forward mathematical order,
		///     i.e. a.Compose(b)(x) = (a ∘ b)(x) = a(b(x)).
		/// </remarks>
		/// <example>
		///     In this example the type of X, Y and Z are all int.
		///     <code>
		/// Func&lt;int, int&gt; f = x =&gt; x * x; // f(x) = x^2
		/// Func&lt;int, int&gt; g = x =&gt; x - 3; // g(x) = x - 3
		/// Func&lt;int, int&gt; h = f.Compose(g);  // h(x) = (f ∘ g)(x) = (x - 3)^2;
		/// Func&lt;int, int&gt; j = g.Compose(f);  // j(x) = (g ∘ f)(x) = x^2 - 3;
		///     </code>
		///     As also can be seen from this example, the ∘ operator is not commutative
		///     even when all types are the same.
		/// </example>
		public static Func<X, Z> Compose<X, Y, Z>(this Func<Y, Z> f, Func<X, Y> g)
		{
			return x => f(g(x));
		}



		/// <summary>
		///     Composes a list of functions into one.
		/// </summary>
		/// <typeparam name="T">The in and out type of the functions in the list.</typeparam>
		/// <param name="this">A list of functions.</param>
		/// <returns>
		///     A function that will do the work of all functions in the list, in the
		///     reverse order. I.e. the last function in the list will be applied to the
		///     argument, and the first function in the list will return the result.
		/// </returns>
		/// <remarks>
		///     The functions in the list will be applied in the forward mathematical order
		///     <i>(fn[0] ∘ fn[1] ∘ ... ∘ fn[n])(x) = fn[0](fn[1]( ...fn[n](x)... ))</i>.
		///     All functions in the list must have the same input as output types. If the
		///     list is null or have no elements, this functional returns the identity
		///     function (x =&gt; x).
		/// </remarks>
		public static Func<T, T> Compose<T>(this IList<Func<T, T>> @this)
		{
			if (@this == null || @this.Count == 0)
			{
				return x => x;
			}

			Func<T, T> result = @this[0];
			for (int i = 1; i < @this.Count; i++)
			{
				result = result.Compose(@this[i]);
			}

			return result;
		}



		/// <summary>
		///     Composes the invocation list elements of a multicast delegate into one
		///     function, so that the output of one delegate is the input to the next.
		/// </summary>
		/// <typeparam name="T">The in and out type of the multicast delegate.</typeparam>
		/// <param name="this">A multicast delegate.</param>
		/// <returns>
		///     A function that will do the work of all delegates in the invocation list of
		///     the multicast delegate.
		/// </returns>
		/// <remarks>
		///     The functions in the invocation list will be applied in the forward
		///     mathematical order, i.e. the last item in the invocation list will be
		///     applied to the argument first, and finally the first item. This is in
		///     contrast to invoking the multicast delegate directly, where the delegates
		///     are combined (not composed) and where they all will have the same input,
		///     and the final output will be that of the last delegate in the invocation
		///     list alone. If the multicast delegate is null, or has no delegates in its
		///     invocation list, this functional will return the identity function (x =&gt; x).
		/// </remarks>
		public static Func<T, T> Compose<T>(this Func<T, T> @this)
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
				result = result.Compose((Func<T, T>)delegates[i]);
			}

			return result;
		}

	}

}