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

		/// <summary>
		///     Gets multiple data from the current data record of the current data reader, converted
		///     to a specified entity type.
		/// </summary>
		/// <typeparam name="T">The type of the returned entity object.</typeparam>
		/// <param name="me">The current data reader.</param>
		/// <returns>
		///     A new entity object of type <typeparamref name="T"/> that is populated with data from
		///     the current record position of the current data reader.
		/// </returns>
		public static T GetEntity<T>(this IDataReader me) where T : new()
		{
			//return new EntityFactory<T>(me).Create(me);

			PropertyInfo[] properties = me.GetMappingProperties<T>();
			FieldInfo[]    fields     = me.GetMappingFields<T>();

			return me.GetEntity<T>(properties, fields);
		}



		/// <summary>
		///     Gets multiple data from the current data record of the current data reader, converted
		///     to a specified entity type.
		/// </summary>
		/// <typeparam name="T">The type of the returned entity object.</typeparam>
		/// <param name="me">The current data reader.</param>
		/// <param name="properties">
		///     The properties in the new entity object to set with values from the current data reader.
		/// </param>
		/// <param name="fields">
		///     The fields in the new entity object to set with values from the current data reader.
		/// </param>
		/// <returns>
		///     A new entity object of type <typeparamref name="T"/> that is populated with data from
		///     the current record position of the current data reader.
		/// </returns>
		/// <remarks>
		///     By providing the <paramref name="properties"/> and <paramref name="fields"/> this
		///     method doesn't have to look up these as the parameterless
		///     <see cref="GetEntity{T}(IDataReader)"/> does, which will increase performance when
		///     getting multiple entities from the same data reader.
		/// </remarks>
		public static T GetEntity<T>(this IDataReader me, PropertyInfo[] properties, FieldInfo[] fields) where T : new()
		{
			T entity = new T();
			me.SetValuesTo(entity, properties, fields);
			return entity;
		}



		/// <summary>
		///     Converts all records in the current data reader to a list of entity objects of a
		///     specified type.
		/// </summary>
		/// <typeparam name="T">The type of objects in the returned list.</typeparam>
		/// <param name="me">The current data reader.</param>
		/// <returns></returns>
		public static IList<T> ToEntityList<T>(this IDataReader me) where T : new()
		{
			List<T> list = new List<T>();

			//var factory = new EntityFactory<T>(me);
			PropertyInfo[] properties = me.GetMappingProperties<T>();
			FieldInfo[]    fields     = me.GetMappingFields<T>();

			while (me.Read())
			{
				//list.Add(factory.Create(me));
				list.Add(me.GetEntity<T>(properties, fields));
			}

			return list;
		}



		/// <summary>
		///     Gets an array of the <see cref="PropertyInfo"/> objects in the type
		///     <typeparamref name="T"/> that matches a column in the current data reader.
		/// </summary>
		/// <typeparam name="T">
		///     The type in which the properties should be mapped against the columns in the cirrent
		///     data reader.
		/// </typeparam>
		/// <param name="me">The current data reader.</param>
		/// <returns>
		///     An array of <see cref="PropertyInfo"/> objects that matches a column in the current
		///     data reader.
		/// </returns>
		internal static PropertyInfo[] GetMappingProperties<T>(this IDataReader me)
		{
			return me.GetMappingProperties(typeof(T));
		}



		/// <summary>
		///     Gets an array of the <see cref="PropertyInfo"/> objects in the
		///     <paramref name="mappingType"/> that matches a column in the current data reader.
		/// </summary>
		/// <param name="me">The current data reader.</param>
		/// <param name="mappingType">
		///     The type in which the properties should be mapped against the columns in the current
		///     data reader.
		/// </param>
		/// <returns>
		///     An array of <see cref="PropertyInfo"/> objects that matches a column in the current
		///     data reader.
		/// </returns>
		internal static PropertyInfo[] GetMappingProperties(this IDataReader me, Type mappingType)
		{
			IEnumerable<string> columns = Enumerable.Range(0, me.FieldCount).Select(me.GetName);

			return mappingType
				.GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(typeProp => columns.Contains(typeProp.Name))
				.ToArray();
		}



		/// <summary>
		///     Gets an array of the <see cref="FieldInfo"/> objects in the type
		///     <typeparamref name="T"/> that matches a column in the current data reader.
		/// </summary>
		/// <typeparam name="T">
		///     The type in which the fields should be mapped against the columns in the current data reader.
		/// </typeparam>
		/// <param name="me">The current data reader.</param>
		/// <returns>
		///     An array of <see cref="FieldInfo"/> objects that matches a column in the current data reader.
		/// </returns>
		internal static FieldInfo[] GetMappingFields<T>(this IDataReader me)
		{
			return me.GetMappingFields(typeof(T));
		}



		/// <summary>
		///     Gets an array of the <see cref="FieldInfo"/> objects in the
		///     <paramref name="mappingType"/> that matches a column in the current data reader.
		/// </summary>
		/// <param name="me">The current data reader.</param>
		/// <param name="mappingType">
		///     The type in which the fields should be mapped against the columns in the current data reader.
		/// </param>
		/// <returns>
		///     An array of <see cref="FieldInfo"/> objects that matches a column in the current data reader.
		/// </returns>
		internal static FieldInfo[] GetMappingFields(this IDataReader me, Type mappingType)
		{
			IEnumerable<string> columns = Enumerable.Range(0, me.FieldCount).Select(me.GetName);

			return mappingType
				.GetFields(BindingFlags.Public | BindingFlags.Instance)
				.Where(typeField => columns.Contains(typeField.Name))
				.ToArray();
		}



		/// <summary>
		///     Sets values from the current row in the current data reader to the properties and
		///     fields of an entity object.
		/// </summary>
		/// <typeparam name="T">The entity type.</typeparam>
		/// <param name="me">The current data reader.</param>
		/// <param name="targetObject">
		///     The entity object to have its properties and fields set with values from the columns
		///     in the current data reader.
		/// </param>
		/// <param name="properties">
		///     The properties in the <paramref name="targetObject"/> to set.
		/// </param>
		/// <param name="fields">The fields in the <paramref name="targetObject"/> to set.</param>
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

	}

}
