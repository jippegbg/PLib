using System;
using System.Linq;


namespace PLib.Extensions.System
{

	public static partial class StringExtensions
	{

		/// <summary>
		///     Returns a copy of the current string with ensured minimum length.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="minLength">
		///     The minimum length of the resulting string. Pads to the left if positive, and on the
		///     right if negative.
		/// </param>
		/// <returns>TODO</returns>
		/// <remarks>
		///     If the string is longer than the minimum length, the string is left untouched.
		/// </remarks>
		public static string Pad(this string @this, int minLength)
		{
			if (@this == null)
			{
				return null;
			}

			//if (minLength < 0) {
			//	throw new ArgumentOutOfRangeException("minLength", minLength, "The minimum length cannot be less than zero.");
			//}

			return minLength < 0 ? @this.PadRight(-minLength) : @this.PadLeft(minLength);
		}



		/// <summary>
		///     Returns a copy of the current string with ensured minimum length.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="minLength">
		///     The minimum length of the resulting string. Pads to the left if positive, and on the
		///     right if negative.
		/// </param>
		/// <param name="paddingChar">A Unicode padding character.</param>
		/// <returns>TODO</returns>
		/// <remarks>
		///     If the string is longer than the minimum length, the string is left untouched.
		/// </remarks>
		public static string Pad(this string @this, int minLength, char paddingChar)
		{
			if (@this == null)
			{
				return null;
			}

			return minLength < 0 ? @this.PadRight(-minLength, paddingChar) : @this.PadLeft(minLength, paddingChar);
		}



		#region [ Multi-Line ]

		/// <summary>
		///     Returns a copy of the current string where the minimum length of every line in a
		///     string are ensured, by adding spaces to the left if necessary.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="minLineLength">The minimum length of every line in a string.</param>
		/// <returns>TODO</returns>
		/// <remarks>
		///     If a line in the string is longer than the minimum length, it is left untouched.
		/// </remarks>
		public static string PadLinesLeft(this string @this, int minLineLength)
		{
			return @this?
				.Lines()
				.Select(line => line.PadLeft(minLineLength))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where the minimum length of every line in a
		///     string are ensured, by adding characters to the left if necessary.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="minLineLength">The minimum length of every line in a string.</param>
		/// <param name="paddingChar">A Unicode padding character.</param>
		/// <returns>TODO</returns>
		/// <remarks>
		///     If a line in the string is longer than the minimum length, it is left untouched.
		/// </remarks>
		public static string PadLinesLeft(this string @this, int minLineLength, char paddingChar)
		{
			return @this?
				.Lines()
				.Select(line => line.PadLeft(minLineLength, paddingChar))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where the minimum length of every line in a
		///     string are ensured, by adding spaces to the right if necessary.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="minLineLength">The minimum length of every line in a string.</param>
		/// <returns>TODO</returns>
		/// <remarks>
		///     If a line in the string is longer than the minimum length, it is left untouched.
		/// </remarks>
		public static string PadLinesRight(this string @this, int minLineLength)
		{
			return @this?
				.Lines()
				.Select(line => line.PadRight(minLineLength))
				.Join(Environment.NewLine);
		}



		/// <summary>
		///     Returns a copy of the current string where the minimum length of every line in a
		///     string are ensured, by adding characters to the right if necessary.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="minLineLength">The minimum length of every line in a string.</param>
		/// <param name="paddingChar">A Unicode padding character.</param>
		/// <returns>TODO</returns>
		/// <remarks>
		///     If a line in the string is longer than the minimum length, it is left untouched.
		/// </remarks>
		public static string PadLinesRight(this string @this, int minLineLength, char paddingChar)
		{
			return @this?
				.Lines()
				.Select(line => line.PadRight(minLineLength, paddingChar))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where the minimum length of every line in a
		///     string are ensured, by adding spaces if necessary.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="minLineLength">
		///     The minimum length of every line in a string. Pads on the left if positive, and on
		///     the right if negative.
		/// </param>
		/// <returns>TODO</returns>
		/// <remarks>
		///     If a line in the string is longer than the minimum length, it is left untouched.
		/// </remarks>
		public static string PadLines(this string @this, int minLineLength)
		{
			return @this?
				.Lines()
				.Select(line => line.Pad(minLineLength))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where the minimum length of every line in a
		///     string are ensured, by adding characters if necessary.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="minLineLength">
		///     The minimum length of every line in a string. Pads on the left if positive, and on
		///     the right if negative.
		/// </param>
		/// <param name="paddingChar">A Unicode padding character.</param>
		/// <returns>TODO</returns>
		/// <remarks>
		///     If a line in the string is longer than the minimum length, it is left untouched.
		/// </remarks>
		public static string PadLines(this string @this, int minLineLength, char paddingChar)
		{
			return @this?
				.Lines()
				.Select(line => line.Pad(minLineLength, paddingChar))
				.JoinLines();
		}

		#endregion [ Multi-Line ]

	}

}
