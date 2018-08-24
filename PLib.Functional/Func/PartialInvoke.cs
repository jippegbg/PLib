using System;


namespace PLib.Functional {

	public static partial class FuncExtensions
	{

		public static Func<T2, TResult> PartialInvoke<T1, T2, TResult>(this Func<T1, T2, TResult> fn, T1 a)
		{
			return b => fn(a, b);
		}



		public static Func<T1, TResult> PartialInvoke<T1, T2, TResult>(this Func<T1, T2, TResult> fn, T2 b)
		{
			return a => fn(a, b);
		}



		public static Func<T2, T3, TResult> PartialInvoke<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> fn, T1 a)
		{
			return (b, c) => fn(a, b, c);
		}



		public static Func<T1, T3, TResult> PartialInvoke<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> fn, T2 b)
		{
			return (a, c) => fn(a, b, c);
		}



		public static Func<T1, T2, TResult> PartialInvoke<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> fn, T3 c)
		{
			return (a, b) => fn(a, b, c);
		}



		public static Func<T3, TResult> PartialInvoke<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> fn, T1 a, T2 b)
		{
			return c => fn(a, b, c);
		}



		public static Func<T2, TResult> PartialInvoke<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> fn, T1 a, T3 c)
		{
			return b => fn(a, b, c);
		}



		public static Func<T1, TResult> PartialInvoke<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> fn, T2 b, T3 c)
		{
			return a => fn(a, b, c);
		}



		public static Func<T2, T3, T4, TResult> PartialInvoke<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> fn, T1 a)
		{
			return (b, c, d) => fn(a, b, c, d);
		}



		public static Func<T1, T3, T4, TResult> PartialInvoke<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> fn, T2 b)
		{
			return (a, c, d) => fn(a, b, c, d);
		}



		public static Func<T1, T2, T4, TResult> PartialInvoke<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> fn, T3 c)
		{
			return (a, b, d) => fn(a, b, c, d);
		}



		public static Func<T1, T2, T3, TResult> PartialInvoke<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> fn, T4 d)
		{
			return (a, b, c) => fn(a, b, c, d);
		}



		public static Func<T3, T4, TResult> PartialInvoke<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> fn, T1 a, T2 b)
		{
			return (c, d) => fn(a, b, c, d);
		}



		public static Func<T1, T4, TResult> PartialInvoke<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> fn, T2 b, T3 c)
		{
			return (a, d) => fn(a, b, c, d);
		}



		public static Func<T1, T2, TResult> PartialInvoke<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> fn, T3 c, T4 d)
		{
			return (a, b) => fn(a, b, c, d);
		}



		public static Func<T2, T3, TResult> PartialInvoke<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> fn, T1 a, T4 d)
		{
			return (b, c) => fn(a, b, c, d);
		}



		public static Func<T4, TResult> PartialInvoke<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> fn, T1 a, T2 b, T3 c)
		{
			return d => fn(a, b, c, d);
		}



		public static Func<T3, TResult> PartialInvoke<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> fn, T1 a, T2 b, T4 d)
		{
			return c => fn(a, b, c, d);
		}



		public static Func<T2, TResult> PartialInvoke<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> fn, T1 a, T3 c, T4 d)
		{
			return b => fn(a, b, c, d);
		}



		public static Func<T1, TResult> PartialInvoke<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> fn, T2 b, T3 c, T4 d)
		{
			return a => fn(a, b, c, d);
		}

	}

}