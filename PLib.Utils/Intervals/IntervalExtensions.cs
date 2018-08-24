using System;
using System.Text.RegularExpressions;

using PLib.Extensions.Core;


namespace PLib.Utils.Intervals
{
	public static class IntervalExtensions
	{

		private static readonly Regex RxIntervalExpression = new Regex(@"(?<st>\[|\(|\])?(?<s>[+-\.0-9]?)(?:\.\.|,)(?<e>[+-\.0-9]?)(?<et>\[|\)|\])?");



		/// <summary>
		///     Parses a string expression as a new <see cref="Interval{T}"/> .
		/// </summary>
		/// <typeparam name="T">The type of the interval.</typeparam>
		/// <param name="expression">A string to parse.</param>
		/// <returns>A new interval based on the <paramref name="expression"/>.</returns>
		/// <remarks>
		///     <code>
		/// +--------+--------+------------------------------------------------+-----------------------------------------+
		/// | Expr.  | Math.  | Meaning                                        | Alt. Expr                               |
		/// +--------+--------+------------------------------------------------+--------+------+--------+-------+--------+
		/// | [2,)   | [2,+∞) | from and including 2 to positive infinity      | [2,[   | 2..  | [2..)  | [2..] | [2..[  |
		/// +--------+--------+------------------------------------------------+------- +------+--------+-------+--------+
		/// | [2,5]  | [2,5]  | from and including 2 to and including 5        |        | 2..5 | [2..5] |       |        |
		/// +--------+--------+------------------------------------------------+--------+------+--------+-------+--------+
		/// | [2,5)  | [2,5)  | from and including 2 to but excluding 5        | [2,5[  |      | [2..5) |       | [2..5[ |
		/// +--------+--------+------------------------------------------------+--------+------+--------+-------+--------+
		/// | (,5)   | (-∞,5) | from negative infinity to but excluding 5      |  ],5[  |  ..5 |  (..5) | [..5[ | ]..5[  |
		/// +--------+--------+------------------------------------------------+--------+------+--------+-------+--------+
		///     </code>
		/// </remarks>
		/// <example>
		///     <code>
		/// var interval_1 = IntervalExtensions.ParseInterval&lt;int&gt;("(2..5]");
		/// var interval_2 = "[3..)".ParseInterval&lt;int&gt;();
		///     </code>
		/// </example>
		public static Interval<T> ParseInterval<T>(this string expression) where T : IComparable<T>, IEquatable<T>
		{
			Match match = RxIntervalExpression.Match(expression);

			if (!match.Success)
			{
				throw new FormatException($"Cannot parse expression as an interval: {expression}");
			}

			Limit<T> lower = null;

			if (match.Groups["s"].Success)
			{
				string start = match.Groups["s"].Value;

				if (!start.CanConvertTo<T>()) // TODO: implement a TryConvertTo method
				{
					throw new FormatException($"Cannot convert lower limit value {start} to type {typeof(T).Name}.");
				}

				T minValue = start.ConvertTo<T>();

				bool inclusive = !match.Groups["st"].Success || !match.Groups["st"].Value.IsIn("(", "]");

				lower = new Limit<T>(minValue, inclusive);
			}

			Limit<T> upper = null;

			if (match.Groups["e"].Success)
			{
				string end = match.Groups["e"].Value;

				if (!end.CanConvertTo<T>())
				{
					throw new FormatException($"Cannot convert upper limit value {end} to type {typeof(T).Name}.");
				}

				T maxValue = end.ConvertTo<T>();

				bool inclusive = !match.Groups["et"].Success || !match.Groups["et"].Value.IsIn(")", "[");

				upper = new Limit<T>(maxValue, inclusive);
			}

			return new Interval<T>(lower, upper);
		}



		/// <summary>
		///     Creates a new closed interval where the current value is the lower limit value.
		/// </summary>
		/// <typeparam name="T">The type of the interval.</typeparam>
		/// <param name="from">The current closed lower limit value.</param>
		/// <param name="to">The closed upper limit value.</param>
		/// <returns>A new closed interval.</returns>
		/// <example>
		///     <code>
		/// var interval = 2.To(5);
		///     </code>
		/// </example>
		public static Interval<T> To<T>(this T from, T to) where T : IComparable<T>, IEquatable<T>
		{
			return new Interval<T>(from, to);
		}

	}
}
