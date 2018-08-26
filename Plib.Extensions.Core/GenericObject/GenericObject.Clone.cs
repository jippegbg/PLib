using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace PLib.Extensions.Core.GenericObject
{

	public static partial class GenericObjectExtensions
	{

		/// <summary>
		///     Creates a deep clone of the current object.
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me">The current object.</param>
		/// <returns>A deep clone of the current object.</returns>
		/// <remarks>
		///     The cloning is performed by serializing the current object into a stream, and then
		///     deserializing the stream into a new object.
		/// </remarks>
		public static T Clone<T>(this T me)
		{
			IFormatter formatter = new BinaryFormatter();

			using (MemoryStream stream = new MemoryStream())
			{
				formatter.Serialize(stream, me);
				stream.Seek(0, SeekOrigin.Begin);

				return (T)formatter.Deserialize(stream);
			}
		}

	}

}