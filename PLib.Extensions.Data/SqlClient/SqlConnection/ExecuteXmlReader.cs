using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;


namespace PLib.Extensions.Data.SqlClient
{

	public static partial class SqlConnectionExtensions
	{

		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="XmlReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="command">The command to execute.</param>
		/// <returns>An <see cref="XmlReader"/> object.</returns>
		public static XmlReader ExecuteXmlReader(this SqlConnection me, SqlCommand command)
		{
			command.Connection = me;
			return command.ExecuteXmlReader();
		}



		/// <summary>
		///     Executes a command prepared by a <paramref name="commandFactory"/> using the current
		///     connection, and builds an <see cref="XmlReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandFactory">The command factory.</param>
		/// <returns>An <see cref="XmlReader"/> object.</returns>
		public static XmlReader ExecuteXmlReader(this SqlConnection me, Action<SqlCommand> commandFactory)
		{
			using (SqlCommand command = me.CreateCommand())
			{
				commandFactory(command);

				return command.ExecuteXmlReader();
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="XmlReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>An <see cref="XmlReader"/> object.</returns>
		public static XmlReader ExecuteXmlReader(this SqlConnection me, string commandText)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandText = commandText;

				return cmd.ExecuteXmlReader();
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="XmlReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>An <see cref="XmlReader"/> object.</returns>
		public static XmlReader ExecuteXmlReader(this SqlConnection me, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandText = commandText;

				if (sqlParameters != null)
				{
					cmd.Parameters.AddRange(sqlParameters);
				}

				return cmd.ExecuteXmlReader();
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="XmlReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns>An <see cref="XmlReader"/> object.</returns>
		public static XmlReader ExecuteXmlReader(this SqlConnection me, SqlTransaction transaction, string commandText)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.Transaction = transaction;
				cmd.CommandText = commandText;

				return cmd.ExecuteXmlReader();
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="XmlReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <returns>An <see cref="XmlReader"/> object.</returns>
		public static XmlReader ExecuteXmlReader(this SqlConnection me, CommandType commandType, string commandText)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandType = commandType;
				cmd.CommandText = commandText;

				return cmd.ExecuteXmlReader();
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
		/// <param name="commandText">The command text.</param>
		/// <returns>An <see cref="XmlReader"/> object.</returns>
		public static XmlReader ExecuteXmlReader(this SqlConnection me, SqlTransaction transaction, CommandType commandType, string commandText)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.Transaction = transaction;
				cmd.CommandType = commandType;
				cmd.CommandText = commandText;

				return cmd.ExecuteXmlReader();
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="XmlReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>An <see cref="XmlReader"/> object.</returns>
		public static XmlReader ExecuteXmlReader(this SqlConnection me, SqlTransaction transaction, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.Transaction = transaction;
				cmd.CommandText = commandText;

				if (sqlParameters != null)
				{
					cmd.Parameters.AddRange(sqlParameters);
				}

				return cmd.ExecuteXmlReader();
			}
		}



		/// <summary>
		///     Executes a command using the current connection and builds an <see cref="XmlReader"/>.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>An <see cref="XmlReader"/> object.</returns>
		public static XmlReader ExecuteXmlReader(this SqlConnection me, CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
		{
			using (SqlCommand cmd = me.CreateCommand())
			{
				cmd.CommandType = commandType;
				cmd.CommandText = commandText;

				if (sqlParameters != null)
				{
					cmd.Parameters.AddRange(sqlParameters);
				}

				return cmd.ExecuteXmlReader();
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
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters">The SQL parameters.</param>
		/// <returns>An <see cref="XmlReader"/> object.</returns>
		public static XmlReader ExecuteXmlReader(this SqlConnection me, SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
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

				return cmd.ExecuteXmlReader();
			}
		}

	}

}
