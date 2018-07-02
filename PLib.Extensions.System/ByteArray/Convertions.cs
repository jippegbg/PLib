using System;
using System.Text;


namespace PLib.Extensions.System
{

	/// <summary>
	/// 
	/// </summary>
	/// TODO Edit XML Comment Template for ByteArrayExtensions
	public static partial class ByteArrayExtensions
	{

		#region [ GetString ]

		/// <summary>
		///     Decodes all the bytes in the specified byte array into a string using the UTF8 encoding.
		/// </summary>
		/// <param name="me">The byte array containing the sequence of bytes to decode.</param>
		/// <returns>
		///     A string that contains the results of decoding the specified sequence of bytes.
		/// </returns>
		public static string GetString(this byte[] me)
		{
			return Encoding.UTF8.GetString(me);
		}



		/// <summary>
		///     Decodes all the bytes in the specified byte array into a string using the given encoding.
		/// </summary>
		/// <param name="me">The byte array containing the sequence of bytes to decode.</param>
		/// <param name="encoding">The encoding to use for conversion.</param>
		/// <returns>
		///     A string that contains the results of decoding the specified sequence of bytes.
		/// </returns>
		public static string GetString(this byte[] me, Encoding encoding)
		{
			return encoding.GetString(me);
		}

		#endregion [ GetString ]



		#region [ ToBase64String ]

		/// <summary>
		/// To the base64 string.
		/// </summary>
		/// <param name="me">Me.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToBase64String
		public static string ToBase64String(this byte[] me)
		{
			return Convert.ToBase64String(me);
		}



		/// <summary>
		/// To the base64 string.
		/// </summary>
		/// <param name="me">Me.</param>
		/// <param name="options">The options.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToBase64String
		public static string ToBase64String(this byte[] me, Base64FormattingOptions options)
		{
			return Convert.ToBase64String(me, options);
		}



		/// <summary>
		/// To the base64 string.
		/// </summary>
		/// <param name="me">Me.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="length">The length.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToBase64String
		public static string ToBase64String(this byte[] me, int offset, int length)
		{
			return Convert.ToBase64String(me, offset, length);
		}



		/// <summary>
		/// To the base64 string.
		/// </summary>
		/// <param name="me">Me.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="length">The length.</param>
		/// <param name="options">The options.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToBase64String
		public static string ToBase64String(this byte[] me, int offset, int length, Base64FormattingOptions options)
		{
			return Convert.ToBase64String(me, offset, length, options);
		}

		#endregion [ ToBase64String ]



		#region [ ToBase64CharArray ]

		private static int CalculateBase64Count(int bytesCount)
		{
			return (int)Math.Ceiling(bytesCount / 3.0) * 4;

			/*int count = (int)((4.0d / 3.0d) * bytesCount);
			int rem = count % 4;
			if (rem != 0)
			{
				count += 4 - rem;
			}

			return count;*/
		}



		/// <summary>
		/// To the base64 character array.
		/// </summary>
		/// <param name="me">The current byte array.</param>
		/// <returns></returns>
		public static char[] ToBase64CharArray(this byte[] me)
		{
			int length = me.Length;

			char[] chars = new char[CalculateBase64Count(length)];

			Convert.ToBase64CharArray(me, 0, length, chars, 0);

			return chars;
		}



		/// <summary>
		/// To the base64 character array.
		/// </summary>
		/// <param name="me">Me.</param>
		/// <param name="options">The options.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToBase64CharArray
		public static char[] ToBase64CharArray(this byte[] me, Base64FormattingOptions options)
		{
			int length = me.Length;

			char[] chars = new char[CalculateBase64Count(length)];

			Convert.ToBase64CharArray(me, 0, length, chars, 0, options);

			return chars;
		}



		/// <summary>
		/// To the base64 character array.
		/// </summary>
		/// <param name="me">Me.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="length">The length.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToBase64CharArray
		public static char[] ToBase64CharArray(this byte[] me, int offset, int length)
		{
			char[] chars = new char[CalculateBase64Count(length)];

			Convert.ToBase64CharArray(me, 0, length, chars, 0);

			return chars;
		}



		/// <summary>
		/// To the base64 character array.
		/// </summary>
		/// <param name="me">Me.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="length">The length.</param>
		/// <param name="options">The options.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToBase64CharArray
		public static char[] ToBase64CharArray(this byte[] me, int offset, int length, Base64FormattingOptions options)
		{
			char[] chars = new char[CalculateBase64Count(length)];

			Convert.ToBase64CharArray(me, 0, length, chars, 0, options);

			return chars;
		}

		#endregion [ ToBase64CharArray ]

	}

}
