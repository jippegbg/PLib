using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;


namespace PLib.Extensions.System
{

	public static partial class StringExtensions
	{

		/// <summary>
		///     Returns the current string with right-aligned line numbers at the start of each line.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns>
		///     A copy of the current string with right-aligned line numbers at the start of each line.
		/// </returns>
		/// <remarks>
		///     This will extend the length of each line, so if a specific maximum line length is
		///     required, the string needs to be re-wrapped with a smaller maximum line length before
		///     adding line numbers, which in turn can increase the number of lines.
		/// </remarks>
		public static string AddLineNumbers(this string @this)
		{
			if (@this == null)
			{
				return null;
			}

			// Split the string into separate lines.
			string[] lines = @this.Lines();

			// How many digits are needed to display the highest line number?
			int nDigits = (int)Math.Floor(Math.Log10(lines.Length)) + 1;

			// Add the right-aligned line number before each line, concatenate the lines, and return the result.
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < lines.Length; i++)
			{
				sb.AppendFormat("{0}: {1}{2}", (i + 1).ToString().PadLeft(nDigits), lines[i], Environment.NewLine);
			}

			return sb.ToString();
		}



		/// <summary>
		/// Inverts the casing for each character in a string.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <returns></returns>
		public static string InvertCase(this string @this)
		{
			return @this?.Select(c => char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c)).ToString();
		}



		/// <summary>
		///     Reverses the specified string.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns>A copy of the current string with characters in reverse order.</returns>
		public static string Reverse(this string @this)
		{
			//return @this?.Reverse<char>().ToString();

			if (@this == null)
			{
				return null;
			}

			if (@this.Length <= 1)
			{
				return @this;
			}

			char[] chars = @this.ToCharArray();
			Array.Reverse(chars);
			return new string(chars);
		}



		/// <summary>
		///     Converts the current string to title-case.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns>TODO</returns>
		public static string ToTitleCase(this string @this)
		{
			if (@this == null)
			{
				return null;
			}

			return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(@this);
		}



		/// <summary>
		///     Returns an unwrapped string where all line breaks are removed and replaced with a space.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns>An unwrapped string where all line breaks are removed and replaced with a space.</returns>
		public static string UnWrap(this string @this)
		{
			return @this?.Replace(Environment.NewLine, STRING_SPACE);
		}



		/// <summary>
		///     Returns a string that is wrapped into multiple lines, where every line is at its most
		///     a specified number of characters long.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="maxLineLength">The maximum line length.</param>
		/// <returns>
		///     A multi-line string where every line is at most a specified number of characters long.
		/// </returns>
		/// <remarks>
		///     If the string already is multi-line, the string is first made into a single line
		///     string by unwrapping it, before it's wrapped again with a new maximum line length.
		/// </remarks>
		public static string Wrap(this string @this, int maxLineLength)
		{
			if (@this == null)
			{
				return null;
			}

			// Split the string into separate words.
			string[]
				words = @this.UnWrap().Split(CHAR_SPACE); // Note that words can end with .,!? etc. i.e. character in the PUNCTUATIONS constant.

			// A list of all the lines added. Start with an empty list.
			List<string> resultLines = new List<string>();

			// A working line to add words to. Start with a blank line.
			StringBuilder line = new StringBuilder();


			// A local function that adds a word to an empty line, and hyphenates it if necessary.
			// Note that this function should only be called when the current line is empty.
			Action<string> add = word =>
			{
				// Try to add the word to the current line. If it fits,
				if (word.Length <= maxLineLength)
				{
					// add it.
					line.Append(word);
				}
				else
				{
					// Otherwise it's longer than the maximum line length and must be hyphenated.
					// As the current line is empty, we can directly add the hyphenated word to the list instead,
					// and as long as the remainder is longer than the maximum line length, keep hyphenate.
					string remainder = word;
					while (maxLineLength <= remainder.Length)
					{
						// Don't hyphenate a single ending punctuation character.
						if (remainder.Length == maxLineLength && PUNCTUATIONS.Contains(remainder.Last()))
						{
							// Just add the remainder, which precisely fits, and return. There's nothing left to add to the current line.
							resultLines.Add(remainder);
							return;
						}

						resultLines.Add(remainder.Substring(0, maxLineLength - 1) + STRING_HYPHEN);
						remainder = remainder.Substring(maxLineLength - 1);
					}

					// When the remainder is finally shorter than maximum line length, add it to the current line.
					line.Append(remainder);
				}
			};


			// For every word, do the following.
			foreach (string word in words)
			{
				// Is the current line empty?
				if (line.Length == 0)
				{
					add(word);
				}
				else if (line.Length + 1 + word.Length < maxLineLength)
				{
					// The current line isn't empty, but the word, including a separating space, still fits.
					// Add it with a space before.
					line.Append(STRING_SPACE + word);
				}
				else
				{
					// The current line isn't empty, and the word, including a separating space, doesn't fit.
					// Add the current line to the list,
					resultLines.Add(line.ToString());

					// start with a new line,
					line.Clear();

					// and finally add the word to the new line.
					add(word);
				}
			}

			// Add the final current line if not empty.
			if (line.Length > 0)
			{
				resultLines.Add(line.ToString());
			}

			// Concatenate the list of lines and return it as a whole string.
			return string.Join(Environment.NewLine, resultLines);
		}

	}

}
