using System;


namespace PLib.Interval {

	internal static class IntervalValueTypeExtensions
	{

		public static string ToString(this IntervalValueType type, IntervalNotationPosition position)
		{
			switch (position)
			{
				case IntervalNotationPosition.Left:
					switch (type)
					{
						case IntervalValueType.Inclusive:
							return "[";
						case IntervalValueType.Exclusive:
							return "(";

						default:
							throw new NotSupportedException();
					}

				case IntervalNotationPosition.Right:
					switch (type)
					{
						case IntervalValueType.Inclusive:
							return "]";
						case IntervalValueType.Exclusive:
							return ")";

						default:
							throw new NotSupportedException();
					}

				default:
					throw new NotSupportedException();
			}
		}

	}

}