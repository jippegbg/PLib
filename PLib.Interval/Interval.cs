using System;
using System.Text;


namespace PLib.Interval
{

	/// <summary>
	///     The Interval class.
	/// </summary>
	/// <typeparam name="T">Generic parameter.</typeparam>
	public struct Interval<T> : IEquatable<Interval<T>> where T : IComparable<T>, IEquatable<T>
	{

		/// <summary>
		///     Interprets a string expression as an interval.
		/// </summary>
		/// <param name="expression">A string to interpret.</param>
		/// <returns>A new interval based on the <paramref name="expression"/>.</returns>
		/// <example>
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
		/// </example>
		public static Interval<T> Parse(string expression)
		{
			throw new NotImplementedException();
		}



		/// <summary>
		///     Performs an implicit conversion from a <see cref="string"/> expression to a
		///     <see cref="Interval{T}"/> object.
		/// </summary>
		/// <param name="expression">The expression to convert.</param>
		/// <returns>A new interval based on the <paramref name="expression"/>.</returns>
		public static implicit operator Interval<T>(string expression)
		{
			return Parse(expression);
		}



		/// <summary>
		///     Initializes a new instance of the <see cref="Interval{T}"/> class.
		/// </summary>
		/// <param name="minimum">The minimum interval value.</param>
		/// <param name="maximum">The maximum interval value.</param>
		public Interval(IntervalValue<T> minimum, IntervalValue<T> maximum)
		{
			Minimum = minimum;
			Maximum = maximum;
		}



		/// <summary>
		///     Minimum value of the interval.
		/// </summary>
		public IntervalValue<T>? Minimum { get; }



		/// <summary>
		///     Maximum value of the interval.
		/// </summary>
		public IntervalValue<T>? Maximum { get; }



		/// <summary>
		///     Presents the Interval in readable format.
		/// </summary>
		/// <returns>String representation of the Interval</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append(Minimum.HasValue ? Minimum.Value.ToString(IntervalNotationPosition.Left) : "(-∞");
			sb.Append(',');
			sb.Append(Maximum.HasValue ? Maximum.Value.ToString(IntervalNotationPosition.Right) : "+∞)");

			return sb.ToString();
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
			if (Minimum.HasValue && Maximum.HasValue)
			{
				return Minimum.Value.Value.CompareTo(Maximum.Value.Value) <= 0;
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

			bool result = true; // (-∞,∞)

			if (Minimum.HasValue)
			{
				switch (Minimum.Value.ValueType)
				{
					case IntervalValueType.Exclusive:
						result &= Minimum.Value.Value.CompareTo(x) < 0;
						break;

					case IntervalValueType.Inclusive:
						result &= Minimum.Value.Value.CompareTo(x) <= 0;
						break;

					default:
						throw new NotSupportedException();
				}
			}

			if (Maximum.HasValue)
			{
				switch (Maximum.Value.ValueType)
				{
					case IntervalValueType.Exclusive:
						result &= Maximum.Value.Value.CompareTo(x) > 0;
						break;

					case IntervalValueType.Inclusive:
						result &= Maximum.Value.Value.CompareTo(x) >= 0;
						break;

					default:
						throw new NotSupportedException();
				}
			}

			return result;
		}



		public bool IsSubsetOf(Interval<T> other)
		{
			throw new NotImplementedException();
		}



		public bool IsProperSubsetOf(Interval<T> other)
		{
			throw new NotImplementedException();
		}



		public bool IsSupersetOf(Interval<T> other)
		{
			throw new NotImplementedException();
		}



		public bool IsProperSupersetOf(Interval<T> other)
		{
			throw new NotImplementedException();
		}



		public Interval<T> Union(Interval<T> other)
		{
			throw new NotImplementedException();
		}



		public Interval<T> Intersect(Interval<T> other)
		{
			throw new NotImplementedException();
		}



		public Interval<T> Difference(Interval<T> other)
		{
			throw new NotImplementedException();
		}



		/// <inheritdoc />
		public bool Equals(Interval<T> other)
		{
			return Minimum.Equals(other.Minimum) && Maximum.Equals(other.Maximum);
		}



		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			return obj is Interval<T> && Equals((Interval<T>)obj);
		}



		/// <inheritdoc />
		public override int GetHashCode()
		{
			unchecked
			{
				int h1 = Minimum.GetHashCode();
				int h2 = Maximum.GetHashCode();

				return ((h1 << 5) + h1) ^ h2;
			}
		}



		public static bool operator ==(Interval<T> left, Interval<T> right)
		{
			return left.Equals(right);
		}



		public static bool operator !=(Interval<T> left, Interval<T> right)
		{
			return !left.Equals(right);
		}

	}

}
