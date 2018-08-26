using System.Linq;


namespace PLib.Extensions.Core
{

	public static partial class StringExtensions
	{

		/// <summary>
		///     If the current string is not null, removes all leading white-space characters from
		///     the current string.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns>
		///     The string that remains after all occurrences of white-space characters are removed
		///     from the start of the current string. Returns <see langword="null"/>, if the current string is <see langword="null"/>.
		/// </returns>
		public static string SafeTrimStart(this string me)
		{
			return me?.TrimStart();
		}



		/// <summary>
		///     If the current string is not null, removes all leading occurrences of a set of
		///     characters specified in an array from the current string.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="trimChars">An array of Unicode characters to remove, or null.</param>
		/// <returns>
		///     The string that remains after all occurrences of characters in the
		///     <paramref name="trimChars"/> parameter are removed from the start of the current
		///     string. If <paramref name="trimChars"/> is null or an empty array, white-space
		///     characters are removed instead. Returns <see langword="null"/>, if the current string is <see langword="null"/>.
		/// </returns>
		public static string SafeTrimStart(this string me, params char[] trimChars)
		{
			return me?.TrimStart(trimChars);
		}



		/// <summary>
		///     If the current string is not null, removes all trailing white-space characters from
		///     the current string.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns>
		///     The string that remains after all occurrences of white-space characters are removed
		///     from the end of the current string. Returns <see langword="null"/>, if the current string is <see langword="null"/>.
		/// </returns>
		public static string SafeTrimEnd(this string me)
		{
			return me?.TrimEnd();
		}



		/// <summary>
		///     If the current string is not null, removes all trailing occurrences of a set of
		///     characters specified in an array from the current string.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="trimChars">An array of Unicode characters to remove, or null.</param>
		/// <returns>
		///     The string that remains after all occurrences of characters in the
		///     <paramref name="trimChars"/> parameter are removed from the end of the current
		///     string. If <paramref name="trimChars"/> is null or an empty array, white-space
		///     characters are removed instead. Returns <see langword="null"/>, if the current string is <see langword="null"/>.
		/// </returns>
		public static string SafeTrimEnd(this string me, params char[] trimChars)
		{
			return me?.TrimEnd(trimChars);
		}



		/// <summary>
		///     If the current string is not null, removes all leading and trailing white-space
		///     characters from the current string.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns>
		///     The string that remains after all occurrences of white-space characters are removed
		///     from the start and end of the current string. Returns <see langword="null"/>, if the current
		///     string is <see langword="null"/>.
		/// </returns>
		public static string SafeTrim(this string me)
		{
			return me?.Trim();
		}



		/// <summary>
		///     If the current string is not null, removes all leading and trailing occurrences of a
		///     set of characters specified in an array from the current string.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="trimChars">An array of Unicode characters to remove, or null.</param>
		/// <returns>
		///     The string that remains after all occurrences of characters in the
		///     <paramref name="trimChars"/> parameter are removed from the start and end of the
		///     current string. If <paramref name="trimChars"/> is null or an empty array,
		///     white-space characters are removed instead. Returns <see langword="null"/>, if the current
		///     string is <see langword="null"/>.
		/// </returns>
		public static string SafeTrim(this string me, params char[] trimChars)
		{
			return me?.Trim(trimChars);
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number of character has been
		///     removed from the start.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="numChars">The number of characters to remove.</param>
		/// <returns>
		///     A copy of the current string where a specified number of character has been removed
		///     from the start.
		/// </returns>
		/// <remarks>
		///     If <paramref name="numChars"/> is zero or less, the original string will be returned.
		///     If <paramref name="numChars"/> is grater than the length of the string, an empty
		///     string will be returned.
		/// </remarks>
		public static string TrimStart(this string me, int numChars)
		{
			if (me == null || numChars < 0)
			{
				return me;
			}

			if (me.Length < numChars)
			{
				return string.Empty;
			}

			return me.Substring(numChars);
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number of character has been
		///     removed from the end.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="numChars">The number of characters to remove.</param>
		/// <returns>
		///     A copy of the current string where a specified number of character has been removed
		///     from the end.
		/// </returns>
		/// <remarks>
		///     If <paramref name="numChars"/> is zero or less, the original string will be returned.
		///     If <paramref name="numChars"/> is grater than the length of the string, an empty
		///     string will be returned.
		/// </remarks>
		public static string TrimEnd(this string me, int numChars)
		{
			if (me == null || numChars < 0)
			{
				return me;
			}

			if (me.Length < numChars)
			{
				return string.Empty;
			}

			return me.Substring(0, me.Length - numChars);
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number of character has been
		///     removed from either side.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="numChars">
		///     The number of characters to remove. Removes characters from the start if
		///     positive, and end if negative.
		/// </param>
		/// <returns>
		///     A copy of the current string where a specified number of character has been removed
		///     from either side.
		/// </returns>
		/// <remarks>
		///     If the absolute value of <paramref name="numChars"/> is greater than the length of
		///     the string, an empty string will be returned.
		/// </remarks>
		public static string Trim(this string me, int numChars)
		{
			if (me == null)
			{
				return null;
			}

			return numChars < 0 ? me.TrimEnd(-numChars) : me.TrimStart(numChars);
		}



		#region [ Multi-Line ]

		/// <summary>
		///     Removes all leading white-space characters from every line of the current string.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns>TODO</returns>
		public static string TrimLineStarts(this string me)
		{
			return me?
				.Lines()
				.Select(line => line.TrimStart())
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number of character has been
		///     removed from the start of every line.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="numChars">The number of characters to remove from every line.</param>
		/// <returns>
		///     A copy of the current string where a specified number of character has been removed
		///     from the start of every line.
		/// </returns>
		/// <remarks>
		///     If <paramref name="numChars"/> is zero or less, the original string will be returned.
		///     Lines that are shorter than <paramref name="numChars"/> will be empty in the result.
		/// </remarks>
		public static string TrimLineStarts(this string me, int numChars)
		{
			return me?
				.Lines()
				.Select(line => line.TrimStart(numChars))
				.JoinLines();
		}



		/// <summary>
		///     Removes all trailing white-space characters from every line of the current string.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns>TODO</returns>
		public static string TrimLineEnds(this string me)
		{
			return me?
				.Lines()
				.Select(line => line.TrimEnd())
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number of character has been
		///     removed from the end of every line.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="numChars">The number of characters to remove from every line.</param>
		/// <returns>
		///     A copy of the current string where a specified number of character has been removed
		///     from the end of every line.
		/// </returns>
		/// <remarks>
		///     If <paramref name="numChars"/> is zero or less, the original string will be returned.
		///     Lines that are shorter than <paramref name="numChars"/> will be empty in the result.
		/// </remarks>
		public static string TrimLineEnds(this string me, int numChars)
		{
			return me?
				.Lines()
				.Select(line => line.TrimEnd(numChars))
				.JoinLines();
		}



		/// <summary>
		///     Removes all leading and trailing white-space characters from every line of the current string.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns>TODO</returns>
		public static string TrimLines(this string me)
		{
			return me?
				.Lines()
				.Select(line => line.Trim())
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string where a specified number of character has been
		///     removed from either side of every line.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="numChars">
		///     The number of characters to remove from every line. Removes characters from the left
		///     side if positive, and end if negative.
		/// </param>
		/// <returns>
		///     A copy of the current string where a specified number of character has been removed
		///     from either side of every line.
		/// </returns>
		/// <remarks>
		///     If <paramref name="numChars"/> is zero, the original string will be returned. Lines
		///     that are shorter than the absolute value of <paramref name="numChars"/> will be empty
		///     in the result.
		/// </remarks>
		public static string TrimLines(this string me, int numChars)
		{
			return me?
				.Lines()
				.Select(line => line.Trim(numChars))
				.JoinLines();
		}

		#endregion [ Multi-Line ]

	}

}
