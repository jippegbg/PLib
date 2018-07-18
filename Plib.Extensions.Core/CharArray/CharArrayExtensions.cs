using System;


namespace PLib.Extensions.Core
{

	/// <summary>
	/// Extensions of char arrays.
	/// </summary>
	public static class CharArrayExtensions
	{

		/// <summary>
		///     Converts the current array of Unicode characters into a new instance of the
		///     <see cref="String"/> class.
		/// </summary>
		/// <param name="me">The current array of unicode characters.</param>
		/// <returns>A new string created from the characters in the current array.</returns>
		public static string GetString(this char[] me)
		{
			return new string(me);
		}

	}

}
