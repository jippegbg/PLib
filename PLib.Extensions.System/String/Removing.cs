using System.Collections.Generic;


namespace PLib.Extensions.System
{

	public static partial class StringExtensions
	{

		/// <summary>
		///     Returns a new string in which all characters from, and including, the first occurance
		///     of a specified character in the current instance, are deleted.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="value">The first character in the current string from where to delete.</param>
		/// <returns>
		///     A new string that is equivalent to this instance except for the removed characters.
		/// </returns>
		public static string RemoveFromFirst(this string me, char value)
		{
			if (me == null)
			{
				return null;
			}

			int pos = me.IndexOf(value);

			if (pos > 0)
			{
				return me.Substring(0, pos);
			}

			return me;
		}



		/// <summary>
		///     Returns a new string in which all characters from and including, the last occurance
		///     of a specified character in the current instance, are deleted.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="value">The last character in the current string from where to delete.</param>
		/// <returns>
		///     A new string that is equivalent to this instance except for the removed characters.
		/// </returns>
		public static string RemoveFromLast(this string me, char value)
		{
			if (me == null)
			{
				return null;
			}

			int pos = me.LastIndexOf(value);

			if (pos > 0)
			{
				return me.Substring(0, pos);
			}

			return me;
		}



		/// <summary>
		///     Returns a new string in which all characters from the start to, not including,
		///     the first occurance of a specified character in the current instance, are deleted.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="value">The first character in the current string from where to keep.</param>
		/// <returns>
		///     A new string that is equivalent to this instance except for the removed characters.
		/// </returns>
		public static string RemoveToFirst(this string me, char value)
		{
			if (me == null)
			{
				return null;
			}

			int pos = me.IndexOf(value);

			if (pos > 0)
			{
				return me.Substring(pos);
			}

			return me;
		}



		/// <summary>
		///     Returns a new string in which all characters from the start to, not including,
		///     the last occurance of a specified character in the current instance, are deleted.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="value">The last character in the current string from where to keep.</param>
		/// <returns>
		///     A new string that is equivalent to this instance except for the removed characters.
		/// </returns>
		public static string RemoveToLast(this string me, char value)
		{
			if (me == null)
			{
				return null;
			}

			int pos = me.LastIndexOf(value);

			if (pos > 0)
			{
				return me.Substring(pos);
			}

			return me;
		}



		/// <summary>
		///     Returns a copy of the current string where all occurrences of a specified character
		///     are removed.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="c">A character to remove.</param>
		/// <returns>
		///     A copy of the current string where all occurrences of a specified character are removed.
		/// </returns>
		public static string Remove(this string me, char c)
		{
			if (me == null)
			{
				return null;
			}

			List<char> result = new List<char>(me.Length);

			for (int i = 0; i < me.Length; i++)
			{
				if (me[i] != c)
				{
					result.Add(me[i]);
				}
			}

			return new string(result.ToArray());
		}



		/// <summary>
		///     Returns a copy of the current string where all occurrences of all characters in a
		///     list are removed.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="chars">An array of characters to remove.</param>
		/// <returns>
		///     A copy of the current string where all occurrences of all characters in a list are removed.
		/// </returns>
		public static string Remove(this string me, params char[] chars)
		{
			if (me == null)
			{
				return null;
			}

			List<char> result = new List<char>(me.Length);

			for (int i = 0; i < me.Length; i++)
			{
				bool noMatch = true;

				for (int j = 0; j < chars.Length; noMatch &= me[i] != chars[j++]) { } // :D

				if (noMatch)
				{
					result.Add(me[i]);
				}
			}

			return new string(result.ToArray());
		}



		/// <summary>
		///     Returns a copy of the current string where all occurrences of a specified substring
		///     are removed.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="substring">The substring to be removed.</param>
		/// <returns>
		///     A copy of the current string where all occurrences of a specified substring are removed.
		/// </returns>
		public static string Remove(this string me, string substring)
		{
			return me?.Replace(substring, string.Empty);
		}



		/// <summary>
		///     Returns a copy of the current string where all white-space characters are removed.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns>A copy of the current string where all white-space characters are removed.</returns>
		public static string RemoveWhiteSpace(this string me)
		{
			if (me == null)
			{
				return null;
			}

			return RxWhiteSpace.Value.Replace(me, string.Empty);
		}



		/// <summary>
		///     Returns a copy of the current string where quotings are removed from the start
		///     and end, and escaped quotings inside the string are unescaped.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns>
		///     A copy of the current string where quotings are removed from the start and end,
		///     and escaped quotings inside the string are unescaped.
		/// </returns>
		public static string RemoveQuoting(this string me)
		{
			if (me == null)
			{
				return null;
			}

			// Regular string surrounded by quotes (can contain escaped quotes)
			if (me.StartsWith("\"") && me.EndsWith("\""))
			{
				return me.Trim('"').Replace("\\\"", "\"");
			}

			// Regular string surrounded by apostrophes (can contain escaped apostrophes)
			if (me.StartsWith("'") && me.EndsWith("'"))
			{
				return me.Trim('\'').Replace("\\'", "'");
			}

			// Verbatim string surrounded by quotes (can contain double quotes)
			if (me.StartsWith("@\"") && me.EndsWith("\""))
			{
				return me.Substring(1).Trim('"').Replace("\"\"", "\"");
			}

			// Verbatim string surrounded by apostrophes (can contain double apostrophes)
			if (me.StartsWith("@'") && me.EndsWith("'"))
			{
				return me.Substring(1).Trim('\'').Replace("''", "'");
			}

			return me;
		}

	}

}
