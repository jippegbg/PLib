using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;


namespace PLib.Extensions.System
{

	public static partial class StringExtensions
	{

		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static DateTime ToDateTime(this string me)
		{
			return DateTime.Parse(me);
		}



		/// <summary>
		/// To the date time.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="provider">The provider.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment
		public static DateTime ToDateTime(this string me, IFormatProvider provider)
		{
			return DateTime.Parse(me, provider);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="provider">The provider.</param>
		/// <param name="styles">The styles.</param>
		/// <returns></returns>
		public static DateTime ToDateTime(this string me, IFormatProvider provider, DateTimeStyles styles)
		{
			return DateTime.Parse(me, provider, styles);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToDateTime(this string me, out DateTime value)
		{
			return DateTime.TryParse(me, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="provider">The provider.</param>
		/// <param name="styles">The styles.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToDateTime(this string me, IFormatProvider provider, DateTimeStyles styles, out DateTime value)
		{
			return DateTime.TryParse(me, provider, styles, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="format">The format.</param>
		/// <param name="provider">The provider.</param>
		/// <returns></returns>
		public static DateTime ToDateTime(this string me, string format, IFormatProvider provider)
		{
			return DateTime.ParseExact(me, format, provider);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="format">The format.</param>
		/// <param name="provider">The provider.</param>
		/// <param name="styles">The styles.</param>
		/// <returns></returns>
		public static DateTime ToDateTime(this string me, string format, IFormatProvider provider, DateTimeStyles styles)
		{
			return DateTime.ParseExact(me, format, provider, styles);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="formats">The formats.</param>
		/// <param name="provider">The provider.</param>
		/// <param name="styles">The styles.</param>
		/// <returns></returns>
		public static DateTime ToDateTime(this string me, string[] formats, IFormatProvider provider, DateTimeStyles styles)
		{
			return DateTime.ParseExact(me, formats, provider, styles);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="format">The format.</param>
		/// <param name="provider">The provider.</param>
		/// <param name="styles">The styles.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToDateTime(this string me, string format, IFormatProvider provider, DateTimeStyles styles, out DateTime value)
		{
			return DateTime.TryParseExact(me, format, provider, styles, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="formats">The formats.</param>
		/// <param name="provider">The provider.</param>
		/// <param name="styles">The styles.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToDateTime(this string me, string[] formats, IFormatProvider provider, DateTimeStyles styles, out DateTime value)
		{
			return DateTime.TryParseExact(me, formats, provider, styles, out value);
		}



		/// <summary>
		///     Converts the the current string as a representation of the name or numeric
		///     value of one or more enumerated constants to an equivalent enumerated
		///     object. An optional parameter specifies whether the operation is
		///     case-insensitive. The return value indicates whether the conversion succeeded.
		/// </summary>
		/// <typeparam name="T">
		///     The enumeration type into which to convert the current string.
		/// </typeparam>
		/// <param name="me">The current string.</param>
		/// <param name="result">
		///     When this method returns, contains an object of type
		///     <typeparamref name="T"/> whose value is represented by the current string.
		///     This parameter is passed uninitialized.
		/// </param>
		/// <param name="ignoreCase">
		///     If <c>true</c>, ignore case; otherwise, regard case. Default is true.
		/// </param>
		/// <returns>
		///     <c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.
		/// </returns>
		public static bool ToEnum<T>(this string me, out T result, bool ignoreCase) where T : struct
		{
			return Enum.TryParse(me, out result);
		}



		/// <summary>
		///     Converts the current string as a representation of the name or numeric
		///     value of one or more enumerated constants to an equivalent enumerated
		///     object. An optional parameter specifies whether the operation is case-insensitive.
		/// </summary>
		/// <typeparam name="T">
		///     The enumeration type into which to convert the current string.
		/// </typeparam>
		/// <param name="me">The current string.</param>
		/// <param name="ignoreCase">
		///     If <c>true</c>, ignore case; otherwise, regard case. Default is true.
		/// </param>
		/// <returns>
		///     An object of type <typeparamref name="T"/> whose value is represented by
		///     the current string.
		/// </returns>
		public static T ToEnum<T>(this string me, bool ignoreCase = true) where T : struct
		{
			return (T)Enum.Parse(typeof(T), me, ignoreCase);
		}



		/// <summary>
		///     Creates a new non-resizable <see cref="MemoryStream"/> based on the current
		///     string encoded according to the current system code page.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="writable">
		///     The setting of the <see cref="MemoryStream.CanWrite"/> property, which
		///     determines whether the stream supports writing.
		/// </param>
		/// <returns>
		///     A new non-resizable <see cref="MemoryStream"/> based on the current string
		///     encoded according to the current system code page.
		/// </returns>
		public static MemoryStream ToMemoryStream(this string me, bool writable = true)
		{
			return new MemoryStream(Encoding.Default.GetBytes(me), writable);
		}



		/// <summary>
		///     Creates a new non-resizable <see cref="MemoryStream"/> based on the current
		///     string encoded as specified.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="encoding">The encoding to use for converting the string.</param>
		/// <param name="writable">
		///     The setting of the <see cref="MemoryStream.CanWrite"/> property, which
		///     determines whether the stream supports writing.
		/// </param>
		/// <returns>
		///     A new non-resizable <see cref="MemoryStream"/> based on the current string
		///     encoded as specified.
		/// </returns>
		public static MemoryStream ToMemoryStream(this string me, Encoding encoding = null, bool writable = true)
		{
			if (encoding == null)
			{
				encoding = Encoding.Default;
			}

			return new MemoryStream(encoding.GetBytes(me), writable);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static sbyte ToSByte(this string me)
		{
			return sbyte.Parse(me);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToSByte(this string me, out sbyte value)
		{
			return sbyte.TryParse(me, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static byte ToByte(this string me)
		{
			return byte.Parse(me);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToByte(this string me, out byte value)
		{
			return byte.TryParse(me, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static ushort ToUInt16(this string me)
		{
			return ushort.Parse(me);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToUInt16(this string me, out ushort value)
		{
			return ushort.TryParse(me, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static short ToInt16(this string me)
		{
			return short.Parse(me);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToInt16(this string me, out short value)
		{
			return short.TryParse(me, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static uint ToUInt32(this string me)
		{
			return uint.Parse(me);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToUInt32(this string me, out uint value)
		{
			return uint.TryParse(me, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static int ToInt32(this string me)
		{
			return int.Parse(me);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToInt32(this string me, out int value)
		{
			return int.TryParse(me, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static ulong ToUInt64(this string me)
		{
			return ulong.Parse(me);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToUInt64(this string me, out ulong value)
		{
			return ulong.TryParse(me, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static long ToInt64(this string me)
		{
			return long.Parse(me);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToInt64(this string me, out long value)
		{
			return long.TryParse(me, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static decimal ToDecimal(this string me)
		{
			return decimal.Parse(me);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToDecimal(this string me, out decimal value)
		{
			return decimal.TryParse(me, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static double ToDouble(this string me)
		{
			return double.Parse(me);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToDouble(this string me, out double value)
		{
			return double.TryParse(me, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static float ToFloat(this string me)
		{
			return float.Parse(me);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToFloat(this string me, out float value)
		{
			return float.TryParse(me, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentException">if the current string cannot be interpreted as a boolean value.</exception>
		public static bool ToBoolean(this string me)
		{
			switch (me.Trim().ToLower())
			{
				case "true":
				case "yes":
				case "y":
				case "1":
					return true;
				case "false":
				case "no":
				case "n":
				case "0":
					return false;
				default:
					throw new ArgumentException("Not a boolean expression.", nameof(me));
			}
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static DirectoryInfo ToDirectoryInfo(this string me) => new DirectoryInfo(me);



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static FileInfo ToFileInfo(this string me) => new FileInfo(me);



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static XDocument ToXDocument(this string me) => XDocument.Parse(me);



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns></returns>
		public static XmlDocument ToXmlDocument(this string me)
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(me);
			return doc;
		}



		/// <summary>
		///     Encodes the current string using UTF-8 encoding, and converts the resulting
		///     byte array to a Base64 string.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <returns>
		///     A new Base64 string created from the UTF-8 encoding of the current string.
		/// </returns>
		public static string ToBase64String(this string me)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(me));
		}



		/// <summary>
		///     Encodes the current string using the specified encoding, and converts the
		///     resulting byte array to a Base64 string.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="encoding">
		///     The character encoding used for the bytes converted to Base64 string.
		/// </param>
		/// <returns>
		///     A new Base64 string created from the specified encoding of the current string.
		/// </returns>
		public static string ToBase64String(this string me, Encoding encoding)
		{
			return Convert.ToBase64String(encoding.GetBytes(me));
		}



		/// <summary>
		///     Converts the current string from Base64 and decodes the resulting bytes as UTF-8.
		/// </summary>
		/// <param name="me">The current Base64 string.</param>
		/// <returns>
		///     A new string created from the current Base64 string using the UTF-8 encoding.
		/// </returns>
		public static string FromBase64String(this string me)
		{
			return Encoding.UTF8.GetString(Convert.FromBase64String(me));
		}


		/// <summary>
		///     Converts the current string from Base64 and decodes the resulting bytes
		///     using the specified encoding.
		/// </summary>
		/// <param name="me">The current Base64 string.</param>
		/// <param name="encoding">
		///     The character encoding used for the bytes converted as the current Base64 string.
		/// </param>
		/// <returns>
		///     A new string created from the current Base64 string using the specified encoding.
		/// </returns>
		public static string FromBase64String(this string me, Encoding encoding)
		{
			return encoding.GetString(Convert.FromBase64String(me));
		}

	}

}
