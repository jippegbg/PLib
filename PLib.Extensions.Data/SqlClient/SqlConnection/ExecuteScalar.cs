using System.Data.SqlClient;
using System.Threading.Tasks;


namespace PLib.Extensions.Data.SqlClient
{

	public static partial class SqlConnectionExtensions
	{

		public static object ExecuteScalar(this SqlConnection me, string commandText)
		{
			return new SqlCommand(commandText, me).ExecuteScalar();
		}



		public static async Task<object> ExecuteScalarAsync(this SqlConnection me, string commandText)
		{
			return await new SqlCommand(commandText, me).ExecuteScalarAsync();
		}



		public static T ExecuteScalar<T>(this SqlConnection me, string commandText)
		{
			return (T)new SqlCommand(commandText, me).ExecuteScalar();
		}



		public static async Task<T> ExecuteScalarAsync<T>(this SqlConnection me, string commandText)
		{
			return (T)await new SqlCommand(commandText, me).ExecuteScalarAsync();
		}

	}

}
