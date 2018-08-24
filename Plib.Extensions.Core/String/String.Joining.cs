using System;
using System.Collections.Generic;
using System.Text;


namespace PLib.Extensions.Core
{

	public static partial class StringExtensions
	{

		/// <summary>
		///     Concatenates all the elements of a string sequence, using the specified separator
		///     between each element.
		/// </summary>
		/// <param name="me">The string sequence to concatenate.</param>
		/// <param name="separator">The string to use as a separator. Optional.</param>
		/// <returns>
		///     A string that consists of the elements in <paramref name="me"/> delimited by the
		///     <paramref name="separator"/> string. If <paramref name="me"/> is an empty sequence,
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
		///     <para>
		///         When joining/concatenating more than about 1000 strings, use a
		///         <see cref="StringBuilder"/> instead, for better performance.
		///     </para>
		/// </remarks>
		public static string Join(this IEnumerable<string> me, string separator = null)
		{
			return string.Join(separator, me);
		}



		/// <summary>
		///     Concatenates all the elements of a string sequence into one string delimited by a
		///     new-line separator.
		/// </summary>
		/// <param name="me">The string sequence to concatenate.</param>
		/// <returns>
		///     A string that consists of the elements in <paramref name="me"/> delimited by a line
		///     separator. If <paramref name="me"/> is an empty sequence, the method returns <see cref="string.Empty"/>.
		/// </returns>
		public static string JoinLines(this IEnumerable<string> me)
		{
			return string.Join(Environment.NewLine, me);
		}

	}

}
