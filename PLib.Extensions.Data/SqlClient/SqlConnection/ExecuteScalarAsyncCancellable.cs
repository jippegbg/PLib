using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;


namespace PLib.Extensions.Data.SqlClient
{

	public static partial class SqlConnectionExtensions
	{

		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <param name="command">The command to execute.</param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<object> ExecuteScalarAsync(this SqlConnection me, CancellationToken cancellationToken, SqlCommand command)
		{
			command.Connection = me;
			return await command.ExecuteScalarAsync(cancellationToken);
		}



		/// <summary>
		///     Executes the scalar asynchronous.
		/// </summary>
		/// <param name="me">Me.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="commandFactory">The command factory.</param>
		/// <returns></returns>
		public static async Task<object> ExecuteScalarAsync(this SqlConnection me, CancellationToken cancellationToken, Action<SqlCommand> commandFactory)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				commandFactory(command);

				return await command.ExecuteScalarAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<object> ExecuteScalarAsync(this SqlConnection me, CancellationToken cancellationToken, string commandText)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandText = commandText;

				return await cmd.ExecuteScalarAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<object> ExecuteScalarAsync(this SqlConnection me, CancellationToken cancellationToken, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandText = commandText;

				if (sqlParameters != null)
				{
					cmd.Parameters.AddRange(sqlParameters);
				}

				return await cmd.ExecuteScalarAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<object> ExecuteScalarAsync(this SqlConnection me, CancellationToken cancellationToken, SqlTransaction transaction, string commandText)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.Transaction = transaction;
				cmd.CommandText = commandText;

				return await cmd.ExecuteScalarAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<object> ExecuteScalarAsync(this SqlConnection me, CancellationToken cancellationToken, CommandType commandType, string commandText)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandType = commandType;
				cmd.CommandText = commandText;

				return await cmd.ExecuteScalarAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<object> ExecuteScalarAsync(this SqlConnection me, CancellationToken cancellationToken, SqlTransaction transaction, CommandType commandType, string commandText)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.Transaction = transaction;
				cmd.CommandType = commandType;
				cmd.CommandText = commandText;

				return await cmd.ExecuteScalarAsync(cancellationToken);
			}
		}



		/// <summary>
		///     TExecutes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<object> ExecuteScalarAsync(this SqlConnection me, CancellationToken cancellationToken, SqlTransaction transaction, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.Transaction = transaction;
				cmd.CommandText = commandText;

				if (sqlParameters != null)
				{
					cmd.Parameters.AddRange(sqlParameters);
				}

				return await cmd.ExecuteScalarAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<object> ExecuteScalarAsync(this SqlConnection me, CancellationToken cancellationToken, CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandType = commandType;
				cmd.CommandText = commandText;

				if (sqlParameters != null)
				{
					cmd.Parameters.AddRange(sqlParameters);
				}

				return await cmd.ExecuteScalarAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<object> ExecuteScalarAsync(this SqlConnection me, CancellationToken cancellationToken, SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
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

				return await cmd.ExecuteScalarAsync(cancellationToken);
			}
		}

	}

}
