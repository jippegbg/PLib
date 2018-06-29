using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace PLib.Extensions.Core.System.String
{

	public static partial class Extensions
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
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="count">The count.</param>
		/// <returns></returns>
		public static string Repeat(this string @this, int count)
		{
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < count; i++)
			{
				sb.Append(@this);
			}

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

	}

}
