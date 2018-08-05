using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;


namespace PLib.Extensions.Data
{

	/// <summary>
	///     Provides a way of reading a forward-only stream of entity objects from a SQL Server database.
	/// </summary>
	/// <typeparam name="T">The type of the entity to read.</typeparam>
	/// <remarks>
	///     <para>
	///         The entities are mapped against the database result rows on a name basis. This means
	///         that the entity should have the same name on its public properties or fields as the
	///         name of the columns in the database result set.
	///     </para>
	///     <para>
	///         The reason for this specialized reader is to improve performance. If using a regular
	///         <see cref="SqlDataReader"/> one could call
	///         <see cref="IDataReaderExtensions.GetEntity{T}(IDataReader)"/>, which would look up
	///         the same property and field mappings for each record. By using this
	///         <c>SqlEntityReader</c>, looking up mapping will only happen once at initialization,
	///         which will speed up reading out values into multiple entity objects.
	///     </para>
	/// </remarks>
	public class SqlEntityReader<T> where T : new()
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
		///     Gets a value that indicates whether this <see cref="SqlEntityReader{T}"/> contains one or more rows.
		/// </summary>
		public bool HasRows => m_reader.HasRows;



		/// <summary>
		///     Gets a value that indicates whether this <see cref="SqlEntityReader{T}"/> has been closed.
		/// </summary>
		public bool IsClosed => m_reader.IsClosed;



		/// <summary>
		///     Gets the number of columns in the current row.
		/// </summary>
		public int FieldCount => m_reader.FieldCount;



		/// <summary>
		///     Initializes a new instance of the <see cref="SqlEntityReader{T}"/> class.
		/// </summary>
		/// <param name="reader">
		///     An <see cref="SqlDataReader"/> that provides data to this new <see cref="SqlEntityReader{T}"/>.
		/// </param>
		internal SqlEntityReader(SqlDataReader reader)
		{
			m_reader = reader;

			if (m_reader.HasRows)
			{
				m_mappedProperties = m_reader.GetMappingProperties<T>();
				m_mappedFields     = m_reader.GetMappingFields<T>();
			}
		}



		/// <summary>
		///     Gets an object of type <typeparamref name="T"/> that is constructed from
		///     the current record in this <see cref="SqlEntityReader{T}"/>.
		/// </summary>
		/// <returns>A new object of type <typeparamref name="T"/>.</returns>
		/// <exception cref="InvalidOperationException">
		///     if this <see cref="SqlEntityReader{T}"/> has no rows, and hence no current row.
		/// </exception>
		public T GetEntity()
		{
			if (!m_reader.HasRows)
			{
				throw new InvalidOperationException($"The EntityReader<{typeof(T).Name}> has no rows.");
			}

			return m_reader.GetEntity<T>(m_mappedProperties, m_mappedFields);
		}



		/// <summary>
		///     Advances this <see cref="SqlEntityReader{T}"/> to the next record.
		/// </summary>
		/// <returns><c>true</c> if there are more rows; otherwise <c>false</c>.</returns>
		public bool Read()
		{
			return m_reader.Read();
		}



		/// <summary>
		///     An asynchronous version of <see cref="Read"/>, which advances the reader to
		///     the next record in a result set. This method invokes
		///     <see cref="ReadAsync(CancellationToken)"/> with <see cref="CancellationToken.None"/>.
		/// </summary>
		/// <returns>A task representing the asynchronous operation.</returns>
		/// <remarks>
		///     Do not invoke other methods and properties of this
		///     <see cref="SqlEntityReader{T}"/> object until the returned
		///     <see cref="Task{TResult}"/> is complete.
		/// </remarks>
		public async Task<bool> ReadAsync()
		{
			return await m_reader.ReadAsync();
		}



		/// <summary>
		///     An asynchronous version of <see cref="Read"/>, which advances the reader to
		///     the next record in a result set.
		/// </summary>
		/// <param name="cancellationToken">The cancellation toker.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		/// <remarks>
		///     Do not invoke other methods and properties of this
		///     <see cref="SqlEntityReader{T}"/> object until the returned
		///     <see cref="Task{TResult}"/> is complete.
		/// </remarks>
		public async Task<bool> ReadAsync(CancellationToken cancellationToken)
		{
			return await m_reader.ReadAsync(cancellationToken);
		}

	}

}
