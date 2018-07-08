using System.Collections.Generic;
using System.Linq;


namespace PLib.Functional
{

	/// <summary>
	///     A helper function to generate hash codes for aggregated classes. By starting with a
	///     single object or enumeration one gets a new hash code object, which in turn can be
	///     combined with other single object or enumerations to get a composite hash code. Every
	///     single hash code object is immutable.
	/// </summary>
	/// <seealso href="https://rehansaeed.com/gethashcode-made-easy/"/>
	/// <remarks>Combining hash codes is done with the DJB2a algorithm.</remarks>
	public struct HashCode
	{

		private readonly int m_value;



		/// <summary>
		///     Gets the value of the current hash code.
		/// </summary>
		public int Value => m_value;



		private HashCode(int value)
		{
			m_value = value;
		}



		private static int GetHashCode<T>(T item) => item == null ? 0 : item.GetHashCode();



		private static int GetHashCode<T>(IEnumerable<T> items)
		{
			if (items == null)
			{
				return 0;
			}

			T[] array = items as T[] ?? items.ToArray();

			return array.Length > 0 ? array.Select(GetHashCode).Aggregate(CombineHashCodes) : 0;
		}



		/// <summary>
		///     Creates a new hash code from a single object.
		/// </summary>
		/// <typeparam name="T">The type of the object to create a hash code from.</typeparam>
		/// <param name="item">The object to create a hash code from.</param>
		/// <returns>A new hash code object.</returns>
		public static HashCode Of<T>(T item) => new HashCode(GetHashCode(item));



		/// <summary>
		///     Combines the current hash code with another object into a new hash code object.
		/// </summary>
		/// <typeparam name="T">
		///     The type of the object to combine with the current hash code.
		/// </typeparam>
		/// <param name="item">The object to combine with the current hash code.</param>
		/// <returns>
		///     A new hash code object that is combined from the first hash code and the parameter object.
		/// </returns>
		public HashCode And<T>(T item) => new HashCode(CombineHashCodes(m_value, GetHashCode(item)));



		/// <summary>
		///     Creates a new hash code from an enumerable object.
		/// </summary>
		/// <typeparam name="T">The type of the objects in the enumerable object.</typeparam>
		/// <param name="items">The enumerable object.</param>
		/// <returns>A new hash code object.</returns>
		public static HashCode OfEach<T>(IEnumerable<T> items) => new HashCode(GetHashCode(items));



		/// <summary>
		///     Combines the current hash code with an enumerable into a new hash code object.
		/// </summary>
		/// <typeparam name="T">The type of the objects in the enumerable object.</typeparam>
		/// <param name="items">The enumeration.</param>
		/// <returns>
		///     A new hash code object that is combined from the first hash code and the enumerable object.
		/// </returns>
		public HashCode AndEach<T>(IEnumerable<T> items) => new HashCode(CombineHashCodes(m_value, GetHashCode(items)));



		private static int CombineHashCodes(int h1, int h2)
		{
			unchecked
			{
				return ((h1 << 5) + h1) ^ h2; // DJB2a
				                              // return h2 + (h1 << 6) + (h1 << 16) - h1; // SDBM
			}
		}



		/// <summary>
		///     Implicitly unwraps a hash code into an Int32.
		/// </summary>
		/// <param name="hashCode">The hash code to unwrap,</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator int(HashCode hashCode) => hashCode.m_value;

	}

}