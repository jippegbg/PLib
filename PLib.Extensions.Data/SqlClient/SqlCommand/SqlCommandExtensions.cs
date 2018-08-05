using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;


namespace PLib.Extensions.Data.SqlClient
{

	/// <summary>
	///     Extensions of the <see cref="SqlCommand"/> class.
	/// </summary>
	public static class SqlCommandExtensions
	{

		/// <summary>
		///     Fills and returns a new <see cref="DataSet"/> based on the current <see cref="SqlCommand"/>.
		/// </summary>
		/// <param name="me">The current command.</param>
		/// <returns>A new <see cref="DataSet"/> based on the current <see cref="SqlCommand"/>.</returns>
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
		///     Fills and returns a new <see cref="DataSet"/> based on the current
		///     <see cref="SqlCommand"/>, containing one <see cref="DataTable"/> with the specified <paramref name="tableName"/>.
		/// </summary>
		/// <param name="me">The current command.</param>
		/// <param name="tableName">The name of the source and resulting table to be filled.</param>
		/// <returns>
		///     A a new <see cref="DataSet"/> based on the current <see cref="SqlCommand"/>,
		///     containing one <see cref="DataTable"/> with the specified <paramref name="tableName"/>.
		/// </returns>
		public static DataSet ExecuteDataSet(this SqlCommand me, string tableName)
		{
			DataSet set = new DataSet();
			using (SqlDataAdapter dataAdapter = new SqlDataAdapter(me))
			{
				dataAdapter.Fill(set, tableName);
			}

			return set;
		}



		/// <summary>
		///     Fills and returns a new <see cref="DataTable"/> based on the current <see cref="SqlCommand"/>.
		/// </summary>
		/// <param name="me">The current command.</param>
		/// <returns>A new <see cref="DataTable"/> based on the current <see cref="SqlCommand"/>.</returns>
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
		///     Retrieves a new empty <see cref="DataTable"/> with the schema configured based on the
		///     specified <see cref="SchemaType"/>.
		/// </summary>
		/// <param name="me">The current command.</param>
		/// <param name="schemaType">
		///     One of the <see cref="SchemaType"/> values. The default is <see cref="SchemaType.Mapped"/>.
		/// </param>
		/// <returns>
		///     A <see cref="DataTable"/> that contains schema information returned from the data
		///     source, but without any data.
		/// </returns>
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
		///     Sends the <see cref="SqlCommand.CommandText"/> to the
		///     <see cref="SqlCommand.Connection"/> and builds an <see cref="SqlEntityReader{T}"/>.
		/// </summary>
		/// <typeparam name="T">The type of entities to read.</typeparam>
		/// <param name="me">The current command.</param>
		/// <returns>An <see cref="SqlEntityReader{T}"/> object.</returns>
		public static SqlEntityReader<T> ExecuteEntityReader<T>(this SqlCommand me) where T : new()
		{
			return new SqlEntityReader<T>(me.ExecuteReader());
		}



		/// <summary>
		///     Sends the <see cref="SqlCommand.CommandText"/> to the
		///     <see cref="SqlCommand.Connection"/>, and builds an <see cref="SqlEntityReader{T}"/>
		///     using one of the <see cref="CommandBehavior"/> values.
		/// </summary>
		/// <typeparam name="T">The type of entities to read.</typeparam>
		/// <param name="me">The current command.</param>
		/// <param name="behavior">One of the <see cref="CommandBehavior"/> values.</param>
		/// <returns>An <see cref="SqlEntityReader{T}"/> object.</returns>
		public static SqlEntityReader<T> ExecuteEntityReader<T>(this SqlCommand me, CommandBehavior behavior) where T : new()
		{
			return new SqlEntityReader<T>(me.ExecuteReader(behavior));
		}



		/// <summary>
		///     An asynchronous version of <see cref="ExecuteEntityReader{T}(SqlCommand)"/>, which
		///     sends the <see cref="SqlCommand.CommandText"/> to the
		///     <see cref="SqlCommand.Connection"/> and builds an <see cref="SqlEntityReader{T}"/>.
		///     Exceptions will be reported via the returned <see cref="Task{TResult}"/> object.
		/// </summary>
		/// <typeparam name="T">The type of entities to read.</typeparam>
		/// <param name="me">The current command.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<SqlEntityReader<T>> ExecuteEntityReaderAsync<T>(this SqlCommand me) where T : new()
		{
			return new SqlEntityReader<T>(await me.ExecuteReaderAsync());
		}



		/// <summary>
		///     An asynchronous version of <see cref="ExecuteEntityReader{T}(SqlCommand)"/>, which
		///     sends the <see cref="SqlCommand.CommandText"/> to the
		///     <see cref="SqlCommand.Connection"/> and builds an <see cref="SqlEntityReader{T}"/>.
		///     Exceptions will be reported via the returned <see cref="Task{TResult}"/> object.
		/// </summary>
		/// <typeparam name="T">The type of entities to read.</typeparam>
		/// <param name="me">The current command.</param>
		/// <param name="behavior">
		///     Options for statement execution and data retrieval. When is set to
		///     <see cref="CommandBehavior.Default"/>, <see cref="SqlEntityReader{T}.ReadAsync()"/>
		///     reads the entire row before returning a complete Task.
		/// </param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<SqlEntityReader<T>> ExecuteEntityReaderAsync<T>(this SqlCommand me, CommandBehavior behavior) where T : new()
		{
			return new SqlEntityReader<T>(await me.ExecuteReaderAsync(behavior));
		}



		/// <summary>
		///     An asynchronous version of <see cref="ExecuteEntityReader{T}(SqlCommand)"/>, which
		///     sends the <see cref="SqlCommand.CommandText"/> to the
		///     <see cref="SqlCommand.Connection"/> and builds an <see cref="SqlEntityReader{T}"/>. The
		///     cancellation token can be used to request that the operation be abandoned before the
		///     command timeout elapses. Exceptions will be reported via the returned Task object.
		/// </summary>
		/// <typeparam name="T">The type of entities to read.</typeparam>
		/// <param name="me">The current command.</param>
		/// <param name="cancellationToken">The cancellation instruction.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<SqlEntityReader<T>> ExecuteEntityReaderAsync<T>(this SqlCommand me, CancellationToken cancellationToken) where T : new()
		{
			return new SqlEntityReader<T>(await me.ExecuteReaderAsync(cancellationToken));
		}



		/// <summary>
		///     An asynchronous version of <see cref="ExecuteEntityReader{T}(SqlCommand)"/>, which
		///     sends the <see cref="SqlCommand.CommandText"/> to the
		///     <see cref="SqlCommand.Connection"/> and builds an <see cref="SqlEntityReader{T}"/>. The
		///     cancellation token can be used to request that the operation be abandoned before the
		///     command timeout elapses. Exceptions will be reported via the returned Task object.
		/// </summary>
		/// <typeparam name="T">The type of entities to read.</typeparam>
		/// <param name="me">The current command.</param>
		/// <param name="behavior">
		///     Options for statement execution and data retrieval. When is set to
		///     <see cref="CommandBehavior.Default"/>, <see cref="SqlEntityReader{T}.ReadAsync()"/>
		///     reads the entire row before returning a complete Task.
		/// </param>
		/// <param name="cancellationToken">The cancellation instruction.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<SqlEntityReader<T>> ExecuteEntityReaderAsync<T>(this SqlCommand me, CommandBehavior behavior, CancellationToken cancellationToken) where T : new()
		{
			return new SqlEntityReader<T>(await me.ExecuteReaderAsync(behavior, cancellationToken));
		}

	}

}
