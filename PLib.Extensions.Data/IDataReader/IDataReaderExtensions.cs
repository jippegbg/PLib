using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;


namespace PLib.Extensions.Data
{

	/// <summary>
	/// TODO: Edit XML Comments
	/// </summary>
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public static partial class IDataReaderExtensions
	{

		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current data reader.</param>
		/// <param name="columnIndex"></param>
		/// <returns></returns>
		public static IEnumerable<T> AsEnumerable<T>(this IDataReader me, int columnIndex)
		{
			while (me.Read())
			{
				yield return me.GetValue<T>(columnIndex);
			}
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">The current data reader.</param>
		/// <param name="columnName"></param>
		/// <returns></returns>
		public static IEnumerable<T> AsEnumerable<T>(this IDataReader me, string columnName)
		{
			while (me.Read())
			{
				yield return me.GetValue<T>(columnName);
			}
		}



		/// <summary>
		///     Gets an iterator iterator of entity objects.
		/// </summary>
		/// <typeparam name="T">The type of the entity objects.</typeparam>
		/// <param name="me">The current data reader.</param>
		/// <returns>
		///     A sequence of entity object of type <typeparamref name="T"/> that are
		///     populated with data from the current data reader, one entity object for
		///     each record.
		/// </returns>
		/// <remarks>
		///     <para>The reader must stay opened while the iterator is used.</para>
		///     <para>
		///         By materializing this enumeration (e.g. ToList() etc.) one can then
		///         close the data reader and the underlying database connection, and keep
		///         working with the data disconnected from the database.
		///     </para>
		/// </remarks>
		public static IEnumerable<T> AsEnumerable<T>(this IDataReader me) where T : new()
		{
			PropertyInfo[] properties = me.GetMappingProperties<T>();
			FieldInfo[]    fields     = me.GetMappingFields<T>();

			while (me.Read())
			{
				yield return me.GetEntity<T>(properties, fields);
			}
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <param name="me">The current data reader.</param>
		/// <param name="action"></param>
		/// <returns></returns>
		public static IDataReader ForEach(this IDataReader me, Action<IDataReader> action)
		{
			while (me.Read())
			{
				action(me);
			}

			return me;
		}



		/// <summary>
		/// Gets the column value at the current data record of the current data reader, converted to a specified type.
		/// </summary>
		/// <typeparam name="T">The type of the return value.</typeparam>
		/// <param name="me">The current data reader.</param>
		/// <param name="columnIndex"></param>
		/// <returns></returns>
		public static T GetValue<T>(this IDataReader me, int columnIndex)
		{
			return (T)me.GetValue(columnIndex);
		}



		/// <summary>
		/// Gets the column value at the current data record of the current data reader, converted to a specified type.
		/// </summary>
		/// <typeparam name="T">The type of the return value.</typeparam>
		/// <param name="me">The current data reader.</param>
		/// <param name="columnName"></param>
		/// <returns></returns>
		public static T GetValue<T>(this IDataReader me, string columnName)
		{
			return (T)me.GetValue(me.GetOrdinal(columnName));
		}



		/// <summary>
		///     Gets multiple data from the current data record of the current data reader,
		///     converted to a specified entity type.
		/// </summary>
		/// <typeparam name="T">The type of the returned entity object.</typeparam>
		/// <param name="me">The current data reader.</param>
		/// <returns>
		///     A new entity object of type <typeparamref name="T"/> that is populated with
		///     data from the current record position of the current data reader.
		/// </returns>
		public static T GetEntity<T>(this IDataReader me) where T : new()
		{
			PropertyInfo[] properties = me.GetMappingProperties<T>();
			FieldInfo[]    fields     = me.GetMappingFields<T>();

			return me.GetEntity<T>(properties, fields);
		}



		public static T GetEntity<T>(this IDataReader me, PropertyInfo[] properties, FieldInfo[] fields) where T : new()
		{
			T entity = new T();
			me.SetValuesTo(entity, properties, fields);
			return entity;
		}



		/// <summary>
		/// TODO: Edit XML Comment
		/// </summary>
		/// <param name="me">The current data reader.</param>
		/// <returns></returns>
		public static DataTable ToDataTable(this IDataReader me)
		{
			DataTable dt = new DataTable();
			dt.Load(me);
			return dt;
		}



		internal static PropertyInfo[] GetMappingProperties<T>(this IDataReader me)
		{
			return me.GetMappingProperties(typeof(T));
		}



		internal static PropertyInfo[] GetMappingProperties(this IDataReader me, Type mappingType)
		{
			return mappingType
				.GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(p => Enumerable.Range(0, me.FieldCount).Select(me.GetName).Contains(p.Name))
				.ToArray();
		}



		internal static FieldInfo[] GetMappingFields<T>(this IDataReader me)
		{
			return me.GetMappingFields(typeof(T));
		}



		internal static FieldInfo[] GetMappingFields(this IDataReader me, Type mappingType)
		{
			return mappingType
				.GetFields(BindingFlags.Public | BindingFlags.Instance)
				.Where(p => Enumerable.Range(0, me.FieldCount).Select(me.GetName).Contains(p.Name))
				.ToArray();
		}



		internal static void SetValuesTo<T>(this IDataReader me, T targetObject, PropertyInfo[] properties, FieldInfo[] fields)
		{
			for (int i = 0; i < properties.Length; i++)
			{
				properties[i].SetValue(targetObject, me[properties[i].Name]);
			}

			for (int i = 0; i < fields.Length; i++)
			{
				fields[i].SetValue(targetObject, me[fields[i].Name]);
			}
		}



		internal static void GetValuesFrom<T>(this T me, IDataReader reader, PropertyInfo[] properties, FieldInfo[] fields)
		{
			reader.SetValuesTo(me, properties, fields);
		}



		/*internal static void GetTypeInfo(Type type, IEnumerable<string> readerColumns, out PropertyInfo[] properties, out FieldInfo[] fields)
		{
			properties = type
				.GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(p => readerColumns.Contains(p.Name))
				.ToArray();

			fields = type
				.GetFields(BindingFlags.Public | BindingFlags.Instance)
				.Where(f => readerColumns.Contains(f.Name))
				.ToArray();
		}



		internal static void SetEntityValues<T>(T entity, PropertyInfo[] properties, FieldInfo[] fields, IDataReader reader)
		{
			for (int i = 0; i < properties.Length; i++)
			{
				properties[i].SetValue(entity, reader[properties[i].Name]);
			}

			for (int i = 0; i < fields.Length; i++)
			{
				fields[i].SetValue(entity, reader[fields[i].Name]);
			}
		}*/

	}

}
