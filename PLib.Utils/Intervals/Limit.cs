using System;
using System.Collections.Generic;


namespace PLib.Utils.Intervals
{

	public enum LimitPosition { Lower, Upper, Undefined }

	public enum LimitType { Closed, Open, Infinite }



	public class Limit<T> : IEquatable<Limit<T>> where T : IComparable<T>, IEquatable<T>
	{

		public Limit(T value, LimitType type)
		{
			Value    = value;
			Type     = type;
			Position = LimitPosition.Undefined;
		}



		internal Limit(T value, LimitType type, LimitPosition pos)
		{
			Value    = value;
			Type     = type;
			Position = pos;
		}



		public LimitPosition Position { get; }
		public LimitType     Type     { get; }
		public T             Value    { get; }


		public bool Closed => Type == LimitType.Closed;

		public bool Open => Type == LimitType.Open;

		public bool Infinite => Type == LimitType.Infinite;

		public bool Lower => Position == LimitPosition.Lower;

		public bool Upper => Position == LimitPosition.Upper;

		public bool LowerClosed => Lower && Closed;

		public bool LowerOpen => Lower && Open;

		public bool LowerInfinite => Lower && Infinite;

		public bool UpperClosed => Upper && Closed;

		public bool UpperOpen => Upper && Open;

		public bool UpperInfinite => Upper && Infinite;



		public int CompareTo(Limit<T> other)
		{
			throw new NotImplementedException();
		}



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

			return Position == other.Position && Type == other.Type && EqualityComparer<T>.Default.Equals(Value, other.Value);
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
				int hashCode = (int)Position;
				hashCode = (hashCode * 397) ^ (int)Type;
				hashCode = (hashCode * 397) ^ EqualityComparer<T>.Default.GetHashCode(Value);
				return hashCode;
			}
		}



		public static bool operator ==(Limit<T> left, Limit<T> right)
		{
			return Equals(left, right);
		}



		public static bool operator !=(Limit<T> left, Limit<T> right)
		{
			return !Equals(left, right);
		}



		public static bool operator <(Limit<T> left, Limit<T> right)
		{
			return left.CompareTo(right) < 0;
		}



		public static bool operator >(Limit<T> left, Limit<T> right)
		{
			return left.CompareTo(right) > 0;
		}



		public static bool operator <=(Limit<T> left, Limit<T> right)
		{
			return left.CompareTo(right) <= 0;
		}



		public static bool operator >=(Limit<T> left, Limit<T> right)
		{
			return left.CompareTo(right) >= 0;
		}

	}

	/*public class Limit<T> : IComparable<Limit<T>>, IEquatable<Limit<T>> where T : IComparable<T>, IEquatable<T>
	{

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <param name="closed"></param>
		public Limit(T value, bool closed = true)
		{
			Value    = value;
			Closed   = closed;
			Position = Position.Undefined;
		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <param name="closed"></param>
		/// <param name="pos"></param>
		internal Limit(T value, bool closed, Position pos)
		{
			Value    = value;
			Closed   = closed;
			Position = pos;
		}



		/// <summary>
		/// 
		/// </summary>
		public T Value { get; }



		/// <summary>
		/// 
		/// </summary>
		public bool Closed { get; }



		public bool Inclusive => Closed;
		public bool Exclusive => !Closed;



		/// <summary>
		/// 
		/// </summary>
		public bool Open => !Closed;



		/// <summary>
		/// 
		/// </summary>
		public Position Position { get; internal set; }



		public bool Lower => Position == Position.Lower;

		public bool Upper => Position == Position.Upper;




		/// <inheritdoc />
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

			return EqualityComparer<T>.Default.Equals(Value, other.Value) &&
			       Closed == other.Closed &&
			       Position == other.Position;
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

			return obj.GetType() == GetType() && Equals((Limit<T>)obj);
		}



		/// <inheritdoc />
		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = EqualityComparer<T>.Default.GetHashCode(Value);
				hashCode = (hashCode * 397) ^ Closed.GetHashCode();
				hashCode = (hashCode * 397) ^ (int)Position;
				return hashCode;
			}
		}



		/// <inheritdoc />
		public int CompareTo(Limit<T> other)
		{
			if (ReferenceEquals(this, other))
			{
				return 0;
			}



			/*if (ReferenceEquals(null, other))
			{
				return 1;
			}

			int valueComparison = Value.CompareTo(other.Value);
			if (valueComparison != 0)
			{
				return valueComparison;
			}

			int closedComparison = Closed.CompareTo(other.Closed);
			if (closedComparison != 0)
			{
				return closedComparison;
			}

			return Position.CompareTo(other.Position);#1#
		}



		public static bool operator ==(Limit<T> left, Limit<T> right)
		{
			return Equals(left, right);
		}



		public static bool operator !=(Limit<T> left, Limit<T> right)
		{
			return !Equals(left, right);
		}



		public static bool operator <(Limit<T> left, Limit<T> right)
		{
			return left.CompareTo(right) < 0;
		}



		public static bool operator >(Limit<T> left, Limit<T> right)
		{
			return left.CompareTo(right) > 0;
		}



		public static bool operator <=(Limit<T> left, Limit<T> right)
		{
			return left.CompareTo(right) <= 0;
		}



		public static bool operator >=(Limit<T> left, Limit<T> right)
		{
			return left.CompareTo(right) >= 0;
		}

	}*/

}
