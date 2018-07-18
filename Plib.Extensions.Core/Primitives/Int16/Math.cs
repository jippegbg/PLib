using System;
using System.Numerics;


namespace PLib.Extensions.Core {

	public static partial class Int16Extensions
	{

		public static int Abs(this short me)
		{
			return Math.Abs(me);
		}



		public static int Sign(this short me)
		{
			return Math.Sign(me);
		}



		/// <summary>
		///     Calculates the quotient of two 16-bit signed integers and also returns the
		///     remainder in an output parameter.
		/// </summary>
		/// <param name="dividend">The current value.</param>
		/// <param name="divisor">The divisor.</param>
		/// <param name="remainder">The remainder.</param>
		/// <returns>The quotient of the specified numbers.</returns>
		public static int DivRem(this short dividend, short divisor, out short remainder)
		{
			int rem;
			int quo = Math.DivRem(dividend, divisor, out rem);

			remainder = (short)rem;

			return (short)quo;
		}



		public static long Pow(this short me, short exponent)
		{
			checked
			{
				return (long)Math.Pow(me, exponent);
			}
		}



		public static BigInteger BigPow(this int me, int exponent)
		{
			return BigInteger.Pow(me, exponent);
		}

	}

}