using System;


namespace PLib.Interval
{

	public sealed class Limit<T> : IEquatable<Limit<T>> where T : IComparable<T>, IEquatable<T>
	{

		/// <summary>
		///     Initializes a new instance of the <see cref="Limit{T}"/> class.
		/// </summary>
		/// <param name="value">The value of the limit.</param>
		/// <param name="inclusive">
		///     A value that determines whether the limit value should be included (closed) or not (open).
		///     Optional. Default true.
		/// </param>
		public Limit(T value, bool inclusive = true)
		{
			Value     = value;
			Inclusive = inclusive;
		}



		/// <summary>
		///     The actual value of the limit.
		/// </summary>
		public T Value { get; }



		/// <summary>
		///     States whether the value should be included (closed) or not (open).
		/// </summary>
		public bool Inclusive { get; }


		/// <summary>
		///     States whether the value should be excluded (open) or not (closed).
		/// </summary>
		public bool Exclusive => !Inclusive;



		public bool Equals(Limit<T> other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}

			if (ReferenceEquals(this, other))
			{
				return true;
			}

			return Value.Equals(other.Value) && Inclusive == other.Inclusive;
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

			return obj.GetType() == GetType() && Equals((Limit<T>)obj);
		}



		public override int GetHashCode()
		{
			unchecked
			{
				int h1 = Value.GetHashCode();
				int h2 = Inclusive.GetHashCode();

				return ((h1 << 5) + h1) ^ h2;
			}
		}

	}



	public static class LimitExtensions
	{

		public static string GetString<T>(this Limit<T> limit, Position pos) where T : IComparable<T>, IEquatable<T>
		{
			switch (pos)
			{
				case Position.Lower:

					if (limit == null)
					{
						return "(-∞";
					}

					return $"{(limit.Inclusive ? "[" : "(")}{limit.Value}";

				case Position.Upper:

					if (limit == null)
					{
						return "+∞)";
					}

					return $"{limit.Value}{(limit.Inclusive ? "]" : ")")}";

				default:

					throw new NotSupportedException();
			}
		}

	}

}
