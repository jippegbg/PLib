using System;


namespace PLib.Interval
{

	/// <summary>
	///     The Interval class.
	/// </summary>
	/// <typeparam name="T">Generic parameter.</typeparam>
	public class Interval<T> : IEquatable<Interval<T>> where T : IComparable<T>, IEquatable<T>
	{

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
		public static Interval<T> Parse(string expression)
		{
			return expression.ParseInterval<T>();
		}


		/// <summary>
		///     Interprets a string expression as an interval. A return value indicates whether the
		///     conversion succeeded.
		/// </summary>
		/// <param name="expression">A string to interpret.</param>
		/// <param name="interval">
		///     A new interval based on the <paramref name="expression"/>, if the interpretation
		///     succeeds, or <b>null</b> if it fails.
		/// </param>
		/// <param name="exception">
		///     If the interpretation fails, an exception describing the cause, or <b>null</b> if it succeeds.
		/// </param>
		/// <returns>
		///     <b>true</b> if the <paramref name="expression"/> was interpreted successfully;
		///     otherwise, <b>false</b>.
		/// </returns>
		public static bool TryParse(string expression, out Interval<T> interval, out Exception exception)
		{
			try
			{
				interval = expression.ParseInterval<T>();
				exception = null;
				return true;
			}
			catch (Exception e)
			{
				interval = null;
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
		///     succeeds, or <b>null</b> if it fails.
		/// </param>
		/// <returns>
		///     <b>true</b> if the <paramref name="expression"/> was interpreted successfully;
		///     otherwise, <b>false</b>.
		/// </returns>
		public static bool TryParse(string expression, out Interval<T> interval)
		{
			Exception exception;
			return TryParse(expression, out interval, out exception);
		}



		/// <summary>
		///     Performs an implicit conversion from a <see cref="string"/> expression to a
		///     <see cref="Interval{T}"/> object.
		/// </summary>
		/// <param name="expression">The expression to convert.</param>
		/// <returns>A new interval based on the <paramref name="expression"/>.</returns>
		/// <example>
		///     <code>
		/// Interval&lt;int&gt; interval = "1..10"; // the closed interval [1,10]
		///     </code>
		/// </example>
		public static implicit operator Interval<T>(string expression)
		{
			return Parse(expression);
		}



		/// <summary>
		///     Initializes a new interval.
		/// </summary>
		/// <param name="lower">The lower interval limit, or null if infinite.</param>
		/// <param name="upper">The upper interval limit, or null if infinite.</param>
		public Interval(Limit<T> lower, Limit<T> upper)
		{
			LowerLimit = lower;
			UpperLimit = upper;
		}



		/// <summary>
		///     Initializes a new interval.
		/// </summary>
		/// <param name="lowerValue">The lower limit value, or null if infinite.</param>
		/// <param name="lowerInclusive">
		///     A value that determines whether the lower limit value should be included (closed) or
		///     not (open). Discarded if <paramref name="lowerValue"/> is null.
		/// </param>
		/// <param name="upperValue">The upper limit value, or null if infinite.</param>
		/// <param name="upperInclusive">
		///     A value that determines whether the upper limit value should be included (closed) or
		///     not (open). Discarded if <paramref name="upperValue"/> is null.
		/// </param>
		public Interval(T lowerValue, bool lowerInclusive, T upperValue, bool upperInclusive)
		{
			if (lowerValue != null)
			{
				LowerLimit = new Limit<T>(lowerValue, lowerInclusive);
			}

			if (upperValue != null)
			{
				UpperLimit = new Limit<T>(upperValue, upperInclusive);
			}
		}



		/// <summary>
		///     Initializes a new fully closed interval.
		/// </summary>
		/// <param name="lowerValue">The closed lower limit value, or null if infinite.</param>
		/// <param name="upperValue">The closed upper limit value, or null if infinite.</param>
		public Interval(T lowerValue, T upperValue)
		{
			if (lowerValue != null)
			{
				LowerLimit = new Limit<T>(lowerValue);
			}

			if (upperValue != null)
			{
				UpperLimit = new Limit<T>(upperValue);
			}
		}



		/// <summary>
		///     The lower limit of the interval.
		/// </summary>
		public Limit<T> LowerLimit { get; }



		/// <summary>
		///     The upper limit of the interval.
		/// </summary>
		public Limit<T> UpperLimit { get; }



		/// <summary>
		///     Determines if the interval is closed on both ends.
		/// </summary>
		public bool Closed => LowerLimit != null && LowerLimit.Inclusive && UpperLimit != null && UpperLimit.Inclusive;



		public bool Open => (LowerLimit == null || LowerLimit.Exclusive) && (UpperLimit == null || UpperLimit.Exclusive);



		/// <summary>
		///     Determines if the interval is closed to the left but not to the right.
		/// </summary>
		/// <remarks>Same as <see cref="RightOpen"/>.</remarks>
		public bool LeftClosed => LowerLimit != null && LowerLimit.Inclusive && (UpperLimit == null || UpperLimit.Exclusive);



		/// <summary>
		///     Determines if the interval is open to the right but not to the left.
		/// </summary>
		/// <remarks>Same as <see cref="LeftClosed"/>.</remarks>
		public bool RightOpen => LeftClosed;



		/// <summary>
		///     Determines if the interval is closed to the right but not to the left.
		/// </summary>
		/// <remarks>Same as <see cref="LeftOpen"/>.</remarks>
		public bool RightClosed => (LowerLimit == null || LowerLimit.Exclusive) && UpperLimit != null && UpperLimit.Inclusive;



		/// <summary>
		///     Determines if the interval is open to the left but not to the right.
		/// </summary>
		/// <remarks>Same as <see cref="RightClosed"/>.</remarks>
		public bool LeftOpen => RightClosed;



		/// <summary>
		///     Determines if the interval is infinite at both ends.
		/// </summary>
		public bool Infinite => LowerLimit == null && UpperLimit == null;



		/// <summary>
		///     Determines if the interval is infinite on the left side but not on the right side.
		/// </summary>
		public bool LeftInfinite => LowerLimit == null && UpperLimit != null;



		/// <summary>
		///     Determines if the interval is infinite on the right side but not on the left side.
		/// </summary>
		public bool RightInfinite => LowerLimit != null && UpperLimit == null;



		/// <summary>
		///     Presents the Interval in readable format.
		/// </summary>
		/// <returns>String representation of the Interval</returns>
		public override string ToString()
		{
			return $"{LowerLimit.GetString(Position.Lower)},{UpperLimit.GetString(Position.Upper)}";
		}



		/// <summary>
		///     Determines if the interval is valid.
		/// </summary>
		/// <returns><b>true</b> if the interval is valid; otherwise, <b>false</b>.</returns>
		/// <remarks>
		///     The interval is valid if it's either open in one end, or closed in both ends and the lower limit is less than
		///     or equal to the upper limit.
		/// </remarks>
		public bool IsValid()
		{
			// If any of the limits are infinite, the interval is always valid.
			if (LowerLimit != null && UpperLimit != null)
			{
				return LowerLimit.Value.CompareTo(UpperLimit.Value) <= 0;
			}

			return true;
		}



		/// <summary>
		///     Determines if the provided value is inside the interval.
		/// </summary>
		/// <param name="x">The value to test</param>
		/// <returns>True if the value is inside Interval, else false</returns>
		public bool ContainsValue(T x)
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
				if (LowerLimit.Inclusive)
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
				if (UpperLimit.Inclusive)
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
		/// TODO: Edit XML Comment
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool IsSubsetOf(Interval<T> other)
		{
			throw new NotImplementedException();
		}


		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool IsProperSubsetOf(Interval<T> other)
		{
			throw new NotImplementedException();
		}


		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool IsSupersetOf(Interval<T> other)
		{
			throw new NotImplementedException();
		}


		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool IsProperSupersetOf(Interval<T> other)
		{
			throw new NotImplementedException();
		}


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
				else if (LowerLimit.Inclusive && !other.LowerLimit.Inclusive)
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
				else if (UpperLimit.Inclusive && !other.UpperLimit.Inclusive)
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
				else if (LowerLimit.Inclusive && !other.LowerLimit.Inclusive)
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
				else if (UpperLimit.Inclusive && !other.UpperLimit.Inclusive)
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
		public Interval<T> Difference(Interval<T> other)
		{
			throw new NotImplementedException();
		}



		/// <inheritdoc />
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



		/// <inheritdoc />
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



		/// <inheritdoc />
		public override int GetHashCode()
		{
			unchecked
			{
				int h1 = LowerLimit != null ? LowerLimit.GetHashCode() : 0;
				int h2 = UpperLimit != null ? UpperLimit.GetHashCode() : 0;

				return ((h1 << 5) + h1) ^ h2;
			}
		}

	}

}
