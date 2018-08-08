using System;


namespace PLib.Interval {

	public struct IntervalValue<T> : IEquatable<IntervalValue<T>> where T : IComparable<T>, IEquatable<T> //, IFormattable
	{

		private readonly T                 m_value;
		private readonly IntervalValueType m_type;



		public IntervalValue(T value, IntervalValueType type)
		{
			if (value == null)
			{
				throw new ArgumentNullException(nameof(value));
			}

			m_value = value;
			m_type  = type;
		}



		public T Value => m_value;


		public IntervalValueType ValueType => m_type;



		public bool Equals(IntervalValue<T> other)
		{
			return m_value.Equals(other.m_value) && m_type == other.m_type;
		}



		public override bool Equals(object obj)
		{
			return obj is IntervalValue<T> && Equals((IntervalValue<T>)obj);
		}



		public override int GetHashCode()
		{
			unchecked
			{
				int h1 = m_value.GetHashCode();
				int h2 = m_type.GetHashCode();

				return ((h1 << 5) + h1) ^ h2;
			}
		}



		internal string ToString(IntervalNotationPosition position)
		{
			string notation = ValueType.ToString(position);

			switch (position)
			{
				case IntervalNotationPosition.Left:
					return $"{notation}{Value}";

				case IntervalNotationPosition.Right:
					return $"{Value}{notation}";

				default:
					throw new NotSupportedException();
			}
		}

	}

}