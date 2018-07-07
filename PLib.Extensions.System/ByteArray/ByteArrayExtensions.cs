using System.IO;


namespace PLib.Extensions.System
{

	/// <summary>
	/// TODO: Edit XML Comment
	/// </summary>
	public static partial class ByteArrayExtensions
	{

		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <param name="this">The this.</param>
		/// <returns></returns>
		public static MemoryStream ToMemoryStream(this byte[] @this)
		{
			return new MemoryStream(@this);
		}

	}

}
