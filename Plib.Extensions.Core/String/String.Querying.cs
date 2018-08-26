using System;
using System.Collections.Generic;
using System.Linq;


namespace PLib.Extensions.Core
{

	public static partial class StringExtensions
	{

		/// <summary>
		///     Checks if a string contains another sub-string.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="value">The sub-string to search for.</param>
		/// <param name="comparisonType">
		///     One of the enumeration values that specifies the rules for the search.
		///     Default <see cref="StringComparison.CurrentCulture"/>.
		/// </param>
		/// <returns>
		///     <see langword="true"/> if the current string contains the given substring; otherwise <see langword="false"/>.
		/// </returns>
		public static bool Contains(this string me, string value, StringComparison comparisonType = StringComparison.CurrentCulture)
		{
			return me.IndexOf(value, comparisonType) != -1;
		}



		/// <summary>
		///     Checks if a string contains all of the specified substrings.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="comparisonType">
		///     One of the enumeration values that specifies the rules for the search.
		///     Default <see cref="StringComparison.CurrentCulture"/>.
		/// </param>
		/// <param name="values">The sub-strings to check.</param>
		/// <returns>
		///   <see langword="true"/> if the specified comparison type contains all of the sppecified
		///     sub-strings; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool ContainsAll(this string me, StringComparison comparisonType = StringComparison.CurrentCulture, params string[] values)
		{
			foreach (string value in values)
			{
				if (me.IndexOf(value, comparisonType) == -1)
				{
					return false;
				}
			}

			return true;
		}



		/// <summary>
		///     Checks if a string contains any of the specified substrings.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="comparisonType">
		///     One of the enumeration values that specifies the rules for the search.
		///     Default <see cref="StringComparison.CurrentCulture"/>.
		/// </param>
		/// <param name="values">The sub-strings to check.</param>
		/// <returns>
		///   <see langword="true"/> if the specified comparison type contains any of the sppecified
		///     sub-strings; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool ContainsAny(this string me, StringComparison comparisonType = StringComparison.CurrentCulture, params string[] values)
		{
			foreach (string value in values)
			{
				if (me.IndexOf(value, comparisonType) != -1)
				{
					return true;
				}
			}

			return false;
		}



		/// <summary>
		///     Determines whether the current string has any unicode letter characters.
		/// </summary>
		/// <param name="me">The string to test.</param>
		/// <returns><see langword="true"/> if the current string has any letters; otherwise, <see langword="false"/>.</returns>
		public static bool HasAlpha(this string me)
		{
			return me != null && me.Any(char.IsLetter);
		}



		/// <summary>
		///     Determines whether this instance has any decimal digits.
		/// </summary>
		/// <param name="me">The string to test.</param>
		/// <returns>
		///     <see langword="true"/> if the current string has any decimal digits; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool HasDecimalDigits(this string me)
		{
			return me != null && me.Any(char.IsDigit);
		}



		/// <summary>
		///     Determines whether the specified string is not <see langword="null"/> nor an empty string.
		/// </summary>
		/// <param name="me">The string to test.</param>
		/// <returns>
		///     <see langword="true"/> if the string is not <see langword="null"/> and has at least one character; otherwise,
		///     false <see langword="false"/>.
		/// </returns>
		public static bool IsNotNullNorEmpty(this string me)
		{
			return !string.IsNullOrEmpty(me);
		}



		/// <summary>
		///     Determines whether a specified string is not <see langword="null"/>, not an empty string, and
		///     doesn't consists of only white-space characters.
		/// </summary>
		/// <param name="me">The string to test.</param>
		/// <returns>
		///     <see langword="true"/> if the string is not <see langword="null"/> and has at least
		///     one non-white-space character; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool IsNotNullNorWhitespace(this string me)
		{
			return !string.IsNullOrWhiteSpace(me);
		}



		/// <summary>
		///     Determines whether the the current string is equal to any of strings in the provided array.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="values">A list of strings to compare with the current one.</param>
		/// <returns>
		///     true if the list of strings contains an element that equals the current string;
		///     otherwise, <see langword="false"/>.
		/// </returns>
		/// <remarks>Comparison is case sensitive.</remarks>
		public static bool IsIn(this string me, params string[] values)
		{
			return Array.IndexOf(values, me) != -1;
		}



		/// <summary>
		///     Determines whether the the current string is equal to any of strings in the provided sequence.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="values">A sequence of strings to compare with the current one.</param>
		/// <param name="ignoreCase">If case should be ignored when comparing stings.</param>
		/// <returns>
		///     <see langword="true"/> if the sequence of strings contains an element that equals the current string;
		///     otherwise, <see langword="false"/>.
		/// </returns>
		public static bool IsIn(this string me, IEnumerable<string> values, bool ignoreCase = false)
		{
			return values.Contains(me, ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
		}



		/// <summary>
		///     Determines whether the current string is composed of all unicode letter characters.
		/// </summary>
		/// <param name="me">The string to test.</param>
		/// <param name="includeSpace">if set to <see langword="true"/>, allow spaces.</param>
		/// <returns>
		///     <see langword="true"/> if the current string is composed of all letter characters (and spaces);
		///     otherwise, <see langword="false"/>.
		/// </returns>
		public static bool IsAlpha(this string me, bool includeSpace = false)
		{
			return !string.IsNullOrEmpty(me) && me.All(c => char.IsLetter(c) || c == ' ' && includeSpace);
		}



		/// <summary>
		///     Determines whether the current string has only letters and decimal digits, optionally
		///     including spaces.
		/// </summary>
		/// <param name="me">The string to test.</param>
		/// <param name="includeSpace">if set to <see langword="true"/>, allow spaces.</param>
		/// <returns>
		///     <see langword="true"/> if the current string has only letters and decimal digits (and spaces);
		///     otherwise, <see langword="false"/>.
		/// </returns>
		public static bool IsAlphaNumeric(this string me, bool includeSpace = false)
		{
			return !string.IsNullOrEmpty(me) && me.All(c => char.IsLetterOrDigit(c) || c == ' ' && includeSpace);
		}



		/// <summary>
		///     Determines whether the current string is an email address.
		/// </summary>
		/// <param name="me">The string to test.</param>
		/// <returns><see langword="true"/> if the current string is an email address; otherwise, <see langword="false"/>.</returns>
		public static bool IsEmailAddress(this string me)
		{
			return !string.IsNullOrEmpty(me) && RxEmailAddress.Value.IsMatch(me);
		}



		/// <summary>
		///     Determines whether the current string is a valid IPv4 address.
		/// </summary>
		/// <param name="me">The string to test.</param>
		/// <returns>
		///     <see langword="true"/> if the current string is a valid IPv4 address; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool IsIPv4Address(this string me)
		{
			return !string.IsNullOrEmpty(me) && RxIPv4Address.Value.IsMatch(me);
		}



		/// <summary>
		///     Determines whether the letters in the current string are all lower case.
		/// </summary>
		/// <param name="me">The string to test.</param>
		/// <returns>
		///     <see langword="true"/> if all letters in the current string are all lower case; otherwise, <see langword="false"/>.
		/// </returns>
		/// <remarks>If the string contains no letters, <see langword="true"/> is returned.</remarks>
		public static bool IsLower(this string me)
		{
			return me != null && me.All(c => !char.IsLetter(c) || char.IsLower(c));
		}



		/// <summary>
		///     Determines whether the specified string is <see langword="null"/> or an empty string.
		/// </summary>
		/// <param name="me">The string to test.</param>
		/// <returns>
		///     <see langword="true"/> if the string is <see langword="null"/> or an empty string (""); otherwise, false <see langword="false"/>.
		/// </returns>
		public static bool IsNullOrEmpty(this string me)
		{
			return string.IsNullOrEmpty(me);
		}



		/// <summary>
		///     Determines whether a specified string is <see langword="null"/>, empty, or consists only of
		///     white-space characters.
		/// </summary>
		/// <param name="me">The string to test.</param>
		/// <returns>
		///     <see langword="true"/> if the string is <see langword="null"/> or an empty string (""), or if the string
		///     consists exclusively of white-space characters; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool IsNullOrWhiteSpace(this string me)
		{
			return string.IsNullOrWhiteSpace(me);
		}



		/// <summary>
		///     Determines whether the letters in the current string are all upper case.
		/// </summary>
		/// <param name="me">The string to test.</param>
		/// <returns>
		///     <see langword="true"/> if all letters in the current string are all upper case; otherwise, <see langword="false"/>.
		/// </returns>
		/// <remarks>If the string contains no letters, <see langword="true"/> is returned.</remarks>
		public static bool IsUpper(this string me)
		{
			return me != null && me.All(c => !char.IsLetter(c) || char.IsUpper(c));
		}

	}

}
