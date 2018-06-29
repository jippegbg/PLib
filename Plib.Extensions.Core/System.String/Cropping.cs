using System;
using System.Linq;


namespace PLib.Extensions.Core.System.String
{

	public static partial class Extensions
	{

		/// <summary>
		///     Returns a copy of the current string with ensured maximum length, by removing
		///     characters from the start, if necessary.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="maxLength">The maximum number of characters in the resulting string.</param>
		/// <returns>A copy of the current string with ensured maximum length.</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///     maxLength - The maximum number of characters cannot be less than zero.
		/// </exception>
		/// <remarks>If the string is shorter than the maximum length, it will be left untouched.</remarks>
		public static string CropLeft(this string @this, int maxLength)
		{
			if (@this == null)
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

			return maxLength < @this.Length ? @this.Substring(@this.Length - maxLength, maxLength) : @this;
		}



		/// <summary>
		///     Returns a copy of the current string with ensured maximum length, by removing
		///     characters from the end, if necessary.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="maxLength">The maximum number of characters in the resulting string.</param>
		/// <returns>A copy of the current string with ensured maximum length.</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///     maxLength - The maximum number of characters cannot be less than zero.
		/// </exception>
		/// <remarks>If the string is shorter than the maximum length, it will be left untouched.</remarks>
		public static string CropRight(this string @this, int maxLength)
		{
			if (@this == null)
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

			return maxLength < @this.Length ? @this.Substring(0, maxLength) : @this;
		}



		/// <summary>
		///     Returns a copy of the current string with ensured maximum length.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="maxLength">
		///     The maximum length of the resulting string. Removes characters from the start if
		///     positive, and from the end if negative.
		/// </param>
		/// <returns>A copy of the current string with ensured maximum length.</returns>
		/// <remarks>
		///     If the string is shorter than the maximum length, the string will be left untouched.
		/// </remarks>
		public static string Crop(this string @this, int maxLength)
		{
			if (@this == null)
			{
				return null;
			}

			return maxLength < 0 ? @this.CropRight(-maxLength) : @this.CropLeft(maxLength);
		}



		#region [ Multi-Line ]

		/// <summary>
		///     Returns a copy of the current string with ensured maximum length of every line, by
		///     removing characters from the start if necessary.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="maxLineLength">
		///     The maximum number of characters of every line in the resulting string.
		/// </param>
		/// <returns>A copy of the current string with ensured maximum length of every line.</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///     maxLineLength - The maximum number of characters cannot be less than zero.
		/// </exception>
		/// <remarks>The lines that are shorter than the maximum length will be left untouched.</remarks>
		public static string CropLinesLeft(this string @this, int maxLineLength)
		{
			if (@this == null)
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

			return @this
				.Lines()
				.Select(line => line.CropLeft(maxLineLength))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string with ensured maximum length of every line, by
		///     removing characters from the end if necessary.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="maxLineLength">
		///     The maximum number of characters of every line in the resulting string.
		/// </param>
		/// <returns>A copy of the current string with ensured maximum length of every line.</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		///     maxLineLength - The maximum number of characters cannot be less than zero.
		/// </exception>
		/// <remarks>The lines that are shorter than the maximum length will be left untouched.</remarks>
		public static string CropLinesRight(this string @this, int maxLineLength)
		{
			if (@this == null)
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

			return @this
				.Lines()
				.Select(line => line.CropRight(maxLineLength))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string with ensured maximum length of every line.
		/// </summary>
		/// <param name="this">The current string.</param>
		/// <param name="maxLineLength">
		///     The maximum number of characters of every line in the resulting string. Removes
		///     characters from the start if positive, and the end if negative.
		/// </param>
		/// <returns>A copy of the current string with ensured maximum length of every line.</returns>
		/// <remarks>The lines that are shorter than the maximum length will be left untouched.</remarks>
		public static string CropLines(this string @this, int maxLineLength)
		{
			return @this?
				.Lines()
				.Select(line => line.Crop(maxLineLength))
				.JoinLines();
		}

		#endregion [ Multi-Line ]

	}

}
