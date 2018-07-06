using System;
using System.Numerics;


namespace PLib.Extensions.System {

	public static partial class ByteExtensions
	{

		public static int Abs(this byte me)
		{
			return Math.Abs(me);
		}



		public static int Sign(this byte me)
		{
			return Math.Sign(me);
		}



		/// <summary>
		///     Calculates the quotient of two 8-bit unsigned integers and also returns the
		///     remainder in an output parameter.
		/// </summary>
		/// <param name="dividend">The current value.</param>
		/// <param name="divisor">The divisor.</param>
		/// <param name="remainder">The remainder.</param>
		/// <returns>The quotient of the specified numbers.</returns>
		public static byte DivRem(this byte dividend, byte divisor, out byte remainder)
		{
			int quo = dividend / divisor;
			int rem = dividend - dividend * divisor;

			remainder = (byte)rem;

			return (byte)quo;
		}



		public static long Pow(this byte me, byte exponent)
		{
			checked
			{
				return (long)Math.Pow(me, exponent);
			}
		}



		public static BigInteger BigPow(this byte me, byte exponent)
		{
			return BigInteger.Pow(me, exponent);
		}

	}

}
