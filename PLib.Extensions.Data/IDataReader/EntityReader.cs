using System;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;


namespace PLib.Extensions.Data
{

	/// <summary>
	///     TODO Edit XML Comment
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class EntityReader<T> where T : new()
	{

		/// <summary>
		///     The encapsulated reader to get sequential data from.
		/// </summary>
		private readonly SqlDataReader m_reader;

		/// <summary>
		///     The properties of type T, that have corresponding column names in m_reader.
		///     I.e. properties that can be populated from a record in m_reader.
		/// </summary>
		private readonly PropertyInfo[] m_mappedProperties;

		/// <summary>
		///     The fields of type T, that have corresponding column names in m_reader.
		///     I.e. fields that can be populated from a record in m_reader.
		/// </summary>
		private readonly FieldInfo[] m_mappedFields;



		/// <summary>
		///     TODO Edit XML Comment
		/// </summary>
		/// <value><c>true</c> if this instance has rows; otherwise, <c>false</c>.</value>
		public bool HasRows => m_reader.HasRows;



		/// <summary>
		///     TODO Edit XML Comment
		/// </summary>
		/// <value><c>true</c> if this instance is closed; otherwise, <c>false</c>.</value>
		public bool IsClosed => m_reader.IsClosed;



		/// <summary>
		///     TODO Edit XML Comment
		/// </summary>
		/// <value>The field count.</value>
		public int FieldCount => m_reader.FieldCount;



		/// <summary>
		///     TODO Edit XML Comment
		/// </summary>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException"></exception>
		public T GetEntity()
		{
			if (!m_reader.HasRows)
			{
				throw new InvalidOperationException($"The EntityReader<{typeof(T).Name}> has no rows.");
			}

			return m_reader.GetEntity<T>(m_mappedProperties, m_mappedFields);
		}



		/// <summary>
		///     TODO Edit XML Comment
		///     Initializes a new instance of the <see cref="EntityReader{T}"/> class.
		/// </summary>
		/// <param name="reader">The reader.</param>
		internal EntityReader(SqlDataReader reader)
		{
			m_reader = reader;
			if (m_reader.HasRows)
			{
				m_mappedProperties = m_reader.GetMappingProperties<T>();
				m_mappedFields     = m_reader.GetMappingFields<T>();
			}
		}



		/// <summary>
		///     TODO Edit XML Comment
		/// </summary>
		/// <returns></returns>
		public bool Read()
		{
			return m_reader.Read();
		}



		/// <summary>
		///     TODO Edit XML Comment
		/// </summary>
		/// <returns></returns>
		public async Task<bool> ReadAsync()
		{
			return await m_reader.ReadAsync();
		}



		/// <summary>
		///     TODO Edit XML Comment
		/// </summary>
		/// <param name="cancellationToker">The cancellation toker.</param>
		/// <returns></returns>
		public async Task<bool> ReadAsync(CancellationToken cancellationToker)
		{
			return await m_reader.ReadAsync(cancellationToker);
		}

	}

}
