using System;
using System.Linq.Expressions;


namespace PLib.Utils
{

	public class Operator<T>
	{

		internal static INullOp<T> NullOp { get; }

		public static T Zero { get; }

		public static Func<T, T> Negate    { get; } = ExpressionUtil.CreateExpression<T, T>(Expression.Negate);
		public static Func<T, T> Not       { get; } = ExpressionUtil.CreateExpression<T, T>(Expression.Not);
		public static Func<T, T> Increment { get; } = ExpressionUtil.CreateExpression<T, T>(Expression.Increment);
		public static Func<T, T> Decrement { get; } = ExpressionUtil.CreateExpression<T, T>(Expression.Decrement);

		public static Func<T, T, T> Or       { get; } = ExpressionUtil.CreateExpression<T, T, T>(Expression.Or);
		public static Func<T, T, T> OrElse   { get; } = ExpressionUtil.CreateExpression<T, T, T>(Expression.OrElse);
		public static Func<T, T, T> And      { get; } = ExpressionUtil.CreateExpression<T, T, T>(Expression.And);
		public static Func<T, T, T> AndAlso  { get; } = ExpressionUtil.CreateExpression<T, T, T>(Expression.AndAlso);
		public static Func<T, T, T> Xor      { get; } = ExpressionUtil.CreateExpression<T, T, T>(Expression.ExclusiveOr);
		public static Func<T, T, T> Add      { get; } = ExpressionUtil.CreateExpression<T, T, T>(Expression.Add);
		public static Func<T, T, T> Subtract { get; } = ExpressionUtil.CreateExpression<T, T, T>(Expression.Subtract);
		public static Func<T, T, T> Multiply { get; } = ExpressionUtil.CreateExpression<T, T, T>(Expression.Multiply);
		public static Func<T, T, T> Divide   { get; } = ExpressionUtil.CreateExpression<T, T, T>(Expression.Divide);
		public static Func<T, T, T> Power    { get; } = ExpressionUtil.CreateExpression<T, T, T>(Expression.Power);

		public static Func<T, T, bool> Equal              { get; } = ExpressionUtil.CreateExpression<T, T, bool>(Expression.Equal);
		public static Func<T, T, bool> NotEqual           { get; } = ExpressionUtil.CreateExpression<T, T, bool>(Expression.NotEqual);
		public static Func<T, T, bool> GreaterThan        { get; } = ExpressionUtil.CreateExpression<T, T, bool>(Expression.GreaterThan);
		public static Func<T, T, bool> LessThan           { get; } = ExpressionUtil.CreateExpression<T, T, bool>(Expression.LessThan);
		public static Func<T, T, bool> GreaterThanOrEqual { get; } = ExpressionUtil.CreateExpression<T, T, bool>(Expression.GreaterThanOrEqual);
		public static Func<T, T, bool> LessThanOrEqual    { get; } = ExpressionUtil.CreateExpression<T, T, bool>(Expression.LessThanOrEqual);

		public static Func<T, T, T> Max { get; }
		public static Func<T, T, T> Min { get; }

		public static Func<T, T> Abs { get; }

		public static Func<T, T, T> Difference { get; }



		static Operator()
		{
			Type type = typeof(T);
			if (type.IsValueType && type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				Type nullType = type.GetGenericArguments()[0];

				Zero   = (T)Activator.CreateInstance(nullType);
				NullOp = (INullOp<T>)Activator.CreateInstance(typeof(StructNullOp<>).MakeGenericType(nullType));
			}
			else
			{
				Zero = default(T);
				if (type.IsValueType)
				{
					NullOp = (INullOp<T>)Activator.CreateInstance(typeof(StructNullOp<>).MakeGenericType(type));
				}
				else
				{
					NullOp = (INullOp<T>)Activator.CreateInstance(typeof(ClassNullOp<>).MakeGenericType(type));
				}
			}

			Max = (x, y) => GreaterThan(x, y) ? x : y;
			Min = (x, y) => LessThan(x, y)    ? x : y;

			Abs = x => LessThan(x, Zero) ? Negate(x) : x;

			Difference = (x, y) => Abs(Subtract(x, y));
		}

	}

}
