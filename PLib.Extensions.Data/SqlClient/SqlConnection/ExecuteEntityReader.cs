using System;
using System.Data;
using System.Data.SqlClient;


namespace PLib.Extensions.Data.SqlClient {

	public static partial class SqlConnectionExtensions
	{

		// TODO: Adjust comments for EntityReader<T>

		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="command">The command to execute.</param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		/// <remarks>
		///     One can also call
		///     <c>SqlConnection.ExecuteReader(command).AsEnumerable&lt;T&gt;()</c> to get
		///     the same result.
		/// </remarks>
		public static EntityReader<T> ExecuteEntityReader<T>(this SqlConnection me, SqlCommand command) where T : new()
		{
			command.Connection = me;
			return command.ExecuteEntityReader<T>();
		}

		// Note: One can also call
		//           SqlConnection.ExecuteReader(command).AsEnumerable<T>()

		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="commandFactory">The command factory.</param>
		/// <returns></returns>
		public static EntityReader<T> ExecuteEntityReader<T>(this SqlConnection me, Action<SqlCommand> commandFactory) where T : new()
		{
			using (SqlCommand command = me.CreateCommand())
			{
				commandFactory(command);

				return command.ExecuteEntityReader<T>();
			}
		}



		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static EntityReader<T> ExecuteEntityReader<T>(this SqlConnection me, string commandText) where T : new()
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandText = commandText;

				return cmd.ExecuteEntityReader<T>();
			}
		}



		/// <summary>
		/// Executes a query, and returns the first column of the first row in the
		/// result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>
		/// The first column of the first row in the result set, or a null reference if
		/// the result set is empty.
		/// </returns>
		public static EntityReader<T> ExecuteEntityReader<T>(this SqlConnection me, string commandText, params SqlParameter[] sqlParameters) where T : new()
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandText = commandText;

				if (sqlParameters != null)
				{
					cmd.Parameters.AddRange(sqlParameters);
				}

				return cmd.ExecuteEntityReader<T>();
			}
		}



		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static EntityReader<T> ExecuteEntityReader<T>(this SqlConnection me, SqlTransaction transaction, string commandText) where T : new()
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.Transaction = transaction;
				cmd.CommandText = commandText;

				return cmd.ExecuteEntityReader<T>();
			}
		}



		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandType">A value that indicates how the <paramref name="commandText"/> is to be interpretaded.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static EntityReader<T> ExecuteEntityReader<T>(this SqlConnection me, CommandType commandType, string commandText) where T : new()
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandType = commandType;
				cmd.CommandText = commandText;

				return cmd.ExecuteEntityReader<T>();
			}
		}



		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandType">A value that indicates how the <paramref name="commandText"/> is to be interpretaded.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static EntityReader<T> ExecuteEntityReader<T>(this SqlConnection me, SqlTransaction transaction, CommandType commandType, string commandText) where T : new()
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.Transaction = transaction;
				cmd.CommandType = commandType;
				cmd.CommandText = commandText;

				return cmd.ExecuteEntityReader<T>();
			}
		}



		/// <summary>
		///     TExecutes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters"></param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static EntityReader<T> ExecuteEntityReader<T>(this SqlConnection me, SqlTransaction transaction, string commandText, params SqlParameter[] sqlParameters) where T : new()
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.Transaction = transaction;
				cmd.CommandText = commandText;

				if (sqlParameters != null)
				{
					cmd.Parameters.AddRange(sqlParameters);
				}

				return cmd.ExecuteEntityReader<T>();
			}
		}



		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandType">A value that indicates how the <paramref name="commandText"/> is to be interpretaded.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters"></param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static EntityReader<T> ExecuteEntityReader<T>(this SqlConnection me, CommandType commandType, string commandText, params SqlParameter[] sqlParameters) where T : new()
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandType = commandType;
				cmd.CommandText = commandText;

				if (sqlParameters != null)
				{
					cmd.Parameters.AddRange(sqlParameters);
				}

				return cmd.ExecuteEntityReader<T>();
			}
		}



		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandType">A value that indicates how the <paramref name="commandText"/> is to be interpretaded.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters"></param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static EntityReader<T> ExecuteEntityReader<T>(this SqlConnection me, SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] sqlParameters) where T : new()
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.Transaction = transaction;
				cmd.CommandType = commandType;
				cmd.CommandText = commandText;

				if (sqlParameters != null)
				{
					cmd.Parameters.AddRange(sqlParameters);
				}

				return cmd.ExecuteEntityReader<T>();
			}
		}

	}

}