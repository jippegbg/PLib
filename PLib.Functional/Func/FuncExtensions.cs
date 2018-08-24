namespace PLib.Functional
{

	/// <summary>
	///     <para>
	///         This extension class provides methods for making complex functions from two
	///         or more simpler functions. This process is called composing. As part from
	///         combining, where a parameter is the same input to all given functions,
	///         composing implies that a parameter is the input to the "first" given
	///         function only, and that the result of that first function is the input to
	///         the next function, and so on. The result of the "last" given function is
	///         the result of the whole operation.
	///     </para>
	///     <para>
	///         Function composition is the point-wise application of one function to the
	///         result of another to produce a third function. For example, the functions
	///         <i>f : Y -&gt; Z</i> and <i>g : X -&gt; Y</i> can be composed as <i>f ∘ g :
	///         X -&gt; Z</i>, defined by <i>(f ∘ g)(x) = f(g(x))</i>. The notation f ∘ g
	///         can be read as "f after g", to more intuitively understand the effect.
	///     </para>
	///     <para>
	///         <b>Composing</b> is the process of applying the functions in the forward
	///         mathematical order, so that the last function is applied first, and the
	///         first function last. I.e. <c>f.Compose(g)(x)</c> = <i>(f ∘ g)(x) = f(g(x))</i>.
	///     </para>
	///     <para>
	///         <b>Chaining</b> (aka. piping) is the process of applying the functions in
	///         the reverse mathematical order, so that the first function is applied
	///         first, and the last function last. I.e. <c>f.Chain(g)(x)</c> = <i>(g ∘
	///         f)(x) = g(f(x))</i>. This is particularly useful when having a list of
	///         functions that should be applied to an argument in the same order as in the
	///         list. But in this particular case all functions in that list must have the
	///         same input as output types, e.g. <c>IList&lt;Func&lt;T, T&gt;&gt;</c>,
	///         which also will be the input and output types of the resulting function.
	///     </para>
	/// </summary>
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
	public static partial class FuncExtensions { }

}
