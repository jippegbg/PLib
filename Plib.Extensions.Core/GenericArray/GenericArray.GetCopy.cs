using System;


namespace PLib.Extensions.Core
{

	public static partial class GenericArrayExtensions
	{

		/// <summary>
		///     Copies the entire current one-dimentional array (vector) into a new one.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="me">The current one-dimetional array.</param>
		/// <returns>A copy of the entire current one-dimetional array.</returns>
		public static T[] GetCopy<T>(this T[] me)
		{
			if (me == null)
			{
				return null;
			}

			T[] copy = new T[me.LongLength];
			Array.Copy(me, copy, me.LongLength);
			return copy;
		}



		/// <summary>
		///     Copies the entire current two-dimentional array (matrix) into a new one.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="me">The current two-dimetional array.</param>
		/// <returns>A copy of the entire current two-dimetional array.</returns>
		public static T[,] GetCopy<T>(this T[,] me)
		{
			if (me == null)
			{
				return null;
			}

			T[,] copy = new T[me.GetLongLength(0), me.GetLongLength(1)];
			Array.Copy(me, copy, me.LongLength);
			return copy;
		}



		/// <summary>
		///     Copies the entire current three-dimentional array (cube) into a new one.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current three-dimetional array.</param>
		/// <returns>A copy of the entire current three-dimetional array.</returns>
		public static T[,,] GetCopy<T>(this T[,,] me)
		{
			if (me == null)
			{
				return null;
			}

			T[,,] copy = new T[me.GetLongLength(0), me.GetLongLength(1), me.GetLongLength(2)];
			Array.Copy(me, copy, me.LongLength);
			return copy;
		}

	}

}
