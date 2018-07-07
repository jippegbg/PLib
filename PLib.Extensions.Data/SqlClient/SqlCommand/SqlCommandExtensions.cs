using System.Data;
using System.Data.SqlClient;


namespace PLib.Extensions.Data.SqlClient
{

	/// <summary>
	/// TODO: Edit XML Comments
	/// </summary>
	public static partial class SqlCommandExtensions
	{

		/// <summary>
		/// 
		/// </summary>
		/// <param name="me">The current command.</param>
		/// <returns></returns>
		public static DataSet ExecuteDataSet(this SqlCommand me)
		{
			DataSet set = new DataSet();
			using (SqlDataAdapter dataAdapter = new SqlDataAdapter(me))
			{
				dataAdapter.Fill(set);
			}

			return set;
		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="me">The current command.</param>
		/// <returns></returns>
		public static DataTable ExecuteDataTable(this SqlCommand me)
		{
			DataTable table = new DataTable();
			using (SqlDataAdapter dataAdapter = new SqlDataAdapter(me))
			{
				dataAdapter.Fill(table);
			}

			return table;
		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="me">The current command.</param>
		/// <param name="tableName">The name of the table in the resulting DataSet that should be filled with the command result.</param>
		/// <returns></returns>
		public static DataSet ExecuteDataTable(this SqlCommand me, string tableName)
		{
			DataSet set = new DataSet();
			using (SqlDataAdapter dataAdapter = new SqlDataAdapter(me))
			{
				dataAdapter.Fill(set, tableName);
			}

			return set;
		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="me">The current command.</param>
		/// <param name="schemaType"></param>
		/// <returns></returns>
		public static DataTable ExecuteSchema(this SqlCommand me, SchemaType schemaType = SchemaType.Mapped)
		{
			DataTable table = new DataTable();
			using (SqlDataAdapter dataAdapter = new SqlDataAdapter(me))
			{
				dataAdapter.FillSchema(table, schemaType);
			}

			return table;
		}

	}

}
