using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace PLib.Extensions.Core.GenericObject
{

	/// <summary>
	///     Extensions of any generic object.
	/// </summary>
	public static partial class GenericObjectExtensions
	{

		/// <summary>
		///     Creates a shallow copy of the current object.
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me">The current object.</param>
		/// <returns>A shallow copy of the current object.</returns>
		/// <exception cref="MissingMethodException">
		///     if the method MemberwiseClone cannot be accessed.
		/// </exception>
		/// <remarks>
		///     The copying is performed by accessing the
		///     <see cref="Object.MemberwiseClone"/> method of the current object.
		/// </remarks>
		public static T Copy<T>(this T me)
		{
			MethodInfo method = me.GetType().GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);

			if (method == null)
			{
				throw new MissingMethodException($"Method MemberwiseClone not available for object of type {me.GetType().Name}.");
			}

			return (T)method.Invoke(me, null);
		}



		/// <summary>
		///     Creates a deep clone of the current object.
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me">The current object.</param>
		/// <returns>A deep clone of the current object.</returns>
		/// <remarks>
		///     The cloning is performed by serializing the current object into a stream,
		///     and then deserializing the stream into a new object.
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



		/// <summary>
		///     Returns the current object; or if null, the first non-null value of the
		///     <paramref name="values"/> parameters; or if all are null, the default value
		///     of type <typeparamref name="T"/>.
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me">The type of the current object.</param>
		/// <param name="values">The values.</param>
		/// <returns>
		///     The current object; or if null, the first non-null value of the
		///     <paramref name="values"/> parameters; or if all are null, the default value
		///     of type <typeparamref name="T"/>.
		/// </returns>
		public static T Coalesce<T>(this T me, params T[] values) where T : class
		{
			return me ?? values.FirstOrDefault(value => value != null);
		}

	}

}
