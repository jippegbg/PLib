using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace PLib.Extensions.System
{

	public static partial class StringExtensions
	{

		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static string Copy(this string @this) => string.Copy(@this);



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="pattern">The pattern.</param>
		/// <param name="options">The options.</param>
		/// <returns></returns>
		public static bool Matches(this string @this, string pattern, RegexOptions options = RegexOptions.None)
		{
			return Regex.IsMatch(@this, pattern, options);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="pattern">The pattern.</param>
		/// <param name="options">The options.</param>
		/// <returns></returns>
		public static Match GetMatch(this string @this, string pattern, RegexOptions options = RegexOptions.None)
		{
			return Regex.Match(@this, pattern, options);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="pattern">The pattern.</param>
		/// <param name="options">The options.</param>
		/// <returns></returns>
		public static IEnumerable<Match> GetMatches(this string @this, string pattern, RegexOptions options = RegexOptions.None)
		{
			foreach (Match m in Regex.Matches(@this, pattern, options))
			{
				yield return m;
			}
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static string EncodeBase64(this string @this) => Convert.ToBase64String(Encoding.ASCII.GetBytes(@this));



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static string DecodeBase64(this string @this) => Encoding.ASCII.GetString(Convert.FromBase64String(@this));



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static string FilterLetters(this string @this) => @this.ToCharArray().Where(char.IsLetter).ToString();



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static string FilterDecimalDigits(this string @this) => @this.ToCharArray().Where(char.IsDigit).ToString();



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static string FilterNumbers(this string @this) => @this.ToCharArray().Where(char.IsNumber).ToString();



		/// <summary>
		///     Repeats the current string a specified number of times.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="count">The nuber to repeat teh current string.</param>
		/// <returns>
		///     A new string where the current string is repeated after itself a specified
		///     number of times.
		/// </returns>
		public static string Repeat(this string @this, int count)
		{
			StringBuilder sb = new StringBuilder(@this.Length * count);

			do
			{
				sb.Append(@this);
			}
			while (--count > 0);

			return sb.ToString();
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="replacement">The replacement.</param>
		/// <returns></returns>
		public static string IfNull(this string @this, string replacement)
		{
			return @this ?? replacement;
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="replacement">The replacement.</param>
		/// <returns></returns>
		public static string IfNullOrEmpty(this string @this, string replacement)
		{
			return string.IsNullOrEmpty(@this) ? replacement : @this;
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="replacement">The replacement.</param>
		/// <returns></returns>
		public static string IfNullOrWhiteSpace(this string @this, string replacement)
		{
			return string.IsNullOrWhiteSpace(@this) ? replacement : @this;
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="other">The other.</param>
		/// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
		/// <returns>
		///   <c>true</c> if the specified other is anagram; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsAnagram(this string @this, string other, bool ignoreCase = false)
		{
			if (@this == null || other == null || @this.Length != other.Length)
			{
				return false;
			}

			char[] chars = @this.ToCharArray();
			Array.Sort(chars);

			char[] otherChars = other.ToCharArray();
			Array.Sort(otherChars);

			return new string(chars).Equals(new string(otherChars), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="other">The other.</param>
		/// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
		/// <returns>
		///   <c>true</c> if the specified other is palindrome; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsPalindrome(this string @this, string other, bool ignoreCase = false)
		{
			return @this.Equals(@this.Reverse(), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="pattern">The pattern.</param>
		/// <returns>
		///   <c>true</c> if the specified pattern is like; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsLike(this string @this, string pattern)
		{
			// Turn the pattern into regex pattern, and match the whole string with ^$
			string regexPattern = "^" + Regex.Escape(pattern) + "$";

			// Escape special character ?, #, *, [], and [!]
			regexPattern = regexPattern.Replace(@"\[!", "[^")
				.Replace(@"\[", "[")
				.Replace(@"\]", "]")
				.Replace(@"\?", ".")
				.Replace(@"\*", ".*")
				.Replace(@"\#", @"\d");

			return Regex.IsMatch(@this, regexPattern);
		}



		/// <summary>
		/// Combines the path with.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="paths">The paths.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for CombinePathWith
		public static string CombinePathWith(this string @this, params string[] paths)
		{
			string[] args = new string[paths.Length + 1];
			Array.Copy(paths, 0, args, 1, paths.Length);
			args[0] = @this;
			return Path.Combine(args);
		}



		/// <summary>
		/// Removes the letters.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for RemoveLetters
		public static string RemoveLetters(this string @this)
		{
			return new string(@this.Where(c => !Char.IsLetter(c)).ToArray());
		}



		/// <summary>
		/// Removes the numbers.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for RemoveNumbers
		public static string RemoveNumbers(this string @this)
		{
			return new string(@this.Where(c => !Char.IsNumber(c)).ToArray());
		}



		/// <summary>
		/// Removes the decimal digits.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for RemoveDecimalDigits
		public static string RemoveDecimalDigits(this string @this)
		{
			return new string(@this.Where(c => !Char.IsDigit(c)).ToArray());
		}



		/// <summary>
		/// Removes the character where.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for RemoveCharacterWhere
		public static string RemoveCharacterWhere(this string @this, Func<char, bool> predicate)
		{
			return new string(@this.Where(c => !predicate(c)).ToArray());
		}



		/// <summary>
		/// Replaces the segment.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="startIndex">The start index.</param>
		/// <param name="endIndex">The end index.</param>
		/// <param name="replacement">The replacement.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ReplaceSegment
		public static string ReplaceSegment(this string @this, int startIndex, int endIndex, string replacement)
		{
			return $"{@this.Substring(0, startIndex)}{replacement}{@this.Substring(endIndex)}";
		}



		/// <summary>
		/// Replaces the length of the segment.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="startIndex">The start index.</param>
		/// <param name="length">The length.</param>
		/// <param name="replacement">The replacement.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ReplaceSegmentLength
		public static string ReplaceSegmentLength(this string @this, int startIndex, int length, string replacement)
		{
			return $"{@this.Substring(0, startIndex)}{replacement}{@this.Substring(startIndex + length)}";
		}



		/// <summary>
		/// Replaces the first.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="substring">The substring.</param>
		/// <param name="replacement">The replacement.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ReplaceFirst
		public static string ReplaceFirst(this string @this, string substring, string replacement)
		{
			int ix = @this.IndexOf(substring, StringComparison.Ordinal);

			if (ix == -1)
			{
				return @this;
			}

			return $@"{@this.Substring(0, ix)}{replacement}{@this.Substring(ix + substring.Length)}";
		}



		/// <summary>
		/// Replaces the last.
		/// </summary>
		/// <param name="this">The @this.</param>
		/// <param name="substring">The substring.</param>
		/// <param name="replacement">The replacement.</param>
		/// <returns></returns>
		public static string ReplaceLast(this string @this, string substring, string replacement)
		{
			int ix = @this.LastIndexOf(substring, StringComparison.Ordinal);

			if (ix == -1)
			{
				return @this;
			}

			return $@"{@this.Substring(0, ix)}{replacement}{@this.Substring(ix + substring.Length)}";
		}



		/// <summary>
		/// Erases the specified substrings.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="substrings">The substrings.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for Erase
		public static string Erase(this string @this, params string[] substrings)
		{
			foreach (string ss in substrings)
			{
				@this = @this.Replace(ss, new string(CHAR_SPACE, ss.Length));
			}

			return @this;
		}



		/// <summary>
		/// Erases the segment.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="startIndex">The start index.</param>
		/// <param name="endIndex">The end index.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for EraseSegment
		public static string EraseSegment(this string @this, int startIndex, int endIndex)
		{
			char[] chars = @this.ToCharArray();

			for (int i = startIndex; i < endIndex; i++)
			{
				chars[i] = CHAR_SPACE;
			}

			return new string(chars);

			//return $"{@this.Substring(0, startIndex)}{new string(CHAR_SPACE, endIndex - startIndex)}{@this.Substring(endIndex)}";
		}



		/// <summary>
		/// Erases the first.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="substring">The substring.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for EraseFirst
		public static string EraseFirst(this string @this, string substring)
		{
			int ix = @this.IndexOf(substring, StringComparison.Ordinal);

			if (ix == -1)
			{
				return @this;
			}

			char[] chars = @this.ToCharArray();
			for (int i = ix; i < substring.Length; i++)
			{
				chars[i] = CHAR_SPACE;
			}

			return new string(chars);
		}



		/// <summary>
		/// Erases the last.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="substring">The substring.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for EraseLast
		public static string EraseLast(this string @this, string substring)
		{
			int ix = @this.LastIndexOf(substring, StringComparison.Ordinal);

			if (ix == -1)
			{
				return @this;
			}

			char[] chars = @this.ToCharArray();
			for (int i = ix; i < substring.Length; i++)
			{
				chars[i] = CHAR_SPACE;
			}

			return new string(chars);
		}



		/// <summary>
		/// Removes the specified substrings.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="substrings">The substrings.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for Remove
		public static string Remove(this string @this, params string[] substrings)
		{
			foreach (string ss in substrings)
			{
				@this = @this.Replace(ss, string.Empty);
			}

			return @this;
		}



		/// <summary>
		/// Removes the segment.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="startIndex">The start index.</param>
		/// <param name="endIndex">The end index.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for RemoveSegment
		public static string RemoveSegment(this string @this, int startIndex, int endIndex)
		{
			return $"{@this.Substring(0, startIndex)}{@this.Substring(endIndex)}";
		}



		/// <summary>
		/// Removes the first.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="substring">The substring.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for RemoveFirst
		public static string RemoveFirst(this string @this, string substring)
		{
			int ix = @this.IndexOf(substring, StringComparison.Ordinal);

			if (ix == -1)
			{
				return @this;
			}

			return $"{@this.Substring(0, ix)}{@this.Substring(ix + substring.Length)}";
		}



		/// <summary>
		/// Removes the last.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="substring">The substring.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for RemoveLast
		public static string RemoveLast(this string @this, string substring)
		{
			int ix = @this.LastIndexOf(substring, StringComparison.Ordinal);

			if (ix == -1)
			{
				return @this;
			}

			return $"{@this.Substring(0, ix)}{@this.Substring(ix + substring.Length)}";
		}



		/// <summary>
		/// Saves as.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="append">if set to <c>true</c> [append].</param>
		/// TODO Edit XML Comment Template for SaveAs
		public static void SaveAs(this string @this, string fileName, bool append = false)
		{
			using (TextWriter tw = new StreamWriter(fileName, append))
			{
				tw.Write(@this);
			}
		}



		/// <summary>
		/// Saves as.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="encoding">The encoding.</param>
		/// <param name="append">if set to <c>true</c> [append].</param>
		/// TODO Edit XML Comment Template for SaveAs
		public static void SaveAs(this string @this, string fileName, Encoding encoding, bool append = false)
		{
			using (TextWriter tw = new StreamWriter(fileName, append, encoding))
			{
				tw.Write(@this);
			}
		}



		/// <summary>
		/// Saves as.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="file">The file.</param>
		/// <param name="append">if set to <c>true</c> [append].</param>
		/// TODO Edit XML Comment Template for SaveAs
		public static void SaveAs(this string @this, FileInfo file, bool append)
		{
			using (TextWriter tw = new StreamWriter(file.FullName, append))
			{
				tw.Write(@this);
			}
		}



		/// <summary>
		/// Saves as.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="file">The file.</param>
		/// <param name="encoding">The encoding.</param>
		/// <param name="append">if set to <c>true</c> [append].</param>
		/// TODO Edit XML Comment Template for SaveAs
		public static void SaveAs(this string @this, FileInfo file, Encoding encoding, bool append = false)
		{
			using (TextWriter tw = new StreamWriter(file.FullName, append, encoding))
			{
				tw.Write(@this);
			}
		}

	}

}
