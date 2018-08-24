using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace PLib.Utils.Ranges
{

	public class Sequence : IEnumerable<int>
	{

		#region [ Static Creators ]

		/// <summary>
		///     Creates an infinite sequence of integral numbers starting at a specified value.
		/// </summary>
		/// <param name="start">The inclusive starting value of the sequence.</param>
		/// <param name="reverse">
		///     <see langword="true"/> if the sequence should be generated in ever decreasing values;
		///     otherwise, <see langword="false"/>. Optional. Default <see langword="false"/>.
		/// </param>
		/// <returns>
		///     A sequence that starts at a specified value and continues forever, in either
		///     increasing or decreasing direction.
		/// </returns>
		public static Sequence Create(int start, bool reverse = false)
		{
			return new Sequence(start, reverse);
		}



		/// <summary>
		///     Creates a sequence of integral numbers starting at, and ending before, specified values.
		/// </summary>
		/// <param name="start">The inclusive starting value of the sequence.</param>
		/// <param name="end">The inclusive ending value of the sequence.</param>
		/// <returns>
		///     A sequence that starts at <paramref name="start"/> and stops before
		///     <paramref name="end"/>, in single steps (+/-1).
		/// </returns>
		/// <remarks>
		///     If <paramref name="end"/> is less than <paramref name="start"/> the sequence will be reversed.
		/// </remarks>
		public static Sequence Create(int start, int end)
		{
			return new Sequence(start, end);
		}



		/// <summary>
		///     Creates a sequence of integral numbers starting at, and ending before, specified values.
		/// </summary>
		/// <param name="start">The inclusive starting value of the sequence.</param>
		/// <param name="end">The inclusive ending value of the sequence.</param>
		/// <param name="step">The difference between two consecutive values in the sequence.</param>
		/// <returns>
		///     A sequence that starts at <paramref name="start"/> and stops before
		///     <paramref name="end"/>, in steps of <paramref name="step"/>.
		/// </returns>
		/// <exception cref="ArgumentException">
		///     If <paramref name="start"/> is less than or equal to <paramref name="end"/> and
		///     <paramref name="step"/> is negative.
		///     <para/>
		///     -or-
		///     <para/>
		///     If <paramref name="start"/> is greater than <paramref name="end"/> and
		///     <paramref name="step"/> is positive.
		///     <para/>
		///     -or-
		///     <para/>
		///     If <paramref name="step"/> is zero.
		/// </exception>
		public static Sequence Create(int start, int end, int step)
		{
			return new Sequence(start, end, step);
		}



		/// <summary>
		///     Creates a sequence of integral numbers starting at, and ending before, specified values.
		/// </summary>
		/// <param name="start">The inclusive starting value of the sequence.</param>
		/// <param name="end">The inclusive ending value of the sequence.</param>
		/// <param name="next">
		///     A function that gives the next value in the sequence, given the current value.
		/// </param>
		/// <returns>
		///     A sequence that starts at <paramref name="start"/> and stops before
		///     <paramref name="end"/>, in steps given by the <paramref name="next"/> function.
		/// </returns>
		/// <remarks>
		///     Depending on the <paramref name="next"/> function, the sequence might not converge.
		///     It's up to the user to make sure the sequence is finite.
		/// </remarks>
		public static Sequence Create(int start, int end, Expression<Func<int, int>> next)
		{
			return new Sequence(start, end, next);
		}



		/// <summary>
		///     Creates a sequence of integral numbers starting at a specified value and continues
		///     until a specified predicate is false.
		/// </summary>
		/// <param name="start">The inclusive starting value of the sequence.</param>
		/// <param name="cont">
		///     A predicate that, given the current sequence value, determines if the enumeration
		///     should continue or not.
		/// </param>
		/// <param name="next">
		///     A function that gives the next value in the sequence, given the current value.
		/// </param>
		/// <returns>
		///     A sequence that starts at <paramref name="start"/> and continues as long as the
		///     predicate <paramref name="cont"/> is true, in steps given by the
		///     <paramref name="next"/> function.
		/// </returns>
		public static Sequence Create(int start, Expression<Predicate<int>> cont, Expression<Func<int, int>> next)
		{
			return new Sequence(start, cont, next);
		}

		#endregion [ Static Creators ]



		#region [ Fields ]

		private Predicate<int> m_continue;

		private Func<int, int> m_next;

		#endregion [ Fields ]



		#region [ Constructors ]

		/// <summary>
		///     Creates an infinite sequence of integral numbers starting at a specified value.
		/// </summary>
		/// <param name="start">The inclusive starting value of the sequence.</param>
		/// <param name="reverse">
		///     <see langword="true"/> if the sequence should be generated in ever decreasing values;
		///     otherwise, <see langword="false"/>. Optional. Default <see langword="false"/>.
		/// </param>
		public Sequence(int start, bool reverse)
		{
			Start    = start;
			Continue = x => true;
			if (reverse)
			{
				NextValue = x => x - 1;
			}
			else
			{
				NextValue = x => x + 1;
			}

			Compile();
		}



		/// <summary>
		///     Creates a sequence of integral numbers starting at, and ending before, specified values.
		/// </summary>
		/// <param name="start">The inclusive starting value of the sequence.</param>
		/// <param name="end">The inclusive ending value of the sequence.</param>
		/// <remarks>
		///     If <paramref name="end"/> is less than <paramref name="start"/> the sequence will be reversed.
		/// </remarks>
		public Sequence(int start, int end)
		{
			Start = start;

			if (start <= end)
			{
				Continue  = x => x <= end;
				NextValue = x => x + 1;
			}
			else
			{
				Continue  = x => x >= end;
				NextValue = x => x - 1;
			}

			Compile();
		}



		/// <summary>
		///     Creates a sequence of integral numbers starting at, and ending before, specified values.
		/// </summary>
		/// <param name="start">The inclusive starting value of the sequence.</param>
		/// <param name="end">The inclusive ending value of the sequence.</param>
		/// <param name="step">The difference between two consecutive values in the sequence.</param>
		/// <exception cref="ArgumentException">
		///     If <paramref name="start"/> is less than or equal to <paramref name="end"/> and
		///     <paramref name="step"/> is negative.
		///     <para/>
		///     -or-
		///     <para/>
		///     If <paramref name="start"/> is greater than <paramref name="end"/> and
		///     <paramref name="step"/> is positive.
		///     <para/>
		///     -or-
		///     <para/>
		///     If <paramref name="step"/> is zero.
		/// </exception>
		public Sequence(int start, int end, int step)
		{
			if (start <= end && step < 0 || start > end && step > 0 || step == 0)
			{
				throw new ArgumentException("Invalid value. Sequence does not converge.", nameof(step));
			}

			Start = start;

			if (start <= end)
			{
				Continue = x => x <= end;
			}
			else
			{
				Continue = x => x >= end;
			}

			NextValue = x => x + step;

			Compile();
		}



		/// <summary>
		///     Creates a sequence of integral numbers starting at, and ending before, specified values.
		/// </summary>
		/// <param name="start">The inclusive starting value of the sequence.</param>
		/// <param name="end">The inclusive ending value of the sequence.</param>
		/// <param name="next">
		///     A function that gives the next value in the sequence, given the current value.
		/// </param>
		/// <remarks>
		///     Depending on the <paramref name="next"/> function, the sequence might not converge.
		///     It's up to the user to make sure the sequence is finite.
		/// </remarks>
		public Sequence(int start, int end, Expression<Func<int, int>> next)
		{
			Start = start;
			if (start <= end)
			{
				Continue = i => i <= end;
			}
			else
			{
				Continue = i => i >= end;
			}

			NextValue = next;

			Compile();
		}



		/// <summary>
		///     Creates a sequence of integral numbers starting at a specified value and continues
		///     until a specified predicate is false.
		/// </summary>
		/// <param name="start">The inclusive starting value of the sequence.</param>
		/// <param name="cont">
		///     A predicate that, given the current sequence value, determines if the enumeration
		///     should continue or not.
		/// </param>
		/// <param name="next">
		///     A function that gives the next value in the sequence, given the current value.
		/// </param>
		public Sequence(int start, Expression<Predicate<int>> cont, Expression<Func<int, int>> next)
		{
			Start     = start;
			Continue  = cont;
			NextValue = next;

			Compile();
		}

		#endregion [ Constructors ]



		#region [ Properties ]

		/// <summary>
		///     Gets the expression that determines if the sequence, given the current value, should
		///     continue or not.
		/// </summary>
		public Expression<Predicate<int>> Continue { get; }



		/// <summary>
		///     Gets the expression that determines the next value in the sequence.
		/// </summary>
		public Expression<Func<int, int>> NextValue { get; }



		/// <summary>
		///     Gets the starting value of the sequence.
		/// </summary>
		public int Start { get; }

		#endregion [ Properties ]



		#region [ Implementations ]

		/// <inheritdoc />
		public IEnumerator<int> GetEnumerator()
		{
			for (int i = Start; m_continue(i); i = m_next(i))
			{
				yield return i;
			}
		}



		/// <inheritdoc />
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion [ Implementations ]



		private void Compile()
		{
			m_continue = Continue.Compile();
			m_next     = NextValue.Compile();
		}

	}

}
