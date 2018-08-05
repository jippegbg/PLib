using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace PLib.Extensions.Data.SqlClient
{

	public static partial class SqlConnectionExtensions
	{

		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="command">The command to execute.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<int> ExecuteNonQueryAsync(this SqlConnection me, SqlCommand command)
		{
			command.Connection = me;

			return await command.ExecuteNonQueryAsync();
		}



		/// <summary>
		///     Executes a command prepared by a <paramref name="commandFactory"/> using the current
		///     connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandFactory">An action that prepares a command for execution.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<int> ExecuteNonQueryAsync(this SqlConnection me, Action<SqlCommand> commandFactory)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				commandFactory(command);

				return await command.ExecuteNonQueryAsync();
			}
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<int> ExecuteNonQueryAsync(this SqlConnection me, string commandText)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.CommandText = commandText;

				return await command.ExecuteNonQueryAsync();
			}
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<int> ExecuteNonQueryAsync(this SqlConnection me, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.CommandText = commandText;

				if (sqlParameters != null)
				{
					command.Parameters.AddRange(sqlParameters);
				}

				return await command.ExecuteNonQueryAsync();
			}
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<int> ExecuteNonQueryAsync(this SqlConnection me, SqlTransaction transaction, string commandText)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.Transaction = transaction;
				command.CommandText = commandText;

				return await command.ExecuteNonQueryAsync();
			}
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<int> ExecuteNonQueryAsync(this SqlConnection me, CommandType commandType, string commandText)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.CommandType = commandType;
				command.CommandText = commandText;

				return await command.ExecuteNonQueryAsync();
			}
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<int> ExecuteNonQueryAsync(this SqlConnection me, SqlTransaction transaction, CommandType commandType, string commandText)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.Transaction = transaction;
				command.CommandType = commandType;
				command.CommandText = commandText;

				return await command.ExecuteNonQueryAsync();
			}
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<int> ExecuteNonQueryAsync(this SqlConnection me, SqlTransaction transaction, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.Transaction = transaction;
				command.CommandText = commandText;

				if (sqlParameters != null)
				{
					command.Parameters.AddRange(sqlParameters);
				}

				return await command.ExecuteNonQueryAsync();
			}
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<int> ExecuteNonQueryAsync(this SqlConnection me, CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.CommandType = commandType;
				command.CommandText = commandText;

				if (sqlParameters != null)
				{
					command.Parameters.AddRange(sqlParameters);
				}

				return await command.ExecuteNonQueryAsync();
			}
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<int> ExecuteNonQueryAsync(this SqlConnection me, SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.Transaction = transaction;
				command.CommandType = commandType;
				command.CommandText = commandText;

				if (sqlParameters != null)
				{
					command.Parameters.AddRange(sqlParameters);
				}

				return await command.ExecuteNonQueryAsync();
			}
		}

	}

}
