using System;
using System.Globalization;


namespace PLib.Extensions.Core.System.String
{

	public static partial class Extensions
	{

		/// <summary>
		/// To the date time.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToDateTime
		public static DateTime ToDateTime(this string @this)
		{
			return DateTime.Parse(@this);
		}



		/// <summary>
		/// To the date time.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="provider">The provider.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToDateTime
		public static DateTime ToDateTime(this string @this, IFormatProvider provider)
		{
			return DateTime.Parse(@this, provider);
		}



		/// <summary>
		/// To the date time.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="provider">The provider.</param>
		/// <param name="styles">The styles.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToDateTime
		public static DateTime ToDateTime(this string @this, IFormatProvider provider, DateTimeStyles styles)
		{
			return DateTime.Parse(@this, provider, styles);
		}



		/// <summary>
		/// To the date time.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToDateTime
		public static bool ToDateTime(this string @this, out DateTime value)
		{
			return DateTime.TryParse(@this, out value);
		}



		/// <summary>
		/// To the date time.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="provider">The provider.</param>
		/// <param name="styles">The styles.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToDateTime
		public static bool ToDateTime(this string @this, IFormatProvider provider, DateTimeStyles styles, out DateTime value)
		{
			return DateTime.TryParse(@this, provider, styles, out value);
		}



		/// <summary>
		/// To the date time.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="format">The format.</param>
		/// <param name="provider">The provider.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToDateTime
		public static DateTime ToDateTime(this string @this, string format, IFormatProvider provider)
		{
			return DateTime.ParseExact(@this, format, provider);
		}



		/// <summary>
		/// To the date time.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="format">The format.</param>
		/// <param name="provider">The provider.</param>
		/// <param name="styles">The styles.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToDateTime
		public static DateTime ToDateTime(this string @this, string format, IFormatProvider provider, DateTimeStyles styles)
		{
			return DateTime.ParseExact(@this, format, provider, styles);
		}



		/// <summary>
		/// To the date time.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="formats">The formats.</param>
		/// <param name="provider">The provider.</param>
		/// <param name="styles">The styles.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToDateTime
		public static DateTime ToDateTime(this string @this, string[] formats, IFormatProvider provider, DateTimeStyles styles)
		{
			return DateTime.ParseExact(@this, formats, provider, styles);
		}



		/// <summary>
		/// To the date time.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="format">The format.</param>
		/// <param name="provider">The provider.</param>
		/// <param name="styles">The styles.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToDateTime
		public static bool ToDateTime(this string @this, string format, IFormatProvider provider, DateTimeStyles styles, out DateTime value)
		{
			return DateTime.TryParseExact(@this, format, provider, styles, out value);
		}



		/// <summary>
		/// To the date time.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <param name="formats">The formats.</param>
		/// <param name="provider">The provider.</param>
		/// <param name="styles">The styles.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToDateTime
		public static bool ToDateTime(this string @this, string[] formats, IFormatProvider provider, DateTimeStyles styles, out DateTime value)
		{
			return DateTime.TryParseExact(@this, formats, provider, styles, out value);
		}



		/// <summary>
		///     Converts the current string to an enum value of a specified type.
		/// </summary>
		/// <typeparam name="T">The enum type to convert the string value into.</typeparam>
		/// <param name="this">The current string.</param>
		/// <param name="result">The result.</param>
		/// <returns>A value of the specified enum type, or the the default value if no match.</returns>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="ArgumentException">
		///     if the type <typeparamref name="T"/> is not an enum type.
		/// </exception>
		public static bool ToEnum<T>(this string @this, out T result) where T : struct
		{
			Type type = typeof(T);

			if (!type.IsEnum)
			{
				throw new ArgumentException($"Type {typeof(T).Name} is not an enum.");
			}

			return Enum.TryParse(@this, out result);
		}



		/// <summary>
		/// To the enum.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="this">The this.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		public static T ToEnum<T>(this string @this) where T : struct
		{
			T result;
			if (!@this.ToEnum(out result))
			{
				throw new ArgumentException($"Current string could not be interpreted as an enum value of type {typeof(T).Name}.");
			}

			return result;
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static sbyte ToSByte(this string @this)
		{
			return sbyte.Parse(@this);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToSByte(this string @this, out sbyte value)
		{
			return sbyte.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static byte ToByte(this string @this)
		{
			return byte.Parse(@this);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToByte(this string @this, out byte value)
		{
			return byte.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static ushort ToUInt16(this string @this)
		{
			return ushort.Parse(@this);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToUInt16(this string @this, out ushort value)
		{
			return ushort.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static short ToInt16(this string @this)
		{
			return short.Parse(@this);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToInt16(this string @this, out short value)
		{
			return short.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static uint ToUInt32(this string @this)
		{
			return uint.Parse(@this);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToUInt32(this string @this, out uint value)
		{
			return uint.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static int ToInt32(this string @this)
		{
			return int.Parse(@this);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToInt32(this string @this, out int value)
		{
			return int.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static ulong ToUInt64(this string @this)
		{
			return ulong.Parse(@this);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToUInt64(this string @this, out ulong value)
		{
			return ulong.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static long ToInt64(this string @this)
		{
			return long.Parse(@this);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToInt64(this string @this, out long value)
		{
			return long.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static decimal ToDecimal(this string @this)
		{
			return decimal.Parse(@this);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToDecimal(this string @this, out decimal value)
		{
			return decimal.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static double ToDouble(this string @this)
		{
			return double.Parse(@this);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToDouble(this string @this, out double value)
		{
			return double.TryParse(@this, out value);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <returns></returns>
		public static float ToFloat(this string @this)
		{
			return float.Parse(@this);
		}



		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool ToFloat(this string @this, out float value)
		{
			return float.TryParse(@this, out value);
		}



		/// <summary>
		/// To the boolean.
		/// </summary>
		/// <param name="this">The this.</param>
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

	}

}
