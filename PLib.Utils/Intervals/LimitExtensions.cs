using System;


namespace PLib.Utils.Intervals
{

	public static class LimitExtensions
	{

		private static readonly NotSupportedException DefaultException = new NotSupportedException("Undefined position not supported.");


		public static string GetString<T>(this Limit<T> limit, Position pos) where T : IComparable<T>, IEquatable<T>
		{
			switch (pos)
			{
				case Position.Lower:

					if (limit == null)
					{
						return "(-∞";
					}

					return $"{(limit.Closed ? "[" : "(")}{limit.Value}";

				case Position.Upper:

					if (limit == null)
					{
						return "+∞)";
					}

					return $"{limit.Value}{(limit.Closed ? "]" : ")")}";

				default:

					throw DefaultException;
			}
		}



		public static bool LessThan<T>(this Limit<T> @this, Limit<T> other) where T : IComparable<T>, IEquatable<T>
		{
			if (@this.LowerInfinite) // assuming @this.LowerInfinite
			{
				return other != null && other.Lower;
			}

			if (other == null) // assuming other.UpperInfinite
			{
				return @this.Upper;
			}


			if (@this.Value.Equals(other.Value))
			{
				if (@this.Lower)
				{
					if (@this.Closed)
					{
						//     [---
						//     [--- false
						//     (--- true
						//  ---)    false
						//  ---]    false
						return other.Lower && other.Open;
					}

					// else @this.Open
					//     (---
					//     [--- false
					//     (--- false
					//  ---)    false
					//  ---]    false
					return false;
				}

				if (@this.Upper)
				{
					if (@this.Open)
					{
						//  ---)
						//     [--- true
						//     (--- true
						//  ---)    false
						//  ---]    true
						return other.Lower || other.Closed;
					}

					// else @this.Closed
					//  ---]
					//     [--- false
					//     (--- true
					//  ---)    false
					//  ---]    false
					return other.Lower && other.Open;
				}

				// else @this.Position == Position.Undefined
			}

			return @this.Value.CompareTo(other.Value) < 0;
		}



		public static bool LessThanOrEqual<T>(this Limit<T> @this, Limit<T> other) where T : IComparable<T>, IEquatable<T>
		{
			if (@this == null) // assuming @this.LowerInfinite
			{
				return other == null || other.Lower;
			}

			if (other == null) // assuming other.UpperInfinite
			{
				return @this.Upper;
			}

			if (@this.Value.Equals(other.Value))
			{
				if (@this.Lower)
				{
					if (@this.Closed)
					{
						//     [---
						//     [--- true
						//     (--- true
						//  ---)    false
						//  ---]    true
						return other.Lower || other.Closed;
					}

					// else @this.Open
					//     (---
					//     [--- false
					//     (--- true
					//  ---)    false
					//  ---]    false
					return other.Lower && other.Open;
				}

				if (@this.Upper)
				{
					if (@this.Open)
					{
						//  ---)
						//     [--- true
						//     (--- true
						//  ---)    true
						//  ---]    true
						return true;
					}

					// else @this.Closed
					//  ---]
					//     [--- true
					//     (--- true
					//  ---)    false
					//  ---]    true
					return other.Lower || other.Closed;
				}

				// else @this.Position == Position.Undefined
			}

			return @this.Value.CompareTo(other.Value) < 0;
		}



		public static bool GreaterThan<T>(this Limit<T> @this, Limit<T> other) where T : IComparable<T>, IEquatable<T>
		{
			if (@this == null) // assuming @this.UpperInfinite
			{
				return other != null && other.Upper;
			}

			if (other == null) // assuming other.LowerInfinite
			{
				return @this.Lower;
			}

			if (@this.Value.Equals(other.Value))
			{
				if (@this.Lower)
				{
					if (@this.Closed)
					{
						//     [---
						//     [--- false
						//     (--- false
						//  ---)    true
						//  ---]    false
						return other.Upper && other.Open;
					}

					// else @this.Open
					//     (---
					//     [--- true
					//     (--- false
					//  ---)    true
					//  ---]    true
					return other.Upper || other.Closed;
				}

				if (@this.Upper)
				{
					if (@this.Open)
					{
						//  ---)
						//     [--- false
						//     (--- false
						//  ---)    false
						//  ---]   	false
						return false;
					}

					// else @this.Closed
					//  ---]
					//     [--- false
					//     (--- false
					//  ---)    true
					//  ---]    false
					return other.Upper && other.Open;
				}

				// else @this.Position == Position.Undefined
			}

			return @this.Value.CompareTo(other.Value) > 0;
		}



		public static bool GreaterThanOrEqual<T>(this Limit<T> @this, Limit<T> other) where T : IComparable<T>, IEquatable<T>
		{
			if (@this == null) // assuming @this.UpperInfinite
			{
				return other == null || other.Upper;
			}

			if (other == null) // assuming other.LowerInfinite
			{
				return @this.Lower;
			}

			if (@this.Value.Equals(other.Value))
			{
				if (@this.Lower)
				{
					if (@this.Closed)
					{
						//     [---
						//     [--- true
						//     (--- false
						//  ---)    true
						//  ---]    true
						return other.Upper || other.Closed;
					}

					// else @this.Open
					//     (---
					//     [--- true
					//     (--- true
					//  ---)    true
					//  ---]   	true
					return true;
				}

				if (@this.Upper)
				{
					if (@this.Open)
					{
						//  ---)
						//     [--- false
						//     (--- false
						//  ---)    true
						//  ---]   	false
						return other.Upper && other.Open;
					}

					// else @this.Closed
					//  ---]
					//     [--- true
					//     (--- false
					//  ---)    true
					//  ---]    true
					return other.Upper || other.Closed;
				}

				// else @this.Position == Position.Undefined
			}

			return @this.Value.CompareTo(other.Value) > 0;
		}



		/*
		public static bool LessThan<T>(this Limit<T> @this, Limit<T> other, Position pos) where T : IComparable<T>, IEquatable<T>
		{
			// this < other (left)
			// this   [  [  (  (  -∞   x  -∞
			// other  [  (  [  (   x  -∞  -∞
			//        0  1  0  0   1   0   0
			// 
			// this < other (right)
			// this   ]  ]  )  )  +∞   x  +∞
			// other  ]  )  ]  )   x  +∞  +∞
			//        0  0  1  0   0   1   0

			if (@this == null)
			{
				return pos == Position.Lower && other != null;
			}

			if (other == null)
			{
				return pos == Position.Upper; // && @this != null;
			}

			if (@this.Value.Equals(other.Value))
			{
				switch (pos)
				{
					case Position.Lower: return @this.Closed && other.Open;
					case Position.Upper: return @this.Open && other.Closed;
					default:             throw DefaultException;
				}
			}

			return @this.Value.CompareTo(other.Value) < 0;
		}



		public static bool LessThanOrEqual<T>(this Limit<T> @this, Limit<T> other, Position pos) where T : IComparable<T>, IEquatable<T>
		{
			// this <= other (left)
			// this   [  [  (  (  -∞   x  -∞
			// other  [  (  [  (   x  -∞  -∞
			//        1  1  0  1   1   0   1
			// 
			// this <= other (right)
			// this   ]  ]  )  )  +∞   x  +∞
			// other  ]  )  ]  )   x  +∞  +∞
			//        1  0  1  1   0   1   1

			if (@this == null)
			{
				return other == null || pos == Position.Lower;
			}

			if (other == null)
			{
				return pos == Position.Upper;
			}

			if (@this.Value.Equals(other.Value))
			{
				switch (pos)
				{
					case Position.Lower: return @this.Closed || other.Open;
					case Position.Upper: return @this.Open || other.Closed;
					default:             throw DefaultException;
				}
			}

			return @this.Value.CompareTo(other.Value) < 0;
		}



		public static bool GreaterThan<T>(this Limit<T> @this, Limit<T> other, Position pos) where T : IComparable<T>, IEquatable<T>
		{
			// this > other (left)
			// this   [  [  (  (  -∞   x  -∞
			// other  [  (  [  (   x  -∞  -∞
			//        0  0  1  0   0   1   0
			// 
			// this > other (right)
			// this   ]  ]  )  )  +∞   x  +∞
			// other  ]  )  ]  )   x  +∞  +∞
			//        0  1  0  0   1   0   0

			if (@this == null)
			{
				return pos == Position.Upper && other != null;
			}

			if (other == null)
			{
				return pos == Position.Lower; // && @this != null;
			}

			if (@this.Value.Equals(other.Value))
			{
				switch (pos)
				{
					case Position.Lower: return @this.Open && other.Closed;
					case Position.Upper: return @this.Closed && other.Open;
					default:             throw DefaultException;
				}
			}

			return @this.Value.CompareTo(other.Value) > 0;
		}



		public static bool GreaterThanOrEqual<T>(this Limit<T> @this, Limit<T> other, Position pos) where T : IComparable<T>, IEquatable<T>
		{
			// this >= other (left)
			// this   [  [  (  (  -∞   x  -∞
			// other  [  (  [  (   x  -∞  -∞
			//        1  0  1  1   0   1   1
			// 
			// this >= other (right)
			// this   ]  ]  )  )  +∞   x  +∞
			// other  ]  )  ]  )   x  +∞  +∞
			//        1  1  0  1   1   0   1

			if (@this == null)
			{
				return other == null || pos == Position.Upper;
			}

			if (other == null)
			{
				return pos == Position.Lower;
			}

			if (@this.Value.Equals(other.Value))
			{
				switch (pos)
				{
					case Position.Lower: return @this.Open || other.Closed;
					case Position.Upper: return @this.Closed || other.Open;
					default:             throw DefaultException;
				}
			}

			return @this.Value.CompareTo(other.Value) > 0;
		}
		*/

	}

}
