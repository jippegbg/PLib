﻿using System;
using System.Linq;


namespace PLib.Extensions.System
{

	public static partial class StringExtensions
	{

		/// <summary>
		///     Returns a copy of the current string where a specified number spaces are added to the left.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="numSpaces">The number of spaces to add to the left side.</param>
		/// <returns>TODO</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///     numSpaces - The number of spaces cannot be less than zero.
		/// </exception>
		public static string ExtendLeft(this string @this, int numSpaces)
		{
			if (@this == null)
			{
				return null;
			}

			if (numSpaces < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(numSpaces), numSpaces, "The number of spaces cannot be less than zero.");
			}

			return new string(CHAR_SPACE, numSpaces) + @this;
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number characters are added to
		///     the left.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="numChars">The number of characters to add to the left side.</param>
		/// <param name="extensionChar">A Unicode extension character.</param>
		/// <returns>TODO</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///     numChars - The number of characters cannot be less than zero.
		/// </exception>
		public static string ExtendLeft(this string @this, int numChars, char extensionChar)
		{
			if (@this == null)
			{
				return null;
			}

			if (numChars < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(numChars), numChars, "The number of characters cannot be less than zero.");
			}

			return new string(extensionChar, numChars) + @this;
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number spaces are added to the right.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="numSpaces">The number of spaces to add to the right side.</param>
		/// <returns>TODO</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///     numSpaces - The number of spaces cannot be less than zero.
		/// </exception>
		public static string ExtendRight(this string @this, int numSpaces)
		{
			if (@this == null)
			{
				return null;
			}

			if (numSpaces < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(numSpaces), numSpaces, "The number of spaces cannot be less than zero.");
			}

			return @this + new string(CHAR_SPACE, numSpaces);
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number characters are added to
		///     the right.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="numChars">The number of characters to add to the right side.</param>
		/// <param name="extensionChar">A Unicode extension character.</param>
		/// <returns>TODO</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///     numChars - The number of characters cannot be less than zero.
		/// </exception>
		public static string ExtendRight(this string @this, int numChars, char extensionChar)
		{
			if (@this == null)
			{
				return null;
			}

			if (numChars < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(numChars), numChars, "The number of characters cannot be less than zero.");
			}

			return @this + new string(extensionChar, numChars);
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number spaces are added.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="numSpaces">
		///     The number of spaces to add. Add to the left if positive and to the right if negative.
		/// </param>
		/// <returns>TODO</returns>
		public static string Extend(this string @this, int numSpaces)
		{
			if (@this == null)
			{
				return null;
			}

			return numSpaces < 0 ? @this.ExtendRight(-numSpaces) : @this.ExtendLeft(numSpaces);
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number characters are added.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="numChars">
		///     The number of characters to add. Add to the left if positive and to the right if negative.
		/// </param>
		/// <param name="extensionChar">A Unicode extension character.</param>
		/// <returns>TODO</returns>
		public static string Extend(this string @this, int numChars, char extensionChar)
		{
			if (@this == null)
			{
				return null;
			}

			return numChars < 0 ? @this.ExtendRight(-numChars, extensionChar) : @this.ExtendLeft(numChars, extensionChar);
		}



		#region [ Multi-Line ]

		/// <summary>
		///     Returns a copy of the current string where a specified number spaces are added to the
		///     left of each line.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="numSpaces">The number of spaces to add to the left side of each line.</param>
		/// <returns>TODO</returns>
		public static string ExtendLinesLeft(this string @this, int numSpaces)
		{
			return @this?
				.Lines()
				.Select(line => line.ExtendLeft(numSpaces))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number characters are added to
		///     the left of each line.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="numChars">
		///     The number of characters to add to the left side of each line.
		/// </param>
		/// <param name="extensionChar">A Unicode extension character.</param>
		/// <returns>TODO</returns>
		public static string ExtendLinesLeft(this string @this, int numChars, char extensionChar)
		{
			return @this?
				.Lines()
				.Select(line => line.ExtendLeft(numChars, extensionChar))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number spaces are added to the
		///     right of each line.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="numSpaces">The number of spaces to add to the right side of each line.</param>
		/// <returns>TODO</returns>
		public static string ExtendLinesRight(this string @this, int numSpaces)
		{
			return @this?
				.Lines()
				.Select(line => line.ExtendRight(numSpaces))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number characters are added to
		///     the right of each line.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="numChars">
		///     The number of characters to add to the right side of each line.
		/// </param>
		/// <param name="extensionChar">A Unicode extension character.</param>
		/// <returns>TODO</returns>
		public static string ExtendLinesRight(this string @this, int numChars, char extensionChar)
		{
			return @this?
				.Lines()
				.Select(line => line.ExtendRight(numChars, extensionChar))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number spaces are added to
		///     each line.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="numSpaces">
		///     The number of spaces to add to each line. Add to the left if positive and to the
		///     right if negative.
		/// </param>
		/// <returns>TODO</returns>
		public static string ExtendLines(this string @this, int numSpaces)
		{
			return @this?
				.Lines()
				.Select(line => line.Extend(numSpaces))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number characters are added to
		///     each line.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="numChars">
		///     The number of characters to add to each line. Add to the left if positive and to the
		///     right if negative.
		/// </param>
		/// <param name="extensionChar">A Unicode extension character.</param>
		/// <returns>
		///     A copy of the current string where a specified number characters are added to each line.
		/// </returns>
		public static string ExtendLines(this string @this, int numChars, char extensionChar)
		{
			return @this?
				.Lines()
				.Select(line => line.Extend(numChars, extensionChar))
				.JoinLines();
		}



		/// <summary>
		///     Indents every line in a string a specified number of spaces.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="numSpaces">The number of spaces to indent each line with.</param>
		/// <returns>
		///     A copy of the current string where every line is indented the specified number of spaces.
		/// </returns>
		/// <remarks>
		///     This is actually an alias for the <see cref="ExtendLinesLeft(string, int)"/> method.
		///     It works with single line strings as well.
		/// </remarks>
		public static string Indent(this string @this, int numSpaces)
		{
			return ExtendLinesLeft(@this, numSpaces);
		}

		#endregion [ Multi-Line ]

	}

}