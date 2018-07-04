using System;
using System.IO;


namespace PLib.Extensions.System
{

	/// <summary>
	/// 
	/// </summary>
	/// TODO Edit XML Comment Template for ByteArrayExtensions
	public static partial class ByteArrayExtensions
	{

		/// <summary>
		/// To the memory stream.
		/// </summary>
		/// <param name="this">The this.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToMemoryStream
		public static MemoryStream ToMemoryStream(this byte[] @this)
		{
			return new MemoryStream(@this);
		}

	}

}
