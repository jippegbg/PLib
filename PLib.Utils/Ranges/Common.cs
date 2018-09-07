using System;
using System.Text.RegularExpressions;
using System.Threading;


namespace PLib.Utils.Ranges
{

	internal static class Common
	{

		public static readonly Lazy<Regex> RxRangeExpression = new Lazy<Regex>(
			() => new Regex(
				@"\[?\s*(?<s>[+-]?\d+)\s*(?:\.\.|,)\s*(?<e>[+-]?\d+)\s*\]?",
				RegexOptions.Compiled
			),
			LazyThreadSafetyMode.ExecutionAndPublication
		);

	}

}
