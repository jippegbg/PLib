using System.Collections.Generic;
using System.Data.SqlClient;


namespace PLib.Extensions.Data.SqlClient
{

	public static partial class SqlParameterCollectionExtensions
	{

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
