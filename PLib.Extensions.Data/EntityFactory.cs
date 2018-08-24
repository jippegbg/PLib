using System;
using System.Data;
using System.Reflection;
using System.Reflection.Emit;


namespace PLib.Extensions.Data
{

	internal static class EntityFactoryHelpers
	{

		public static readonly MethodInfo GetValueMethod = typeof(IDataRecord).GetMethod("get_Item", new[] { typeof(int) });

		public static readonly MethodInfo IsDbNullMethod = typeof(IDataRecord).GetMethod("IsDBNull", new[] { typeof(int) });

	}



	public class EntityFactory<T>
	{

		private delegate T Loader(IDataRecord dataRecord);



		private readonly Loader m_loader;



		/// <summary>
		///     Initializes a new instance of the <see cref="EntityFactory{T}"/> class.
		/// </summary>
		/// <param name="dataRecord">
		///     A data record to serve as a template in order to initialize the factory.
		/// </param>
		/// <exception cref="System.InvalidOperationException">
		///     if the entity type <typeparamref name="T"/> doesn't have a public parameterless constructor.
		/// </exception>
		public EntityFactory(IDataRecord dataRecord)
		{
			ConstructorInfo ctor = typeof(T).GetConstructor(Type.EmptyTypes);

			if (ctor == null)
			{
				throw new InvalidOperationException($"Type {typeof(T).Name} does not have a public parameterless constructor.");
			}

			m_loader = CreateLoader(ctor, dataRecord);
		}



		/// <summary>
		///     Creates a delegate that, when invoked, initializes a new object of type
		///     <typeparamref name="T"/> from the values of a given data record.
		/// </summary>
		/// <param name="ctor">The public parameterless constructor of type <typeparamref name="T"/>.</param>
		/// <param name="dataRecord">
		///     An example of a data record, containing the columns that will be given when invoking
		///     the delegate returned. The column values are unimportant in this step, only the
		///     column count, their names and types, will be used to construct the delegate.
		/// </param>
		/// <returns>
		///     A new delgate that takes a data record and creates a new entity of type <typeparamref name="T"/>.
		/// </returns>
		private Loader CreateLoader(ConstructorInfo ctor, IDataRecord dataRecord)
		{
			DynamicMethod method =
				new DynamicMethod(
					name: "LoadDataRecord",
					returnType: typeof(T),
					parameterTypes: new[] { typeof(IDataRecord) },
					owner: typeof(T),
					skipVisibility: true
				);

			ILGenerator generator = method.GetILGenerator();

			LocalBuilder result = generator.DeclareLocal(typeof(T));

			generator.Emit(OpCodes.Newobj, ctor);
			generator.Emit(OpCodes.Stloc, result);

			for (int i = 0; i < dataRecord.FieldCount; i++)
			{
				PropertyInfo propertyInfo = typeof(T).GetProperty(dataRecord.GetName(i));
				Label        endIfLabel   = generator.DefineLabel();

				if (propertyInfo != null && propertyInfo.GetSetMethod() != null)
				{
					generator.Emit(OpCodes.Ldarg_0);
					generator.Emit(OpCodes.Ldc_I4, i);
					generator.Emit(OpCodes.Callvirt, EntityFactoryHelpers.IsDbNullMethod);
					generator.Emit(OpCodes.Brtrue, endIfLabel);

					generator.Emit(OpCodes.Ldloc, result);
					generator.Emit(OpCodes.Ldarg_0);
					generator.Emit(OpCodes.Ldc_I4, i);
					generator.Emit(OpCodes.Callvirt, EntityFactoryHelpers.GetValueMethod);
					generator.Emit(OpCodes.Unbox_Any, dataRecord.GetFieldType(i));
					generator.Emit(OpCodes.Callvirt, propertyInfo.GetSetMethod());

					generator.MarkLabel(endIfLabel);
				}
			}

			generator.Emit(OpCodes.Ldloc, result);
			generator.Emit(OpCodes.Ret);

			return (Loader)method.CreateDelegate(typeof(Loader));
		}



		/// <summary>
		///     Initializes a new instance of type <typeparamref name="T"/> from the values of the
		///     given <paramref name="dataRecord"/>.
		/// </summary>
		/// <param name="dataRecord">The data record to use a source from the new entity object.</param>
		/// <returns>A new entity object containing values from the given <paramref name="dataRecord"/>.</returns>
		public T Create(IDataRecord dataRecord)
		{
			return m_loader.Invoke(dataRecord);
		}

	}

}
