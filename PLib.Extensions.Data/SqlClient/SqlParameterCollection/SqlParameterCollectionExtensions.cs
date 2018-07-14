using System.Collections.Generic;
using System.Data.SqlClient;


namespace PLib.Extensions.Data.SqlClient
{

	/// <summary>
	///     Extensions of the <see cref="SqlParameterCollection"/> class.
	/// </summary>
	public static class SqlParameterCollectionExtensions
	{

		/// <summary>
		///     Add parameters from a dictionary to the current collection.
		/// </summary>
		/// <param name="me">The current parameter collection.</param>
		/// <param name="values">
		///     A dictionary containing the parameters to add. The dictionary keys are used as the
		///     parameter names.
		/// </param>
		/// <returns>The current parameter collection with the values added.</returns>
		/// <remarks>
		///     Dictionary keys is missing the leading @ sign will be prefixed before added to the collection.
		/// </remarks>
		public static SqlParameterCollection AddRangeWithValue(this SqlParameterCollection me, IDictionary<string, object> values)
		{
			foreach (KeyValuePair<string, object> entry in values)
			{
				string parameterName = entry.Key;
				if (!parameterName.StartsWith("@"))
				{
					parameterName = $"@{parameterName}";
				}
				me.AddWithValue(parameterName, entry.Value);
			}

			return me;
		}

	}

}
