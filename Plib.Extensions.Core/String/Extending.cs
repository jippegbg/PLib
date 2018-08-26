using System;
using System.Linq;


namespace PLib.Extensions.Core
{

	public static partial class StringExtensions
	{

		/// <summary>
		///     Returns a copy of the current string where a specified number spaces are
		///     added to the left.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="numSpaces">The number of spaces to add to the left side.</param>
		/// <returns>
		///     A copy of the current string where a specified number spaces are added to
		///     the left.
		/// </returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///     If <paramref name="numSpaces"/> is less than zero.
		/// </exception>
		public static string ExtendLeft(this string me, int numSpaces)
		{
			if (me == null)
			{
				return null;
			}

			if (numSpaces < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(numSpaces), numSpaces, "The number of spaces cannot be less than zero.");
			}

			return new string(CHAR_SPACE, numSpaces) + me;
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number characters
		///     are added to the left.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="numChars">The number of characters to add to the left side.</param>
		/// <param name="extensionChar">A Unicode extension character.</param>
		/// <returns>
		///     A copy of the current string where a specified number characters are added
		///     to the left.
		/// </returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///     If <paramref name="numChars"/> is less than zero.
		/// </exception>
		public static string ExtendLeft(this string me, int numChars, char extensionChar)
		{
			if (me == null)
			{
				return null;
			}

			if (numChars < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(numChars), numChars, "The number of characters cannot be less than zero.");
			}

			return new string(extensionChar, numChars) + me;
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number spaces are
		///     added to the right.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="numSpaces">The number of spaces to add to the right side.</param>
		/// <returns>
		///     A copy of the current string where a specified number spaces are added to
		///     the right.
		/// </returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///     If <paramref name="numSpaces"/> is less than zero.
		/// </exception>
		public static string ExtendRight(this string me, int numSpaces)
		{
			if (me == null)
			{
				return null;
			}

			if (numSpaces < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(numSpaces), numSpaces, "The number of spaces cannot be less than zero.");
			}

			return me + new string(CHAR_SPACE, numSpaces);
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number characters
		///     are added to the right.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="numChars">The number of characters to add to the right side.</param>
		/// <param name="extensionChar">A Unicode extension character.</param>
		/// <returns>
		///     A copy of the current string where a specified number characters are added
		///     to the right.
		/// </returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///     If <paramref name="numChars"/> is less than zero.
		/// </exception>
		public static string ExtendRight(this string me, int numChars, char extensionChar)
		{
			if (me == null)
			{
				return null;
			}

			if (numChars < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(numChars), numChars, "The number of characters cannot be less than zero.");
			}

			return me + new string(extensionChar, numChars);
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number spaces are added.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="numSpaces">
		///     The number of spaces to add. Add to the left if positive and to the right
		///     if negative.
		/// </param>
		/// <returns>
		///     A copy of the current string where a specified number spaces are added.
		/// </returns>
		public static string Extend(this string me, int numSpaces)
		{
			if (me == null)
			{
				return null;
			}

			return numSpaces < 0 ? me.ExtendRight(-numSpaces) : me.ExtendLeft(numSpaces);
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number characters
		///     are added.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="numChars">
		///     The number of characters to add. Add to the left if positive and to the
		///     right if negative.
		/// </param>
		/// <param name="extensionChar">A Unicode extension character.</param>
		/// <returns>
		///     A copy of the current string where a specified number characters are added.
		/// </returns>
		public static string Extend(this string me, int numChars, char extensionChar)
		{
			if (me == null)
			{
				return null;
			}

			return numChars < 0 ? me.ExtendRight(-numChars, extensionChar) : me.ExtendLeft(numChars, extensionChar);
		}



		#region [ Multi-Line ]

		/// <summary>
		///     Returns a copy of the current string where a specified number spaces are
		///     added to the left of each line.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="numSpaces">
		///     The number of spaces to add to the left side of each line.
		/// </param>
		/// <returns>
		///     A a copy of the current string where a specified number spaces are added to
		///     the left of each line.
		/// </returns>
		public static string ExtendLinesLeft(this string me, int numSpaces)
		{
			return me?
				.Lines()
				.Select(line => line.ExtendLeft(numSpaces))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number characters
		///     are added to the left of each line.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="numChars">
		///     The number of characters to add to the left side of each line.
		/// </param>
		/// <param name="extensionChar">A Unicode extension character.</param>
		/// <returns>
		///     A copy of the current string where a specified number characters are added
		///     to the left of each line.
		/// </returns>
		public static string ExtendLinesLeft(this string me, int numChars, char extensionChar)
		{
			return me?
				.Lines()
				.Select(line => line.ExtendLeft(numChars, extensionChar))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number spaces are
		///     added to the right of each line.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="numSpaces">
		///     The number of spaces to add to the right side of each line.
		/// </param>
		/// <returns>
		///     A copy of the current string where a specified number spaces are added to
		///     the right of each line.
		/// </returns>
		public static string ExtendLinesRight(this string me, int numSpaces)
		{
			return me?
				.Lines()
				.Select(line => line.ExtendRight(numSpaces))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number characters
		///     are added to the right of each line.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="numChars">
		///     The number of characters to add to the right side of each line.
		/// </param>
		/// <param name="extensionChar">A Unicode extension character.</param>
		/// <returns>
		///     A a copy of the current string where a specified number characters are
		///     added to the right of each line.
		/// </returns>
		public static string ExtendLinesRight(this string me, int numChars, char extensionChar)
		{
			return me?
				.Lines()
				.Select(line => line.ExtendRight(numChars, extensionChar))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number spaces are
		///     added to each line.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="numSpaces">
		///     The number of spaces to add to each line. Add to the left if positive and
		///     to the right if negative.
		/// </param>
		/// <returns>
		///     A copy of the current string where a specified number spaces are added to
		///     each line.
		/// </returns>
		public static string ExtendLines(this string me, int numSpaces)
		{
			return me?
				.Lines()
				.Select(line => line.Extend(numSpaces))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number characters are added to
		///     each line.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="numChars">
		///     The number of characters to add to each line. Add to the left if positive and to the
		///     right if negative.
		/// </param>
		/// <param name="extensionChar">A Unicode extension character.</param>
		/// <returns>
		///     A copy of the current string where a specified number characters are added to each line.
		/// </returns>
		public static string ExtendLines(this string me, int numChars, char extensionChar)
		{
			return me?
				.Lines()
				.Select(line => line.Extend(numChars, extensionChar))
				.JoinLines();
		}



		/// <summary>
		///     Indents every line in a string a specified number of spaces.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="numSpaces">The number of spaces to indent each line with.</param>
		/// <returns>
		///     A copy of the current string where every line is indented the specified number of spaces.
		/// </returns>
		/// <remarks>
		///     This is actually an alias for the <see cref="ExtendLinesLeft(string, int)"/> method.
		///     It works with single line strings as well.
		/// </remarks>
		public static string Indent(this string me, int numSpaces)
		{
			return ExtendLinesLeft(me, numSpaces);
		}

		#endregion [ Multi-Line ]

	}

}
