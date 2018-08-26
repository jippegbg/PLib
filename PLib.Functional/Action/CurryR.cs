using System;


namespace PLib.Functional {

	public static partial class ActionExtensions
	{

		public static Func<T2, Action<T1>> CurryR<T1, T2>(this Action<T1, T2> action)
		{
			return b => a => action(a, b);
		}



		public static Func<T3, Func<T2, Action<T1>>> CurryR<T1, T2, T3>(this Action<T1, T2, T3> action)
		{
			return c => b => a => action(a, b, c);
		}



		public static Func<T4, Func<T3, Func<T2, Action<T1>>>> CurryR<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action)
		{
			return d => c => b => a => action(a, b, c, d);
		}



		public static Func<T5, Func<T4, Func<T3, Func<T2, Action<T1>>>>> CurryR<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action)
		{
			return e => d => c => b => a => action(a, b, c, d, e);
		}



		public static Func<T6, Func<T5, Func<T4, Func<T3, Func<T2, Action<T1>>>>>> CurryR<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action)
		{
			return f => e => d => c => b => a => action(a, b, c, d, e, f);
		}



		public static Func<T7, Func<T6, Func<T5, Func<T4, Func<T3, Func<T2, Action<T1>>>>>>> CurryR<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action)
		{
			return g => f => e => d => c => b => a => action(a, b, c, d, e, f, g);
		}



		public static Func<T8, Func<T7, Func<T6, Func<T5, Func<T4, Func<T3, Func<T2, Action<T1>>>>>>>> CurryR<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
		{
			return h => g => f => e => d => c => b => a => action(a, b, c, d, e, f, g, h);
		}

	}

}