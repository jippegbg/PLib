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
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="command">The command to execute.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task ExecuteNonQueryAsync(this SqlConnection me, CancellationToken cancellationToken, SqlCommand command)
		{
			command.Connection = me;
			await command.ExecuteNonQueryAsync(cancellationToken);
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="commandFactory">The command factory.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task ExecuteNonQueryAsync(this SqlConnection me, CancellationToken cancellationToken, Action<SqlCommand> commandFactory)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				commandFactory(command);

				await command.ExecuteNonQueryAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task ExecuteNonQueryAsync(this SqlConnection me, CancellationToken cancellationToken, string commandText)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.CommandText = commandText;

				await command.ExecuteNonQueryAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task ExecuteNonQueryAsync(this SqlConnection me, CancellationToken cancellationToken, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.CommandText = commandText;

				if (sqlParameters != null)
				{
					command.Parameters.AddRange(sqlParameters);
				}

				await command.ExecuteNonQueryAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task ExecuteNonQueryAsync(this SqlConnection me, CancellationToken cancellationToken, SqlTransaction transaction, string commandText)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.Transaction = transaction;
				command.CommandText = commandText;

				await command.ExecuteNonQueryAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task ExecuteNonQueryAsync(this SqlConnection me, CancellationToken cancellationToken, CommandType commandType, string commandText)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.CommandType = commandType;
				command.CommandText = commandText;

				await command.ExecuteNonQueryAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task ExecuteNonQueryAsync(this SqlConnection me, CancellationToken cancellationToken, SqlTransaction transaction, CommandType commandType, string commandText)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.Transaction = transaction;
				command.CommandType = commandType;
				command.CommandText = commandText;

				await command.ExecuteNonQueryAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task ExecuteNonQueryAsync(this SqlConnection me, CancellationToken cancellationToken, SqlTransaction transaction, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.Transaction = transaction;
				command.CommandText = commandText;

				if (sqlParameters != null)
				{
					command.Parameters.AddRange(sqlParameters);
				}

				await command.ExecuteNonQueryAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task ExecuteNonQueryAsync(this SqlConnection me, CancellationToken cancellationToken, CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.CommandType = commandType;
				command.CommandText = commandText;

				if (sqlParameters != null)
				{
					command.Parameters.AddRange(sqlParameters);
				}

				await command.ExecuteNonQueryAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task ExecuteNonQueryAsync(this SqlConnection me, CancellationToken cancellationToken, SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
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

				await command.ExecuteNonQueryAsync(cancellationToken);
			}
		}

	}

}
