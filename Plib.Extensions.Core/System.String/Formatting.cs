﻿using System;


namespace PLib.Extensions.Core.System.String
{

	public static partial class Extensions
	{

		/// <summary>
		///     Converts the value of objects to strings based on the formats specified by the
		///     current string and inserts them into a copy thereof.
		/// </summary>
		/// <param name="this">The current string that serves as a composite format string.</param>
		/// <param name="args">An object array that contains zero or more objects to format.</param>
		/// <returns>
		///     A copy of the current string in which the format items have been replaced by the
		///     string representation of the corresponding objects in <paramref name="args"/>.
		/// </returns>
		/// <remarks>
		///     This is a fluent version of the <see cref="string.Format(string, object[])"/> method.
		/// </remarks>
		public static string Format(this string @this, params object[] args)
		{
			return string.Format(@this, args);
		}



		/// <summary>
		///     Converts the value of objects to strings according to a culture-specific provider, 
		///     based on the formats specified by the current string and inserts them into a copy thereof.
		/// </summary>
		/// <param name="this">The current string that serves as a composite format string.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <param name="args">An object array that contains zero or more objects to format.</param>
		/// <returns></returns>
		/// <remarks>
		///     This is a fluent version of the
		///     <see cref="string.Format(IFormatProvider, string, object[])"/> method.
		/// </remarks>
		public static string Format(this string @this, IFormatProvider provider, params object[] args)
		{
			return string.Format(provider, @this, args);
		}

	}

}
