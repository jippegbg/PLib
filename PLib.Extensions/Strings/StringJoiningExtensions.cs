using System;
using System.Collections.Generic;


namespace PLib.Extensions.Strings
{

	/// <summary>
	///     Provides functionality for joining together strings.
	/// </summary>
	public static class StringJoiningExtensions
	{

		/// <summary>
		///     Concatenates all the elements of a string sequence, using the specified separator
		///     between each element.
		/// </summary>
		/// <param name="this">The string sequence to concatenate.</param>
		/// <param name="separator">The string to use as a separator. Optional.</param>
		/// <returns>
		///     A string that consists of the elements in <paramref name="this"/> delimited by the
		///     <paramref name="separator"/> string. If <paramref name="this"/> is an empty sequence,
		///     the method returns <see cref="string.Empty"/>.
		/// </returns>
		/// <remarks>
		///     <para>
		///         This is a fluent adaptation of the
		///         <see cref="string.Join(string, IEnumerable{string})"/> method.
		///     </para>
		///     <para>
		///         If the <paramref name="separator"/> is omitted or null, an empty string will be
		///         used as separator instead.
		///     </para>
		/// </remarks>
		public static string Join(this IEnumerable<string> @this, string separator = null)
		{
			return string.Join(separator, @this);
		}



		/// <summary>
		///     Concatenates all the elements of a string sequence into one string delimited by a
		///     new-line separator.
		/// </summary>
		/// <param name="this">The string sequence to concatenate.</param>
		/// <returns>
		///     A string that consists of the elements in <paramref name="this"/> delimited by a line
		///     separator. If <paramref name="this"/> is an empty sequence, the method returns <see cref="string.Empty"/>.
		/// </returns>
		public static string JoinLines(this IEnumerable<string> @this)
		{
			return string.Join(Environment.NewLine, @this);
		}

	}

}
