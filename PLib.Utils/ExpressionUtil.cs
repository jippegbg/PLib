using System;
using System.Linq.Expressions;


namespace PLib.Utils
{

	public static class ExpressionUtil
	{

		/// <summary>
		///     Creates a function delegate representing a unary operation.
		/// </summary>
		/// <typeparam name="T">The operand type.</typeparam>
		/// <typeparam name="TResult">The operation return type.</typeparam>
		/// <param name="body">The body function for the binary operation.</param>
		/// <returns>A compiled function delegate.</returns>
		///// <remarks>
		/////     Note that this method will never throw an exception on failure to find a matching
		/////     operator, but instead the returned function will, when invoked.
		///// </remarks>
		public static Func<T, TResult> CreateExpression<T, TResult>(Func<Expression, UnaryExpression> body)
		{
			ParameterExpression param = Expression.Parameter(typeof(T), "param");

			//try
			//{
				return Expression.Lambda<Func<T, TResult>>(body(param), param).Compile();
			//}
			//catch (Exception ex)
			//{
			//	// ReSharper disable once ThrowFromCatchWithNoInnerException
			//	return delegate { throw new InvalidOperationException(ex.Message); };
			//}
		}



		/// <summary>
		///     Creates a function delegate representing a binary operation.
		/// </summary>
		/// <typeparam name="T1">The left operand type.</typeparam>
		/// <typeparam name="T2">The right operand type.</typeparam>
		/// <typeparam name="TResult">The return type.</typeparam>
		/// <param name="body">The body function for the binary operation.</param>
		/// <returns>A compiled function delegate.</returns>
		/// <remarks>
		///     Note that this method will never throw an exception on failure to find a matching
		///     operator, but instead the returned function will, when invoked.
		/// </remarks>
		public static Func<T1, T2, TResult> CreateExpression<T1, T2, TResult>(Func<Expression, Expression, BinaryExpression> body)
		{
			return CreateExpression<T1, T2, TResult>(body, false);
		}



		/// <summary>
		///     Creates a function delegate representing a binary operation.
		/// </summary>
		/// <typeparam name="T1">The left operand type.</typeparam>
		/// <typeparam name="T2">The right operand type.</typeparam>
		/// <typeparam name="TResult">The return type.</typeparam>
		/// <param name="body">The body function for the binary operation.</param>
		/// <param name="castArgsToResultOnFailure">
		///     If <see langword="true"/>, and if no matching operation is possible, an attempt to convert
		///     <typeparamref name="T1"/> and <typeparamref name="T2"/> to
		///     <typeparamref name="TResult"/> for a match is made. For example, there is no "decimal
		///     operator /(decimal, int)", but by converting <typeparamref name="T2"/> (int) to
		///     <typeparamref name="TResult"/> (decimal), a match is found. If <see langword="false"/>, no such
		///     attempt is done, and if no match can be found the returned function delegate will
		///     throw an <see cref="InvalidOperationException"/> when invoked.
		/// </param>
		/// <returns>A compiled function delegate.</returns>
		///// <remarks>
		/////     Note that this method will never throw an exception on failure to find a matching
		/////     operator, but instead the returned function will, when invoked.
		///// </remarks>
		public static Func<T1, T2, TResult> CreateExpression<T1, T2, TResult>(Func<Expression, Expression, BinaryExpression> body, bool castArgsToResultOnFailure)
		{
			ParameterExpression leftOperand  = Expression.Parameter(typeof(T1), "leftOperand");
			ParameterExpression rightOperand = Expression.Parameter(typeof(T2), "rightOperand");

			//try
			//{
				try
				{
					return Expression.Lambda<Func<T1, T2, TResult>>(body(leftOperand, rightOperand), leftOperand, rightOperand).Compile();
				}
				catch (InvalidOperationException)
				{
					if (!castArgsToResultOnFailure || typeof(T1) == typeof(TResult) && typeof(T2) == typeof(TResult))
					{
						throw;
					}

					Expression castLeftOperand  = typeof(T1) == typeof(TResult) ? leftOperand : (Expression)Expression.Convert(leftOperand, typeof(TResult));
					Expression castRightOperand = typeof(T2) == typeof(TResult) ? rightOperand : (Expression)Expression.Convert(rightOperand, typeof(TResult));

					return Expression.Lambda<Func<T1, T2, TResult>>(body(castLeftOperand, castRightOperand), leftOperand, rightOperand).Compile();
				}
			//}
			//catch (Exception ex)
			//{
			//	// ReSharper disable once ThrowFromCatchWithNoInnerException
			//	return delegate { throw new InvalidOperationException(ex.Message); };
			//}
		}

	}

}
