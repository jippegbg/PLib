using System;


namespace PLib.Extensions.Core
{

	public static partial class ArrayExtensions
	{

		/// <summary>
		///     Sets all elements in the current array to the default value of each element type.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <returns>The current array after all the elements have been cleared.</returns>
		public static Array Clear(this Array me)
		{
			Array.Clear(me, 0, me.Length);
			return me;
		}



		/// <summary>
		///     Sets a range of elements in the current array to the default value of each element type.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="index">The starting index of the range of elements to clear.</param>
		/// <param name="length">The number of elements to clear.</param>
		/// <returns>The current array after the specified elements have been cleared.</returns>
		public static Array Clear(this Array me, int index, int length)
		{
			Array.Clear(me, index, length);
			return me;
		}

	}

}
