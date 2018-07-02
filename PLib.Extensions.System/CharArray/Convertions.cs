using System;


namespace PLib.Extensions.System
{

	public static class CharArrayExtensions
	{

		/// <summary>
		/// Gets the string.
		/// </summary>
		/// <param name="me">Me.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for GetString
		public static string GetString(this char[] me)
		{
			return new string(me);
		}

	}

}
