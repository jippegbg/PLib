﻿using System;
using System.Collections.Generic;


namespace PLib.Extensions.System
{

	/// <summary>
	///     <para>
	///         The extension class, <see cref="ChainingDelegateExtensions"/> provides
	///         methods for making complex functions from two or more simpler functions.
	///         This process is called composing. As part from combining, where a parameter
	///         is the same input to all given functions, composing implies that a
	///         parameter is the input to the "first" given function only, and that the
	///         result of that first function is the input to the next function, and so on.
	///         The result of the "last" given function is the result of the whole operation.
	///     </para>
	///     <para>
	///         Function composition is the point-wise application of one function to the
	///         result of another to produce a third function. For example, the functions
	///         <i>f : Y -&gt; Z</i> and <i>g : X -&gt; Y</i> can be composed as <i>f ∘ g :
	///         X -&gt; Z</i>, defined by <i>(f ∘ g)(x) = f(g(x))</i>. The notation f ∘ g
	///         can be read as "f after g", to more intuitively understand the effect.
	///     </para>
	///     <para>
	///         Function <b>chaining</b> is the process of applying the functions in the
	///         reverse mathematical order, so that the first function is applied first,
	///         and the last function last. I.e. <c>f.Chain(g)(x)</c> = <i>(g ∘ f)(x) =
	///         g(f(x))</i>. This is the opposite oder of combing functions.
	///     </para>
	///     <para>
	///         This is particularly useful when having a list of functions that should be
	///         applied to an argument in the same order as in the list. But in this case
	///         all functions in that list must have the same input as output types, e.g.
	///         <c>IList&lt;Func&lt;T, T&gt;&gt;</c>, which also will be the input and
	///         output types of the resulting function.
	///     </para>
	///     <para>Chaining is also known as piping.</para>
	/// </summary>
	/// <seealso cref="ComposingDelegateExtensions"/>
	/// <seealso href="http://blog.leifbattermann.de/2015/06/04/function-composition-in-csharp/">
	///     Function composition in C# - Leif Battermann
	/// </seealso>
	/// <seealso href="http://designpattern.ninja/news/2017/09/09/csharp-brainfucking-functional-programming-piping.html">
	///     Design pattern NINJA: Brainfucking C#: Functional piping using extension methods
	/// </seealso>
	/// <seealso href="https://en.wikipedia.org/wiki/Function_composition">
	///     Function composition - Wikipedia
	/// </seealso>
	/// <seealso href="https://www.codeproject.com/Articles/375166/Functional-programming-in-Csharp">
	///     Functional programming in C# - CodeProject
	/// </seealso>
	public static class ChainingDelegateExtensions
	{

		/// <summary>
		///     Chains two functions in the order in which they should be applied.
		/// </summary>
		/// <typeparam name="X">The input type of function <paramref name="f"/>.</typeparam>
		/// <typeparam name="Y">
		///     The output type of function <paramref name="f"/> and the input type of
		///     function <paramref name="g"/>.
		/// </typeparam>
		/// <typeparam name="Z">The output type of function <paramref name="g"/>.</typeparam>
		/// <param name="f">
		///     The first function in the chaining, i.e. the function to be applied to the argument.
		/// </param>
		/// <param name="g">
		///     The second function in the chaining, i.e the function to be applied to the
		///     result of the first.
		/// </param>
		/// <returns>
		///     A function that it composed of two other functions in the reverse
		///     mathematical order..
		/// </returns>
		/// <remarks>
		///     This functional composes two functions in the reverse mathematical order,
		///     i.e. <c>a.Chain(b)(x)</c> = <i>(b ∘ a)(x) = b(a(x))</i>.
		/// </remarks>
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
			if (@this == null || @this.Count == 0) {
				return x => x;
			}

			Func<T, T> result = @this[0];
			for (int i = 1; i < @this.Count; i++) {
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
		///     The functions in the array will be applied in the reverse mathematical
		///     order, i.e. the fist item in the invocation list will be applied to the
		///     argument first, and finally the last item. This is in contrast to invoking
		///     the multicast delegate directly, where the delegates are combined (not
		///     composed) and where they all will have the same input, and the final output
		///     will be that of the last delegate in the invocation list alone. If the
		///     multicast delegate is null, or has no delegates in its invocation list,
		///     this functional will return the identity function (x =&gt; x).
		/// </remarks>
		public static Func<T, T> Chain<T>(this Func<T, T> @this)
		{
			if (@this == null) {
				return x => x;
			}

			Delegate[] delegates = @this.GetInvocationList();

			// Note that if the invocation list's length is 0, the delegate is also null.
			// So there is no need to check for 0 delegates in the invocation list if @this
			// is not null.

			Func<T, T> result = (Func<T, T>)delegates[0];
			for (int i = 1; i < delegates.Length; i++) {
				result = result.Chain((Func<T, T>)delegates[i]);
			}

			return result;
		}

	}

}