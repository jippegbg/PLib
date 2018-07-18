using System.Text;


namespace PLib.Extensions.Core
{

	public static partial class StringExtensions
	{

		/// <summary>
		///     Encodes all the characters in the specified string into a sequence of bytes using the
		///     UTF8 encoding.
		/// </summary>
		/// <param name="me">The string containing the characters to encode.</param>
		/// <returns>
		///     A byte array containing the results of encoding the specified set of characters.
		/// </returns>
		public static byte[] GetBytes(this string me)
		{
			return Encoding.UTF8.GetBytes(me);
		}



		/// <summary>
		///     Encodes all the characters in the specified string into a sequence of bytes using the
		///     given encoding.
		/// </summary>
		/// <param name="me">The string containing the characters to encode.</param>
		/// <param name="encoding">The encoding to use for conversion.</param>
		/// <returns>
		///     A byte array containing the results of encoding the specified set of characters.
		/// </returns>
		public static byte[] GetBytes(this string me, Encoding encoding)
		{
			return encoding.GetBytes(me);
		}

	}

}
