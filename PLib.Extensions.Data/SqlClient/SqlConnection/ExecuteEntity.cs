using System;
using System.Data;
using System.Data.SqlClient;

using PLib.Extensions.System;

namespace PLib.Extensions.Data.SqlClient {

	public static partial class SqlConnectionExtensions
	{

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
		public static T ExecuteEntity<T>(this SqlConnection me, SqlCommand command)
		{
			return me.ExecuteScalar(command).ConvertTo<T>();
		}



		/// <summary>
		/// TODO: Edit XML Cooment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">Me.</param>
		/// <param name="commandFactory">The command factory.</param>
		/// <returns></returns>
		public static T ExecuteEntity<T>(this SqlConnection me, Action<SqlCommand> commandFactory)
		{
			return me.ExecuteScalar(commandFactory).ConvertTo<T>();
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
		public static T ExecuteEntity<T>(this SqlConnection me, string commandText)
		{
			return me.ExecuteScalar(commandText).ConvertTo<T>();
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
		public static T ExecuteEntity<T>(this SqlConnection me, string commandText, params SqlParameter[] sqlParameters)
		{
			return me.ExecuteScalar(commandText, sqlParameters).ConvertTo<T>();
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
		public static T ExecuteEntity<T>(this SqlConnection me, SqlTransaction transaction, string commandText)
		{
			return me.ExecuteScalar(transaction, commandText).ConvertTo<T>();
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
		public static T ExecuteEntity<T>(this SqlConnection me, CommandType commandType, string commandText)
		{
			return me.ExecuteScalar(commandType, commandText).ConvertTo<T>();
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
		public static T ExecuteEntity<T>(this SqlConnection me, SqlTransaction transaction, CommandType commandType, string commandText)
		{
			return me.ExecuteScalar(transaction, commandType, commandText).ConvertTo<T>();
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
		public static T ExecuteEntity<T>(this SqlConnection me, SqlTransaction transaction, string commandText, params SqlParameter[] sqlParameters)
		{
			return me.ExecuteScalar(transaction, commandText, sqlParameters).ConvertTo<T>();
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
		public static T ExecuteEntity<T>(this SqlConnection me, CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
		{
			return me.ExecuteScalar(commandType, commandText, sqlParameters).ConvertTo<T>();
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
		public static T ExecuteEntity<T>(this SqlConnection me, SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
		{
			return me.ExecuteScalar(transaction, commandType, commandText, sqlParameters).ConvertTo<T>();
		}


	}

}