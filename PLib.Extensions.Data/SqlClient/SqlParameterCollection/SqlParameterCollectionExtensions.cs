using System.Collections.Generic;
using System.Data.SqlClient;


namespace PLib.Extensions.Data.SqlClient
{

	/// <summary>
	///     TODO: Edit XML Comment
	/// </summary>
	public static partial class SqlParameterCollectionExtensions
	{

		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <param name="me">Me.</param>
		/// <param name="values">The values.</param>
		/// <returns></returns>
		public static SqlParameterCollection AddRangeWithValue(this SqlParameterCollection me, Dictionary<string, object> values)
		{
			foreach (KeyValuePair<string, object> entry in values)
			{
				me.AddWithValue(entry.Key, entry.Value);
			}

			return me;
		}

	}

}
