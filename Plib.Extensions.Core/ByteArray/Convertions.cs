using System;
using System.Text;


namespace PLib.Extensions.Core
{

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
		///     Converts the current byte array to its equivalent string representation that is
		///     encoded with base-64 digits.
		/// </summary>
		/// <param name="me">The current byte array.</param>
		/// <returns>
		///     The string representation, in base 64, of the contents of the current byte array.
		/// </returns>
		public static string ToBase64String(this byte[] me)
		{
			return Convert.ToBase64String(me);
		}



		/// <summary>
		///     Converts the current byte array to its equivalent string representation that is
		///     encoded with base-64 digits. A parameter specifies whether to insert line breaks in
		///     the return value.
		/// </summary>
		/// <param name="me">The current byte array.</param>
		/// <param name="options">
		///     <see cref="Base64FormattingOptions.InsertLineBreaks"/> to insert a line break every
		///     76 characters, or <see cref="Base64FormattingOptions.None"/> to not insert line breaks.
		/// </param>
		/// <returns>
		///     The string representation, in base 64, of the contents of the current byte array.
		/// </returns>
		public static string ToBase64String(this byte[] me, Base64FormattingOptions options)
		{
			return Convert.ToBase64String(me, options);
		}



		/// <summary>
		///     Converts a subset of the current byte array to its equivalent string representation
		///     that is encoded with base-64 digits. Parameters specify the subset as an offset in
		///     the current array, and the number of elements to convert.
		/// </summary>
		/// <param name="me">The current byte array.</param>
		/// <param name="offset">An offset in the current byte array.</param>
		/// <param name="length">The number of elements to convert.</param>
		/// <returns>
		///     The string representation in base 64 of <paramref name="length"/> elements of the current byte array,
		///     starting at position <paramref name="offset"/>.
		/// </returns>
		public static string ToBase64String(this byte[] me, int offset, int length)
		{
			return Convert.ToBase64String(me, offset, length);
		}



		/// <summary>
		///     Converts a subset of the current byte array to its equivalent string representation
		///     that is encoded with base-64 digits. Parameters specify the subset as an offset in
		///     the current byte array, the number of elements to convert, and whether to insert line
		///     breaks in the return value.
		/// </summary>
		/// <param name="me">The current byte array.</param>
		/// <param name="offset">An offset in the current byte array.</param>
		/// <param name="length">The number of elements to convert.</param>
		/// <param name="options">
		///     <see cref="Base64FormattingOptions.InsertLineBreaks"/> to insert a line break every
		///     76 characters, or <see cref="Base64FormattingOptions.None"/> to not insert line breaks.
		/// </param>
		/// <returns>
		///     The string representation in base 64 of <paramref name="length"/> elements of the current byte array,
		///     starting at position <paramref name="offset"/>.
		/// </returns>
		public static string ToBase64String(this byte[] me, int offset, int length, Base64FormattingOptions options)
		{
			return Convert.ToBase64String(me, offset, length, options);
		}

		#endregion [ ToBase64String ]



		#region [ ToBase64CharArray ]

		private static int CalculateBase64Count(int bytesCount)
		{
			return (int)Math.Ceiling(bytesCount / 3.0) * 4;

			/*
			int count = (int)((4.0d / 3.0d) * bytesCount);
			int rem = count % 4;
			if (rem != 0)
			{
				count += 4 - rem;
			}

			return count;
			*/
		}



		/// <summary>
		///     Converts the current byte array to an equivalent array of a Unicode characters
		///     encoded with base-64 digits.
		/// </summary>
		/// <param name="me">The current byte array.</param>
		/// <returns>
		///     A character array of Unicode characters that's equivalent to the current byte array
		///     encoded with base-64 digits.
		/// </returns>
		public static char[] ToBase64CharArray(this byte[] me)
		{
			int length = me.Length;

			char[] chars = new char[CalculateBase64Count(length)];

			Convert.ToBase64CharArray(me, 0, length, chars, 0);

			return chars;
		}



		/// <summary>
		///     Converts the current byte array to an equivalent array of a Unicode characters
		///     encoded with base-64 digits. A parameter specify whether line breaks are inserted in
		///     the output array.
		/// </summary>
		/// <param name="me">The current byte array.</param>
		/// <param name="options">
		///     <see cref="Base64FormattingOptions.InsertLineBreaks"/> to insert a line break every
		///     76 characters, or <see cref="Base64FormattingOptions.None"/> to not insert line breaks.
		/// </param>
		/// <returns>
		///     A character array of Unicode characters that's equivalent to the current byte array
		///     encoded with base-64 digits.
		/// </returns>
		public static char[] ToBase64CharArray(this byte[] me, Base64FormattingOptions options)
		{
			int length = me.Length;

			char[] chars = new char[CalculateBase64Count(length)];

			Convert.ToBase64CharArray(me, 0, length, chars, 0, options);

			return chars;
		}



		/// <summary>
		///     Converts a subset of the current byte array to an equivalent subset of a Unicode
		///     character array encoded with base-64 digits. Parameters specify the subsets as
		///     offsets in the input and output arrays, and the number of elements in the input array
		///     to convert.
		/// </summary>
		/// <param name="me">The current byte array.</param>
		/// <param name="offset">An offset in the current byte array.</param>
		/// <param name="length">The number of elements to convert.</param>
		/// <returns>
		///     A character array of Unicode characters that's equivalent to a subset of the current
		///     byte array encoded with base-64 digits.
		/// </returns>
		public static char[] ToBase64CharArray(this byte[] me, int offset, int length)
		{
			char[] chars = new char[CalculateBase64Count(length)];

			Convert.ToBase64CharArray(me, 0, length, chars, 0);

			return chars;
		}



		/// <summary>
		///     Converts a subset of the current byte array to an equivalent subset of a Unicode
		///     character array encoded with base-64 digits. Parameters specify the subsets as
		///     offsets in the input and output arrays, the number of elements in the input array to
		///     convert, and whether line breaks are inserted in the output array.
		/// </summary>
		/// <param name="me">The current byte array.</param>
		/// <param name="offset">An offset in the current byte array.</param>
		/// <param name="length">The number of elements to convert.</param>
		/// <param name="options">
		///     <see cref="Base64FormattingOptions.InsertLineBreaks"/> to insert a line break every
		///     76 characters, or <see cref="Base64FormattingOptions.None"/> to not insert line breaks.
		/// </param>
		/// <returns>
		///     A character array of Unicode characters that's equivalent to a subset of the current
		///     byte array encoded with base-64 digits.
		/// </returns>
		public static char[] ToBase64CharArray(this byte[] me, int offset, int length, Base64FormattingOptions options)
		{
			char[] chars = new char[CalculateBase64Count(length)];

			Convert.ToBase64CharArray(me, 0, length, chars, 0, options);

			return chars;
		}

		#endregion [ ToBase64CharArray ]

	}

}
