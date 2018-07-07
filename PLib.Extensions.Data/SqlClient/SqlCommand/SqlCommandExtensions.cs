using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;


namespace PLib.Extensions.Data.SqlClient
{

	/// <summary>
	///     TODO: Edit XML Comments
	/// </summary>
	public static partial class SqlCommandExtensions
	{

		/// <summary>
		///     TODO: Edit XML Comment
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
		///     TODO: Edit XML Comment
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
		///     TODO: Edit XML Comment
		/// </summary>
		/// <param name="me">The current command.</param>
		/// <param name="tableName">
		///     The name of the table in the resulting DataSet that should be filled with
		///     the command result.
		/// </param>
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
		///     TODO: Edit XML Comment
		/// </summary>
		/// <param name="me">The current command.</param>
		/// <param name="schemaType">Type of the schema.</param>
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



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">Me.</param>
		/// <returns></returns>
		public static EntityReader<T> ExecuteEntityReader<T>(this SqlCommand me) where T : new()
		{
			return new EntityReader<T>(me.ExecuteReader());
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">Me.</param>
		/// <param name="behavior">The behavior.</param>
		/// <returns></returns>
		public static EntityReader<T> ExecuteEntityReader<T>(this SqlCommand me, CommandBehavior behavior) where T : new()
		{
			return new EntityReader<T>(me.ExecuteReader(behavior));
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">Me.</param>
		/// <returns></returns>
		public static async Task<EntityReader<T>> ExecuteEntityReaderAsync<T>(this SqlCommand me) where T : new()
		{
			return new EntityReader<T>(await me.ExecuteReaderAsync());
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">Me.</param>
		/// <param name="behavior">The behaviour.</param>
		/// <returns></returns>
		public static async Task<EntityReader<T>> ExecuteEntityReaderAsync<T>(this SqlCommand me, CommandBehavior behavior) where T : new()
		{
			return new EntityReader<T>(await me.ExecuteReaderAsync(behavior));
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">Me.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns></returns>
		public static async Task<EntityReader<T>> ExecuteEntityReaderAsync<T>(this SqlCommand me, CancellationToken cancellationToken) where T : new()
		{
			return new EntityReader<T>(await me.ExecuteReaderAsync(cancellationToken));
		}



		/// <summary>
		///     TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">Me.</param>
		/// <param name="behavior">The behaviour.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns></returns>
		public static async Task<EntityReader<T>> ExecuteEntityReaderAsync<T>(this SqlCommand me, CommandBehavior behavior, CancellationToken cancellationToken) where T : new()
		{
			return new EntityReader<T>(await me.ExecuteReaderAsync(behavior, cancellationToken));
		}

	}

}
