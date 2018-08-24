using System;


namespace PLib.Functional {

	public static partial class ActionExtensions
	{

		public static Action<T2> PartialInvoke<T1, T2>(this Action<T1, T2> action, T1 a)
		{
			return b => action(a, b);
		}



		public static Action<T2, T3> PartialInvoke<T1, T2, T3>(this Action<T1, T2, T3> action, T1 a)
		{
			return (b, c) => action(a, b, c);
		}



		public static Action<T1, T3> PartialInvoke<T1, T2, T3>(this Action<T1, T2, T3> action, T2 b)
		{
			return (a, c) => action(a, b, c);
		}



		public static Action<T1, T2> PartialInvoke<T1, T2, T3>(this Action<T1, T2, T3> action, T3 c)
		{
			return (a, b) => action(a, b, c);
		}



		public static Action<T3> PartialInvoke<T1, T2, T3>(this Action<T1, T2, T3> action, T1 a, T2 b)
		{
			return c => action(a, b, c);
		}



		public static Action<T2> PartialInvoke<T1, T2, T3>(this Action<T1, T2, T3> action, T1 a, T3 c)
		{
			return b => action(a, b, c);
		}



		public static Action<T1> PartialInvoke<T1, T2, T3>(this Action<T1, T2, T3> action, T2 b, T3 c)
		{
			return a => action(a, b, c);
		}



		public static Action<T2, T3, T4> PartialInvoke<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 a)
		{
			return (b, c, d) => action(a, b, c, d);
		}



		public static Action<T1, T3, T4> PartialInvoke<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T2 b)
		{
			return (a, c, d) => action(a, b, c, d);
		}



		public static Action<T1, T2, T4> PartialInvoke<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T3 c)
		{
			return (a, b, d) => action(a, b, c, d);
		}



		public static Action<T1, T2, T3> PartialInvoke<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T4 d)
		{
			return (a, b, c) => action(a, b, c, d);
		}



		public static Action<T3, T4> PartialInvoke<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 a, T2 b)
		{
			return (c, d) => action(a, b, c, d);
		}



		public static Action<T1, T4> PartialInvoke<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T2 b, T3 c)
		{
			return (a, d) => action(a, b, c, d);
		}



		public static Action<T1, T2> PartialInvoke<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T3 c, T4 d)
		{
			return (a, b) => action(a, b, c, d);
		}



		public static Action<T2, T3> PartialInvoke<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 a, T4 d)
		{
			return (b, c) => action(a, b, c, d);
		}



		public static Action<T4> PartialInvoke<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 a, T2 b, T3 c)
		{
			return d => action(a, b, c, d);
		}



		public static Action<T3> PartialInvoke<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 a, T2 b, T4 d)
		{
			return c => action(a, b, c, d);
		}



		public static Action<T2> PartialInvoke<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 a, T3 c, T4 d)
		{
			return b => action(a, b, c, d);
		}



		public static Action<T1> PartialInvoke<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T2 b, T3 c, T4 d)
		{
			return a => action(a, b, c, d);
		}

	}

}