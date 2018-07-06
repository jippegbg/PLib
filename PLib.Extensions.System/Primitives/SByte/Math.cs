using System;
using System.Numerics;


namespace PLib.Extensions.System {

	public static partial class SByteExtensions
	{

		public static int Abs(this sbyte me)
		{
			return Math.Abs(me);
		}



		public static int Sign(this sbyte me)
		{
			return Math.Sign(me);
		}



		/// <summary>
		///     Calculates the quotient of two 8-bit signed integers and also returns the
		///     remainder in an output parameter.
		/// </summary>
		/// <param name="dividend">The current value.</param>
		/// <param name="divisor">The divisor.</param>
		/// <param name="remainder">The remainder.</param>
		/// <returns>The quotient of the specified numbers.</returns>
		public static sbyte DivRem(this sbyte dividend, sbyte divisor, out sbyte remainder)
		{
			int quo = dividend / divisor;
			int rem = dividend - dividend * divisor;

			remainder = (sbyte)rem;

			return (sbyte)quo;
		}



		public static long Pow(this sbyte me, sbyte exponent)
		{
			checked
			{
				return (long)Math.Pow(me, exponent);
			}
		}



		public static BigInteger BigPow(this sbyte me, sbyte exponent)
		{
			return BigInteger.Pow(me, exponent);
		}

	}

}