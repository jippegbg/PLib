using System;


namespace PLib.Extensions.Core
{

	public static partial class ArrayExtensions
	{

		/// <summary>
		///     Determines if the specified index is within the bounds of the current array.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="index">The index to check.</param>
		/// <returns>
		///     <see langword="true"/> if the <paramref name="index"/> is within the bounds of the
		///     current array; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool IsWithinBounds(this Array me, int index)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			return 0 <= index && index < me.Length;
		}



		/// <summary>
		///     Determines if the specified index is within the bounds of the current array.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="index">The index to check.</param>
		/// <returns>
		///     <see langword="true"/> if the <paramref name="index"/> is within the bounds of the
		///     current array; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool IsWithinBounds(this Array me, long index)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			return 0L <= index && index < me.LongLength;
		}



		/// <summary>
		///     Determines if the specified index is within the bounds of a specified
		///     dimension of the current multi-dimensional array.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="index">The index to check.</param>
		/// <param name="dimension">
		///     The dimension of the current multi-dimensional array to check the
		///     <paramref name="index"/> against.
		/// </param>
		/// <returns>
		///     <see langword="true"/> if the <paramref name="index"/> is within the bounds of a
		///     specified <paramref name="dimension"/> of the current multi-dimensional
		///     array; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool IsWithinBounds(this Array me, int index, int dimension)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			return me.GetLowerBound(dimension) <= index && index <= me.GetUpperBound(dimension);
		}

	}

}
