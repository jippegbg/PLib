using System;
using System.Text.RegularExpressions;
using System.Threading;


namespace PLib.Utils.Intervals
{

	public static class Common
	{

		internal static readonly Lazy<Regex> RxIntervalExpression = new Lazy<Regex>(
			() => new Regex(
				@"(?<st>\[|\(|\])?(?<s>[+-\.0-9]?)(?:\.\.|,)(?<e>[+-\.0-9]?)(?<et>\[|\)|\])?",
				RegexOptions.Compiled
			),
			LazyThreadSafetyMode.ExecutionAndPublication
		);


		public static readonly Interval<double> Real = new Interval<double>(null, null);                                  // R
		public static readonly Interval<double> PositiveReal = new Interval<double>(new Limit<double>(0.0, false), null); // R+
		public static readonly Interval<double> NegativeReal = new Interval<double>(null, new Limit<double>(0.0, false)); // R-

		public static readonly Interval<long> Integer = new Interval<long>(null, null);                        // Z
		public static readonly Interval<long> Natural = new Interval<long>(new Limit<long>(0), null);          // N
		public static readonly Interval<long> PositiveInteger = new Interval<long>(new Limit<long>(1), null);  // Z+
		public static readonly Interval<long> NegativeInteger = new Interval<long>(null, new Limit<long>(-1)); // Z-

	}

}
