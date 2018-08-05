using System;
using System.Data;
using System.Data.SqlClient;


namespace PLib.Extensions.Data.SqlClient
{

	public static partial class SqlConnectionExtensions
	{

		/// <summary>
		///     Executes a command using the current connection and builds a <see cref="SqlDataReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="command">The command to execute.</param>
		/// <returns>A <see cref="SqlDataReader"/> object.</returns>
		public static SqlDataReader ExecuteReader(this SqlConnection me, SqlCommand command)
		{
			command.Connection = me;

			return command.ExecuteReader();
		}



		/// <summary>
		///     Executes a command prepared by a <paramref name="commandFactory"/> using the current
		///     connection, and builds a <see cref="SqlDataReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandFactory">The command factory.</param>
		/// <returns>A <see cref="SqlDataReader"/> object.</returns>
		public static SqlDataReader ExecuteReader(this SqlConnection me, Action<SqlCommand> commandFactory)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				commandFactory(command);

				return command.ExecuteReader();
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds a <see cref="SqlDataReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>A <see cref="SqlDataReader"/> object.</returns>
		public static SqlDataReader ExecuteReader(this SqlConnection me, string commandText)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.CommandText = commandText;

				return command.ExecuteReader();
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds a <see cref="SqlDataReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>A <see cref="SqlDataReader"/> object.</returns>
		public static SqlDataReader ExecuteReader(this SqlConnection me, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.CommandText = commandText;

				if (sqlParameters != null)
				{
					command.Parameters.AddRange(sqlParameters);
				}

				return command.ExecuteReader();
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds a <see cref="SqlDataReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>A <see cref="SqlDataReader"/> object.</returns>
		public static SqlDataReader ExecuteReader(this SqlConnection me, SqlTransaction transaction, string commandText)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.Transaction = transaction;
				command.CommandText = commandText;

				return command.ExecuteReader();
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds a <see cref="SqlDataReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <returns>A <see cref="SqlDataReader"/> object.</returns>
		public static SqlDataReader ExecuteReader(this SqlConnection me, CommandType commandType, string commandText)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.CommandType = commandType;
				command.CommandText = commandText;

				return command.ExecuteReader();
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds a <see cref="SqlDataReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <returns>A <see cref="SqlDataReader"/> object.</returns>
		public static SqlDataReader ExecuteReader(this SqlConnection me, SqlTransaction transaction, CommandType commandType, string commandText)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.Transaction = transaction;
				command.CommandType = commandType;
				command.CommandText = commandText;

				return command.ExecuteReader();
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds a <see cref="SqlDataReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>A <see cref="SqlDataReader"/> object.</returns>
		public static SqlDataReader ExecuteReader(this SqlConnection me, SqlTransaction transaction, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.Transaction = transaction;
				command.CommandText = commandText;

				if (sqlParameters != null)
				{
					command.Parameters.AddRange(sqlParameters);
				}

				return command.ExecuteReader();
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds a <see cref="SqlDataReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>A <see cref="SqlDataReader"/> object.</returns>
		public static SqlDataReader ExecuteReader(this SqlConnection me, CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				command.CommandType = commandType;
				command.CommandText = commandText;

				if (sqlParameters != null)
				{
					command.Parameters.AddRange(sqlParameters);
				}

				return command.ExecuteReader();
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds a <see cref="SqlDataReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>A <see cref="SqlDataReader"/> object.</returns>
		public static SqlDataReader ExecuteReader(this SqlConnection me, SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
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

				return command.ExecuteReader();
			}
		}

	}

}
