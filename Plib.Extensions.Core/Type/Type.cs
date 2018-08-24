using System;
using System.Collections.Generic;


namespace PLib.Extensions.Core
{

	/// <summary>
	///     Extensions of the <see cref="Type"/> class.
	/// </summary>
	public static partial class TypeExtensions
	{

		private static readonly HashSet<Type> NumericTypes = new HashSet<Type>()
		{
			typeof(byte),
			typeof(sbyte),
			typeof(ushort),
			typeof(short),
			typeof(uint),
			typeof(int),
			typeof(ulong),
			typeof(long),
			typeof(float),
			typeof(double),
			typeof(decimal)
		};

		/// <summary>
		///     Determines if the current type is one of the primitive numeric types.
		/// </summary>
		/// <param name="type">The current type.</param>
		/// <returns>
		///     <see langword="true"/> if the current type is one of the primitive numeric types;
		///     otherwise, <see langword="false"/>.
		/// </returns>
		/// <remarks>
		///     The primitive numeric types are: <see cref="byte"/>, <see cref="sbyte"/>,
		///     <see cref="ushort"/>, <see cref="short"/>, <see cref="uint"/>, <see cref="int"/> ,
		///     <see cref="ulong"/>, <see cref="long"/>, <see cref="float"/>, <see cref="double"/>, <see cref="decimal"/>.
		/// </remarks>
		public static bool IsNumeric(this Type type) => NumericTypes.Contains(type);

	}

}
