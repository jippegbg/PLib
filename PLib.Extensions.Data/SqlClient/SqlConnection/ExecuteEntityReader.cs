using System;
using System.Data;
using System.Data.SqlClient;


namespace PLib.Extensions.Data.SqlClient
{

	public static partial class SqlConnectionExtensions
	{

		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="SqlEntityReader{T}"/>.
		/// </summary>
		/// <typeparam name="T">The type of entities to read.</typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="command">The command to execute.</param>
		/// <returns>An <see cref="SqlEntityReader{T}"/> object.</returns>
		public static SqlEntityReader<T> ExecuteEntityReader<T>(this SqlConnection me, SqlCommand command) where T : new()
		{
			command.Connection = me;

			return command.ExecuteEntityReader<T>();
		}



		/// <summary>
		///     Executes a command prepared by a <paramref name="commandFactory"/> using the current
		///     connection, and builds an <see cref="SqlEntityReader{T}"/>.
		/// </summary>
		/// <typeparam name="T">The type of entities to read.</typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="commandFactory">The command factory.</param>
		/// <returns>An <see cref="SqlEntityReader{T}"/> object.</returns>
		public static SqlEntityReader<T> ExecuteEntityReader<T>(this SqlConnection me, Action<SqlCommand> commandFactory) where T : new()
		{
			using (SqlCommand command = me.CreateCommand())
			{
				commandFactory(command);

				return command.ExecuteEntityReader<T>();
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="SqlEntityReader{T}"/>.
		/// </summary>
		/// <typeparam name="T">The type of entities to read.</typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>An <see cref="SqlEntityReader{T}"/> object.</returns>
		public static SqlEntityReader<T> ExecuteEntityReader<T>(this SqlConnection me, string commandText) where T : new()
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandText = commandText;

				return cmd.ExecuteEntityReader<T>();
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="SqlEntityReader{T}"/>.
		/// </summary>
		/// <typeparam name="T">The type of entities to read.</typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>An <see cref="SqlEntityReader{T}"/> object.</returns>
		public static SqlEntityReader<T> ExecuteEntityReader<T>(this SqlConnection me, string commandText, params SqlParameter[] sqlParameters) where T : new()
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
		///     Executes a command using the current connection and builds an <see cref="SqlEntityReader{T}"/>.
		/// </summary>
		/// <typeparam name="T">The type of entities to read.</typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>An <see cref="SqlEntityReader{T}"/> object.</returns>
		public static SqlEntityReader<T> ExecuteEntityReader<T>(this SqlConnection me, SqlTransaction transaction, string commandText) where T : new()
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.Transaction = transaction;
				cmd.CommandText = commandText;

				return cmd.ExecuteEntityReader<T>();
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="SqlEntityReader{T}"/>.
		/// </summary>
		/// <typeparam name="T">The type of entities to read.</typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <returns>An <see cref="SqlEntityReader{T}"/> object.</returns>
		public static SqlEntityReader<T> ExecuteEntityReader<T>(this SqlConnection me, CommandType commandType, string commandText) where T : new()
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandType = commandType;
				cmd.CommandText = commandText;

				return cmd.ExecuteEntityReader<T>();
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="SqlEntityReader{T}"/>.
		/// </summary>
		/// <typeparam name="T">The type of entities to read.</typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <returns>An <see cref="SqlEntityReader{T}"/> object.</returns>
		public static SqlEntityReader<T> ExecuteEntityReader<T>(this SqlConnection me, SqlTransaction transaction, CommandType commandType, string commandText) where T : new()
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
		///     Executes a command using the current connection and builds an <see cref="SqlEntityReader{T}"/>.
		/// </summary>
		/// <typeparam name="T">The type of entities to read.</typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>An <see cref="SqlEntityReader{T}"/> object.</returns>
		public static SqlEntityReader<T> ExecuteEntityReader<T>(this SqlConnection me, SqlTransaction transaction, string commandText, params SqlParameter[] sqlParameters) where T : new()
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
		///     Executes a command using the current connection and builds an <see cref="SqlEntityReader{T}"/>.
		/// </summary>
		/// <typeparam name="T">The type of entities to read.</typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>An <see cref="SqlEntityReader{T}"/> object.</returns>
		public static SqlEntityReader<T> ExecuteEntityReader<T>(this SqlConnection me, CommandType commandType, string commandText, params SqlParameter[] sqlParameters) where T : new()
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
		///     Executes a command using the current connection and builds an <see cref="SqlEntityReader{T}"/>.
		/// </summary>
		/// <typeparam name="T">The type of entities to read.</typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>An <see cref="SqlEntityReader{T}"/> object.</returns>
		public static SqlEntityReader<T> ExecuteEntityReader<T>(this SqlConnection me, SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] sqlParameters) where T : new()
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
