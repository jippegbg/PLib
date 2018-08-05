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
		///     Executes a command using the current connection, and returns the first record
		///     converted to an entity object of type <typeparam name="T"/> of the first row in the
		///     result set returned by the query.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="command">The command to execute.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<T> ExecuteEntityAsync<T>(this SqlConnection me, CancellationToken cancellationToken, SqlCommand command) where T : new()
		{
			return (await me.ExecuteReaderAsync(cancellationToken, command)).GetEntity<T>();
		}



		/// <summary>
		///     Executes a command prepared by a <paramref name="commandFactory"/> using the current
		///     connection, and returns the first record converted to an entity object of type
		///     <typeparam name="T"/> of the first row in the result set returned by the query.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="commandFactory">The command factory.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<T> ExecuteEntityAsync<T>(this SqlConnection me, CancellationToken cancellationToken, Action<SqlCommand> commandFactory) where T : new()
		{
			return (await me.ExecuteReaderAsync(cancellationToken, commandFactory)).GetEntity<T>();
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the first record
		///     converted to an entity object of type <typeparam name="T"/> of the first row in the
		///     result set returned by the query.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<T> ExecuteEntityAsync<T>(this SqlConnection me, CancellationToken cancellationToken, string commandText) where T : new()
		{
			return (await me.ExecuteReaderAsync(cancellationToken, commandText)).GetEntity<T>();
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the first record
		///     converted to an entity object of type <typeparam name="T"/> of the first row in the
		///     result set returned by the query.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<T> ExecuteEntityAsync<T>(this SqlConnection me, CancellationToken cancellationToken, string commandText, params SqlParameter[] sqlParameters) where T : new()
		{
			return (await me.ExecuteReaderAsync(cancellationToken, commandText, sqlParameters)).GetEntity<T>();
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the first record
		///     converted to an entity object of type <typeparam name="T"/> of the first row in the
		///     result set returned by the query.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<T> ExecuteEntityAsync<T>(this SqlConnection me, CancellationToken cancellationToken, SqlTransaction transaction, string commandText) where T : new()
		{
			return (await me.ExecuteReaderAsync(transaction, cancellationToken, commandText)).GetEntity<T>();
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the first record
		///     converted to an entity object of type <typeparam name="T"/> of the first row in the
		///     result set returned by the query.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<T> ExecuteEntityAsync<T>(this SqlConnection me, CancellationToken cancellationToken, CommandType commandType, string commandText) where T : new()
		{
			return (await me.ExecuteReaderAsync(commandType, cancellationToken, commandText)).GetEntity<T>();
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the first record
		///     converted to an entity object of type <typeparam name="T"/> of the first row in the
		///     result set returned by the query.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<T> ExecuteEntityAsync<T>(this SqlConnection me, CancellationToken cancellationToken, SqlTransaction transaction, CommandType commandType, string commandText) where T : new()
		{
			return (await me.ExecuteReaderAsync(transaction, commandType, cancellationToken, commandText)).GetEntity<T>();
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the first record
		///     converted to an entity object of type <typeparam name="T"/> of the first row in the
		///     result set returned by the query.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<T> ExecuteEntityAsync<T>(this SqlConnection me, CancellationToken cancellationToken, SqlTransaction transaction, string commandText, params SqlParameter[] sqlParameters) where T : new()
		{
			return (await me.ExecuteReaderAsync(transaction, cancellationToken, commandText, sqlParameters)).GetEntity<T>();
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the first record
		///     converted to an entity object of type <typeparam name="T"/> of the first row in the
		///     result set returned by the query.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<T> ExecuteEntityAsync<T>(this SqlConnection me, CancellationToken cancellationToken, CommandType commandType, string commandText, params SqlParameter[] sqlParameters) where T : new()
		{
			return (await me.ExecuteReaderAsync(commandType, cancellationToken, commandText, sqlParameters)).GetEntity<T>();
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the first record
		///     converted to an entity object of type <typeparam name="T"/> of the first row in the
		///     result set returned by the query.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<T> ExecuteEntityAsync<T>(this SqlConnection me, CancellationToken cancellationToken, SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] sqlParameters) where T : new()
		{
			return (await me.ExecuteReaderAsync(transaction, commandType, cancellationToken, commandText, sqlParameters)).GetEntity<T>();
		}

	}

}
