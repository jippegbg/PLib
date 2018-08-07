using System.IO;


namespace PLib.Extensions.Core
{

	/// <summary>
	///     Extensions of byte arrays.
	/// </summary>
	public static partial class ByteArrayExtensions
	{

		/// <summary>
		///     Converts the current byte array into a memory stream.
		/// </summary>
		/// <param name="me">The current byte array.</param>
		/// <returns>A memory stream containing the data of the current byte array.</returns>
		public static MemoryStream ToMemoryStream(this byte[] me)
		{
			return new MemoryStream(me);
		}

	}

}
