using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;


namespace PLib.Extensions.Data
{

	/// <summary>
	///     Extensions of the <see cref="IDataReader"/> interface.
	/// </summary>
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public static partial class IDataReaderExtensions
	{

		/*

		// Don't yield-return an IEnumerable over a data reader as it only allows one round-trip.

		/// <summary>
		///     
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
		///     
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
		///     Gets an iterator of entity objects.
		/// </summary>
		/// <typeparam name="T">The type of the entity objects.</typeparam>
		/// <param name="me">The current data reader.</param>
		/// <returns>
		///     A sequence of entity object of type <typeparamref name="T"/> that are populated with
		///     data from the current data reader, one entity object for each record.
		/// </returns>
		/// <remarks>
		///     <para>The reader must stay opened while the iterator is used.</para>
		///     <para>
		///         By materializing the returned enumeration (e.g. ToList() etc.) one can then close
		///         the data reader and the underlying database connection, and keep working with the
		///         data disconnected from the database.
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
		///     
		/// </summary>
		/// <param name="me"></param>
		/// <returns></returns>
		public static IEnumerable<dynamic> AsEnumerable(this IDataReader me)
		{
			while (me.Read())
			{
				yield return me.GetDynamicObject();
			}
		}*/



		/// <summary>
		///     Determines if there is a column with a specified name in the current data reader.
		/// </summary>
		/// <param name="me">The current data reader.</param>
		/// <param name="columnName">The name of the column to search for.</param>
		/// <returns><c>true</c> if the specified column name exists; otherwise, <c>false</c>.</returns>
		public static bool ContainsColumn(this IDataReader me, string columnName)
		{
			try
			{
				return me.GetOrdinal(columnName) >= 0;
			}
			catch
			{
				try
				{
					return me[columnName] != null;
				}
				catch
				{
					return false;
				}
			}
		}



		/// <summary>
		///     Gets a list of all column names in the current data reader.
		/// </summary>
		/// <param name="me">The current data reader.</param>
		/// <returns>A list of all column names in the current data reader.</returns>
		public static IList<string> GetColumnNames(this IDataReader me)
		{
			return Enumerable
				.Range(0, me.FieldCount)
				.Select(me.GetName)
				.ToList();
		}



		/// <summary>
		///     Gets the column value at the current data record of the current data reader,
		///     converted to a specified type.
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
		///     Converts one column of all records in the current data reader to a list of a specified type of objects.
		/// </summary>
		/// <typeparam name="T">The type of objects in the returned list.</typeparam>
		/// <param name="me">The current data reader.</param>
		/// <param name="columnIndex">Index of the column.</param>
		/// <returns></returns>
		public static IList<T> ToValueList<T>(this IDataReader me, int columnIndex)
		{
			List<T> list = new List<T>();

			while (me.Read())
			{
				list.Add(me.GetValue<T>(columnIndex));
			}

			return list;
		}



		/// <summary>
		///     Gets the column value at the current data record of the current data reader,
		///     converted to a specified type.
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
		///     Converts one column of all records in the current data reader to a list of a specified type of objects.
		/// </summary>
		/// <typeparam name="T">The type of objects in the returned list.</typeparam>
		/// <param name="me">The current data reader.</param>
		/// <param name="columnName">Name of the column.</param>
		/// <returns></returns>
		public static IList<T> ToValueList<T>(this IDataReader me, string columnName)
		{
			return me.ToValueList<T>(me.GetOrdinal(columnName));
		}



		/// <summary>
		///     Transforms the current record of the data reader into a dynamic object, where every
		///     column in the data reader corresponds to a property of the dyanmic object.
		/// </summary>
		/// <param name="me">The current data reader.</param>
		/// <returns>
		///     A new dynamic object with properties and values from the current data reader record.
		/// </returns>
		public static dynamic GetDynamicObject(this IDataReader me)
		{
			dynamic obj = new ExpandoObject();

			IDictionary<string, object> dic = (IDictionary<string, object>)obj;

			Enumerable
				.Range(0, me.FieldCount)
				.Select(me.GetName)
				.ToList()
				.ForEach(c => dic.Add(c, me[c]));

			return obj;
		}



		/// <summary>
		///     Converts all records in the current data reader to a list of dynamic objects.
		/// </summary>
		/// <param name="me">The current data reader.</param>
		/// <returns>A list of dynamic objects.</returns>
		public static IList<dynamic> ToDynamicObjectList(this IDataReader me)
		{
			List<dynamic> list = new List<dynamic>();

			while (me.Read())
			{
				list.Add(me.GetDynamicObject());
			}

			return list;
		}



		/// <summary>
		///     Converts the remining records in the current data reader into a <see cref="DataTable"/>.
		/// </summary>
		/// <param name="me">The current data reader.</param>
		/// <returns>
		///     A new data table filled with values from the remaining records of the current data reader.
		/// </returns>
		public static DataTable ToDataTable(this IDataReader me)
		{
			DataTable dt = new DataTable();
			dt.Load(me); // LoadOptions not applicable as it's a new DataTable.
			return dt;
		}



		/// <summary>
		///     Applies an operation to all remaining records in the current data reader.
		/// </summary>
		/// <param name="me">The current data reader.</param>
		/// <param name="action">The action to apply to each record.</param>
		/// <returns>The current data reader.</returns>
		/// <remarks>
		///     The current data reader is depleted after the return from this method, and cannot be
		///     used for accessing data anymore.
		/// </remarks>
		public static IDataReader ForEach(this IDataReader me, Action<IDataReader> action)
		{
			while (me.Read())
			{
				action(me);
			}

			return me;
		}

	}

}
