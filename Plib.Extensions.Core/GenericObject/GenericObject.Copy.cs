using System;
using System.Reflection;


namespace PLib.Extensions.Core.GenericObject {

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
		///     The copying is performed by accessing the <see cref="Object.MemberwiseClone"/> method
		///     of the current object.
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

	}

}