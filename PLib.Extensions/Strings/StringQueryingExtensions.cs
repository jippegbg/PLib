using System;
using System.Linq;


namespace PLib.Extensions.Strings {

	using static StringExtensionConstants;



	/// <summary>
	///     Contains methods for getting information about strings without modifying them.
	/// </summary>
	public static class StringQueryingExtensions
	{

		/// <summary>
		///     Checks if a string contains another sub-string.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="substring">The sub-string to search for.</param>
		/// <param name="comparisonType">
		///     One of the enumeration values that specifies the rules for the search.
		/// </param>
		/// <returns>
		///     <c>true</c> if the current string contains the given substring; otherwise <c>false</c>.
		/// </returns>
		public static bool Contains(this string @this, string substring, StringComparison comparisonType)
		{
			if (@this == null)
			{
				return false;
			}

			if (substring == null)
			{
				throw new ArgumentNullException(nameof(substring), "substring cannot be null.");
			}

			if (!Enum.IsDefined(typeof(StringComparison), comparisonType))
			{
				throw new ArgumentException("Not a member of StringComparison", nameof(comparisonType));
			}

			return @this.IndexOf(substring, comparisonType) >= 0;
		}



		/// <summary>
		///     Determines whether the current string has any unicode letter characters.
		/// </summary>
		/// <param name="this">The string to test.</param>
		/// <returns><c>true</c> if the current string has any letters; otherwise, <c>false</c>.</returns>
		public static bool HasAlpha(this string @this) => @this != null && @this.Any(char.IsLetter);



		/// <summary>
		///     Determines whether this instance has any decimal digits.
		/// </summary>
		/// <param name="this">The string to test.</param>
		/// <returns>
		///     <c>true</c> if the current string has any decimal digits; otherwise, <c>false</c>.
		/// </returns>
		public static bool HasDecimalDigits(this string @this) => @this != null && @this.Any(char.IsDigit);



		/// <summary>
		///     Determines whether the specified string is not <c>null</c> nor an empty string.
		/// </summary>
		/// <param name="this">The string to test.</param>
		/// <returns>
		///     <c>true</c> if the string is not <c>null</c> nor an empty string (""); otherwise,
		///     false <c>false</c>.
		/// </returns>
		public static bool HasLength(this string @this) => !string.IsNullOrEmpty(@this);



		/// <summary>
		///     Determines whether a specified string is not <c>null</c>, not empty, and doesn't
		///     consists of only white-space characters.
		/// </summary>
		/// <param name="this">The string to test.</param>
		/// <returns>
		///     <c>true</c> if the string is not <c>null</c> nor an empty string (""), and if the
		///     string doesn't consists exclusively of white-space characters; otherwise, <c>false</c>.
		/// </returns>
		public static bool HasValue(this string @this) => !string.IsNullOrWhiteSpace(@this);



		/// <summary>
		///     Determines whether the current string is composed of all unicode letter characters.
		/// </summary>
		/// <param name="this">The string to test.</param>
		/// <param name="includeSpace">if set to <c>true</c>, allow spaces.</param>
		/// <returns>
		///     <c>true</c> if the current string is composed of all letter characters (and spaces);
		///     otherwise, <c>false</c>.
		/// </returns>
		public static bool IsAlpha(this string @this, bool includeSpace = false) =>
			!string.IsNullOrEmpty(@this) && @this.All(c => char.IsLetter(c) || c == ' ' && includeSpace);



		/// <summary>
		///     Determines whether the current string has only letters and decimal digits, optionally
		///     including spaces.
		/// </summary>
		/// <param name="this">The string to test.</param>
		/// <param name="includeSpace">if set to <c>true</c>, allow spaces.</param>
		/// <returns>
		///     <c>true</c> if the current string has only letters and decimal digits (and spaces);
		///     otherwise, <c>false</c>.
		/// </returns>
		public static bool IsAlphaNumeric(this string @this, bool includeSpace = false) =>
			!string.IsNullOrEmpty(@this) && @this.All(c => char.IsLetterOrDigit(c) || c == ' ' && includeSpace);



		/// <summary>
		///     Determines whether the current string is an email address.
		/// </summary>
		/// <param name="this">The string to test.</param>
		/// <returns><c>true</c> if the current string is an email address; otherwise, <c>false</c>.</returns>
		public static bool IsEmailAddress(this string @this) => !string.IsNullOrEmpty(@this) && RxEmailAddress.Value.IsMatch(@this);



		/// <summary>
		///     Determines whether the current string is a valid IPv4 address.
		/// </summary>
		/// <param name="this">The string to test.</param>
		/// <returns>
		///     <c>true</c> if the current string is a valid IPv4 address; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsIPv4Address(this string @this) => !string.IsNullOrEmpty(@this) && RxIPv4Address.Value.IsMatch(@this);



		/// <summary>
		///     Determines whether the letters in the current string are all lower case.
		/// </summary>
		/// <param name="this">The string to test.</param>
		/// <returns>
		///     <c>true</c> if all letters in the current string are all lower case; otherwise, <c>false</c>.
		/// </returns>
		/// <remarks>If the string contains no letters, <c>true</c> is returned.</remarks>
		public static bool IsLower(this string @this) => @this != null && @this.All(c => !char.IsLetter(c) || char.IsLower(c));



		/// <summary>
		///     Determines whether the specified string is <c>null</c> or an empty string.
		/// </summary>
		/// <param name="this">The string to test.</param>
		/// <returns>
		///     <c>true</c> if the string is <c>null</c> or an empty string (""); otherwise, false <c>false</c>.
		/// </returns>
		public static bool IsNullOrEmpty(this string @this) => string.IsNullOrEmpty(@this);



		/// <summary>
		///     Determines whether a specified string is <c>null</c>, empty, or consists only of
		///     white-space characters.
		/// </summary>
		/// <param name="this">The string to test.</param>
		/// <returns>
		///     <c>true</c> if the string is <c>null</c> or an empty string (""), or if the string
		///     consists exclusively of white-space characters; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsNullOrWhiteSpace(this string @this) => string.IsNullOrWhiteSpace(@this);



		/// <summary>
		///     Determines whether the letters in the current string are all upper case.
		/// </summary>
		/// <param name="this">The string to test.</param>
		/// <returns>
		///     <c>true</c> if all letters in the current string are all upper case; otherwise, <c>false</c>.
		/// </returns>
		/// <remarks>If the string contains no letters, <c>true</c> is returned.</remarks>
		public static bool IsUpper(this string @this) => @this != null && @this.All(c => !char.IsLetter(c) || char.IsUpper(c));

	}

}
