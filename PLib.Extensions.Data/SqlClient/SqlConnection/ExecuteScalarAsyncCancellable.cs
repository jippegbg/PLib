using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;


namespace PLib.Extensions.Data.SqlClient
{

	public static partial class SqlConnectionExtensions
	{

		#region [ Using Command Text, Returning object ]

		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<object> ExecuteScalarAsync(this SqlConnection me, string commandText, CancellationToken cancellationToken)
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
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<object> ExecuteScalarAsync(this SqlConnection me, SqlTransaction transaction, string commandText, CancellationToken cancellationToken)
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
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<object> ExecuteScalarAsync(this SqlConnection me, CommandType commandType, string commandText, CancellationToken cancellationToken)
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
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<object> ExecuteScalarAsync(this SqlConnection me, SqlTransaction transaction, CommandType commandType, string commandText, CancellationToken cancellationToken)
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
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters"></param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<object> ExecuteScalarAsync(this SqlConnection me, SqlTransaction transaction, string commandText, SqlParameter[] sqlParameters, CancellationToken cancellationToken)
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
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters"></param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<object> ExecuteScalarAsync(this SqlConnection me, CommandType commandType, string commandText, SqlParameter[] sqlParameters, CancellationToken cancellationToken)
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
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters"></param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<object> ExecuteScalarAsync(this SqlConnection me, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] sqlParameters, CancellationToken cancellationToken)
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

		#endregion [ Using Command Text, Returning object ]



		#region [ Using Command Text, Returning T ]

		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <typeparam name="T">The type of the return value.</typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<T> ExecuteScalarAsyncAs<T>(this SqlConnection me, string commandText, CancellationToken cancellationToken)
		{
			return (T)await me.ExecuteScalarAsync(commandText, cancellationToken);
		}



		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <typeparam name="T">The type of the return value.</typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<T> ExecuteScalarAsyncAs<T>(this SqlConnection me, SqlTransaction transaction, string commandText, CancellationToken cancellationToken)
		{
			return (T)await me.ExecuteScalarAsync(transaction, commandText, cancellationToken);
		}



		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <typeparam name="T">The type of the return value.</typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<T> ExecuteScalarAsyncAs<T>(this SqlConnection me, CommandType commandType, string commandText, CancellationToken cancellationToken)
		{
			return (T)await me.ExecuteScalarAsync(commandType, commandText, cancellationToken);
		}



		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <typeparam name="T">The type of the return value.</typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<T> ExecuteScalarAsyncAs<T>(this SqlConnection me, SqlTransaction transaction, CommandType commandType, string commandText, CancellationToken cancellationToken)
		{
			return (T)await me.ExecuteScalarAsync(transaction, commandType, commandText, cancellationToken);
		}



		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <typeparam name="T">The type of the return value.</typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters"></param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<T> ExecuteScalarAsyncAs<T>(this SqlConnection me, SqlTransaction transaction, string commandText, SqlParameter[] sqlParameters, CancellationToken cancellationToken)
		{
			return (T)await me.ExecuteScalarAsync(transaction, commandText, sqlParameters, cancellationToken);
		}



		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <typeparam name="T">The type of the return value.</typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters"></param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<T> ExecuteScalarAsyncAs<T>(this SqlConnection me, CommandType commandType, string commandText, SqlParameter[] sqlParameters, CancellationToken cancellationToken)
		{
			return (T)await me.ExecuteScalarAsync(commandType, commandText, sqlParameters, cancellationToken);
		}



		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <typeparam name="T">The type of the return value.</typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="transaction">The transaction within which the command executes.</param>
		/// <param name="commandType">
		///     A value that indicates how the <paramref name="commandText"/> is to be interpretaded.
		/// </param>
		/// <param name="commandText">The command text.</param>
		/// <param name="sqlParameters"></param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<T> ExecuteScalarAsyncAs<T>(this SqlConnection me, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] sqlParameters, CancellationToken cancellationToken)
		{
			return (T)await me.ExecuteScalarAsync(transaction, commandType, commandText, sqlParameters, cancellationToken);
		}

		#endregion [ Using Command Text, Returning T ]



		#region [ Using SqlCommand ]

		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <param name="me">The current connection.</param>
		/// <param name="command">The command to execute.</param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<object> ExecuteScalarAsync(this SqlConnection me, SqlCommand command, CancellationToken cancellationToken)
		{
			command.Connection = me;
			return await command.ExecuteScalarAsync(cancellationToken);
		}



		/// <summary>
		///     Executes a query, and returns the first column of the first row in the
		///     result set returned by the query. Additional columns or rows are ignored.
		/// </summary>
		/// <typeparam name="T">The type of the return value.</typeparam>
		/// <param name="me">The current connection.</param>
		/// <param name="command">The command to execute.</param>
		/// <param name="cancellationToken">
		///     A cancellation token can be used to request that the operation should be
		///     abandoned before the command timeout elapses.
		/// </param>
		/// <returns>
		///     The first column of the first row in the result set, or a null reference if
		///     the result set is empty.
		/// </returns>
		public static async Task<T> ExecuteScalarAsyncAs<T>(this SqlConnection me, SqlCommand command, CancellationToken cancellationToken)
		{
			return (T)await me.ExecuteScalarAsync(command, cancellationToken);
		}

		#endregion [ Using SqlCommand ]

	}

}
