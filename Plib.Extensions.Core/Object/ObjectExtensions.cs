using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace PLib.Extensions.Core
{

	/// <summary>
	///     Extensions of the <see cref="Object"/> class.
	/// </summary>
	public static partial class ObjectExtensions
	{

		/// <summary>
		///     Returns a string that represents the current object, or <see cref="string.Empty"/> if
		///     the current object is null.
		/// </summary>
		/// <param name="me">The current object.</param>
		/// <returns>
		///     A string that represents the current object, or <see cref="string.Empty"/> if the
		///     current object is null.
		/// </returns>
		public static string ToStringOrEmpty(this object me)
		{
			return me == null ? string.Empty : me.ToString();
		}



		/// <summary>
		///     Returns a string that represents the current object, or <b>null</b> if the current
		///     object is null.
		/// </summary>
		/// <param name="me">The current object.</param>
		/// <returns>
		///     A string that represents the current object, or <b>null</b> if the current object is null.
		/// </returns>
		public static string ToStringOrNull(this object me)
		{
			return me?.ToString();
		}

	}

}
