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
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static string Copy(this string me) => string.Copy(me);



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="pattern">The pattern.</param>
		/// <param name="options">The options.</param>
		/// <returns></returns>
		public static bool Matches(this string me, string pattern, RegexOptions options = RegexOptions.None)
		{
			return Regex.IsMatch(me, pattern, options);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="pattern">The pattern.</param>
		/// <param name="options">The options.</param>
		/// <returns></returns>
		public static Match GetMatch(this string me, string pattern, RegexOptions options = RegexOptions.None)
		{
			return Regex.Match(me, pattern, options);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="pattern">The pattern.</param>
		/// <param name="options">The options.</param>
		/// <returns></returns>
		public static IEnumerable<Match> GetMatches(this string me, string pattern, RegexOptions options = RegexOptions.None)
		{
			foreach (Match m in Regex.Matches(me, pattern, options))
			{
				yield return m;
			}
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static string EncodeBase64(this string me) => Convert.ToBase64String(Encoding.ASCII.GetBytes(me));



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static string DecodeBase64(this string me) => Encoding.ASCII.GetString(Convert.FromBase64String(me));



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static string FilterLetters(this string me) => me.ToCharArray().Where(char.IsLetter).ToString();



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static string FilterDecimalDigits(this string me) => me.ToCharArray().Where(char.IsDigit).ToString();



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static string FilterNumbers(this string me) => me.ToCharArray().Where(char.IsNumber).ToString();



		/// <summary>
		///     Repeats the current string a specified number of times.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="count">The nuber to repeat teh current string.</param>
		/// <returns>
		///     A new string where the current string is repeated after itself a specified
		///     number of times.
		/// </returns>
		public static string Repeat(this string me, int count)
		{
			StringBuilder sb = new StringBuilder(me.Length * count);

			do
			{
				sb.Append(me);
			}
			while (--count > 0);

			return sb.ToString();
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="replacement">The replacement.</param>
		/// <returns></returns>
		public static string IfNull(this string me, string replacement)
		{
			return me ?? replacement;
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="replacement">The replacement.</param>
		/// <returns></returns>
		public static string IfNullOrEmpty(this string me, string replacement)
		{
			return string.IsNullOrEmpty(me) ? replacement : me;
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="replacement">The replacement.</param>
		/// <returns></returns>
		public static string IfNullOrWhiteSpace(this string me, string replacement)
		{
			return string.IsNullOrWhiteSpace(me) ? replacement : me;
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="other">The other.</param>
		/// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
		/// <returns>
		///   <c>true</c> if the specified other is anagram; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsAnagram(this string me, string other, bool ignoreCase = false)
		{
			if (me == null || other == null || me.Length != other.Length)
			{
				return false;
			}

			char[] chars = me.ToCharArray();
			Array.Sort(chars);

			char[] otherChars = other.ToCharArray();
			Array.Sort(otherChars);

			return new string(chars).Equals(new string(otherChars), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="other">The other.</param>
		/// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
		/// <returns>
		///   <c>true</c> if the specified other is palindrome; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsPalindrome(this string me, string other, bool ignoreCase = false)
		{
			return me.Equals(me.Reverse(), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="pattern">The pattern.</param>
		/// <returns>
		///   <c>true</c> if the specified pattern is like; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsLike(this string me, string pattern)
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

			return Regex.IsMatch(me, regexPattern);
		}



		/// <summary>
		/// Combines the path with.
		/// </summary>
		/// <param name="me">The this.</param>
		/// <param name="paths">The paths.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for CombinePathWith
		public static string CombinePathWith(this string me, params string[] paths)
		{
			string[] args = new string[paths.Length + 1];
			Array.Copy(paths, 0, args, 1, paths.Length);
			args[0] = me;
			return Path.Combine(args);
		}



		/// <summary>
		/// Removes the letters.
		/// </summary>
		/// <param name="me">The this.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for RemoveLetters
		public static string RemoveLetters(this string me)
		{
			return new string(me.Where(c => !Char.IsLetter(c)).ToArray());
		}



		/// <summary>
		/// Removes the numbers.
		/// </summary>
		/// <param name="me">The this.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for RemoveNumbers
		public static string RemoveNumbers(this string me)
		{
			return new string(me.Where(c => !Char.IsNumber(c)).ToArray());
		}



		/// <summary>
		/// Removes the decimal digits.
		/// </summary>
		/// <param name="me">The this.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for RemoveDecimalDigits
		public static string RemoveDecimalDigits(this string me)
		{
			return new string(me.Where(c => !Char.IsDigit(c)).ToArray());
		}



		/// <summary>
		/// Removes the character where.
		/// </summary>
		/// <param name="me">The this.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for RemoveCharacterWhere
		public static string RemoveCharacterWhere(this string me, Func<char, bool> predicate)
		{
			return new string(me.Where(c => !predicate(c)).ToArray());
		}



		/// <summary>
		/// Replaces the segment.
		/// </summary>
		/// <param name="me">The this.</param>
		/// <param name="startIndex">The start index.</param>
		/// <param name="endIndex">The end index.</param>
		/// <param name="replacement">The replacement.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ReplaceSegment
		public static string ReplaceSegment(this string me, int startIndex, int endIndex, string replacement)
		{
			return $"{me.Substring(0, startIndex)}{replacement}{me.Substring(endIndex)}";
		}



		/// <summary>
		/// Replaces the length of the segment.
		/// </summary>
		/// <param name="me">The this.</param>
		/// <param name="startIndex">The start index.</param>
		/// <param name="length">The length.</param>
		/// <param name="replacement">The replacement.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ReplaceSegmentLength
		public static string ReplaceSegmentLength(this string me, int startIndex, int length, string replacement)
		{
			return $"{me.Substring(0, startIndex)}{replacement}{me.Substring(startIndex + length)}";
		}



		/// <summary>
		/// Replaces the first.
		/// </summary>
		/// <param name="me">The this.</param>
		/// <param name="substring">The substring.</param>
		/// <param name="replacement">The replacement.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ReplaceFirst
		public static string ReplaceFirst(this string me, string substring, string replacement)
		{
			int ix = me.IndexOf(substring, StringComparison.Ordinal);

			if (ix == -1)
			{
				return me;
			}

			return $@"{me.Substring(0, ix)}{replacement}{me.Substring(ix + substring.Length)}";
		}



		/// <summary>
		/// Replaces the last.
		/// </summary>
		/// <param name="me">The me.</param>
		/// <param name="substring">The substring.</param>
		/// <param name="replacement">The replacement.</param>
		/// <returns></returns>
		public static string ReplaceLast(this string me, string substring, string replacement)
		{
			int ix = me.LastIndexOf(substring, StringComparison.Ordinal);

			if (ix == -1)
			{
				return me;
			}

			return $@"{me.Substring(0, ix)}{replacement}{me.Substring(ix + substring.Length)}";
		}



		/// <summary>
		/// Erases the specified substrings.
		/// </summary>
		/// <param name="me">The this.</param>
		/// <param name="substrings">The substrings.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for Erase
		public static string Erase(this string me, params string[] substrings)
		{
			foreach (string ss in substrings)
			{
				me = me.Replace(ss, new string(CHAR_SPACE, ss.Length));
			}

			return me;
		}



		/// <summary>
		/// Erases the segment.
		/// </summary>
		/// <param name="me">The this.</param>
		/// <param name="startIndex">The start index.</param>
		/// <param name="endIndex">The end index.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for EraseSegment
		public static string EraseSegment(this string me, int startIndex, int endIndex)
		{
			char[] chars = me.ToCharArray();

			for (int i = startIndex; i < endIndex; i++)
			{
				chars[i] = CHAR_SPACE;
			}

			return new string(chars);

			//return $"{me.Substring(0, startIndex)}{new string(CHAR_SPACE, endIndex - startIndex)}{me.Substring(endIndex)}";
		}



		/// <summary>
		/// Erases the first.
		/// </summary>
		/// <param name="me">The this.</param>
		/// <param name="substring">The substring.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for EraseFirst
		public static string EraseFirst(this string me, string substring)
		{
			int ix = me.IndexOf(substring, StringComparison.Ordinal);

			if (ix == -1)
			{
				return me;
			}

			char[] chars = me.ToCharArray();
			for (int i = ix; i < substring.Length; i++)
			{
				chars[i] = CHAR_SPACE;
			}

			return new string(chars);
		}



		/// <summary>
		/// Erases the last.
		/// </summary>
		/// <param name="me">The this.</param>
		/// <param name="substring">The substring.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for EraseLast
		public static string EraseLast(this string me, string substring)
		{
			int ix = me.LastIndexOf(substring, StringComparison.Ordinal);

			if (ix == -1)
			{
				return me;
			}

			char[] chars = me.ToCharArray();
			for (int i = ix; i < substring.Length; i++)
			{
				chars[i] = CHAR_SPACE;
			}

			return new string(chars);
		}



		/// <summary>
		/// Removes the specified substrings.
		/// </summary>
		/// <param name="me">The this.</param>
		/// <param name="substrings">The substrings.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for Remove
		public static string Remove(this string me, params string[] substrings)
		{
			foreach (string ss in substrings)
			{
				me = me.Replace(ss, string.Empty);
			}

			return me;
		}



		/// <summary>
		/// Removes the segment.
		/// </summary>
		/// <param name="me">The this.</param>
		/// <param name="startIndex">The start index.</param>
		/// <param name="endIndex">The end index.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for RemoveSegment
		public static string RemoveSegment(this string me, int startIndex, int endIndex)
		{
			return $"{me.Substring(0, startIndex)}{me.Substring(endIndex)}";
		}



		/// <summary>
		/// Removes the first.
		/// </summary>
		/// <param name="me">The this.</param>
		/// <param name="substring">The substring.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for RemoveFirst
		public static string RemoveFirst(this string me, string substring)
		{
			int ix = me.IndexOf(substring, StringComparison.Ordinal);

			if (ix == -1)
			{
				return me;
			}

			return $"{me.Substring(0, ix)}{me.Substring(ix + substring.Length)}";
		}



		/// <summary>
		/// Removes the last.
		/// </summary>
		/// <param name="me">The this.</param>
		/// <param name="substring">The substring.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for RemoveLast
		public static string RemoveLast(this string me, string substring)
		{
			int ix = me.LastIndexOf(substring, StringComparison.Ordinal);

			if (ix == -1)
			{
				return me;
			}

			return $"{me.Substring(0, ix)}{me.Substring(ix + substring.Length)}";
		}



		/// <summary>
		/// Saves as.
		/// </summary>
		/// <param name="me">The this.</param>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="append">if set to <c>true</c> [append].</param>
		/// TODO Edit XML Comment Template for SaveAs
		public static void SaveAs(this string me, string fileName, bool append = false)
		{
			using (TextWriter tw = new StreamWriter(fileName, append))
			{
				tw.Write(me);
			}
		}



		/// <summary>
		/// Saves as.
		/// </summary>
		/// <param name="me">The this.</param>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="encoding">The encoding.</param>
		/// <param name="append">if set to <c>true</c> [append].</param>
		/// TODO Edit XML Comment Template for SaveAs
		public static void SaveAs(this string me, string fileName, Encoding encoding, bool append = false)
		{
			using (TextWriter tw = new StreamWriter(fileName, append, encoding))
			{
				tw.Write(me);
			}
		}



		/// <summary>
		/// Saves as.
		/// </summary>
		/// <param name="me">The this.</param>
		/// <param name="file">The file.</param>
		/// <param name="append">if set to <c>true</c> [append].</param>
		/// TODO Edit XML Comment Template for SaveAs
		public static void SaveAs(this string me, FileInfo file, bool append)
		{
			using (TextWriter tw = new StreamWriter(file.FullName, append))
			{
				tw.Write(me);
			}
		}



		/// <summary>
		/// Saves as.
		/// </summary>
		/// <param name="me">The this.</param>
		/// <param name="file">The file.</param>
		/// <param name="encoding">The encoding.</param>
		/// <param name="append">if set to <c>true</c> [append].</param>
		/// TODO Edit XML Comment Template for SaveAs
		public static void SaveAs(this string me, FileInfo file, Encoding encoding, bool append = false)
		{
			using (TextWriter tw = new StreamWriter(file.FullName, append, encoding))
			{
				tw.Write(me);
			}
		}

	}

}
