using System.Collections.Generic;


namespace PLib.Extensions.System
{

	public static partial class StringExtensions
	{

		/// <summary>
		///     Returns a new string in which all characters from, and including, the first occurance
		///     of a specified character in the current instance, are deleted.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The first character in the current string from where to delete.</param>
		/// <returns>
		///     A new string that is equivalent to this instance except for the removed characters.
		/// </returns>
		public static string RemoveFromFirst(this string @this, char value)
		{
			if (@this == null)
			{
				return null;
			}

			int pos = @this.IndexOf(value);

			if (pos > 0)
			{
				return @this.Substring(0, pos);
			}

			return @this;
		}



		/// <summary>
		///     Returns a new string in which all characters from and including, the last occurance
		///     of a specified character in the current instance, are deleted.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The last character in the current string from where to delete.</param>
		/// <returns>
		///     A new string that is equivalent to this instance except for the removed characters.
		/// </returns>
		public static string RemoveFromLast(this string @this, char value)
		{
			if (@this == null)
			{
				return null;
			}

			int pos = @this.LastIndexOf(value);

			if (pos > 0)
			{
				return @this.Substring(0, pos);
			}

			return @this;
		}



		/// <summary>
		///     Returns a new string in which all characters from the start to, not including,
		///     the first occurance of a specified character in the current instance, are deleted.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The first character in the current string from where to keep.</param>
		/// <returns>
		///     A new string that is equivalent to this instance except for the removed characters.
		/// </returns>
		public static string RemoveToFirst(this string @this, char value)
		{
			if (@this == null)
			{
				return null;
			}

			int pos = @this.IndexOf(value);

			if (pos > 0)
			{
				return @this.Substring(pos);
			}

			return @this;
		}



		/// <summary>
		///     Returns a new string in which all characters from the start to, not including,
		///     the last occurance of a specified character in the current instance, are deleted.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The last character in the current string from where to keep.</param>
		/// <returns>
		///     A new string that is equivalent to this instance except for the removed characters.
		/// </returns>
		public static string RemoveToLast(this string @this, char value)
		{
			if (@this == null)
			{
				return null;
			}

			int pos = @this.LastIndexOf(value);

			if (pos > 0)
			{
				return @this.Substring(pos);
			}

			return @this;
		}



		/// <summary>
		///     Returns a copy of the current string where all occurrences of a specified character
		///     are removed.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="c">A character to remove.</param>
		/// <returns>
		///     A copy of the current string where all occurrences of a specified character are removed.
		/// </returns>
		public static string Remove(this string @this, char c)
		{
			if (@this == null)
			{
				return null;
			}

			List<char> result = new List<char>(@this.Length);

			for (int i = 0; i < @this.Length; i++)
			{
				if (@this[i] != c)
				{
					result.Add(@this[i]);
				}
			}

			return new string(result.ToArray());
		}



		/// <summary>
		///     Returns a copy of the current string where all occurrences of all characters in a
		///     list are removed.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="chars">An array of characters to remove.</param>
		/// <returns>
		///     A copy of the current string where all occurrences of all characters in a list are removed.
		/// </returns>
		public static string Remove(this string @this, params char[] chars)
		{
			if (@this == null)
			{
				return null;
			}

			List<char> result = new List<char>(@this.Length);

			for (int i = 0; i < @this.Length; i++)
			{
				bool noMatch = true;

				for (int j = 0; j < chars.Length; noMatch &= @this[i] != chars[j++]) { } // :D

				if (noMatch)
				{
					result.Add(@this[i]);
				}
			}

			return new string(result.ToArray());
		}



		/// <summary>
		///     Returns a copy of the current string where all occurrences of a specified substring
		///     are removed.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="substring">The substring to be removed.</param>
		/// <returns>
		///     A copy of the current string where all occurrences of a specified substring are removed.
		/// </returns>
		public static string Remove(this string @this, string substring)
		{
			return @this?.Replace(substring, string.Empty);
		}



		/// <summary>
		///     Returns a copy of the current string where all white-space characters are removed.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns>A copy of the current string where all white-space characters are removed.</returns>
		public static string RemoveWhiteSpace(this string @this)
		{
			if (@this == null)
			{
				return null;
			}

			return RxWhiteSpace.Value.Replace(@this, string.Empty);
		}



		/// <summary>
		///     Returns a copy of the current string where quotings are removed from the start
		///     and end, and escaped quotings inside the string are unescaped.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns>
		///     A copy of the current string where quotings are removed from the start and end,
		///     and escaped quotings inside the string are unescaped.
		/// </returns>
		public static string RemoveQuoting(this string @this)
		{
			if (@this == null)
			{
				return null;
			}

			// Regular string surrounded by quotes (can contain escaped quotes)
			if (@this.StartsWith("\"") && @this.EndsWith("\""))
			{
				return @this.Trim('"').Replace("\\\"", "\"");
			}

			// Regular string surrounded by apostrophes (can contain escaped apostrophes)
			if (@this.StartsWith("'") && @this.EndsWith("'"))
			{
				return @this.Trim('\'').Replace("\\'", "'");
			}

			// Verbatim string surrounded by quotes (can contain double quotes)
			if (@this.StartsWith("@\"") && @this.EndsWith("\""))
			{
				return @this.Substring(1).Trim('"').Replace("\"\"", "\"");
			}

			// Verbatim string surrounded by apostrophes (can contain double apostrophes)
			if (@this.StartsWith("@'") && @this.EndsWith("'"))
			{
				return @this.Substring(1).Trim('\'').Replace("''", "'");
			}

			return @this;
		}

	}

}
