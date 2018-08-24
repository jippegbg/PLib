using System;


namespace PLib.Functional {

	public static partial class FuncExtensions
	{

		public static Func<T1, Func<T2, TResult>> Curry<T1, T2, TResult>(this Func<T1, T2, TResult> fn)
		{
			return a => b => fn(a, b);
		}



		public static Func<T1, Func<T2, Func<T3, TResult>>> Curry<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> fn)
		{
			return a => b => c => fn(a, b, c);
		}



		public static Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> Curry<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> fn)
		{
			return a => b => c => d => fn(a, b, c, d);
		}



		public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, TResult>>>>> Curry<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> fn)
		{
			return a => b => c => d => e => fn(a, b, c, d, e);
		}



		public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, TResult>>>>>> Curry<T1, T2, T3, T4, T5, T6, TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> fn)
		{
			return a => b => c => d => e => f => fn(a, b, c, d, e, f);
		}



		public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, TResult>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> fn)
		{
			return a => b => c => d => e => f => g => fn(a, b, c, d, e, f, g);
		}



		public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, TResult>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fn)
		{
			return a => b => c => d => e => f => g => h => fn(a, b, c, d, e, f, g, h);
		}

	}

}