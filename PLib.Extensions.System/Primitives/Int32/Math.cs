using System;
using System.Numerics;

namespace PLib.Extensions.System
{

	public static partial class Int32Extensions
	{

		public static int Abs(this int me)
		{
			return Math.Abs(me);
		}



		public static int Sign(this int me)
		{
			return Math.Sign(me);
		}



		/// <summary>
		///     Calculates the quotient of two 32-bit signed integers and also returns the
		///     remainder in an output parameter.
		/// </summary>
		/// <param name="dividend">The current value.</param>
		/// <param name="divisor">The divisor.</param>
		/// <param name="remainder">The remainder.</param>
		/// <returns>The quotient of the specified numbers.</returns>
		public static int DivRem(this int dividend, int divisor, out int remainder)
		{
			return Math.DivRem(dividend, divisor, out remainder);
		}



		public static long Pow(this int me, short exponent)
		{
			checked {
				return (long)Math.Pow(me, exponent);
			}
		}



		public static BigInteger BigPow(this int me, int exponent)
		{
			return BigInteger.Pow(me, exponent);
		}

	}

}
