using System;
using System.Collections.Generic;


namespace PLib.Interval
{

	public class Range<T> : IEquatable<Range<T>> where T : IComparable<T>, IEquatable<T>
	{

		public static Range<T> Create(T lower, T upper)
		{
			return new Range<T>(lower, upper);
		}



		public static Range<T> Create(Tuple<T, T> bounds)
		{
			return new Range<T>(bounds.Item1, bounds.Item2);
		}



		public static Range<T> Parse(string expression)
		{
			throw new NotImplementedException();
		}



		public static bool TryParse(string expression, out Range<T> range)
		{
			Exception exception;
			return TryParse(expression, out range, out exception);
		}



		public static bool TryParse(string expression, out Range<T> range, out Exception exception)
		{
			try
			{
				range     = Parse(expression);
				exception = null;
				return true;
			}
			catch (Exception e)
			{
				range     = null;
				exception = e;
				return false;
			}
		}



		public static implicit operator Range<T>(string expression)
		{
			return Parse(expression);
		}



		public T LowerBound { get; }
		public T UpperBound { get; }



		internal Range(T lowerBound, T upperBound)
		{
			if (lowerBound == null)
			{
				throw new ArgumentNullException(nameof(lowerBound));
			}

			if (upperBound == null)
			{
				throw new ArgumentNullException(nameof(upperBound));
			}

			if (lowerBound.CompareTo(upperBound) > 0)
			{
				throw new ArgumentException("Lower bound is greater than upper bound.");
			}

			LowerBound = lowerBound;
			UpperBound = upperBound;
		}



		public bool Contains(T value)
		{
			if (value == null)
			{
				return false;
			}

			return LowerBound.CompareTo(value) <= 0 && UpperBound.CompareTo(value) >= 0;
		}



		public bool ProperlyContains(T value)
		{
			if (value == null)
			{
				return false;
			}

			return LowerBound.CompareTo(value) < 0 && UpperBound.CompareTo(value) > 0;
		}



		public bool IsSupersetOf(Range<T> other)
		{
			if (other == null)
			{
				return false;
			}

			return LowerBound.CompareTo(other.LowerBound) <= 0 && UpperBound.CompareTo(other.UpperBound) >= 0;
		}



		public bool IsProperSupersetOf(Range<T> other)
		{
			return IsSupersetOf(other) && !Equals(other);
		}



		public bool IsSubsetOf(Range<T> other)
		{
			if (other == null)
			{
				return false;
			}

			return other.IsSupersetOf(this);
		}



		public bool IsProperSubsetOf(Range<T> other)
		{
			return IsSubsetOf(other) && !Equals(other);
		}



		public bool Overlaps(Range<T> other)
		{
			if (other == null)
			{
				return false;
			}

			return Contains(other.LowerBound) || Contains(other.UpperBound) || other.Contains(LowerBound) || other.Contains(UpperBound);

			//         |-------------|
			//     |--------|                  true
			//             |-----|             true
			//                  |--------|	   true
			//     |---------------------|	   true
			// |----|                          false
			//                          |----| false
		}



		public bool IsContiguousWith(Range<T> other)
		{
			if (other == null)
			{
				return false;
			}

			return Overlaps(other) ||
			       LowerBound.Equals(other.UpperBound) ||
			       UpperBound.Equals(other.LowerBound);
		}



		public Range<T> Intersect(Range<T> other)
		{
			if (other == null || !Overlaps(other))
			{
				return null;
			}

			T lower = LowerBound.CompareTo(other.LowerBound) > 0 ? LowerBound : other.LowerBound;
			T upper = UpperBound.CompareTo(other.UpperBound) < 0 ? UpperBound : other.UpperBound;

			return new Range<T>(lower, upper);
		}



		public Range<T> Union(Range<T> other)
		{
			if (other == null)
			{
				return this;
			}

			if (IsSupersetOf(other))
			{
				return this;
			}

			if (IsSubsetOf(other))
			{
				return other;
			}

			T lower = LowerBound.CompareTo(other.LowerBound) < 0 ? LowerBound : other.LowerBound;
			T upper = UpperBound.CompareTo(other.UpperBound) > 0 ? UpperBound : other.UpperBound;

			return new Range<T>(lower, upper);
		}



		public Range<T> Subtract(Range<T> other)
		{
			if (other == null)
			{
				// this      |----------|
				// other
				// result    |----------|
				return this;
			}

			if (Equals(other) || IsSubsetOf(other))
			{
				// this      |----------|         |----------|                  |----------|      |----------|
				// other  |----------------|  OR  |----------------|  OR  |----------------|  OR  |----------|
				// result
				return null;
			}

			if (LowerBound.CompareTo(other.LowerBound) < 0 && UpperBound.CompareTo(other.UpperBound) > 0)
			{
				// this   |----------------|
				// other     |----------|
				// result |--|          |--|
				throw new ArgumentException("The other range is fully contained by this range, and would lead to a split.");
			}

			if (Overlaps(other))
			{
				T lower;
				if (LowerBound.CompareTo(other.LowerBound) > 0 && LowerBound.CompareTo(other.UpperBound) < 0)
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

				T upper;
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

				return new Range<T>(lower, upper);
			}

			return this;
		}



		public Range<T>[] Split(T value)
		{
			if (value == null || !Contains(value) || LowerBound.Equals(value) || UpperBound.Equals(value))
			{
				return new[] { this };
			}

			return new[] { new Range<T>(LowerBound, value), new Range<T>(value, UpperBound) };
		}



		public IEnumerable<T> Iterate(Func<T, T> increment)
		{
			if (increment == null)
			{
				throw new ArgumentNullException(nameof(increment));
			}

			T current = LowerBound;
			do
			{
				yield return current;
				current = increment(current);
			}
			while (UpperBound.CompareTo(current) >= 0);
		}



		public IEnumerable<T> IterateReverse(Func<T, T> decrement)
		{
			if (decrement == null)
			{
				throw new ArgumentNullException(nameof(decrement));
			}

			T current = UpperBound;
			do
			{
				yield return current;
				current = decrement(current);
			}
			while (LowerBound.CompareTo(current) <= 0);
		}



		public bool Equals(Range<T> other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}

			if (ReferenceEquals(this, other))
			{
				return true;
			}

			return LowerBound.Equals(other.LowerBound) &&
			       UpperBound.Equals(other.UpperBound);
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

			return obj.GetType() == GetType() && Equals((Range<T>)obj);
		}



		public override int GetHashCode()
		{
			unchecked
			{
				int h1 = LowerBound.GetHashCode();
				int h2 = UpperBound.GetHashCode();

				return ((h1 << 5) + h1) ^ h2;
			}

			//unchecked
			//{
			//	return (LowerBound.GetHashCode() * 397) ^ UpperBound.GetHashCode();
			//}
		}



		public static bool operator ==(Range<T> left, Range<T> right)
		{
			return Equals(left, right);
		}



		public static bool operator !=(Range<T> left, Range<T> right)
		{
			return !Equals(left, right);
		}

	}



	public static class RangeExtensions
	{

		public static Range<T> To<T>(this T lower, T upper) where T : IComparable<T>, IEquatable<T>
		{
			return new Range<T>(lower, upper);
		}



		public static string Substring<T>(this string @this, Range<int> range) where T : IComparable<T>, IEquatable<T>
		{
			return @this.Substring(range.LowerBound, range.UpperBound - range.LowerBound + 1);
		}

	}

}
