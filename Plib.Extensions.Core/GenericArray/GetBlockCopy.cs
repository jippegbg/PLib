using System;


namespace PLib.Extensions.Core {

	public static partial class GenericArrayExtensions
	{

		/// <summary>
		///     Copies the entire current one-dimentional array into a new one.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="me">The current array.</param>
		/// <returns>A copy of the entire current one-dimetional array.</returns>
		/// <remarks>
		///     <para>
		///         This method provides better performance for copying primitive types
		///         than the other copy methods.
		///     </para>
		///     <para>
		///         Only applicable to arrays of <see cref="bool"/>, <see cref="char"/>,
		///         <see cref="sbyte"/>, <see cref="byte"/>, <see cref="short"/>,
		///         <see cref="ushort"/>, <see cref="int"/>, <see cref="uint"/>,
		///         <see cref="long"/>, <see cref="ulong"/>, <see cref="IntPtr"/>,
		///         <see cref="UIntPtr"/>, <see cref="Single"/>, and <see cref="Double"/>.
		///     </para>
		/// </remarks>
		public static T[] GetBlockCopy<T>(this T[] me)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			T[] copy = new T[me.Length];
			Buffer.BlockCopy(me, 0, copy, 0, Buffer.ByteLength(me));
			return copy;
		}



		/// <summary>
		///     Copies the entire current two-dimentional array into a new one.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current array.</param>
		/// <returns>A copy of the entire current two-dimetional array.</returns>
		/// <exception cref="ArgumentNullException">this</exception>
		/// <remarks>
		///     <para>
		///         This method provides better performance for copying primitive types
		///         than the other copy methods.
		///     </para>
		///     <para>
		///         Only applicable to arrays of <see cref="bool"/>, <see cref="char"/>,
		///         <see cref="sbyte"/>, <see cref="byte"/>, <see cref="short"/>,
		///         <see cref="ushort"/>, <see cref="int"/>, <see cref="uint"/>,
		///         <see cref="long"/>, <see cref="ulong"/>, <see cref="IntPtr"/>,
		///         <see cref="UIntPtr"/>, <see cref="Single"/>, and <see cref="Double"/>.
		///     </para>
		/// </remarks>
		public static T[,] GetBlockCopy<T>(this T[,] me)
		{
			if (me == null)
			{
				throw new ArgumentNullException(nameof(me));
			}

			T[,] copy = new T[me.GetLength(0), me.GetLength(1)];
			Buffer.BlockCopy(me, 0, copy, 0, Buffer.ByteLength(me));
			return copy;
		}

	}

}