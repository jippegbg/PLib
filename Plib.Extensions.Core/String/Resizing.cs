using System;
using System.Linq;


namespace PLib.Extensions.Core
{

	public static partial class StringExtensions
	{

		/// <summary>
		///     Returns a copy of the current string with ensured minimum and maximum length.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="minLength">
		///     The minimum length of the resulting string. Pads with spaces on the right side if the
		///     current string is shorter than this length.
		/// </param>
		/// <param name="maxLength">
		///     The maximum length of the resulting string. Removes characters from the right side if
		///     the current string is longer than this length.
		/// </param>
		/// <returns>A copy of the current string with ensured minimum and maximum length.</returns>
		/// <exception cref="ArgumentException">Maximum length is less than minimum length.</exception>
		/// <remarks>
		///     If the string is longer than the minimum length but shorter than the maximum length,
		///     it will be left untouched.
		/// </remarks>
		public static string ResizeLeft(this string me, int minLength, int maxLength)
		{
			if (me == null)
			{
				return null;
			}

			if (Math.Abs(maxLength) < Math.Abs(minLength))
			{
				throw new ArgumentException("Maximum length is less than minimum length.");
			}

			return me.PadLeft(minLength).CropLeft(maxLength);
		}



		/// <summary>
		///     Returns a copy of the current string with ensured minimum and maximum length.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="minLength">
		///     The minimum length of the resulting string. Pads with spaces on the left side if the
		///     current string is shorter than this length.
		/// </param>
		/// <param name="maxLength">
		///     The maximum length of the resulting string. Removes characters from the left side if
		///     the current string is longer than this length.
		/// </param>
		/// <returns>A copy of the current string with ensured minimum and maximum length.</returns>
		/// <exception cref="ArgumentException">Maximum length is less than minimum length.</exception>
		/// <remarks>
		///     If the string is longer than the minimum length but shorter than the maximum length,
		///     it will be left untouched.
		/// </remarks>
		public static string ResizeRight(this string me, int minLength, int maxLength)
		{
			if (me == null)
			{
				return null;
			}

			if (Math.Abs(maxLength) < Math.Abs(minLength))
			{
				throw new ArgumentException("Maximum length is less than minimum length.");
			}

			return me.PadRight(minLength).CropRight(maxLength);
		}



		/// <summary>
		///     Returns a copy of the current string with ensured minimum and maximum length.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="minLength">
		///     The minimum length of the resulting string. Pads with spaces on the left if positive,
		///     and on the right if negative.
		/// </param>
		/// <param name="maxLength">
		///     The maximum length of the resulting string. Removes characters from the left side if
		///     positive, and right side if negative.
		/// </param>
		/// <returns>A copy of the current string with ensured minimum and maximum length.</returns>
		/// <exception cref="ArgumentException">Maximum length is less than minimum length.</exception>
		/// <remarks>
		///     If the string is longer than the minimum length but shorter than the maximum length,
		///     it will be left untouched.
		/// </remarks>
		public static string Resize(this string me, int minLength, int maxLength)
		{
			if (me == null)
			{
				return null;
			}

			if (Math.Abs(maxLength) < Math.Abs(minLength))
			{
				throw new ArgumentException("Maximum length is less than minimum length.");
			}

			return me.Pad(minLength).Crop(maxLength); // As long as |minLen| <= |maxLen| the operations are commutative, i.e. the order doesn't matter.
		}



		#region [ Multi-Line ]

		/// <summary>
		///     Returns a copy of the current string with ensured minimum and maximum
		///     length of every line in the current string.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="minLineLength">
		///     The minimum length of every line in the resulting string. Pads with spaces
		///     on the left side if the line in the current string is shorter than this length.
		/// </param>
		/// <param name="maxLineLength">
		///     The maximum length of every line in the resulting string. Removes
		///     characters from the left side if the line in the current string is longer
		///     than this maximum length.
		/// </param>
		/// <returns>
		///     A copy of the current string with ensured minimum and maximum length of
		///     every line in the current string.
		/// </returns>
		/// <remarks>
		///     The lines that are longer than the minimum length but shorter than the maximum length
		///     will be left untouched.
		/// </remarks>
		public static string ResizeLinesLeft(this string me, int minLineLength, int maxLineLength)
		{
			return me?
				.Lines()
				.Select(line => line.ResizeLeft(minLineLength, maxLineLength))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string with ensured minimum and maximum
		///     length of every line in the current string.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="minLineLength">
		///     The minimum length of every line in the resulting string. Pads with spaces
		///     on the right side if the line in the current string is shorter than this length.
		/// </param>
		/// <param name="maxLineLength">
		///     The maximum length of every line in the resulting string. Removes
		///     characters from the right side if the line in the current string is longer
		///     than this maximum length.
		/// </param>
		/// <returns>
		///     A copy of the current string with ensured minimum and maximum length of
		///     every line in the current string.
		/// </returns>
		/// <remarks>
		///     The lines that are longer than the minimum length but shorter than the maximum length
		///     will be left untouched.
		/// </remarks>
		public static string ResizeLinesRight(this string me, int minLineLength, int maxLineLength)
		{
			return me?
				.Lines()
				.Select(line => line.ResizeRight(minLineLength, maxLineLength))
				.JoinLines();
		}



		/// <summary>
		///     Returns a copy of the current string with ensured minimum and maximum length of every
		///     line in the current string.
		/// </summary>
		/// <param name="me">The current string.</param>
		/// <param name="minLineLength">
		///     The minimum length of every line in the resulting string. Pads with spaces on the
		///     left if positive, and on the right if negative.
		/// </param>
		/// <param name="maxLineLength">
		///     The maximum length of every line in the resulting string. Removes characters from the
		///     left side if positive, and right side if negative.
		/// </param>
		/// <returns>
		///     A copy of the current string with ensured minimum and maximum length of every line in
		///     the current string.
		/// </returns>
		/// <remarks>
		///     The lines that are longer than the minimum length but shorter than the maximum length
		///     will be left untouched.
		/// </remarks>
		public static string ResizeLines(this string me, int minLineLength, int maxLineLength)
		{
			return me?.Lines()
				.Select(line => line.Resize(minLineLength, maxLineLength))
				.JoinLines();
		}

		#endregion [ Multi-Line ]

	}

}
