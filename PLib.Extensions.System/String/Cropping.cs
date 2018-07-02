using System;
using System.Linq;


namespace PLib.Extensions.System
{

	public static partial class StringExtensions
	{

		/// <summary>
		///     Returns a copy of the current string with ensured maximum length, by removing
		///     characters from the start, if necessary.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="maxLength">The maximum number of characters in the resulting string.</param>
		/// <returns>A copy of the current string with ensured maximum length.</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///     maxLength - The maximum number of characters cannot be less than zero.
		/// </exception>
		/// <remarks>If the string is shorter than the maximum length, it will be left untouched.</remarks>
		public static string CropLeft(this string me, int maxLength)
		{
			if (me == null)
			{
				return null;
			}

			if (maxLength < 0)
			{
				throw new ArgumentOutOfRangeException(
					nameof(maxLength),
					maxLength,
					"The maximum number of characters cannot be less than zero.");
			}

			return maxLength < me.Length ? me.Substring(me.Length - maxLength, maxLength) : me;
		}



		/// <summary>
		///     Returns a copy of the current string with ensured maximum length, by removing
		///     characters from the end, if necessary.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="maxLength">The maximum number of characters in the resulting string.</param>
		/// <returns>A copy of the current string with ensured maximum length.</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///     maxLength - The maximum number of characters cannot be less than zero.
		/// </exception>
		/// <remarks>If the string is shorter than the maximum length, it will be left untouched.</remarks>
		public static string CropRight(this string me, int maxLength)
		{
			if (me == null)
			{
				return null;
			}

			if (maxLength < 0)
			{
				throw new ArgumentOutOfRangeException(
					nameof(maxLength),
					maxLength,
					"The maximum number of characters cannot be less than zero.");
			}

			return maxLength < me.Length ? me.Substring(0, maxLength) : me;
		}



		/// <summary>
		///     Returns a copy of the current string with ensured maximum length.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="maxLength">
		///     The maximum length of the resulting string. Removes characters from the start if
		///     positive, and from the end if negative.
		/// </param>
		/// <returns>A copy of the current string with ensured maximum length.</returns>
		/// <remarks>
		///     If the string is shorter than the maximum length, the string will be left untouched.
		/// </remarks>
		public static string Crop(this string me, int maxLength)
		{
			if (me == null)
			{
				return null;
			}

			return maxLength < 0 ? me.CropRight(-maxLength) : me.CropLeft(maxLength);
		}



		#region [ Multi-Line ]

		/// <summary>
		///     Returns a copy of the current string with ensured maximum length of every line, by
		///     removing characters from the start if necessary.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="maxLineLength">
		///     The maximum number of characters of every line in the resulting string.
		/// </param>
		/// <returns>A copy of the current string with ensured maximum length of every line.</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///     maxLineLength - The maximum number of characters cannot be less than zero.
		/// </exception>
		/// <remarks>The lines that are shorter than the maximum length will be left untouched.</remarks>
		public static string CropLinesLeft(this string me, int maxLineLength)
		{
			if (me == null)
			{
				return null;
			}

			if (maxLineLength < 0)
			{
				throw new ArgumentOutOfRangeException(
					nameof(maxLineLength),
					maxLineLength,
					"The maximum number of characters cannot be less than zero.");
			}

			return me
				.Lines()
				.Select(line => line.CropLeft(maxLineLength))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string with ensured maximum length of every line, by
		///     removing characters from the end if necessary.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="maxLineLength">
		///     The maximum number of characters of every line in the resulting string.
		/// </param>
		/// <returns>A copy of the current string with ensured maximum length of every line.</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///     maxLineLength - The maximum number of characters cannot be less than zero.
		/// </exception>
		/// <remarks>The lines that are shorter than the maximum length will be left untouched.</remarks>
		public static string CropLinesRight(this string me, int maxLineLength)
		{
			if (me == null)
			{
				return null;
			}

			if (maxLineLength < 0)
			{
				throw new ArgumentOutOfRangeException(
					nameof(maxLineLength),
					maxLineLength,
					"The maximum number of characters cannot be less than zero.");
			}

			return me
				.Lines()
				.Select(line => line.CropRight(maxLineLength))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string with ensured maximum length of every line.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="maxLineLength">
		///     The maximum number of characters of every line in the resulting string. Removes
		///     characters from the start if positive, and the end if negative.
		/// </param>
		/// <returns>A copy of the current string with ensured maximum length of every line.</returns>
		/// <remarks>The lines that are shorter than the maximum length will be left untouched.</remarks>
		public static string CropLines(this string me, int maxLineLength)
		{
			return me?
				.Lines()
				.Select(line => line.Crop(maxLineLength))
				.JoinLines();
		}

		#endregion [ Multi-Line ]

	}

}
