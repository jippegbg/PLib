using System;
using System.Linq;


namespace PLib.Extensions.Core
{

	public static partial class StringExtensions
	{

		/// <summary>
		///     Returns a copy of the current string with ensured minimum length.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="minLength">
		///     The minimum length of the resulting string. Pads to the left if positive,
		///     and on the right if negative.
		/// </param>
		/// <returns>
		///     A new string that is equivalent to this instance, but right-aligned and
		///     padded on the left if <paramref name="minLength"/> is positive, or
		///     left-aligned and padded on the right if <paramref name="minLength"/> is
		///     negative, with as many spaces as needed to create a length of the absolute
		///     value of <paramref name="minLength"/>. However, if the absolute value of
		///     <paramref name="minLength"/> is less than the length of the current string,
		///     this method returns a reference to the existing instance. If the absolute
		///     value of <paramref name="minLength"/> is equal to the length of this
		///     instance, the method returns a new string that is identical to this instance.
		/// </returns>
		public static string Pad(this string me, int minLength)
		{
			if (me == null)
			{
				return null;
			}

			return minLength < 0 ? me.PadRight(-minLength) : me.PadLeft(minLength);
		}



		/// <summary>
		///     Returns a copy of the current string with ensured minimum length.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="minLength">
		///     The minimum length of the resulting string. Pads to the left if positive,
		///     and on the right if negative.
		/// </param>
		/// <param name="paddingChar">A Unicode padding character.</param>
		/// <returns>
		///     A new string that is equivalent to this instance, but right-aligned and
		///     padded on the left if <paramref name="minLength"/> is positive, or
		///     left-aligned and padded on the right if <paramref name="minLength"/> is
		///     negative, with as many <paramref name="paddingChar"/> characters as needed
		///     to create a length of the absolute value of <paramref name="minLength"/>.
		///     However, if the absolute value of <paramref name="minLength"/> is less than
		///     the length of the current string, this method returns a reference to the
		///     existing instance. If the absolute value of <paramref name="minLength"/> is
		///     equal to the length of this instance, the method returns a new string that
		///     is identical to this instance.
		/// </returns>
		public static string Pad(this string me, int minLength, char paddingChar)
		{
			if (me == null)
			{
				return null;
			}

			return minLength < 0 ? me.PadRight(-minLength, paddingChar) : me.PadLeft(minLength, paddingChar);
		}



		#region [ Multi-Line ]

		/// <summary>
		///     Returns a copy of the current string where the minimum length of every line
		///     in a string are ensured, by adding spaces to the left if necessary.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="minLineLength">The minimum length of every line in a string.</param>
		/// <returns>
		///     A new string that is equivalent to this instance, but right-aligned and
		///     padded on the left with as many spaces as needed to create a length of
		///     <paramref name="minLineLength"/> at every line.
		/// </returns>
		/// <remarks>
		///     If a line in the string is longer than the minimum length, that line is
		///     left untouched.
		/// </remarks>
		public static string PadLinesLeft(this string me, int minLineLength)
		{
			return me?
				.Lines()
				.Select(line => line.PadLeft(minLineLength))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where the minimum length of every line
		///     in a string are ensured, by adding characters to the left if necessary.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="minLineLength">The minimum length of every line in a string.</param>
		/// <param name="paddingChar">A Unicode padding character.</param>
		/// <returns>
		///     A new string that is equivalent to this instance, but right-aligned and
		///     padded on the left with as many <paramref name="paddingChar"/> characters
		///     as needed to create a length of <paramref name="minLineLength"/> at every line.
		/// </returns>
		/// <remarks>
		///     If a line in the string is longer than the minimum length, that line is
		///     left untouched.
		/// </remarks>
		public static string PadLinesLeft(this string me, int minLineLength, char paddingChar)
		{
			return me?
				.Lines()
				.Select(line => line.PadLeft(minLineLength, paddingChar))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where the minimum length of every line
		///     in a string are ensured, by adding spaces to the right if necessary.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="minLineLength">The minimum length of every line in a string.</param>
		/// <returns>
		///     A new string that is equivalent to this instance, but left-aligned and
		///     padded on the right with as many spaces as needed to create a length of
		///     <paramref name="minLineLength"/> at every line.
		/// </returns>
		/// <remarks>
		///     If a line in the string is longer than the minimum length, that line is
		///     left untouched.
		/// </remarks>
		public static string PadLinesRight(this string me, int minLineLength)
		{
			return me?
				.Lines()
				.Select(line => line.PadRight(minLineLength))
				.Join(Environment.NewLine);
		}



		/// <summary>
		///     Returns a copy of the current string where the minimum length of every line
		///     in a string are ensured, by adding characters to the right if necessary.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="minLineLength">The minimum length of every line in a string.</param>
		/// <param name="paddingChar">A Unicode padding character.</param>
		/// <returns>
		///     A new string that is equivalent to this instance, but left-aligned and
		///     padded on the right with as many <paramref name="paddingChar"/> characters
		///     as needed to create a length of <paramref name="minLineLength"/> at every line.
		/// </returns>
		/// <remarks>
		///     If a line in the string is longer than the minimum length, that line is
		///     left untouched.
		/// </remarks>
		public static string PadLinesRight(this string me, int minLineLength, char paddingChar)
		{
			return me?
				.Lines()
				.Select(line => line.PadRight(minLineLength, paddingChar))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where the minimum length of every line
		///     in a string are ensured, by adding spaces if necessary.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="minLineLength">
		///     The minimum length of every line in a string. Pads on the left if positive,
		///     and on the right if negative.
		/// </param>
		/// <returns>
		///     A new string that is equivalent to this instance, but right-aligned and
		///     padded on the left if <paramref name="minLineLength"/> is positive, or
		///     left-aligned and padded on the right if <paramref name="minLineLength"/> is
		///     negative, with as many spaces as needed to create a length of the absolute
		///     value of <paramref name="minLineLength"/><paramref name="minLineLength"/>
		///     at every line.
		/// </returns>
		/// <remarks>
		///     If a line in the string is longer than the minimum length, that line is
		///     left untouched.
		/// </remarks>
		public static string PadLines(this string me, int minLineLength)
		{
			return me?
				.Lines()
				.Select(line => line.Pad(minLineLength))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where the minimum length of every line
		///     in a string are ensured, by adding characters if necessary.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="minLineLength">
		///     The minimum length of every line in a string. Pads on the left if positive,
		///     and on the right if negative.
		/// </param>
		/// <param name="paddingChar">A Unicode padding character.</param>
		/// <returns>
		///     A new string that is equivalent to this instance, but right-aligned and
		///     padded on the left if <paramref name="minLineLength"/> is positive, or
		///     left-aligned and padded on the right if <paramref name="minLineLength"/> is
		///     negative, with as many <paramref name="paddingChar"/> characters as needed
		///     to create a length of the absolute value of
		///     <paramref name="minLineLength"/><paramref name="minLineLength"/> at every line.
		/// </returns>
		/// <remarks>
		///     If a line in the string is longer than the minimum length, that line is
		///     left untouched.
		/// </remarks>
		public static string PadLines(this string me, int minLineLength, char paddingChar)
		{
			return me?
				.Lines()
				.Select(line => line.Pad(minLineLength, paddingChar))
				.JoinLines();
		}

		#endregion [ Multi-Line ]

	}

}
