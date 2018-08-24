using System;


namespace PLib.Functional {

	public static partial class ActionExtensions
	{

		public static Func<T1, Action<T2>> Curry<T1, T2>(this Action<T1, T2> action)
		{
			return a => b => action(a, b);
		}



		public static Func<T1, Func<T2, Action<T3>>> Curry<T1, T2, T3>(this Action<T1, T2, T3> action)
		{
			return a => b => c => action(a, b, c);
		}



		public static Func<T1, Func<T2, Func<T3, Action<T4>>>> Curry<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action)
		{
			return a => b => c => d => action(a, b, c, d);
		}



		public static Func<T1, Func<T2, Func<T3, Func<T4, Action<T5>>>>> Curry<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action)
		{
			return a => b => c => d => e => action(a, b, c, d, e);
		}



		public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Action<T6>>>>>> Curry<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action)
		{
			return a => b => c => d => e => f => action(a, b, c, d, e, f);
		}



		public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Action<T7>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action)
		{
			return a => b => c => d => e => f => g => action(a, b, c, d, e, f, g);
		}



		public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Action<T8>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
		{
			return a => b => c => d => e => f => g => h => action(a, b, c, d, e, f, g, h);
		}

	}

}