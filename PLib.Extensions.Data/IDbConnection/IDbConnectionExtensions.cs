using System.Data;
using System.Diagnostics.CodeAnalysis;


namespace PLib.Extensions.Data
{

	/// <summary>
	///     Extensions of the <see cref="IDbConnection"/> interface.
	/// </summary>
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public static class IDbConnectionExtensions
	{

		/// <summary>
		/// Ensures the open.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <returns></returns>
		public static IDbConnection EnsureOpen(this IDbConnection me)
		{
			if (me.State != ConnectionState.Open)
			{
				me.Open();
			}

			return me;
		}



		/// <summary>
		/// Determines whether this instance is closed.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <returns>
		///   <c>true</c> if the specified me is closed; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsClosed(this IDbConnection me)
		{
			return me.State == ConnectionState.Closed;
		}



		/// <summary>
		/// Determines whether this instance is open.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <returns>
		///   <c>true</c> if the specified me is open; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsOpen(this IDbConnection me)
		{
			return me.State == ConnectionState.Open;
		}

	}

}
