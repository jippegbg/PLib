using System;


namespace PLib.Extensions.Core
{

	/// <summary>
	///     Extensions of the <see cref="Delegate"/> class.
	/// </summary>
	public static class DelegateExtensions
	{

		/// <summary>
		///     Adds the invocation list of a delegate to the invocation list of the current delegate.
		/// </summary>
		/// <param name="me">The current delegate.</param>
		/// <param name="other">The other delegate.</param>
		/// <returns>
		///     A new delegate with an invocation list that concatenates the invocation lists of the
		///     current delegate and another delegate in that order. Returns the current delegate if
		///     the other is null, returns the other delegate if the current is a null reference, and
		///     returns a null reference if both the current and the other delegate are null references.
		/// </returns>
		public static Delegate Combine(this Delegate me, Delegate other)
		{
			return Delegate.Combine(me, other);
		}



		/// <summary>
		///     Adds the invocation lists of an array of delegates to the invocation list of the current delegate.
		/// </summary>
		/// <param name="me">The current delegate.</param>
		/// <param name="delegates">
		///     An array of delegates to add (combine) to the invocation list of the current one.
		/// </param>
		/// <returns>
		///     A new delegate with an invocation list that concatenates the invocation lists of the
		///     current delegate and the delegates in the delegates array. Returns the current
		///     delegate if the delegates array is null, has zero elements, or if every entry is
		///     null. Returns a combined delegate of the delegates array if the current delegate is
		///     null. Returns null if both the current delegate and the delegates array is null, has
		///     zero elements, or if every entry is null.
		/// </returns>
		public static Delegate Combine(this Delegate me, params Delegate[] delegates)
		{
			return Delegate.Combine(me, Delegate.Combine(delegates));
		}



		/// <summary>
		///     Removes the last occurrence of the invocation list of the specified delegate from the
		///     invocation list of the current delegate.
		/// </summary>
		/// <param name="me">The current delegate.</param>
		/// <param name="value">
		///     The delegate that supplies the invocation list to remove from the invocation list of
		///     the current delegate.
		/// </param>
		/// <returns>
		///     A new delegate with an invocation list formed by taking the invocation list of the
		///     current delegate and removing the last occurrence of the invocation list of
		///     <paramref name="value"/>, if the invocation list of value is found within the
		///     invocation list of the current delegate. Returns the current delegate if
		///     <paramref name="value"/> is null or if the invocation list of
		///     <paramref name="value"/> is not found within the invocation list of the current
		///     delegate. Returns a null reference if the invocation list of <paramref name="value"/>
		///     is equal to the invocation list of the current delegate or if the current delegate is
		///     a null reference.
		/// </returns>
		public static Delegate Remove(this Delegate me, Delegate value)
		{
			return Delegate.Remove(me, value);
		}



		/// <summary>
		///     Removes all occurrences of the invocation list of a delegate from the invocation list
		///     of the current delegate.
		/// </summary>
		/// <param name="me">The current delegate.</param>
		/// <param name="value">
		///     The delegate that supplies the invocation list to remove from the invocation list of
		///     the current delegate.
		/// </param>
		/// <returns>
		///     A new delegate with an invocation list formed by taking the invocation list of the
		///     current delegate and removing all occurrences of the invocation list of
		///     <paramref name="value"/>, if the invocation list of <paramref name="value"/> is found
		///     within the invocation list of the current delegate. Returns the current delegate if
		///     <paramref name="value"/> is null or if the invocation list of
		///     <paramref name="value"/> is not found within the invocation list of the current
		///     delegate. Returns a null reference if the invocation list of <paramref name="value"/>
		///     is equal to the invocation list of the current delegate, if the current delegate
		///     contains only a series of invocation lists that are equal to the invocation list of
		///     <paramref name="value"/>, or if the current delegate is a null reference.
		/// </returns>
		public static Delegate RemoveAll(this Delegate me, Delegate value)
		{
			return Delegate.RemoveAll(me, value);
		}

	}

}
