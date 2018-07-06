using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;


namespace PLib.Extensions.Data
{

	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public static partial class IDataReaderExtensions
	{

		public static IEnumerable<T> AsEnumerable<T>(this IDataReader me, int columnIndex)
		{
			while (me.Read())
			{
				yield return me.GetValue<T>(columnIndex);
			}
		}



		public static IEnumerable<T> AsEnumerable<T>(this IDataReader me, string columnName)
		{
			while (me.Read())
			{
				yield return me.GetValue<T>(columnName);
			}
		}



		public static IEnumerable<T> AsEnumerable<T>(this IDataReader me) where T : new()
		{
			PropertyInfo[] properties;
			FieldInfo[] fields;

			GetTypeInfo(typeof(T), Enumerable.Range(0, me.FieldCount).Select(me.GetName), out properties, out fields);

			while (me.Read())
			{
				T entity = new T();

				SetEntityValues(entity, properties, fields, me);

				yield return entity;
			}
		}



		public static IDataReader ForEach(this IDataReader me, Action<IDataReader> action)
		{
			while (me.Read())
			{
				action(me);
			}

			return me;
		}



		public static T GetEntity<T>(this IDataReader me) where T : new()
		{
			PropertyInfo[] properties;
			FieldInfo[] fields;

			GetTypeInfo(typeof(T), Enumerable.Range(0, me.FieldCount).Select(me.GetName), out properties, out fields);

			T entity = new T();
			SetEntityValues(entity, properties, fields, me);

			return entity;
		}



		public static T GetValue<T>(this IDataReader me, int columnIndex)
		{
			return (T)me.GetValue(columnIndex);
		}



		public static T GetValue<T>(this IDataReader me, string columnName)
		{
			return (T)me.GetValue(me.GetOrdinal(columnName));
		}



		public static DataTable ToDataTable(this IDataReader me)
		{
			DataTable dt = new DataTable();
			dt.Load(me);
			return dt;
		}



		private static void GetTypeInfo(Type type, IEnumerable<string> readerColumns, out PropertyInfo[] properties, out FieldInfo[] fields)
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



		private static void SetEntityValues<T>(T entity, PropertyInfo[] properties, FieldInfo[] fields, IDataReader reader)
		{
			for (int i = 0; i < properties.Length; i++)
			{
				properties[i].SetValue(entity, reader[properties[i].Name]);
			}

			for (int i = 0; i < fields.Length; i++)
			{
				fields[i].SetValue(entity, reader[fields[i].Name]);
			}
		}

	}

}
