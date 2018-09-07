using System;


namespace PLib.Utils.Intervals
{

	public sealed class LimitOld<T> : IEquatable<LimitOld<T>> where T : IComparable<T>, IEquatable<T>
	{

		/// <summary>
		///     Initializes a new instance of the <see cref="LimitOld{T}"/> class.
		/// </summary>
		/// <param name="value">The value of the limit.</param>
		/// <param name="closed">
		///     <see langword="true"/> if the limit should be closed (included); or
		///     <see langword="false"/> if should be open (excluded).
		///     <para/>
		///     Optional. Default true (closed).
		/// </param>
		public LimitOld(T value, bool closed = true)
		{
			Value  = value;
			Closed = closed;
		}



		/// <summary>
		///     The actual value of the limit.
		/// </summary>
		public T Value { get; }



		/// <summary>
		///     Gets whether the limit is closed (included).
		/// </summary>
		public bool Closed { get; }



		/// <summary>
		///     Gets whether the limit is open (excluded).
		/// </summary>
		public bool Open => !Closed;



		public bool Equals(LimitOld<T> other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}

			if (ReferenceEquals(this, other))
			{
				return true;
			}

			return Value.Equals(other.Value) && Closed == other.Closed;
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

			return obj.GetType() == GetType() && Equals((LimitOld<T>)obj);
		}



		public override int GetHashCode()
		{
			unchecked
			{
				int h1 = Value.GetHashCode();
				int h2 = Closed.GetHashCode();

				return ((h1 << 5) + h1) ^ h2;
			}
		}


		// TODO: Adjust these operators to consider if the limits are closed or open.

		public static bool operator <(LimitOld<T> left, LimitOld<T> right)
		{
			return left.Value.CompareTo(right.Value) < 0;
		}



		public static bool operator >(LimitOld<T> left, LimitOld<T> right)
		{
			return left.Value.CompareTo(right.Value) > 0;
		}



		public static bool operator ==(LimitOld<T> left, LimitOld<T> right)
		{
			return Equals(left, right);
		}



		public static bool operator !=(LimitOld<T> left, LimitOld<T> right)
		{
			return !(left == right);
		}

	}

}
