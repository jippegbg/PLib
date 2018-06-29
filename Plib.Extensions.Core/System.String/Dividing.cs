using System;


namespace PLib.Extensions.Core.System.String
{

	public static partial class Extensions
	{

		/// <summary>
		///     Gets the left part of the current string.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="length">The number of characters to extract.</param>
		/// <returns>
		///     the first <paramref name="length"/> no. of characters from the current string.
		/// </returns>
		public static string Left(this string @this, int length)
		{
			if (@this == null)
			{
				return null;
			}

			if (length <= 0)
			{
				return string.Empty;
			}

			if (length >= @this.Length)
			{
				return @this;
			}

			return @this.Substring(0, length);
		}



		/// <summary>
		///     Gets the right part of the current string.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="length">The number of characters to extract.</param>
		/// <returns>
		///     the last <paramref name="length"/> no. of characters from the current string.
		/// </returns>
		public static string Right(this string @this, int length)
		{
			if (@this == null)
			{
				return null;
			}

			if (length <= 0)
			{
				return string.Empty;
			}

			if (length >= @this.Length)
			{
				return @this;
			}

			return @this.Substring(@this.Length - length);
		}



		/// <summary>
		///     Splits the current string into a substring array based on the separate lines in the
		///     current string.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns>An array whose elements contains the separate lines in the current string.</returns>
		public static string[] Lines(this string @this)
		{
			return @this?.Split(Environment.NewLine);
		}



		/// <summary>
		///     Retrieves a segment of the current string, that starts and ends
		///     at specified indexes.
		/// </summary>
		/// <param name="this">The current string.</param>
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
		public static string Slice(this string @this, int startIndex, int endIndex)
		{
			return @this?.Substring(startIndex, endIndex - startIndex);
		}



		/// <summary>
		///     Splits the current string into a substring array based on the separators in an array.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="separators">
		///     A string array that delimits the substrings in this string, an empty array that
		///     contains no delimiters, or null.
		/// </param>
		/// <returns>
		///     An array whose elements contain the substrings in the current string that are delimited by
		///     one or more sub-strings in <paramref name="separators"/>.
		/// </returns>
		public static string[] Split(this string @this, params string[] separators)
		{
			return @this?.Split(separators, StringSplitOptions.RemoveEmptyEntries);
		}



		/// <summary>
		///     Splits the current string into a substring array based on a single separator
		///     character and split options.
		/// </summary>
		/// <param name="this">The current string.</param>
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
		public static string[] Split(this string @this, char separator, StringSplitOptions options)
		{
			return @this?.Split(new[] { separator }, options);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this"></param>
		/// <param name="startIndex"></param>
		/// <returns></returns>
		public static string From(this string @this, int startIndex)
		{
			return @this.Substring(startIndex);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this"></param>
		/// <param name="endIndex"></param>
		/// <returns></returns>
		public static string Until(this string @this, int endIndex)
		{
			return @this.Substring(0, endIndex);
		}

	}

}
