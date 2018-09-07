using System;


namespace PLib.Utils.Intervals
{
/*

	public enum Kind { Infinite, Open, Closed }



	public enum Position { Undefined, Lower, Upper }



	public sealed class Boundary<T>
	{


		public T        Value    { get; private set; }
		public Kind     Kind     { get; internal set; }
		public Position Position { get; internal set; }



		public Boundary(T value, Kind kind)
		{
			Value    = value;
			Kind     = kind;
			Position = Position.Undefined;
		}



		public override string ToString()
		{
			switch (Position)
			{
				case Position.Undefined:

					throw new NotSupportedException("Cannot render limits not part of an interval.");

				case Position.Lower:

					switch (Kind)
					{
						case Kind.Infinite: return "(-∞";
						case Kind.Open:    return $"({Value}";
						case Kind.Closed:  return $"[{Value}";
						default: throw new ArgumentOutOfRangeException("Not a valid limit type.");
					}

				case Position.Upper:

					switch (Kind)
					{
						case Kind.Infinite: return "+∞";
						case Kind.Open:    return $"{Value})";
						case Kind.Closed:  return $"{Value}]";
						default: throw new ArgumentOutOfRangeException("Not a valid limit type.");
					}

				default:

					throw new ArgumentOutOfRangeException("Not a valid Position value.");
			}

		}

	}
*/

}
