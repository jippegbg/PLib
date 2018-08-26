using System;


namespace PLib.Extensions.Core
{

	/// <summary>
	///     Extensions of the <see cref="Array"/> class.
	/// </summary>
	public static partial class ArrayExtensions
	{

		/// <summary>
		///     Determines whether the current array is empty.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <returns><see langword="true"/> if the current array is empty; otherwise, <see langword="false"/>.</returns>
		/// <remarks>If the current array is null, <see langword="false"/> will be returned.</remarks>
		public static bool IsEmpty(this Array me)
		{
			return me != null && me.Length == 0;
		}


		/// <summary>
		///     Determines whether the current array is not empty.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <returns>
		///     <see langword="true"/> if the current array is <see langword="null"/> or has at least
		///     one element; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool IsNotEmpty(this Array me)
		{
			return me == null || me.Length > 0;
		}



		/// <summary>
		///     Determines whether the current array is null or empty.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <returns>
		///     <see langword="true"/> if the current array is <see langword="null"/> or empty;
		///     otherwise, <see langword="false"/>.
		/// </returns>
		public static bool IsNullOrEmpty(this Array me)
		{
			return me == null || me.Length == 0;
		}



		/// <summary>
		///     Determines whether the current array has any elements.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <returns>
		///     <see langword="true"/> if the current array is not null and contains at least one
		///     element; otherwise, <see langword="false"/>.
		/// </returns>
		/// <remarks>This method could also be called IsNotNullNorEmpty.</remarks>
		public static bool HasElements(this Array me)
		{
			return me != null && me.Length > 0;
		}



		/// <summary>
		///     Returns the number of bytes in the current array.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <returns>The number of bytes in the current array.</returns>
		/// <exception cref="ArgumentNullException">The current array is null.</exception>
		/// <exception cref="ArgumentException">The current array is not a primitive.</exception>
		/// <exception cref="OverflowException">
		///     The current array is larger than 2 gigabytes (GB).
		/// </exception>
		public static int ByteLength(this Array me)
		{
			return Buffer.ByteLength(me);
		}



		/// <summary>
		///     Retrieves the byte at a specified location in the current array.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="index">The location in the current array.</param>
		/// <returns>Returns the <paramref name="index"/> byte in the array.</returns>
		/// <exception cref="ArgumentNullException">The current array is null.</exception>
		/// <exception cref="ArgumentException">The current array is not a primitive.</exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     <paramref name="index"/> is negative or greater than the length of the current array.
		/// </exception>
		/// <exception cref="OverflowException">
		///     The current array is larger than 2 gigabytes (GB).
		/// </exception>
		public static byte GetByte(this Array me, int index)
		{
			return Buffer.GetByte(me, index);
		}



		/// <summary>
		///     Assigns a specified value to a byte at a particular location in the current array.
		/// </summary>
		/// <param name="me">The current array.</param>
		/// <param name="index">The location in the current array.</param>
		/// <param name="value">A value to assign.</param>
		/// <exception cref="ArgumentNullException">The current array is null.</exception>
		/// <exception cref="ArgumentException">The current array is not a primitive.</exception>
		/// <exception cref="ArgumentOutOfRangeException">
		///     <paramref name="index"/> is negative or greater than the length of the current array.
		/// </exception>
		/// <exception cref="OverflowException">
		///     The current array is larger than 2 gigabytes (GB).
		/// </exception>
		public static void SetByte(this Array me, int index, byte value)
		{
			Buffer.SetByte(me, index, value);
		}

	}

}
