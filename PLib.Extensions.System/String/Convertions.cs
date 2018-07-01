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
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static DateTime ToDateTime(this string @this)
		{
			return DateTime.Parse(@this);
		}



		/// <summary>
		/// To the date time.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="provider">The provider.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment
		public static DateTime ToDateTime(this string @this, IFormatProvider provider)
		{
			return DateTime.Parse(@this, provider);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="provider">The provider.</param>
		/// <param name="styles">The styles.</param>
		/// <returns></returns>
		public static DateTime ToDateTime(this string @this, IFormatProvider provider, DateTimeStyles styles)
		{
			return DateTime.Parse(@this, provider, styles);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToDateTime(this string @this, out DateTime value)
		{
			return DateTime.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="provider">The provider.</param>
		/// <param name="styles">The styles.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToDateTime(this string @this, IFormatProvider provider, DateTimeStyles styles, out DateTime value)
		{
			return DateTime.TryParse(@this, provider, styles, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="format">The format.</param>
		/// <param name="provider">The provider.</param>
		/// <returns></returns>
		public static DateTime ToDateTime(this string @this, string format, IFormatProvider provider)
		{
			return DateTime.ParseExact(@this, format, provider);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="format">The format.</param>
		/// <param name="provider">The provider.</param>
		/// <param name="styles">The styles.</param>
		/// <returns></returns>
		public static DateTime ToDateTime(this string @this, string format, IFormatProvider provider, DateTimeStyles styles)
		{
			return DateTime.ParseExact(@this, format, provider, styles);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="formats">The formats.</param>
		/// <param name="provider">The provider.</param>
		/// <param name="styles">The styles.</param>
		/// <returns></returns>
		public static DateTime ToDateTime(this string @this, string[] formats, IFormatProvider provider, DateTimeStyles styles)
		{
			return DateTime.ParseExact(@this, formats, provider, styles);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="format">The format.</param>
		/// <param name="provider">The provider.</param>
		/// <param name="styles">The styles.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToDateTime(this string @this, string format, IFormatProvider provider, DateTimeStyles styles, out DateTime value)
		{
			return DateTime.TryParseExact(@this, format, provider, styles, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="formats">The formats.</param>
		/// <param name="provider">The provider.</param>
		/// <param name="styles">The styles.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToDateTime(this string @this, string[] formats, IFormatProvider provider, DateTimeStyles styles, out DateTime value)
		{
			return DateTime.TryParseExact(@this, formats, provider, styles, out value);
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
		/// <param name="this">The current string.</param>
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
		public static bool ToEnum<T>(this string @this, out T result, bool ignoreCase) where T : struct
		{
			return Enum.TryParse(@this, out result);
		}



		/// <summary>
		///     Converts the current string as a representation of the name or numeric
		///     value of one or more enumerated constants to an equivalent enumerated
		///     object. An optional parameter specifies whether the operation is case-insensitive.
		/// </summary>
		/// <typeparam name="T">
		///     The enumeration type into which to convert the current string.
		/// </typeparam>
		/// <param name="this">The current string.</param>
		/// <param name="ignoreCase">
		///     If <c>true</c>, ignore case; otherwise, regard case. Default is true.
		/// </param>
		/// <returns>
		///     An object of type <typeparamref name="T"/> whose value is represented by
		///     the current string.
		/// </returns>
		public static T ToEnum<T>(this string @this, bool ignoreCase = true) where T : struct
		{
			return (T)Enum.Parse(typeof(T), @this, ignoreCase);
		}



		/// <summary>
		///     Creates a new non-resizable <see cref="MemoryStream"/> based on the current
		///     string encoded according to the current system code page.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="writable">
		///     The setting of the <see cref="MemoryStream.CanWrite"/> property, which
		///     determines whether the stream supports writing.
		/// </param>
		/// <returns>
		///     A new non-resizable <see cref="MemoryStream"/> based on the current string
		///     encoded according to the current system code page.
		/// </returns>
		public static MemoryStream ToMemoryStream(this string @this, bool writable = true)
		{
			return new MemoryStream(Encoding.Default.GetBytes(@this), writable);
		}



		/// <summary>
		///     Creates a new non-resizable <see cref="MemoryStream"/> based on the current
		///     string encoded as specified.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="encoding">The encoding to use for converting the string.</param>
		/// <param name="writable">
		///     The setting of the <see cref="MemoryStream.CanWrite"/> property, which
		///     determines whether the stream supports writing.
		/// </param>
		/// <returns>
		///     A new non-resizable <see cref="MemoryStream"/> based on the current string
		///     encoded as specified.
		/// </returns>
		public static MemoryStream ToMemoryStream(this string @this, Encoding encoding = null, bool writable = true)
		{
			if (encoding == null)
			{
				encoding = Encoding.Default;
			}

			return new MemoryStream(encoding.GetBytes(@this), writable);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static sbyte ToSByte(this string @this)
		{
			return sbyte.Parse(@this);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToSByte(this string @this, out sbyte value)
		{
			return sbyte.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static byte ToByte(this string @this)
		{
			return byte.Parse(@this);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToByte(this string @this, out byte value)
		{
			return byte.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static ushort ToUInt16(this string @this)
		{
			return ushort.Parse(@this);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToUInt16(this string @this, out ushort value)
		{
			return ushort.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static short ToInt16(this string @this)
		{
			return short.Parse(@this);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToInt16(this string @this, out short value)
		{
			return short.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static uint ToUInt32(this string @this)
		{
			return uint.Parse(@this);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToUInt32(this string @this, out uint value)
		{
			return uint.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static int ToInt32(this string @this)
		{
			return int.Parse(@this);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToInt32(this string @this, out int value)
		{
			return int.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static ulong ToUInt64(this string @this)
		{
			return ulong.Parse(@this);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToUInt64(this string @this, out ulong value)
		{
			return ulong.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static long ToInt64(this string @this)
		{
			return long.Parse(@this);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToInt64(this string @this, out long value)
		{
			return long.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static decimal ToDecimal(this string @this)
		{
			return decimal.Parse(@this);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToDecimal(this string @this, out decimal value)
		{
			return decimal.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static double ToDouble(this string @this)
		{
			return double.Parse(@this);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToDouble(this string @this, out double value)
		{
			return double.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static float ToFloat(this string @this)
		{
			return float.Parse(@this);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToFloat(this string @this, out float value)
		{
			return float.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentException">if the current string cannot be interpreted as a boolean value.</exception>
		public static bool ToBoolean(this string @this)
		{
			switch (@this.Trim().ToLower())
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
					throw new ArgumentException("Not a boolean expression.", nameof(@this));
			}
		}



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static DirectoryInfo ToDirectoryInfo(this string @this) => new DirectoryInfo(@this);



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static FileInfo ToFileInfo(this string @this) => new FileInfo(@this);



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static XDocument ToXDocument(this string @this) => XDocument.Parse(@this);



		/// <summary>
		/// TODO Edit XML Comment
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static XmlDocument ToXmlDocument(this string @this)
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(@this);
			return doc;
		}

	}

}
