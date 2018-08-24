using System;


namespace PLib.Extensions.Core
{

	public static partial class StringExtensions
	{

		/// <summary>
		///     Gets the left part of the current string.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="length">The number of characters to extract.</param>
		/// <returns>
		///     the first <paramref name="length"/> no. of characters from the current string.
		/// </returns>
		public static string Left(this string me, int length)
		{
			return me?.Substring(0, Math.Min(length, me.Length));
		}



		/// <summary>
		///     Gets the right part of the current string.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="length">The number of characters to extract.</param>
		/// <returns>
		///     the last <paramref name="length"/> no. of characters from the current string.
		/// </returns>
		public static string Right(this string me, int length)
		{
			return me?.Substring(Math.Max(0, me.Length - length));
		}



		/// <summary>
		///     Splits the current string into a substring array based on the separate lines in the
		///     current string.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns>An array whose elements contains the separate lines in the current string.</returns>
		public static string[] Lines(this string me)
		{
			return me?.Split(Environment.NewLine);
		}



		/// <summary>
		///     Retrieves a segment of the current string, that starts and ends
		///     at specified indexes.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="startIndex">
		///     The inclusive zero-based starting character position of the current string.
		/// </param>
		/// <param name="endIndex">
		///     The exclusive zero-based ending character position of the current string.
		/// </param>
		/// <returns>
		///     A string that is equivalent to the substring that begins at
		///     <paramref name="startIndex"/> and end before <paramref name="endIndex"/> of the current string.
		/// </returns>
		public static string Slice(this string me, int startIndex, int endIndex)
		{
			return me?.Substring(startIndex, endIndex - startIndex);
		}



		/// <summary>
		///     Splits the current string into a substring array based on the separators in an array.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="separators">
		///     A string array that delimits the substrings in this string, an empty array that
		///     contains no delimiters, or null.
		/// </param>
		/// <returns>
		///     An array whose elements contain the substrings in the current string that are delimited by
		///     one or more sub-strings in <paramref name="separators"/>.
		/// </returns>
		public static string[] Split(this string me, params string[] separators)
		{
			return me?.Split(separators, StringSplitOptions.RemoveEmptyEntries);
		}



		/// <summary>
		///     Splits the current string into a substring array based on a single separator
		///     character and split options.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="separator">
		///     A single Unicode character that delimit the substrings in this instance.
		/// </param>
		/// <param name="options">
		///     <see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from
		///     the array returned; or <see cref="StringSplitOptions.None"/> to include empty array
		///     elements in the array returned.
		/// </param>
		/// <returns>
		///     An array whose elements contain the substrings in the current string that are
		///     delimited by the <paramref name="separator"/> character.
		/// </returns>
		public static string[] Split(this string me, char separator, StringSplitOptions options)
		{
			return me?.Split(new[] { separator }, options);
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <param name="me"></param>
		/// <param name="startIndex"></param>
		/// <returns></returns>
		public static string From(this string me, int startIndex)
		{
			return me.Substring(startIndex);
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <param name="me"></param>
		/// <param name="endIndex"></param>
		/// <returns></returns>
		public static string Until(this string me, int endIndex)
		{
			return me.Substring(0, endIndex);
		}

	}

}
