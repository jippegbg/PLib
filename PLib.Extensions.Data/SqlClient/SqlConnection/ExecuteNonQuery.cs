using System;
using System.Data;
using System.Data.SqlClient;


namespace PLib.Extensions.Data.SqlClient
{

	public static partial class SqlConnectionExtensions
	{

		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="command">The command to execute.</param>
		/// <returns>The number of rows affected.</returns>
		public static int ExecuteNonQuery(this SqlConnection me, SqlCommand command)
		{
			command.Connection = me;

			return command.ExecuteNonQuery();
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandFactory">The command factory.</param>
		/// <returns>The number of rows affected.</returns>
		public static int ExecuteNonQuery(this SqlConnection me, Action<SqlCommand> commandFactory)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				commandFactory(command);

				return command.ExecuteNonQuery();
			}
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>The number of rows affected.</returns>
		public static int ExecuteNonQuery(this SqlConnection me, string commandText)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandText = commandText;

				return cmd.ExecuteNonQuery();
			}
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>The number of rows affected.</returns>
		public static int ExecuteNonQuery(this SqlConnection me, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandText = commandText;

				if (sqlParameters != null)
				{
					cmd.Parameters.AddRange(sqlParameters);
				}

				return cmd.ExecuteNonQuery();
			}
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>The number of rows affected.</returns>
		public static int ExecuteNonQuery(this SqlConnection me, SqlTransaction transaction, string commandText)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.Transaction = transaction;
				cmd.CommandText = commandText;

				return cmd.ExecuteNonQuery();
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
		/// <returns>The number of rows affected.</returns>
		public static int ExecuteNonQuery(this SqlConnection me, CommandType commandType, string commandText)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandType = commandType;
				cmd.CommandText = commandText;

				return cmd.ExecuteNonQuery();
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
		/// <returns>The number of rows affected.</returns>
		public static int ExecuteNonQuery(this SqlConnection me, SqlTransaction transaction, CommandType commandType, string commandText)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.Transaction = transaction;
				cmd.CommandType = commandType;
				cmd.CommandText = commandText;

				return cmd.ExecuteNonQuery();
			}
		}



		/// <summary>
		///     Executes a command using the current connection, and returns the number of rows affected.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>The number of rows affected.</returns>
		public static int ExecuteNonQuery(this SqlConnection me, SqlTransaction transaction, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.Transaction = transaction;
				cmd.CommandText = commandText;

				if (sqlParameters != null)
				{
					cmd.Parameters.AddRange(sqlParameters);
				}

				return cmd.ExecuteNonQuery();
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
		/// <returns>The number of rows affected.</returns>
		public static int ExecuteNonQuery(this SqlConnection me, CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandType = commandType;
				cmd.CommandText = commandText;

				if (sqlParameters != null)
				{
					cmd.Parameters.AddRange(sqlParameters);
				}

				return cmd.ExecuteNonQuery();
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
		/// <returns>The number of rows affected.</returns>
		public static int ExecuteNonQuery(this SqlConnection me, SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
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

				return cmd.ExecuteNonQuery();
			}
		}

	}

}
