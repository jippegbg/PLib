using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;


namespace PLib.Extensions.Data.SqlClient
{

	public static partial class SqlConnectionExtensions
	{

		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="XmlReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="command">The command to execute.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<XmlReader> ExecuteXmlReaderAsync(this SqlConnection me, CancellationToken cancellationToken, SqlCommand command)
		{
			command.Connection = me;
			return await command.ExecuteXmlReaderAsync(cancellationToken);
		}



		/// <summary>
		///     Executes a command prepared by a <paramref name="commandFactory"/> using the current
		///     connection, and builds an <see cref="XmlReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="commandFactory">The command factory.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<XmlReader> ExecuteXmlReaderAsync(this SqlConnection me, CancellationToken cancellationToken, Action<SqlCommand> commandFactory)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				commandFactory(cmd);

				return await cmd.ExecuteXmlReaderAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="XmlReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<XmlReader> ExecuteXmlReaderAsync(this SqlConnection me, CancellationToken cancellationToken, string commandText)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandText = commandText;

				return await cmd.ExecuteXmlReaderAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="XmlReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<XmlReader> ExecuteXmlReaderAsync(this SqlConnection me, CancellationToken cancellationToken, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandText = commandText;

				if (sqlParameters != null)
				{
					cmd.Parameters.AddRange(sqlParameters);
				}

				return await cmd.ExecuteXmlReaderAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="XmlReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<XmlReader> ExecuteXmlReaderAsync(this SqlConnection me, SqlTransaction transaction, CancellationToken cancellationToken, string commandText)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.Transaction = transaction;
				cmd.CommandText = commandText;

				return await cmd.ExecuteXmlReaderAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="XmlReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<XmlReader> ExecuteXmlReaderAsync(this SqlConnection me, CommandType commandType, CancellationToken cancellationToken, string commandText)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandType = commandType;
				cmd.CommandText = commandText;

				return await cmd.ExecuteXmlReaderAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="XmlReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<XmlReader> ExecuteXmlReaderAsync(this SqlConnection me, SqlTransaction transaction, CommandType commandType, CancellationToken cancellationToken, string commandText)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.Transaction = transaction;
				cmd.CommandType = commandType;
				cmd.CommandText = commandText;

				return await cmd.ExecuteXmlReaderAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="XmlReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<XmlReader> ExecuteXmlReaderAsync(this SqlConnection me, SqlTransaction transaction, CancellationToken cancellationToken, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.Transaction = transaction;
				cmd.CommandText = commandText;

				if (sqlParameters != null)
				{
					cmd.Parameters.AddRange(sqlParameters);
				}

				return await cmd.ExecuteXmlReaderAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="XmlReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<XmlReader> ExecuteXmlReaderAsync(this SqlConnection me, CommandType commandType, CancellationToken cancellationToken, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandType = commandType;
				cmd.CommandText = commandText;

				if (sqlParameters != null)
				{
					cmd.Parameters.AddRange(sqlParameters);
				}

				return await cmd.ExecuteXmlReaderAsync(cancellationToken);
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="XmlReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static async Task<XmlReader> ExecuteXmlReaderAsync(this SqlConnection me, SqlTransaction transaction, CommandType commandType, CancellationToken cancellationToken, string commandText, params SqlParameter[] sqlParameters)
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

				return await cmd.ExecuteXmlReaderAsync(cancellationToken);
			}
		}

	}

}
