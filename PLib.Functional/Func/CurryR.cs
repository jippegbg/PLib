using System;


namespace PLib.Functional {

	public static partial class FuncExtensions
	{

		public static Func<T2, Func<T1, TResult>> CurryR<T1, T2, TResult>(this Func<T1, T2, TResult> fn)
		{
			return b => a => fn(a, b);
		}



		public static Func<T3, Func<T2, Func<T1, TResult>>> CurryR<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> fn)
		{
			return c => b => a => fn(a, b, c);
		}



		public static Func<T4, Func<T3, Func<T2, Func<T1, TResult>>>> CurryR<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> fn)
		{
			return d => c => b => a => fn(a, b, c, d);
		}



		public static Func<T5, Func<T4, Func<T3, Func<T2, Func<T1, TResult>>>>> CurryR<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> fn)
		{
			return e => d => c => b => a => fn(a, b, c, d, e);
		}



		public static Func<T6, Func<T5, Func<T4, Func<T3, Func<T2, Func<T1, TResult>>>>>> CurryR<T1, T2, T3, T4, T5, T6, TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> fn)
		{
			return f => e => d => c => b => a => fn(a, b, c, d, e, f);
		}



		public static Func<T7, Func<T6, Func<T5, Func<T4, Func<T3, Func<T2, Func<T1, TResult>>>>>>> CurryR<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> fn)
		{
			return g => f => e => d => c => b => a => fn(a, b, c, d, e, f, g);
		}



		public static Func<T8, Func<T7, Func<T6, Func<T5, Func<T4, Func<T3, Func<T2, Func<T1, TResult>>>>>>>> CurryR<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fn)
		{
			return h => g => f => e => d => c => b => a => fn(a, b, c, d, e, f, g, h);
		}

	}

}