using System;


namespace PLib.Extensions.Core
{

	public static partial class ArrayExtensions
	{

		/// <summary>
		///     Reverses the sequence of the elements in the entire current one-dimensional array.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <returns>The current array after the elements have been reversed.</returns>
		public static Array Reverse(this Array me)
		{
			Array.Reverse(me);
			return me;
		}



		/// <summary>
		///     Reverses the sequence of the elements in a section of elements in the current
		///     one-dimensional array.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="offset">The starting index of the section to reverse.</param>
		/// <param name="length">The number of elements in the section to reverse.</param>
		/// <returns>The current array after the elements have been reversed.</returns>
		public static Array Reverse(this Array me, int offset, int length)
		{
			Array.Reverse(me, offset, length);
			return me;
		}

	}

}
