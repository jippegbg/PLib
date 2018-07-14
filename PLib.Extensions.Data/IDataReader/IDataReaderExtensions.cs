using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;
using System.Reflection;


namespace PLib.Extensions.Data
{

	/// <summary>
	///     Extensions of the <see cref="IDataReader"/> interface.
	/// </summary>
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public static partial class IDataReaderExtensions
	{

		// TODO: DON'T !!!!! return an IEnumerable over a data reader as it only allows one round-trip.

		/*/// <summary>
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
		/// To the list.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">Me.</param>
		/// <param name="columnIndex">Index of the column.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToList`1
		public static IList<T> ToList<T>(this IDataReader me, int columnIndex)
		{
			List<T> list = new List<T>();

			while (me.Read())
			{
				list.Add(me.GetValue<T>(columnIndex));
			}

			return list;
		}



		/// <summary>
		/// To the list.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">Me.</param>
		/// <param name="columnName">Name of the column.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToList`1
		public static IList<T> ToList<T>(this IDataReader me, string columnName)
		{
			List<T> list = new List<T>();

			while (me.Read())
			{
				list.Add(me.GetValue<T>(columnName));
			}

			return list;
		}



		/// <summary>
		/// To the list.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="me">Me.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToList`1
		public static IList<T> ToList<T>(this IDataReader me) where T : new()
		{
			List<T> list = new List<T>();

			while (me.Read())
			{
				list.Add(me.GetEntity<T>());
			}

			return list;
		}



		/// <summary>
		/// To the list.
		/// </summary>
		/// <param name="me">Me.</param>
		/// <returns></returns>
		/// TODO Edit XML Comment Template for ToList
		public static IList<dynamic> ToList(this IDataReader me)
		{
			List<dynamic> list = new List<dynamic>();

			while (me.Read())
			{
				list.Add(me.GetDynamicObject());
			}

			return list;
		}





		/// <summary>
		///     TODO: Edit XML Comment
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

			return me; // TODO: not good, the reader is now depleted and useless
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
		///     TODO: Edit XML Comment
		/// </summary>
		/// <param name="me">The current data reader.</param>
		/// <returns></returns>
		public static DataTable ToDataTable(this IDataReader me)
		{
			DataTable dt = new DataTable();
			dt.Load(me);
			return dt;
		}

	}

}
