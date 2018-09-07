using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

using PLib.Extensions.Core;

using static PLib.Utils.Intervals.Common;


namespace PLib.Utils.Intervals
{

	/// <summary>
	///     The Interval class.
	/// </summary>
	/// <typeparam name="T">Generic parameter.</typeparam>
	public class Interval<T> : IEquatable<Interval<T>> where T : IComparable<T>, IEquatable<T>
	{

		#region [ Static ]

		/// <summary>
		///     Interprets a string expression as an interval.
		/// </summary>
		/// <param name="expression">A string to interpret.</param>
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
		/// <exception cref="FormatException">
		///     If the format of the <paramref name="expression"/> cannot be interpreted as an interval.
		/// </exception>
		/// <exception cref="ArgumentNullException"><paramref name="expression"/> is null.</exception>
		/// <exception cref="TimeoutException">
		///     If there was a time-out when trying to match the <paramref name="expression"/>
		///     against valid formats.
		/// </exception>
		public static Interval<T> Parse(string expression)
		{
			Match match;

			try
			{
				match = RxIntervalExpression.Value.Match(expression);
			}
			catch (RegexMatchTimeoutException e)
			{
				throw new TimeoutException("A time-out occurred when trying to match the string expression against valid formats.", e);
			}

			if (!match.Success)
			{
				throw new FormatException($"Cannot parse expression as an interval: {expression}");
			}

			Limit<T> lower = null;

			if (match.Groups["s"].Success)
			{
				string start = match.Groups["s"].Value;

				if (!start.CanConvertTo<T>())
				{
					throw new FormatException($"Cannot convert lower limit value {start} to type {typeof(T).Name}.");
				}

				T minValue = start.ConvertTo<T>();

				bool closed = !match.Groups["st"].Success || !match.Groups["st"].Value.EqualsAnyOf("(", "]");

				lower = new Limit<T>(minValue, closed);
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

				bool closed = !match.Groups["et"].Success || !match.Groups["et"].Value.EqualsAnyOf(")", "[");

				upper = new Limit<T>(maxValue, closed);
			}

			return new Interval<T>(lower, upper);
		}



		/// <summary>
		///     Interprets a string expression as an interval. A return value indicates whether the
		///     conversion succeeded.
		/// </summary>
		/// <param name="expression">A string to interpret.</param>
		/// <param name="interval">
		///     A new interval based on the <paramref name="expression"/>, if the interpretation
		///     succeeds, or <see langword="null"/> if it fails.
		/// </param>
		/// <param name="exception">
		///     If the interpretation fails, an exception describing the cause, or <see langword="null"/> if it succeeds.
		/// </param>
		/// <returns>
		///     <see langword="true"/> if the <paramref name="expression"/> was interpreted successfully;
		///     otherwise, <see langword="false"/>.
		/// </returns>
		[SuppressMessage("ReSharper", "CatchAllClause")]
		public static bool TryParse(string expression, out Interval<T> interval, out Exception exception)
		{
			try
			{
				interval  = Parse(expression);
				exception = null;
				return true;
			}
			catch (Exception e)
			{
				interval  = null;
				exception = e;
				return false;
			}
		}



		/// <summary>
		///     Interprets a string expression as an interval. A return value indicates whether the
		///     conversion succeeded.
		/// </summary>
		/// <param name="expression">A string to interpret.</param>
		/// <param name="interval">
		///     A new interval based on the <paramref name="expression"/>, if the interpretation
		///     succeeds, or <see langword="null"/> if it fails.
		/// </param>
		/// <returns>
		///     <see langword="true"/> if the <paramref name="expression"/> was interpreted successfully;
		///     otherwise, <see langword="false"/>.
		/// </returns>
		public static bool TryParse(string expression, out Interval<T> interval)
		{
			Exception exception;
			return TryParse(expression, out interval, out exception);
		}

		#endregion [ Static ]



		#region [ Properties ]

		// <summary>
		///     The lower limit of the interval.
		/// </summary>
		public Limit<T> LowerLimit { get; }



		/// <summary>
		///     The upper limit of the interval.
		/// </summary>
		public Limit<T> UpperLimit { get; }



		/// <summary>
		///     Determines if the interval is bounded on both sides.
		/// </summary>
		public bool Bounded => LowerLimit != null && UpperLimit != null;



		/// <summary>
		///     Determines if the interval is bounded on the left side.
		/// </summary>
		public bool LeftBounded => LowerLimit != null;



		/// <summary>
		///     Determines if the interval is bounded on the right side.
		/// </summary>
		public bool RightBounded => UpperLimit != null;



		/// <summary>
		///     Determines if the interval is unbounded at both ends.
		/// </summary>
		public bool Infinite => LowerLimit == null && UpperLimit == null;



		/// <summary>
		///     Determines if the interval is infinite on the left side.
		/// </summary>
		public bool LeftInfinite => LowerLimit == null;



		/// <summary>
		///     Determines if the interval is infinite on the right side.
		/// </summary>
		public bool RightInfinite => UpperLimit == null;



		/// <summary>
		///     Determines if the interval is bounded and closed on both sides.
		/// </summary>
		public bool Closed => Bounded && LowerLimit.Closed && UpperLimit.Closed;



		/// <summary>
		///     Determines if the interval is bounded and closed on the left side.
		/// </summary>
		public bool LeftClosed => LowerLimit != null && LowerLimit.Closed;



		/// <summary>
		///     Determines if the interval is boundedn and closed on the right side.
		/// </summary>
		public bool RightClosed => UpperLimit != null && UpperLimit.Closed;



		/// <summary>
		///     Determines if the interval is bounded and open on both sides.
		/// </summary>
		public bool Open => Bounded && LowerLimit.Open && UpperLimit.Open;



		/// <summary>
		///     Determines if the interval is bounded and open on the left side.
		/// </summary>
		public bool LeftOpen => LowerLimit != null && LowerLimit.Open;



		/// <summary>
		///     Determines if the interval is bounded and open on the right side.
		/// </summary>
		public bool RightOpen => UpperLimit != null && UpperLimit.Open;

		#endregion [ Properties ]



		#region [ Constructors ]

		/// <summary>
		///     Initializes a new interval.
		/// </summary>
		/// <param name="lower">The lower interval limit, or null if unbounded.</param>
		/// <param name="upper">The upper interval limit, or null if unbounded.</param>
		public Interval(Limit<T> lower, Limit<T> upper)
		{
			(LowerLimit = lower).Position = Position.Lower;
			(UpperLimit = upper).Position = Position.Upper;
		}



		/// <summary>
		///     Initializes a new bounded interval.
		/// </summary>
		/// <param name="lowerValue">The lower limit value, or null if unbounded.</param>
		/// <param name="lowerClosed">
		///     A value that determines whether the lower limit value should be closed. If
		///     <typeparamref name="T"/> is a reference type and this value is
		///     <see langword="null"/>, the lower limit will be unbounded.
		/// </param>
		/// <param name="upperValue">The upper limit value, or null if unbounded.</param>
		/// <param name="upperClosed">
		///     A value that determines whether the upper limit value should be closed. If
		///     <typeparamref name="T"/> is a reference type and this value is
		///     <see langword="null"/>, the upper limit will be unbounded.
		/// </param>
		/// <remarks>
		///     To create an unbounded interval when <typeparamref name="T"/> is a value type, use
		///     the constructor <see cref="Interval{T}(Limit{T}, Limit{T})"/>.
		/// </remarks>
		public Interval(T lowerValue, bool lowerClosed, T upperValue, bool upperClosed)
		{
			if (lowerValue != null)
			{
				LowerLimit = new Limit<T>(lowerValue, lowerClosed, Position.Lower);
			}

			if (upperValue != null)
			{
				UpperLimit = new Limit<T>(upperValue, upperClosed, Position.Upper);
			}
		}



		/// <summary>
		///     Initializes a new closed interval.
		/// </summary>
		/// <param name="lowerValue">
		///     The closed lower limit value. If <typeparamref name="T"/> is a reference type and
		///     this value is <see langword="null"/>, the lower limit will be unbounded.
		/// </param>
		/// <param name="upperValue">
		///     The closed upper limit value. If <typeparamref name="T"/> is a reference type and
		///     this value is <see langword="null"/>, the upper limit will be unbounded.
		/// </param>
		public Interval(T lowerValue, T upperValue)
		{
			if (lowerValue != null)
			{
				LowerLimit = new Limit<T>(lowerValue, true, Position.Lower);
			}

			if (upperValue != null)
			{
				UpperLimit = new Limit<T>(upperValue, true, Position.Upper);
			}
		}

		#endregion [ Constructors ]



		#region [ Operators ]
		
		/// <summary>
		///     Determines if two interval objects are equal.
		/// </summary>
		/// <param name="left">The left interval operand.</param>
		/// <param name="right">The right interval operand.</param>
		/// <returns>
		///     <see langword="true"/> if both the interval operands are equal; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator ==(Interval<T> left, Interval<T> right)
		{
			return Equals(left, right);
		}



		/// <summary>
		///     Determines if two interval objects are not equal.
		/// </summary>
		/// <param name="left">The left interval operand.</param>
		/// <param name="right">The right interval operand.</param>
		/// <returns>
		///     <see langword="true"/> if both the interval operands are not equal; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator !=(Interval<T> left, Interval<T> right)
		{
			return !Equals(left, right);
		}



		/// <summary>
		///     Determines if the left interval is a proper subset of the right interval.
		/// </summary>
		/// <param name="left">The left interval operand.</param>
		/// <param name="right">The right interval operand.</param>
		/// <returns>
		///     <see langword="true"/> if the <paramref name="left"/> interval is a proper subset of the
		///     <paramref name="right"/> interval; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator <(Interval<T> left, Interval<T> right)
		{
			return left.IsProperSubsetOf(right);
		}



		/// <summary>
		///     Determines if the left interval is a subset of the right interval.
		/// </summary>
		/// <param name="left">The left interval operand.</param>
		/// <param name="right">The right interval operand.</param>
		/// <returns>
		///     <see langword="true"/> if the <paramref name="left"/> interval is a subset of the
		///     <paramref name="right"/> interval; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator <=(Interval<T> left, Interval<T> right)
		{
			return left.IsSubsetOf(right);
		}



		/// <summary>
		///     Determines if the left interval is a proper superset of the right interval.
		/// </summary>
		/// <param name="left">The left interval operand.</param>
		/// <param name="right">The right interval operand.</param>
		/// <returns>
		///     <see langword="true"/> if the <paramref name="left"/> interval is a proper superset of
		///     the <paramref name="right"/> interval; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator >(Interval<T> left, Interval<T> right)
		{
			return left.IsProperSupersetOf(right);
		}



		/// <summary>
		/// Determines if the left interval is a superset of the right interval.
		/// </summary>
		/// <param name="left">The left interval operand.</param>
		/// <param name="right">The right interval operand.</param>
		/// <returns>
		///     <see langword="true"/> if the <paramref name="left"/> interval is a proper superset of the
		///     <paramref name="right"/> interval; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator >=(Interval<T> left, Interval<T> right)
		{
			return left.IsSupersetOf(right);
		}



		/// <summary>
		///     Calculates the union between two ranges.
		/// </summary>
		/// <param name="left">The left interval operand.</param>
		/// <param name="right">The right interval operand.</param>
		/// <returns>An interval that hold the values that exists in either of the interval operands.</returns>
		public static Interval<T> operator |(Interval<T> left, Interval<T> right)
		{
			return left.Union(right);
		}



		/// <summary>
		///     Calculates the intersection between two ranges.
		/// </summary>
		/// <param name="left">The left interval operand.</param>
		/// <param name="right">The right interval operand.</param>
		/// <returns>An interval that holds the values that exists in both the intervals.</returns>
		public static Interval<T> operator &(Interval<T> left, Interval<T> right)
		{
			return left.Intersect(right);
		}



		/// <summary>
		///     Calculates the difference between two ranges.
		/// </summary>
		/// <param name="left">The left interval operand.</param>
		/// <param name="right">The right interval operand.</param>
		/// <returns>
		///     The <paramref name="left"/> interval without the values from the
		///     <paramref name="right"/> interval.
		/// </returns>
		public static Interval<T> operator -(Interval<T> left, Interval<T> right)
		{
			return left.Subtract(right);
		}



		/// <summary>
		///     Calculates the symmetric difference between two intervals.
		/// </summary>
		/// <param name="left">The left interval operand.</param>
		/// <param name="right">The right interval operand.</param>
		/// <returns>
		///     A pair of new intervals that together is the symmetric difference of the
		///     <paramref name="left"/> and <paramref name="right"/> intervals, if they overlap;
		///     otherwise, the <paramref name="left"/> and <paramref name="right"/> intervals as they are.
		/// </returns>
		public static Tuple<Interval<T>, Interval<T>> operator ^(Interval<T> left, Interval<T> right)
		{
			return new Tuple<Interval<T>, Interval<T>>(
				left.Subtract(right),
				right.Subtract(left)
			);
		}

		#endregion [ Operators ]



		#region [ Comparison ]

		public bool Equals(Interval<T> other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}

			if (ReferenceEquals(this, other))
			{
				return true;
			}

			return Equals(LowerLimit, other.LowerLimit) && Equals(UpperLimit, other.UpperLimit);
		}



		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			return obj.GetType() == GetType() && Equals((Interval<T>)obj);
		}



		/// <summary>
		///     Determines if the provided value is inside the interval.
		/// </summary>
		/// <param name="x">The value to test</param>
		/// <returns>True if the value is inside Interval, else false</returns>
		/// <exception cref="InvalidOperationException">If the current inteval is not valid.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="x"/> is <see langword="null"/></exception>
		public bool Contains(T x)
		{
			if (x == null)
			{
				throw new ArgumentNullException(nameof(x));
			}

			if (!IsValid())
			{
				throw new InvalidOperationException("Interval is not valid.");
			}

			bool result = true; // first, assume an infinite interval (-∞,∞)

			if (LowerLimit != null)
			{
				if (LowerLimit.Closed)
				{
					result &= LowerLimit.Value.CompareTo(x) <= 0;
				}
				else
				{
					result &= LowerLimit.Value.CompareTo(x) < 0;
				}
			}

			if (UpperLimit != null)
			{
				if (UpperLimit.Closed)
				{
					result &= UpperLimit.Value.CompareTo(x) >= 0;
				}
				else
				{
					result &= UpperLimit.Value.CompareTo(x) > 0;
				}
			}

			return result;
		}



		/// <summary>
		///     Determines whether whether the current interval is contained by a specified interval.
		/// </summary>
		/// <param name="other">The interval to check.</param>
		/// <returns>
		///     <see langword="true"/> if the current interval is inside, or equal to, the specified
		///     interval <paramref name="other"/>; otherwise, <see langword="false"/>.
		/// </returns>
		public bool IsSubsetOf(Interval<T> other)
		{
			if (other == null)
			{
				return false;
			}

			return LowerLimit.GreaterThanOrEqual(other.LowerLimit, Position.Lower) &&
			       UpperLimit.LessThanOrEqual(other.UpperLimit, Position.Upper);
		}



		/// <summary>
		///     Determines whether whether the current interval is contained by a specified interval.
		/// </summary>
		/// <param name="other">The interval to check.</param>
		/// <returns>
		///     <see langword="true"/> if the current interval is inside, and not equal to, the
		///     specified interval <paramref name="other"/>; otherwise, <see langword="false"/>.
		/// </returns>
		public bool IsProperSubsetOf(Interval<T> other)
		{
			if (other == null)
			{
				return false;
			}

			return LowerLimit.GreaterThan(other.LowerLimit, Position.Lower) &&
			       UpperLimit.LessThan(other.UpperLimit, Position.Upper);
		}



		/// <summary>
		///     Determines whether whether a specified interval is contained by the current interval.
		/// </summary>
		/// <param name="other">The interval to check.</param>
		/// <returns>
		///     <see langword="true"/> if the specified interval <paramref name="other"/> is inside,
		///     or equal to, the current interval; otherwise, <see langword="false"/>.
		/// </returns>
		public bool IsSupersetOf(Interval<T> other)
		{
			if (other == null)
			{
				return true;
			}

			return LowerLimit.LessThanOrEqual(other.LowerLimit, Position.Lower) &&
			       UpperLimit.GreaterThanOrEqual(other.UpperLimit, Position.Upper);
		}



		/// <summary>
		///     Determines whether whether a specified interval is contained by the current interval.
		/// </summary>
		/// <param name="other">The interval to check.</param>
		/// <returns>
		///     <see langword="true"/> if the specified interval <paramref name="other"/> is inside,
		///     and not equal to, the current interval; otherwise, <see langword="false"/>.
		/// </returns>
		public bool IsProperSupersetOf(Interval<T> other)
		{
			if (other == null)
			{
				return true;
			}

			return LowerLimit.LessThan(other.LowerLimit, Position.Lower) &&
			       UpperLimit.GreaterThan(other.UpperLimit, Position.Upper);
		}



		/// <summary>
		///     Determines whether the current interval and another specified interval have any
		///     common values.
		/// </summary>
		/// <param name="other">The other interval to check.</param>
		/// <returns>
		///     <see langword="true"/> if the current interval, and the specified interval
		///     <paramref name="other"/> has any common values; otherwise, <see langword="false"/>.
		/// </returns>
		public bool Overlaps(Interval<T> other)
		{
			if (other == null)
			{
				return false;
			}

			throw new NotImplementedException();
		}



		/// <summary>
		///     Determines whether the current interval and another specified interval have any
		///     common values, except the bounds.
		/// </summary>
		/// <param name="other">The other interval to check against.</param>
		/// <returns>
		///     <see langword="true"/> if the current interval, and the specified interval
		///     <paramref name="other"/> has any common values except the bounds; otherwise, <see langword="false"/>.
		/// </returns>
		public bool ProperlyOverlaps(Interval<T> other)
		{
			if (other == null)
			{
				return false;
			}

			throw new NotImplementedException();
		}

		#endregion [ Comparison ]



		#region [ Set Operations ]

		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public Interval<T> Union(Interval<T> other)
		{
			Limit<T> lower;
			if (LowerLimit == null || other.LowerLimit == null)
			{
				//  (..5] U [3..8] = (..8]
				// (2..5] U  (..8] = (..8]
				//  (..5] U  (..8] = (..8]
				lower = null;
			}
			else // both have lower limit values
			{
				// [2..5] U [3..8] = [2..8]
				// (2..5] U [3..8] = (2..8]
				// (2..5] U [2..8] = [2..8]
				if (LowerLimit.Value.CompareTo(other.LowerLimit.Value) < 0)
				{
					// (2..5] U [3..8] = (2..8]
					lower = LowerLimit;
				}
				else if (LowerLimit.Value.CompareTo(other.LowerLimit.Value) > 0)
				{
					// (3..5] U [2..8] = [2..8]
					lower = other.LowerLimit;
				}
				else if (LowerLimit.Closed && !other.LowerLimit.Closed)
				{
					// [3..5] U (3..8] = [3..8]
					lower = LowerLimit;
				}
				else
				{
					// (3..5] U [3..8] = [3..8]
					// [3..5] U [3..8] = [3..8]
					lower = other.LowerLimit;
				}
			}

			Limit<T> upper;
			if (UpperLimit == null || other.UpperLimit == null)
			{
				// (2..)  U [3..8] = (2..)
				// (2..5] U [3..)  = (2..)
				// (2..)  U [3..)  = (2..)
				upper = null;
			}
			else // both have upper limit values
			{
				if (UpperLimit.Value.CompareTo(other.UpperLimit.Value) > 0)
				{
					// [2..8] U [3..5] = [2..8]
					upper = UpperLimit;
				}
				else if (UpperLimit.Value.CompareTo(other.UpperLimit.Value) < 0)
				{
					// [2..5] U [3..8] = [2..8]
					upper = other.UpperLimit;
				}
				else if (UpperLimit.Closed && !other.UpperLimit.Closed)
				{
					// [2..8] U [3..8) = [2..8]
					upper = UpperLimit;
				}
				else
				{
					// [2..8) U [3..8] = [2..8]
					// [2..8] U [3..8] = [3..8]
					upper = other.UpperLimit;
				}
			}

			return new Interval<T>(lower, upper);
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public Interval<T> Intersect(Interval<T> other)
		{
			Limit<T> lower;
			if (LowerLimit == null && other.LowerLimit == null)
			{
				// (..5] ∩ (..8] = (..5]
				lower = null;
			}
			else if (LowerLimit == null)
			{
				// (..5] ∩ [3..8] = [3..5]
				lower = other.LowerLimit;
			}
			else if (other.LowerLimit == null)
			{
				// (2..5] ∩ (..8] = (2..5]
				lower = LowerLimit;
			}
			else // both have lower limit values
			{
				if (LowerLimit.Value.CompareTo(other.LowerLimit.Value) < 0)
				{
					// [2..5] ∩ [3..8] = [3..5]
					lower = other.LowerLimit;
				}
				else if (LowerLimit.Value.CompareTo(other.LowerLimit.Value) > 0)
				{
					// [3..5] ∩ [2..8] = [3..5]
					lower = LowerLimit;
				}
				else if (LowerLimit.Closed && !other.LowerLimit.Closed)
				{
					// [3..5] ∩ (3..8] = (3..5]
					lower = other.LowerLimit;
				}
				else
				{
					// (3..5] ∩ (3..8] = (3..5]
					// (3..5] ∩ [3..8] = (3..5]
					// [3..5] ∩ [3..8] = [3..5]
					lower = LowerLimit;
				}
			}

			Limit<T> upper;
			if (UpperLimit == null && other.UpperLimit == null)
			{
				// (2..) ∩ [3..) = (2..)
				upper = null;
			}
			else if (UpperLimit == null)
			{
				// (2..) ∩ [3..8] = [3..8]
				upper = other.UpperLimit;
			}
			else if (other.UpperLimit == null)
			{
				// (2..5] ∩ [3..) = [3..5]
				upper = UpperLimit;
			}
			else // both have upper limit values
			{
				if (UpperLimit.Value.CompareTo(other.UpperLimit.Value) > 0)
				{
					// (2..8] ∩ [3..5] = [3..5]
					upper = other.UpperLimit;
				}
				else if (UpperLimit.Value.CompareTo(other.UpperLimit.Value) < 0)
				{
					// (2..5] ∩ [3..8] = [3..5]
					upper = UpperLimit;
				}
				else if (UpperLimit.Closed && !other.UpperLimit.Closed)
				{
					// (2..5] ∩ (3..5) = (3..5)
					upper = other.UpperLimit;
				}
				else
				{
					// (2..8] ∩ (3..8] = (3..8]
					// (2..8) ∩ [3..8] = (3..8)
					// (2..8) ∩ [3..8) = [3..8)
					upper = UpperLimit;
				}
			}

			return new Interval<T>(lower, upper);
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public Interval<T> Subtract(Interval<T> other)
		{
			throw new NotImplementedException();
		}

		#endregion [ Set Operations ]



		#region [ Overrides ]

		/// <summary>
		///     Serves as the default hash function.
		/// </summary>
		/// <returns>A hash code for the current interval.</returns>
		public override int GetHashCode()
		{
			unchecked
			{
				int h1 = LowerLimit != null ? LowerLimit.GetHashCode() : 0;
				int h2 = UpperLimit != null ? UpperLimit.GetHashCode() : 0;

				return ((h1 << 5) + h1) ^ h2;
			}
		}



		/// <summary>
		///     Returns a string that represents the current interval.
		/// </summary>
		/// <returns>A string that represents the current interval.</returns>
		public override string ToString()
		{
			return $"{LowerLimit.GetString(Position.Lower)},{UpperLimit.GetString(Position.Upper)}";
		}

		#endregion [ Overrides ]



		/// <summary>
		///     Determines if the interval is valid.
		/// </summary>
		/// <returns><see langword="true"/> if the interval is valid; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		///     The interval is valid if it's either infinite in one or both ends, or finite in both ends and the lower limit is less than
		///     or equal to the upper limit.
		/// </remarks>
		public bool IsValid()
		{
			if (LowerLimit == null || UpperLimit == null)
			{
				return true;
			}

			return LowerLimit.Value.CompareTo(UpperLimit.Value) <= 0;
		}

	}

}
