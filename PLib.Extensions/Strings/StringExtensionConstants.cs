using System;
using System.Text.RegularExpressions;
using System.Threading;


namespace PLib.Extensions.Strings
{

	/// <summary>
	///     Contains constants and static fields that can be used by all string extension methods.
	/// </summary>
	internal static class StringExtensionConstants
	{

		public const char CHAR_SPACE = ' ';
		public const char CHAR_HYPHEN = '-';
		public const char CHAR_APOSTROPHE = '\'';
		public const char CHAR_QUOTE = '"';

		public const string STRING_SPACE = " ";
		public const string STRING_HYPHEN = "-";
		public const string STRING_APOSTROPHE = "'";
		public const string STRING_QUOTE = "\"";

		public const string PUNCTUATIONS = ".,;:!?'\"";

		public static readonly Lazy<Regex> RxEmailAddress = new Lazy<Regex>(
			() => new Regex(
				@"^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$",
				RegexOptions.Compiled
			),
			LazyThreadSafetyMode.ExecutionAndPublication
		);

		public static readonly Lazy<Regex> RxIPv4Address = new Lazy<Regex>(
			() => new Regex(
				@"(?:^|\s)([a-z]{3,6}(?=://))?(://)?((?:25[0-5]|2[0-4]\d|[01]?\d\d?)\.(?:25[0-5]|2[0-4]\d|[01]?\d\d?)\.(?:25[0-5]|2[0-4]\d|[01]?\d\d?)\.(?:25[0-5]|2[0-4]\d|[01]?\d\d?))(?::(\d{2,5}))?(?:\s|$)",
				RegexOptions.Compiled
			),
			LazyThreadSafetyMode.ExecutionAndPublication
		);

		public static readonly Lazy<Regex> RxWhiteSpace = new Lazy<Regex>(
			() => new Regex(@"[ \t\r\n\f\v]", RegexOptions.Compiled),
			LazyThreadSafetyMode.ExecutionAndPublication
		);
		
		private static readonly Lazy<Regex> RxLeadingWhiteSpaceOnLines  = new Lazy<Regex>(
			() => new Regex(@"^\s+", RegexOptions.Multiline | RegexOptions.Compiled),
			LazyThreadSafetyMode.ExecutionAndPublication
		);

		private static readonly Lazy<Regex> RxTrailingWhiteSpaceOnLines = new Lazy<Regex>(
			() => new Regex(@"\s+$", RegexOptions.Multiline | RegexOptions.Compiled),
			LazyThreadSafetyMode.ExecutionAndPublication
		);

	}

}
