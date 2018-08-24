using System;


namespace PLib.Extensions.Core
{

	public static partial class GenericArrayExtensions
	{

		/// <summary>
		///     Retrieves a subarray from the current one-dimensional array. The subarray starts at a
		///     specified position and continues to the end of the the current array.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="startIndex">
		///     The zero-based starting position of a subarray in this array.
		/// </param>
		/// <returns>
		///     An array that is equivalent to the subarray that begins at
		///     <paramref name="startIndex"/> in the current array, <see cref="Array.Empty{T}"/> if
		///     <paramref name="startIndex"/> is equal to the length of the current array, or
		///     <see langword="null"/> if the current array is <see langword="null"/>.
		/// </returns>
		/// <remarks>
		///     <note type="note"> This method does not modify the value of the current array.
		///     Instead, it returns a new array that begins at the <paramref name="startIndex"/>
		///     position in the current array. </note>
		/// </remarks>
		/// <exception cref="ArgumentOutOfRangeException">
		///     <paramref name="startIndex"/> is less than zero or greater than the length of the
		///     current array.
		/// </exception>
		/// <remarks>
		///     If <paramref name="startIndex"/> is equal to zero, the method returns the original
		///     array unchanged.
		/// </remarks>
		public static T[] Subarray<T>(this T[] me, int startIndex)
		{
			if (me == null)
			{
				return null;
			}

			if (startIndex < 0 || me.Length < startIndex)
			{
				throw new ArgumentOutOfRangeException(nameof(startIndex));
			}

			if (startIndex == 0)
			{
				return me;
			}

			int length = me.Length - startIndex;

			T[] copy = new T[length];
			Array.Copy(me, startIndex, copy, 0, length);
			return copy;
		}



		/// <summary>
		///     Retrieves a subarray from the current one-dimensional array. The subarray starts at a
		///     specified position and has a specified length.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="startIndex">
		///     The zero-based starting position of a subarray in this array.
		/// </param>
		/// <param name="length">The number of elements in the subarray.</param>
		/// <returns>
		///     An array that is equivalent to the subarray of length <paramref name="length"/> that
		///     begins at <paramref name="startIndex"/> in the current array,
		///     <see cref="Array.Empty{T}"/> if <paramref name="length"/> is zero, or
		///     <see langword="null"/> if the current array is <see langword="null"/>.
		/// </returns>
		/// <remarks>
		///     <note type="note">This method does not modify the value of the current array.
		///     Instead, it returns a new array with <paramref name="length"/> elements starting from
		///     the <paramref name="startIndex"/> position in the current array.</note> If
		///     <paramref name="startIndex"/> is equal to zero and equals the length of the current
		///     array, this method returns the current array unchanged.
		/// </remarks>
		/// <exception cref="ArgumentNullException">If the current array is null.</exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     The <paramref name="startIndex"/> is outside the bounds of the current array.
		/// </exception>
		/// <exception cref="ArgumentException">
		///     The <paramref name="length"/> is greater than the number of elements from
		///     <paramref name="startIndex"/> to the end of the current array.
		/// </exception>
		public static T[] Subarray<T>(this T[] me, int startIndex, int length)
		{
			if (me == null)
			{
				return null;
			}

			if (startIndex < 0 || me.Length < startIndex)
			{
				throw new ArgumentOutOfRangeException(nameof(startIndex));
			}

			if (me.Length < startIndex + length)
			{
				throw new ArgumentException("The length is greater than the number of elements from offset to the end of the current array.");
			}

			if (startIndex == 0 && length == me.Length)
			{
				return me;
			}

			T[] copy = new T[length];
			Array.Copy(me, startIndex, copy, 0, length);
			return copy;
		}



		/// <summary>
		///     Retrieves a subarray from the current one-dimensional array. The subarray starts at a
		///     specified position and has a specified length.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <param name="startIndex">
		///     The zero-based starting position of a subarray in this array.
		/// </param>
		/// <param name="length">The number of elements in the subarray.</param>
		/// <returns>
		///     An array that is equivalent to the subarray of length <paramref name="length"/> that
		///     begins at <paramref name="startIndex"/> in the current array,
		///     <see cref="Array.Empty{T}"/> if <paramref name="length"/> is zero, or
		///     <see langword="null"/> if the current array is <see langword="null"/>.
		/// </returns>
		/// <remarks>
		///     <note type="note">This method does not modify the value of the current array.
		///     Instead, it returns a new array with <paramref name="length"/> elements starting from
		///     the <paramref name="startIndex"/> position in the current array.</note> If
		///     <paramref name="startIndex"/> is equal to zero and equals the length of the current
		///     array, this method returns the current array unchanged.
		/// </remarks>
		/// <exception cref="ArgumentNullException">If the current array is null.</exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     The <paramref name="startIndex"/> is outside the bounds of the current array.
		/// </exception>
		/// <exception cref="ArgumentException">
		///     The <paramref name="length"/> is greater than the number of elements from
		///     <paramref name="startIndex"/> to the end of the current array.
		/// </exception>
		public static T[] Subarray<T>(this T[] me, long startIndex, long length)
		{
			if (me == null)
			{
				return null;
			}

			if (startIndex < 0 || me.Length < startIndex)
			{
				throw new ArgumentOutOfRangeException(nameof(startIndex));
			}

			if (me.Length < startIndex + length)
			{
				throw new ArgumentException("The length is greater than the number of elements from offset to the end of the current array.");
			}

			if (startIndex == 0 && length == me.Length)
			{
				return me;
			}

			T[] copy = new T[length];
			Array.Copy(me, startIndex, copy, 0, length);
			return copy;
		}



		/// <summary>
		///     Retrieves a segment of the current array, that starts and ends
		///     at specified indexes.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="startIndex">
		///     The inclusive zero-based starting character position of the current string.
		/// </param>
		/// <param name="endIndex">
		///     The exclusive zero-based ending character position of the current string.
		/// </param>
		/// <returns>
		///     An array that is equivalent to the subarray that begins at
		///     <paramref name="startIndex"/> and end before <paramref name="endIndex"/> of the current array.
		/// </returns>
		public static T[] Slice<T>(this T[] me, int startIndex, int endIndex)
		{
			return me?.Subarray(startIndex, endIndex - startIndex);
		}



		/// <summary>
		///     Retrieves a segment of the current array, that starts and ends
		///     at specified indexes.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="startIndex">
		///     The inclusive zero-based starting character position of the current string.
		/// </param>
		/// <param name="endIndex">
		///     The exclusive zero-based ending character position of the current string.
		/// </param>
		/// <returns>
		///     An array that is equivalent to the subarray that begins at
		///     <paramref name="startIndex"/> and end before <paramref name="endIndex"/> of the current array.
		/// </returns>
		public static T[] Slice<T>(this T[] me, long startIndex, long endIndex)
		{
			return me?.Subarray(startIndex, endIndex - startIndex);
		}

	}

}
