using System.Linq;


namespace PLib.Extensions.Core.GenericObject {

	public static partial class GenericObjectExtensions {

		/// <summary>
		///     Returns the current object; or if <see langword="null"/>, the first non-null value of the
		///     <paramref name="values"/> parameters; or if all are <see langword="null"/>, the default value
		///     of type <typeparamref name="T"/>.
		/// </summary>
		/// <typeparam name="T">The type of the current object.</typeparam>
		/// <param name="me">The type of the current object.</param>
		/// <param name="values">An array of values to replace the current with, if it's null.</param>
		/// <returns>
		///     The current object; or if <see langword="null"/>, the first non-null value of the
		///     <paramref name="values"/> parameters; or if all are null, the default value
		///     of type <typeparamref name="T"/>.
		/// </returns>
		public static T Coalesce<T>(this T me, params T[] values) where T : class
		{
			return me ?? values.FirstOrDefault(value => value != null);
		}

	}

}