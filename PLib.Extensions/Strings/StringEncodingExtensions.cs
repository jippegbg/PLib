using System.Text;


namespace PLib.Extensions.Strings
{

	/// <summary>
	///     Provides functionality for encoding and decoding string to and from byte arrays.
	/// </summary>
	public static class StringEncodingExtensions
	{

		/// <summary>
		///     Encodes all the characters in the specified string into a sequence of bytes using the
		///     UTF8 encoding.
		/// </summary>
		/// <param name="this">The string containing the characters to encode.</param>
		/// <returns>
		///     A byte array containing the results of encoding the specified set of characters.
		/// </returns>
		public static byte[] GetBytes(this string @this)
		{
			return Encoding.UTF8.GetBytes(@this);
		}



		/// <summary>
		///     Encodes all the characters in the specified string into a sequence of bytes using the
		///     given encoding.
		/// </summary>
		/// <param name="this">The string containing the characters to encode.</param>
		/// <param name="encoding">The encoding to use for conversion.</param>
		/// <returns>
		///     A byte array containing the results of encoding the specified set of characters.
		/// </returns>
		public static byte[] GetBytes(this string @this, Encoding encoding)
		{
			return encoding.GetBytes(@this);
		}



		/// <summary>
		///     Decodes all the bytes in the specified byte array into a string using the UTF8 encoding.
		/// </summary>
		/// <param name="this">The byte array containing the sequence of bytes to decode.</param>
		/// <returns>
		///     A string that contains the results of decoding the specified sequence of bytes.
		/// </returns>
		public static string GetString(this byte[] @this)
		{
			return Encoding.UTF8.GetString(@this);
		}



		/// <summary>
		///     Decodes all the bytes in the specified byte array into a string using the given encoding.
		/// </summary>
		/// <param name="this">The byte array containing the sequence of bytes to decode.</param>
		/// <param name="encoding">The encoding to use for conversion.</param>
		/// <returns>
		///     A string that contains the results of decoding the specified sequence of bytes.
		/// </returns>
		public static string GetString(this byte[] @this, Encoding encoding)
		{
			return encoding.GetString(@this);
		}

	}

}
