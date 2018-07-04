using System;
using System.Numerics;


namespace PLib.Extensions.System {

	public static partial class Int64Extensions
	{

		public static long Abs(this long me)
		{
			return Math.Abs(me);
		}



		public static int Sign(this long me)
		{
			return Math.Sign(me);
		}



		/// <summary>
		///     Calculates the quotient of two 64-bit signed integers and also returns the
		///     remainder in an output parameter.
		/// </summary>
		/// <param name="dividend">The current value.</param>
		/// <param name="divisor">The divisor.</param>
		/// <param name="remainder">The remainder.</param>
		/// <returns>The quotient of the specified numbers.</returns>
		public static long DivRem(this long dividend, long divisor, out long remainder)
		{
			return Math.DivRem(dividend, divisor, out remainder);
		}



		public static long Pow(this long me, short exponent)
		{
			checked
			{
				return (long)Math.Pow(me, exponent);
			}
		}



		public static BigInteger BigPow(this long me, int exponent)
		{
			return BigInteger.Pow(me, exponent);
		}

	}

}