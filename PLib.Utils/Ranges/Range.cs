using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

using PLib.Extensions.Core;

using static PLib.Utils.Ranges.Common;


namespace PLib.Utils.Ranges
{

	/// <summary>
	///     A class that represents an interval of integral numbers, using a lower and an upper
	///     bound. Both bounds are inclusive.
	/// </summary>
	public class Range : IEnumerable<int>, IEquatable<Range>
	{

		#region [ Static ]

		/// <summary>
		///     Creates a new instance of the <see cref="Range"/> class.
		/// </summary>
		/// <param name="first">The start value of the range.</param>
		/// <param name="last">The end value of the range.</param>
		/// <returns>
		///     <para>
		///         A new <see cref="Range"/> with a <see cref="LowerBound"/> set to the minimum
		///         value of <paramref name="first"/> and <paramref name="last"/>, and
		///         <see cref="UpperBound"/> to the maximum value of the same.
		///     </para>
		///     <para>
		///         If <paramref name="first"/> is greater than <paramref name="last"/>,
		///         <see cref="Reverse"/> will be <see langword="true"/>; otherwise, <see langword="false"/>.
		///     </para>
		/// </returns>
		public static Range Create(int first, int last)
		{
			return new Range(first, last);
		}



		/// <summary>
		/// Creates a new instance of the <see cref="Range"/> class.
		/// </summary>
		/// <param name="bounds">A tuple containing the bounds of the range.</param>
		/// <returns>
		///     <para>
		///         A new <see cref="Range"/> with a <see cref="LowerBound"/> set to the minimum
		///         value of two items in the tuple <paramref name="bounds"/>, and
		///         <see cref="UpperBound"/> to the maximum value of the same.
		///     </para>
		///     <para>
		///         If <see cref="Tuple{T1, T2}.Item1"/> is greater than <see cref="Tuple{T1, T2}.Item2"/>,
		///         <see cref="Reverse"/> will be <see langword="true"/>; otherwise, <see langword="false"/>.
		///     </para>
		/// </returns>
		public static Range Create(Tuple<int, int> bounds)
		{
			return new Range(bounds.Item1, bounds.Item2);
		}



		/// <summary>
		///     Converts the specified expression into a new <see cref="Range"/> object.
		/// </summary>
		/// <param name="expression">A string containing an expression to parse, in the format "[&lt;start&gt;..&lt;end&gt;]".</param>
		/// <returns>A new <see cref="Range"/> based on the <paramref name="expression"/>.</returns>
		/// <exception cref="FormatException">
		///     If the format of the <paramref name="expression"/> cannot be interpreted as a range.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		///     If <paramref name="expression"/> is null.
		/// </exception>
		/// <exception cref="TimeoutException">
		///     If there was a time-out when trying to match the <paramref name="expression"/>
		///     against valid formats.
		/// </exception>
		/// <example>
		///     <para>
		///         In the following example a reverse range is created and enumerated. Note that
		///         <see cref="LowerBound"/> will still be 0, and <see cref="UpperBound"/> 10, even
		///         if the enumeration will run in reverse.
		///     </para>
		///     <code>
		/// Console.WriteLine("Countdown...");
		/// foreach (var i in Range.Parse("[10..0]")) { // "[10..0]".ToRange() will also work
		///     Console.WriteLine(i);
		///     Thread.Sleep(1000);
		/// }
		/// Console.WriteLine("Liftoff! We have a liftoff!");
		///     </code>
		/// </example>
		public static Range Parse(string expression)
		{
			if (expression == null)
			{
				throw new ArgumentNullException(nameof(expression));
			}

			Match match;

			try
			{
				match = RxRangeExpression.Value.Match(expression);
			}
			catch (RegexMatchTimeoutException e)
			{
				throw new TimeoutException("A time-out occurred when trying to match the string expression against valid formats.", e);
			}

			if (!match.Success)
			{
				throw new FormatException($"Expression {expression} could not be interpreted.");
			}

			Group startGroup = match.Groups["s"];
			Group endGroup = match.Groups["e"];

			if (!startGroup.Success || !endGroup.Success)
			{
				throw new FormatException($"Expression {expression} could not be interpreted.");
			}

			int start, end;

			try
			{
				start = startGroup.Value.ConvertTo<int>();
				end = endGroup.Value.ConvertTo<int>();
			}
			catch (Exception e)
			{
				throw new FormatException($"Expression {expression} could not be interpreted.", e);
			}

			return new Range(start, end);
		}



		/// <summary>
		///     Tries to convert the specified expression into a new <see cref="Range"/> object.
		///     A return value indicates whether the conversion succeeded.
		/// </summary>
		/// <param name="expression">A string containing an expression to convert.</param>
		/// <param name="range">
		///     A new <see cref="Range"/> based on the <paramref name="expression"/>, if the
		///     conversion succeeds, or <see langword="null"/> if it fails.
		/// </param>
		/// <returns>
		///     <see langword="true"/> if the <paramref name="expression"/> was converted
		///     successfully; otherwise, <see langword="false"/>.
		/// </returns>
		/// <seealso cref="Parse(string)"/>
		public static bool TryParse(string expression, out Range range)
		{
			Exception exception;
			return TryParse(expression, out range, out exception);
		}



		/// <summary>
		///     Tries to convert the specified expression into a new <see cref="Range"/> object. A
		///     return value indicates whether the conversion succeeded.
		/// </summary>
		/// <param name="expression">A string containing an expression to convert.</param>
		/// <param name="range">
		///     A new <see cref="Range"/> based on the <paramref name="expression"/>, if the
		///     conversion succeeds, or <see langword="null"/> if it fails.
		/// </param>
		/// <param name="exception">
		///     An <see cref="Exception"/> describing the cause if the conversion fails, or
		///     <see langword="null"/> if it succeeds.
		/// </param>
		/// <returns>
		///     <see langword="true"/> if the <paramref name="expression"/> was converted
		///     successfully; otherwise, <see langword="false"/>.
		/// </returns>
		/// <seealso cref="Parse(string)"/>
		[SuppressMessage("ReSharper", "CatchAllClause")]
		public static bool TryParse(string expression, out Range range, out Exception exception)
		{
			try
			{
				range = Parse(expression);
				exception = null;
				return true;
			}
			catch (Exception e)
			{
				range = null;
				exception = e;
				return false;
			}
		}

		#endregion [ Static ]



		#region [ Properties ]

		/// <summary>
		///     Gets the lower bound.
		/// </summary>
		public int LowerBound { get; }



		/// <summary>
		///     Gets the upper bound.
		/// </summary>
		public int UpperBound { get; }



		/// <summary>
		///     Gets the length from the lower bound to the upper bound inclusively.
		/// </summary>
		/// <remarks>
		///     The value is always positive regardless of the value of the <see cref="Reverse"/> property.
		/// </remarks>
		public int Length => UpperBound - LowerBound + 1;



		/// <summary>
		///     Gets or sets a value indicating whether this <see cref="Range"/> should be enumerated
		///     in reverse.
		/// </summary>
		/// <value>
		///     <see langword="true"/> if enumeration should be done in reverse, i.e. from
		///     <see cref="UpperBound"/> to <see cref="LowerBound"/>; otherwise,
		///     <see langword="false"/> if if enumeration should be done from
		///     <see cref="LowerBound"/> to <see cref="UpperBound"/>.
		/// </value>
		public bool Reverse { get; set; }

		#endregion [ Properties ]



		#region [ Constructors ]

		/// <summary>
		///     Initializes a new instance of the <see cref="Range"/> class.
		/// </summary>
		/// <param name="first">The start value of the range.</param>
		/// <param name="last">The end value of the range.</param>
		/// <remarks>
		///     <para>
		///         The <see cref="LowerBound"/> will be assigned the minimum value of
		///         <paramref name="first"/> and <paramref name="last"/>, and the
		///         <see cref="UpperBound"/> the maximum value of the same.
		///     </para>
		///     <para>
		///         If <paramref name="first"/> is greater than <paramref name="last"/>,
		///         <see cref="Reverse"/> will be <see langword="true"/>; otherwise, <see langword="false"/>.
		///     </para>
		/// </remarks>
		public Range(int first, int last)
		{
			if (first < last)
			{
				LowerBound = first;
				UpperBound = last;
				Reverse = false;
			}
			else
			{
				LowerBound = last;
				UpperBound = first;
				Reverse = true;
			}
		}

		#endregion [ Constructors ]



		#region [ Operators ]

		/// <summary>
		///     Determines if two range objects are equal.
		/// </summary>
		/// <param name="left">The left range operand.</param>
		/// <param name="right">The right range operand.</param>
		/// <returns>
		///     <see langword="true"/> if both the range operands are equal; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator ==(Range left, Range right)
		{
			return Equals(left, right);
		}



		/// <summary>
		///     Determines if two range objects are not equal.
		/// </summary>
		/// <param name="left">The left range operand.</param>
		/// <param name="right">The right range operand.</param>
		/// <returns>
		///     <see langword="true"/> if both the range operands are not equal; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator !=(Range left, Range right)
		{
			return !Equals(left, right);
		}



		/// <summary>
		///     Determines if the left range is a proper subrange of the right range.
		/// </summary>
		/// <param name="left">The left range operand.</param>
		/// <param name="right">The right range operand.</param>
		/// <returns>
		///     <see langword="true"/> if the <paramref name="left"/> range is a proper subrange of the
		///     <paramref name="right"/> range; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator <(Range left, Range right)
		{
			return left.IsProperSubrangeOf(right);
		}



		/// <summary>
		///     Determines if the left range is a subrange of the right range.
		/// </summary>
		/// <param name="left">The left range operand.</param>
		/// <param name="right">The right range operand.</param>
		/// <returns>
		///     <see langword="true"/> if the <paramref name="left"/> range is a subrange of the
		///     <paramref name="right"/> range; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator <=(Range left, Range right)
		{
			return left.IsSubrangeOf(right);
		}



		/// <summary>
		///     Determines if the left range is a proper superrange of the right range.
		/// </summary>
		/// <param name="left">The left range operand.</param>
		/// <param name="right">The right range operand.</param>
		/// <returns>
		///     <see langword="true"/> if the <paramref name="left"/> range is a proper superrange of
		///     the <paramref name="right"/> range; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator >(Range left, Range right)
		{
			return left.IsProperSuperrangeOf(right);
		}



		/// <summary>
		/// Determines if the left range is a superrange of the right range.
		/// </summary>
		/// <param name="left">The left range operand.</param>
		/// <param name="right">The right range operand.</param>
		/// <returns>
		///     <see langword="true"/> if the <paramref name="left"/> range is a proper superrange of the
		///     <paramref name="right"/> range; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator >=(Range left, Range right)
		{
			return left.IsSuperrangeOf(right);
		}



		/// <summary>
		///     Calculates the union between two ranges.
		/// </summary>
		/// <param name="left">The left range operand.</param>
		/// <param name="right">The right range operand.</param>
		/// <returns>A range that hold the values that exists in either of the operands.</returns>
		public static Range operator |(Range left, Range right)
		{
			return left.Union(right);
		}



		/// <summary>
		///     Calculates the intersection between two ranges.
		/// </summary>
		/// <param name="left">The left range operand.</param>
		/// <param name="right">The right range operand.</param>
		/// <returns>A range that holds the values that exists in both the ranges.</returns>
		public static Range operator &(Range left, Range right)
		{
			return left.Intersect(right);
		}



		/// <summary>
		///     Calculates the difference between two ranges.
		/// </summary>
		/// <param name="left">The left range operand.</param>
		/// <param name="right">The right range operand.</param>
		/// <returns>
		///     The <paramref name="left"/> range without the values from the
		///     <paramref name="right"/> range.
		/// </returns>
		public static Range operator -(Range left, Range right)
		{
			return left.Subtract(right);
		}



		/// <summary>
		///     Calculates the symmetric difference between two ranges.
		/// </summary>
		/// <param name="left">The left range operand.</param>
		/// <param name="right">The right range operand.</param>
		/// <returns>
		///     A pair of new ranges that together is the symmetric difference of the
		///     <paramref name="left"/> and <paramref name="right"/> ranges, if they overlap;
		///     otherwise, the <paramref name="left"/> and <paramref name="right"/> ranges as they are.
		/// </returns>
		public static Tuple<Range, Range> operator ^(Range left, Range right)
		{
			return new Tuple<Range, Range>(
				left.Subtract(right),
				right.Subtract(left)
			);
		}

		#endregion [ Operators ]



		#region [ Comparison ]

		/// <summary>
		///     Determines whether a specified value is inside, or at a bound of, the current range.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <returns>
		///     <see langword="true"/> if the value is inside the current range, including the
		///     bounds; otherwise, <see langword="false"/>.
		/// </returns>
		/// <remarks>
		///     <code>
		/// current         |----------|
		/// other      x                            false
		/// other           x                       TRUE
		/// other                x                  true
		/// other                      x            TRUE
		/// other                            x      false
		///     </code>
		/// </remarks>
		public bool Contains(int value)
		{
			return LowerBound <= value && value <= UpperBound;
		}



		/// <summary>
		///     Determines whether a specified value is inside, but not at a bound of, the current range.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <returns>
		///     <see langword="true"/> if the value is inside the current range, excluding the
		///     bounds; otherwise, <see langword="false"/>.
		/// </returns>
		/// <remarks>
		///     <code>
		/// current         |----------|
		/// other      x                            false
		/// other           x                       FALSE
		/// other                x                  true
		/// other                      x            FALSE
		/// other                            x      false
		///     </code>
		/// </remarks>
		public bool ProperlyContains(int value)
		{
			return LowerBound < value && value < UpperBound;
		}



		/// <summary>
		///     Indicates whether the current range object is equal to another range object of the
		///     same type.
		/// </summary>
		/// <param name="other">A range object to compare with this range object.</param>
		/// <returns>
		///     <see langword="true"/> if the current object is equal to the <paramref name="other"/> parameter;
		///     otherwise, <see langword="false"/>.
		/// </returns>
		public bool Equals(Range other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}

			if (ReferenceEquals(this, other))
			{
				return true;
			}

			return LowerBound == other.LowerBound && UpperBound == other.UpperBound;
		}



		/// <summary>
		///     Determines whether the specified object is equal to the current range object.
		/// </summary>
		/// <param name="other">The object to compare with the current range object.</param>
		/// <returns>
		///     <see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.
		/// </returns>
		public override bool Equals(object other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}

			if (ReferenceEquals(this, other))
			{
				return true;
			}

			return GetType() == other.GetType() && Equals((Range)other);
		}



		/// <summary>
		///     Determines whether the current range and another specified range are contiguous but
		///     not properly overlapping.
		/// </summary>
		/// <param name="other">The other range to check against.</param>
		/// <returns>
		///     <see langword="true"/> if the current range have one bound in common with the
		///     <paramref name="other"/>, but no other values; otherwise, <see langword="false"/>
		/// </returns>
		/// <remarks>
		///     <code>
		/// current         |----------|
		/// other     |-----|                     true
		/// other                      |-----|    true
		/// other   |-----|                       false
		/// other        |-----|                  false
		/// other             |-----|             false
		/// other                   |-----|       false
		/// other                        |-----|  false
		/// other           |----------|          false
		/// other   |--------------------------|  false
		///     </code>
		/// </remarks>
		public bool IsContiguousWith(Range other)
		{
			if (other == null)
			{
				return false;
			}

			return LowerBound.Equals(other.UpperBound) ||
				   UpperBound.Equals(other.LowerBound);
		}



		/// <summary>
		///     Determines whether whether a specified range is contained by the current range.
		/// </summary>
		/// <param name="other">The range to check.</param>
		/// <returns>
		///     <see langword="true"/> if the specified range <paramref name="other"/> is inside, or equal to, the current
		///     range; otherwise, <see langword="false"/>.
		/// </returns>
		/// <remarks><code>
		/// current         |----------|
		/// other            |--------|             true
		/// other           |---------|             true
		/// other            |---------|            true
		/// other           |----------|            TRUE
		/// other      |--------|                   false
		/// other                   |--------|      false
		/// other      |---------------------|      false
		/// other  |----|                           false
		/// other                           |----|  false
		/// </code></remarks>
		public bool IsSuperrangeOf(Range other)
		{
			if (other == null)
			{
				return false;
			}

			return LowerBound.CompareTo(other.LowerBound) <= 0 &&
				   UpperBound.CompareTo(other.UpperBound) >= 0;
		}



		/// <summary>
		///     Determines whether whether a specified range is contained by the current range.
		/// </summary>
		/// <param name="other">The range to check.</param>
		/// <returns>
		///     <see langword="true"/> if the specified range <paramref name="other"/> is inside, and
		///     not equal to, the current range; otherwise, <see langword="false"/>.
		/// </returns>
		/// <remarks>
		///     <code>
		/// current         |----------|
		/// other            |--------|             true
		/// other           |---------|             true
		/// other            |---------|            true
		/// other           |----------|            FALSE
		/// other      |--------|                   false
		/// other                   |--------|      false
		/// other      |---------------------|      false
		/// other  |----|                           false
		/// other                           |----|  false
		///     </code>
		/// </remarks>
		public bool IsProperSuperrangeOf(Range other)
		{
			return IsSuperrangeOf(other) && !Equals(other);
		}



		/// <summary>
		///     Determines whether whether the current range is contained by a specified range.
		/// </summary>
		/// <param name="other">The range to check.</param>
		/// <returns>
		///     <see langword="true"/> if the current range is inside, or equal to, the specified range
		///     <paramref name="other"/>; otherwise, <see langword="false"/>.
		/// </returns>
		/// <remarks>
		///     <code>
		/// other             |----------|
		/// current            |--------|             true
		/// current           |---------|             true
		/// current            |---------|            true
		/// current           |----------|            TRUE
		/// current      |--------|                   false
		/// current                   |--------|      false
		/// current      |---------------------|      false
		/// current  |----|                           false
		/// current                           |----|  false
		///     </code>
		/// </remarks>
		public bool IsSubrangeOf(Range other)
		{
			if (other == null)
			{
				return false;
			}

			return other.IsSuperrangeOf(this);
		}



		/// <summary>
		///     Determines whether whether the current range is contained by a specified range.
		/// </summary>
		/// <param name="other">The range to check.</param>
		/// <returns>
		///     <see langword="true"/> if the current range is inside, and not equal to, the specified range
		///     <paramref name="other"/>; otherwise, <see langword="false"/>.
		/// </returns>
		/// <remarks>
		///     <code>
		/// other             |----------|
		/// current            |--------|             true
		/// current           |---------|             true
		/// current            |---------|            true
		/// current           |----------|            FALSE
		/// current      |--------|                   false
		/// current                   |--------|      false
		/// current      |---------------------|      false
		/// current  |----|                           false
		/// current                           |----|  false
		///     </code>
		/// </remarks>
		public bool IsProperSubrangeOf(Range other)
		{
			return IsSubrangeOf(other) && !Equals(other);
		}



		/// <summary>
		///     Determines whether the current range and another specified range have any common values.
		/// </summary>
		/// <param name="other">The other range to check.</param>
		/// <returns>
		///     <see langword="true"/> if the current range, and the specified range
		///     <paramref name="other"/> has any common values; otherwise, <see langword="false"/>.
		/// </returns>
		/// <remarks>
		///     <code>
		/// current         |----------|
		/// other   |-------|                       TRUE
		/// other      |--------|                   true
		/// other              |-----|              true
		/// other                   |--------|      true
		/// other                      |---------|  TRUE
		/// other      |---------------------|      true
		/// other  |----|                           false
		/// other                           |----|  false
		///     </code>
		/// </remarks>
		public bool Overlaps(Range other)
		{
			if (other == null)
			{
				return false;
			}

			return Contains(other.LowerBound) ||
				   Contains(other.UpperBound) ||
				   other.Contains(LowerBound) ||
				   other.Contains(UpperBound);
		}



		/// <summary>
		///     Determines whether the current range and another specified range have any common
		///     values, except the bounds.
		/// </summary>
		/// <param name="other">The other range to check against.</param>
		/// <returns>
		///     <see langword="true"/> if the current range, and the specified range
		///     <paramref name="other"/> has any common values except the bounds;
		///     otherwise, <see langword="false"/>.
		/// </returns>
		/// <remarks>
		///     <code>
		/// current         |----------|
		/// other   |-------|                       FALSE
		/// other      |--------|                   true
		/// other              |-----|              true
		/// other                   |--------|      true
		/// other                      |---------|  FALSE
		/// other      |---------------------|      true
		/// other  |----|                           false
		/// other                           |----|  false
		///     </code>
		/// </remarks>
		public bool ProperlyOverlaps(Range other)
		{
			if (other == null)
			{
				return false;
			}

			return ProperlyContains(other.LowerBound) ||
				   ProperlyContains(other.UpperBound) ||
				   other.ProperlyContains(LowerBound) ||
				   other.ProperlyContains(UpperBound);
		}

		#endregion [ Comparison ]



		#region [ Set Operations ]

		/// <summary>
		///     Returns the common range between the current and a specified range.
		/// </summary>
		/// <param name="other">The other range.</param>
		/// <returns>
		///     The common range between the current and the specified range, or null if they don't overlap.
		/// </returns>
		/// <remarks>
		///     Any returned range will have the same value of <see cref="Reverse"/> as the current range.
		/// </remarks>
		public Range Intersect(Range other)
		{
			if (other == null || !Overlaps(other))
			{
				return null;
			}

			int lower = LowerBound > other.LowerBound ? LowerBound : other.LowerBound;
			int upper = UpperBound < other.UpperBound ? UpperBound : other.UpperBound;

			return new Range(lower, upper) { Reverse = Reverse };
		}



		/// <summary>
		///     Calculates the union between the current and another range.
		/// </summary>
		/// <param name="other">The other range.</param>
		/// <returns>
		///     <see langword="null"/> if the current range is <see langword="null"/>, the current
		///     range if it's a superrange of the <paramref name="other"/> range, the
		///     <paramref name="other"/> range if it's a superrange of the current, or else a new
		///     range that is the combined ranges from both the current and the
		///     <paramref name="other"/> range if they are contiguous.
		/// </returns>
		/// <exception cref="System.ArgumentException">
		///     if the current range is not contiguous with the <paramref name="other"/> range.
		/// </exception>
		/// <remarks>
		///     Any returned range will have the same value of <see cref="Reverse"/> as the current range.
		/// </remarks>
		public Range Union(Range other)
		{
			if (other == null)
			{
				return this;
			}

			if (IsSuperrangeOf(other))
			{
				return this;
			}

			if (IsSubrangeOf(other))
			{
				return other;
			}

			if (!IsContiguousWith(other))
			{
				throw new ArgumentException("The current range is not contiguous with the other range.");
			}

			int lower = LowerBound < other.LowerBound ? LowerBound : other.LowerBound;
			int upper = UpperBound > other.UpperBound ? UpperBound : other.UpperBound;

			return new Range(lower, upper) { Reverse = Reverse };
		}



		/// <summary>
		///     Removes a subrange from the current range.
		/// </summary>
		/// <param name="other">A range that should be removed from the current range.</param>
		/// <returns>
		///     A copy of the current range where the overlapping subrange of the
		///     <paramref name="other"/> range is removed, <see langword="null"/> if the current
		///     range is a subrange of the <paramref name="other"/>, or the current range if no
		///     overlapping exists.
		/// </returns>
		/// <exception cref="System.ArgumentException">
		///     if the <paramref name="other"/> range is a proper subrange of the current range, and
		///     would lead to a split.
		/// </exception>
		/// <remarks>
		///     <para>Only the subrange that overlaps is removed.</para>
		///     <para>Any returned range will have the same value of <see cref="Reverse"/> as the current range.</para>
		/// </remarks>
		public Range Subtract(Range other)
		{
			if (other == null)
			{
				// this      |----------|
				// other
				// result    |----------|
				return this;
			}

			if (Equals(other) || IsSubrangeOf(other))
			{
				// this      |----------|         |----------|                  |----------|      |----------|
				// other  |----------------|  OR  |----------------|  OR  |----------------|  OR  |----------|
				// result
				return null;
			}

			if (LowerBound < other.LowerBound && UpperBound > other.UpperBound)
			{
				// this   |----------------|
				// other     |----------|
				// result |--|          |--|
				throw new ArgumentException("The other range is a proper subrange of this range, and would lead to a split.");
			}

			if (Overlaps(other))
			{
				int lower;
				if (LowerBound > other.LowerBound && LowerBound < other.UpperBound)
				{
					// this         |----------|
					// other  |----------|
					// result            |-----|
					lower = other.UpperBound;
				}
				else if (LowerBound.Equals(other.LowerBound))
				{
					// this   |----------------|
					// other  |-------------|
					// result               |--|
					lower = other.UpperBound;
				}
				else
				{
					// this   |----------|
					// other        |----------|
					// result |-----|
					lower = LowerBound;
				}

				int upper;
				if (UpperBound.CompareTo(other.LowerBound) > 0 && UpperBound.CompareTo(other.UpperBound) < 0)
				{
					// this   |----------|
					// other        |----------|
					// result |-----|
					upper = other.LowerBound;
				}
				else if (UpperBound.Equals(other.UpperBound))
				{
					// this   |----------------|
					// other     |-------------|
					// result |--|
					upper = other.LowerBound;
				}
				else
				{
					// this         |----------|
					// other  |----------|
					// result            |-----|
					upper = UpperBound;
				}

				return new Range(lower, upper) { Reverse = Reverse };
			}

			return this;
		}



		/// <summary>
		///     Divides the current range in two.
		/// </summary>
		/// <param name="value">The value at which the split should occur.</param>
		/// <returns>
		///     An empty array if the current range is <see langword="null"/>. An array containing the current
		///     range if the <paramref name="value"/> is outside, or at any bound of, the current
		///     range. An array containing two new ranges if the <paramref name="value"/> is strictly
		///     inside the current range, where the first range starts at the current
		///     <see cref="LowerBound"/> and ends at <paramref name="value"/>, and the
		///     second range starts at <paramref name="value"/> and ends at the current <see cref="UpperBound"/>.
		/// </returns>
		/// <remarks>
		///     Any returned range will have the same value of <see cref="Reverse"/> as the current range.
		/// </remarks>
		public Range[] Split(int value)
		{
			if (!Contains(value) || LowerBound == value || UpperBound == value)
			{
				return new[] { this };
			}

			return new[]
			{
				new Range(LowerBound, value) { Reverse = Reverse },
				new Range(value, UpperBound) { Reverse = Reverse }
			};
		}

		#endregion [ Set Operations ]



		#region [ Enumerating ]

		/// <summary>
		///     Returns an enumerator that iterates through this range.
		/// </summary>
		/// <returns>An enumerator that can be used to iterate through this range.</returns>
		public IEnumerator<int> GetEnumerator()
		{
			Sequence s = Reverse ? Sequence.Create(UpperBound, LowerBound) : Sequence.Create(LowerBound, UpperBound);

			return s.GetEnumerator();

			//if (Reverse)
			//{
			//	for (int i = UpperBound; i >= LowerBound; i--)
			//	{
			//		yield return i;
			//	}
			//}
			//else
			//{
			//	for (int i = LowerBound; i <= UpperBound; i++)
			//	{
			//		yield return i;
			//	}
			//}
		}



		/// <summary>
		///     Returns an enumerator that iterates through this range.
		/// </summary>
		/// <returns>
		///     An <see cref="IEnumerator"/> object that can be used to iterate through
		///     this range.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		#endregion [ Enumerating ]



		#region [ Overrides ]

		/// <summary>
		///     Serves as the default hash function.
		/// </summary>
		/// <returns>A hash code for the current range.</returns>
		public override int GetHashCode()
		{
			unchecked
			{
				int h1 = LowerBound.GetHashCode();
				int h2 = UpperBound.GetHashCode();

				return ((h1 << 5) + h1) ^ h2;
			}
		}



		/// <summary>
		///     Returns a string that represents the current range.
		/// </summary>
		/// <returns>A string that represents the current range.</returns>
		public override string ToString()
		{
			return Reverse ? $"[{UpperBound}..{LowerBound}]" : $"[{LowerBound}..{UpperBound}]";
		}

		#endregion [ Overrides ]

	}

}
